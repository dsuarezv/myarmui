using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MyArmUI
{
    public partial class CameraView : UserControl, IDisposable
    {
        private ImageMatcher mMatcher;
        private Capture mCapture;
        private bool mIsStarted = false;
        private string mTargetImageFileName = "CvImages/top-bw.png";
        private Image<Gray, byte> mTargetImage;
        private int mCaptureDeviceIndex = 2;


        public CameraView()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (mTargetImage != null) mTargetImage.Dispose();
            if (mCapture != null) mCapture.Dispose();
            if (mMatcher != null) mMatcher.Dispose();

            mTargetImage = null;
            mCapture = null;
            mMatcher = null;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void StartCaptureButton_Click(object sender, EventArgs e)
        {
            if (mIsStarted)
            {
                mCapture.Stop();
                StartCaptureButton.Text = "Stop capture";
                mIsStarted = false;
            }
            else
            {
                mTargetImage = new Image<Gray, byte>(mTargetImageFileName);
                mMatcher = new ImageMatcher(mTargetImage);

                mCapture = new Capture(mCaptureDeviceIndex);
                mCapture.ImageGrabbed += FrameCaptured;
                mCapture.Start();
                
                StartCaptureButton.Text = "Start capture";
                mIsStarted = true;
            }

        }

        private void FrameCaptured(object sender, EventArgs e)
        {
            Image<Gray, Byte> frame = mCapture.RetrieveGrayFrame();

            

            long matchTime;
            var result = mMatcher.Draw(frame, out matchTime);

            //if (imageBox1.Image != null) imageBox1.Image.Dispose();
            imageBox1.Image = frame;

            frame.Dispose();
        }

    }
}
