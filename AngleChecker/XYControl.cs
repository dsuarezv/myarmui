using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleChecker
{
    public partial class XYControl : Control
    {
        private const double DegreesToRadians = Math.PI / 180;
        private const int MinimumX = 25;

        private double mAngle1 = 70;
        private double mAngle2 = 10;
        private double mLength1 = 100;
        private double mLength2 = 100;
        private ArcDescriptor mAngle1Limits = new ArcDescriptor();
        private ArcDescriptor mAngle2Limits = new ArcDescriptor();

        private PointF mClickPoint;


        public event KinematicSolverDelegate KinematicSolutionNeeded;
        public event KinematicClickDelegate KinematicSolved;


        public int GroundLevel { get; set; }

        public ArcDescriptor Angle1Limits 
        { 
            get { return mAngle1Limits; }
            set { mAngle1Limits = value; Invalidate(); }
        }

        public ArcDescriptor Angle2Limits 
        { 
            get { return mAngle2Limits; }
            set { mAngle2Limits = value; Invalidate(); }
        }

        public double Angle1
        {
            get { return mAngle1; }
            set { mAngle1 = value; Invalidate(); }
        }

        public double Angle2
        {
            get { return mAngle2; }
            set { mAngle2 = value; Invalidate(); }
        }

        public double Length1
        {
            get { return mLength1; }
            set { mLength1 = value; Invalidate(); }
        }

        public double Length2
        {
            get { return mLength2; }
            set { mLength2 = value; Invalidate(); }
        }


        public XYControl()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                , true);
        }

        private PointF mLastEffectorLocation;

        protected override void OnPaint(PaintEventArgs pe)
        {
            var a1 = mAngle1 * DegreesToRadians;
            var a2 = -mAngle2 * DegreesToRadians;

            var p0 = new PointF(0, 0);
            var p1 = new PointF((float)(mLength1 * Math.Cos(a1)), (float)(mLength1 * Math.Sin(a1)));
            var p2 = new PointF((float)(p1.X + mLength2 * Math.Cos(a2)), (float)(p1.Y + mLength2 * Math.Sin(a2)));
            mLastEffectorLocation = p2;

            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Joint limits
            DrawDescriptor(Angle1Limits, p0, pe.Graphics);
            DrawDescriptor(Angle2Limits, p1, pe.Graphics);

            // Links
            using (var p = new Pen(Color.Red, 4f))
            {
                pe.Graphics.DrawLine(p, SpaceToScreen(p0), SpaceToScreen(p1));
                pe.Graphics.DrawLine(p, SpaceToScreen(p1), SpaceToScreen(p2));
            }

            // Joint balls
            //pe.Graphics.DrawLine(Pens.Magenta, SpaceToScreen(p0), SpaceToScreen(p2));
            DrawBall(p0, 8, Color.Red, pe.Graphics);
            DrawBall(p1, 8, Color.Red, pe.Graphics);
            DrawBall(p2, 8, Color.Red, pe.Graphics);

            // Clicked point
            DrawBall(mClickPoint, 5, Color.Orange, pe.Graphics);

            // Ground
            pe.Graphics.DrawLine(Pens.Maroon, SpaceToScreen(new PointF(85, GroundLevel)), SpaceToScreen(new PointF(280, GroundLevel)));

            // Debug info
            pe.Graphics.DrawString(GetLegend(), Font, Brushes.Black, 0, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            SolveKinematics(ScreenToSpace(new PointF(e.X, e.Y)));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SolveKinematics(ScreenToSpace(new PointF(e.X, e.Y)));
                Invalidate();
            }
        }

        private void DrawDescriptor(ArcDescriptor ad, PointF p, Graphics g)
        {
            if (ad == null) return;

            double I = ad.Inverted ? -1 : 1;

            var start = new PointF(
                (float)(p.X + ad.Length * Math.Cos(ad.StartAngle * DegreesToRadians)),
                (float)(p.Y + ad.Length * I * Math.Sin(ad.StartAngle * DegreesToRadians)));

            var end = new PointF(
                (float)(p.X + ad.Length * Math.Cos(ad.EndAngle * DegreesToRadians)),
                (float)(p.Y + ad.Length * I * Math.Sin(ad.EndAngle * DegreesToRadians)));

            using (var pen = new Pen(ad.Color))
            {
                g.DrawLine(pen, SpaceToScreen(p), SpaceToScreen(start));
                g.DrawLine(pen, SpaceToScreen(p), SpaceToScreen(end));
            }
        }

        private void SolveKinematics(PointF p)
        {
            if (p.X < MinimumX) p.X = MinimumX;
            mClickPoint = p;

            if (KinematicSolutionNeeded == null) return;

            double a1, a2;
            KinematicSolutionNeeded((int)p.X, (int)p.Y, mLength1, mLength2, out a1, out a2);

            Angle1 = Angle1Limits.Constrain(a1);
            Angle2 = Angle2Limits.Constrain(a2);

            if (KinematicSolved != null) KinematicSolved();
        }

        private void DrawBall(PointF point, int radius, Color c, Graphics g)
        { 
            int r2 = radius * 2;
            var p = SpaceToScreen(point);

            using (var b = new SolidBrush(c))
            {
                g.FillEllipse(b, p.X - radius, p.Y - radius, r2, r2);
            }
        }

        private string GetLegend()
        {
            return string.Format("Angle 1 (right): {0}\nAngle 2 (left): {1}\nX, Y: ({2:0}, {3:0})\nClick: ({4:0}, {5:0})", 
                mAngle1, mAngle2, 
                mLastEffectorLocation.X, mLastEffectorLocation.Y, 
                mClickPoint.X, mClickPoint.Y);
        }

        private PointF SpaceToScreen(PointF p)
        {
            return new PointF(p.X + Width / 2, Height / 2 - p.Y);
        }

        private PointF ScreenToSpace(PointF p)
        {
            return new PointF(p.X - Width / 2, Height / 2 - p.Y);
        }
    }


    public delegate void KinematicSolverDelegate(int x, int y, double l1, double l2, out double a1, out double a2);
    public delegate void KinematicClickDelegate();


    public class ArcDescriptor
    {
        public bool Inverted = false;
        public double StartAngle { get; set; }
        public double EndAngle { get; set; }
        public double Length { get; set; }
        public Color Color { get; set; }

        public ArcDescriptor()
        {
            StartAngle = 0;
            EndAngle = 180;
            Length = 20;
            Color = Color.DarkOrange;
        }

        public double Constrain(double angle)
        {
            if (angle < StartAngle) return StartAngle;
            if (angle > EndAngle) return EndAngle;

            return angle;
        }
    }
}
