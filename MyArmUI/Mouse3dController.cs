using MyArmClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArmUI
{
    public class Mouse3dController: Control, ICoordinatesProvider
    {
        private const float VerticalworkArea = 9f / 10f;
        private Matrix mTransform;
        private Matrix mTransformInverse;
        private float mAngleCorrection = 0;
        private Point3 mPosition = new Point3(0, 145, 158);
        private const int MaxY = 250;
        private const int MinY = -250;
        private const int MinZ = 30;
        private const int DeltaStep = 30;
        private const int MaxRadius = 270;


        public event Action<object, Point3> PositionChanged;


        public Point3 Position 
        {
            get { return mPosition; }
            set { mPosition = value; }
        }


        public Mouse3dController()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserMouse
                , true);
        }

        public Point3 GetCoordinates()
        {
            return mPosition;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            float maxArcWidth = MaxRadius * 2;
            float scale = (Width - 40) / maxArcWidth;

            mTransform = new Matrix();
            mTransform.Translate(Width / 2, (int)(VerticalworkArea * Height));
            mTransform.Scale(scale, -scale);
            mTransform.Rotate(mAngleCorrection);

            mTransformInverse = mTransform.Clone();
            mTransformInverse.Invert();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            UpdateXYZ(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateXYZ(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            UpdateY(mPosition.Y + e.Delta / DeltaStep);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            //e.Graphics.DrawRectangle(Pens.DarkGray,  0, 0, Width - 1, Height - 1);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Apply transformation for centering and any possible rotation correction.
            e.Graphics.Transform = mTransform;
            
            DrawScopeArc(e);
            DrawArm(e);

            // Reset transform to draw title and elevation on top of the previous steps
            e.Graphics.Transform = new Matrix();

            DrawTitle(e);
            DrawElevation(e);
        }

        private void DrawTitle(PaintEventArgs e)
        {
            using (var b = new SolidBrush(ForeColor)) e.Graphics.DrawString("Top view", Font, b, 5, 5);
            using (var bs = new SolidBrush(Color.FromArgb(150, ForeColor)))
                e.Graphics.DrawString(mPosition.ToString(), Font, bs, 5, 22);
        }

        private void DrawElevation(PaintEventArgs e)
        {
            float x = Width - 10;
            float topMargin = (1 - VerticalworkArea) * Height;
            float height = Height - (topMargin * 2);
            float barWidth = 3;
            float markerWidth = 7;
            float markerHeight = 3;

            using (var p = new Pen(Color.FromArgb(150, Color.White), 1))
            {
                e.Graphics.DrawRectangle(p, x, topMargin, barWidth, height);
            }

            var loc = Map((float)Position.Y, MinY, MaxY, (int)(topMargin + height - markerHeight), (int)(topMargin));

            using (var b = new SolidBrush(Color.FromArgb(150, Color.Red)))
            {
                e.Graphics.FillRectangle(b, x + barWidth / 2 - markerWidth / 2, loc, markerWidth, markerHeight);
            }
        }

        private void DrawScopeArc(PaintEventArgs e)
        {
            const float r = MaxRadius;

            using (var arc = new GraphicsPath())
            {
                arc.AddArc(-r, -r, r * 2, r * 2, 0, 180);

                using (var b = new SolidBrush(Color.FromArgb(10, Color.Black))) e.Graphics.FillPath(b, arc);
                using (var p = new Pen(Color.FromArgb(20, Color.Black), 3)) e.Graphics.DrawPath(p, arc);
            }
        }


        private void DrawArm(PaintEventArgs e)
        {
            using (var p = new Pen(Color.Red, 5))
            {
                var point = new PointF((float)mPosition.X, (float)mPosition.Z);
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                e.Graphics.DrawLine(p, new PointF(0, 0), point);

                DrawBall(point, 10, Color.Red, e.Graphics);
            }
        }

        private void DrawBall(PointF point, int radius, Color c, Graphics g)
        {
            int r2 = radius * 2;
            var p = point;

            using (var b = new SolidBrush(c))
            {
                g.FillEllipse(b, p.X - radius, p.Y - radius, r2, r2);
            }
        }


        public static float Map(float val, int fromMin, int fromMax, int toMin, int toMax)
        {
            int fromRange = fromMax - fromMin;
            int toRange = toMax - toMin;

            double startVal = val - fromMin;
            double x = (double)toRange * startVal / (double)fromRange;

            return (float)(x + toMin);
        }


        private bool IsPointInElevationArea(int screenX, int screenY)
        {
            float x = Width - 15;

            return (screenX >= x);
        }

        private double GetElevationFromScreen(int screenY)
        {
            float topMargin = (1 - VerticalworkArea) * Height;
            float height = Height - (topMargin * 2);

            var loc = Map((float)screenY, (int)(topMargin + height), (int)(topMargin), MinY, MaxY);

            return loc;
        }

        private void UpdateXYZ(MouseEventArgs e)
        {
            if (IsPointInElevationArea(e.X, e.Y))
            {
                UpdateY(GetElevationFromScreen(e.Y));
            }
            else
            {
                UpdateXZ(e.X, e.Y);
            }
        }

        private void UpdateXZ(int screenX, int screenY)
        {
            var p = ScreenToSpace(new Point(screenX, screenY));
            p = ConstrainXZ(p);

            mPosition.X = p.X;
            mPosition.Z = p.Y;

            OnPositionChanged();

            Invalidate();
        }

        private void UpdateY(double y)
        {
            if (y < MinY) y = MinY;
            if (y > MaxY) y = MaxY;

            mPosition.Y = y;

            OnPositionChanged();

            Invalidate();
        }

        private PointF ConstrainXZ(PointF p)
        {
            if (p.Y < MinZ) p.Y = MinZ;

            float len = (float)Math.Sqrt(p.X * p.X + p.Y * p.Y);

            if (len < MaxRadius) return p;

            var angle = Math.Atan2(p.Y, p.X);
            return new PointF((float)(MaxRadius * Math.Cos(angle)), (float)(MaxRadius * Math.Sin(angle)));
        }

        private PointF SpaceToScreen(PointF p)
        {
            return ApplyMatrixToPoint(p, mTransform);
        }

        private PointF ScreenToSpace(PointF p)
        {
            return ApplyMatrixToPoint(p, mTransformInverse);
        }

        private PointF ApplyMatrixToPoint(PointF p, Matrix m)
        {
            var points = new PointF[] { p };
            m.TransformPoints(points);
            return points[0];
        }

        protected virtual void OnPositionChanged()
        {
            if (PositionChanged != null) PositionChanged(this, mPosition);
        }

    }
}
