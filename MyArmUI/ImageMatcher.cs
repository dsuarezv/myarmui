using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace MyArmUI
{
    public class ImageMatcher: IDisposable
    {
        private Image<Gray, byte> mModelImage;
        private VectorOfKeyPoint mModelKeyPoints;
        private DescriptorMatcher<float> mMatcher;
        private Feature2DBase<float> mDetector;

        public ImageMatcher(Image<Gray, byte> modelImage)
        {
            SetupModelImage(modelImage);
        }

        public void Dispose()
        {
            if (mModelKeyPoints != null) mModelKeyPoints.Dispose();
            if (mMatcher != null) mMatcher.Dispose();
            if (mDetector != null) mDetector.Dispose();

            mModelKeyPoints = null;
            mMatcher = null;
            mDetector = null;
        }

        private void SetupModelImage(Image<Gray, byte> modelImage)
        {
            mModelImage = modelImage;

            mDetector = new SURFDetector(500, false);

            mModelKeyPoints = new VectorOfKeyPoint();
            var modelDescriptors = mDetector.DetectAndCompute(mModelImage, null, mModelKeyPoints);

            mMatcher = new BruteForceMatcher<float>(DistanceType.L2);
            mMatcher.Add(modelDescriptors);
        }

        private void FindMatch(Image<Gray, byte> observedImage, out long matchTime, out HomographyMatrix homography)
        {
            const int k = 2;
            const double uniquenessThreshold = 0.8;
            
            
            Matrix<byte> mask;
            homography = null;
            var watch = Stopwatch.StartNew();

            var observedKeyPoints = new VectorOfKeyPoint();
            Matrix<float> observedDescriptors = mDetector.DetectAndCompute(observedImage, null, observedKeyPoints);


            var indices = new Matrix<int>(observedDescriptors.Rows, k);
            using (var distance = new Matrix<float>(observedDescriptors.Rows, k))
            {
                mMatcher.KnnMatch(observedDescriptors, indices, distance, k, null);
                mask = new Matrix<byte>(distance.Rows, 1);
                mask.SetValue(255);
                Features2DToolbox.VoteForUniqueness(distance, uniquenessThreshold, mask);
            }

            int nonZeroCount = CvInvoke.cvCountNonZero(mask);
            if (nonZeroCount >= 4)
            {
                nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation
                    (mModelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);

                if (nonZeroCount >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures
                        (mModelKeyPoints, observedKeyPoints, indices, mask, 2);
                }
            }

            //mask.Dispose();
            //indices.Dispose();
            //observedKeyPoints.Dispose();
            //observedDescriptors.Dispose();


            watch.Stop();
            matchTime = watch.ElapsedMilliseconds;
        }


        //public static void FindMatch(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, out Matrix<int> indices, out Matrix<byte> mask, out HomographyMatrix homography)
        //{
        //    int k = 2;
        //    double uniquenessThreshold = 0.8;
        //    SURFDetector surfCPU = new SURFDetector(500, false);
        //    Stopwatch watch;
        //    homography = null;

        //    //extract features from the object image
        //    modelKeyPoints = new VectorOfKeyPoint();
        //    Matrix<float> modelDescriptors = surfCPU.DetectAndCompute(modelImage, null, modelKeyPoints);

        //    watch = Stopwatch.StartNew();

        //    // extract features from the observed image
        //    observedKeyPoints = new VectorOfKeyPoint();
        //    Matrix<float> observedDescriptors = surfCPU.DetectAndCompute(observedImage, null, observedKeyPoints);
        //    BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
        //    matcher.Add(modelDescriptors);

        //    indices = new Matrix<int>(observedDescriptors.Rows, k);
        //    using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
        //    {
        //        matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
        //        mask = new Matrix<byte>(dist.Rows, 1);
        //        mask.SetValue(255);
        //        Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
        //    }

        //    int nonZeroCount = CvInvoke.cvCountNonZero(mask);
        //    if (nonZeroCount >= 4)
        //    {
        //        nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
        //        if (nonZeroCount >= 4)
        //            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
        //    }

        //    watch.Stop();

        //    matchTime = watch.ElapsedMilliseconds;
        //}
        

        /// <summary>
        /// Draw the model image and observed image, the matched features and homography projection.
        /// </summary>
        /// <param name="modelImage">The model image</param>
        /// <param name="observedImage">The observed image</param>
        /// <param name="matchTime">The output total time for computing the homography matrix.</param>
        /// <returns>The model image and observed image, the matched features and homography projection.</returns>
        public Image<Bgr, Byte> Draw(Image<Gray, byte> observedImage, out long matchTime)
        {
            HomographyMatrix homography;

            FindMatch(observedImage, out matchTime, out homography);

            //Draw the matched keypoints
            //Image<Bgr, Byte> result = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
            //   indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);

            Image<Bgr, Byte> result = observedImage.Convert<Bgr, byte>();

            //if (homography != null)
            //{  //draw a rectangle along the projected model
            //    Rectangle rect = mModelImage.ROI;
            //    PointF[] pts = new PointF[] { 
            //       new PointF(rect.Left, rect.Bottom),
            //       new PointF(rect.Right, rect.Bottom),
            //       new PointF(rect.Right, rect.Top),
            //       new PointF(rect.Left, rect.Top)};
            //    homography.ProjectPoints(pts);

            //    result.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Red), 5);
            //}

            //homography.Dispose();

            return result;
        }
    }
}
