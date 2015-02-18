using Engine.Core;
using Engine.WinFormsControl;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmUI
{
    public class SceneHandler
    {
        private const double DegreesToRadians = Math.PI / 180.0;

        private EngineControl mControl;
        private double mAngle1 = 0; 
        private double mAngle2 = 0;
        private double mAngle3 = 10;
        private double mLength1 = 100;
        private double mLength2 = 148;
        private double mLength3 = 161;
        

        private Entity mRight;
        private Entity mTop;
        private Entity mBase;


        public double Angle1
        {
            get { return mAngle1; }
            set { mAngle1 = value; UpdateArm(); }
        }

        public double Angle2
        {
            get { return mAngle2; }
            set { mAngle2 = value; UpdateArm(); }
        }

        public double Angle3
        {
            get { return mAngle3; }
            set { mAngle3 = value; UpdateArm(); }
        }


        public double Length1
        {
            get { return mLength2; }
            set { mLength2 = value; UpdateArm(); }
        }

        public double Length2
        {
            get { return mLength3; }
            set { mLength3 = value; UpdateArm(); }
        }


        public SceneHandler(EngineControl target)
        {
            mControl = target;
        }

        public void Setup()
        {
            Content.LoadAssetFromDepot("LocalDepot/right.model", typeof(Mesh));

            mRight = new Entity("right").AddComponent(new MeshRenderer("LocalDepot/right.model"));
            mControl.Scene.AddEntity(mRight);

            mTop = new Entity("top").AddComponent(new MeshRenderer("LocalDepot/top.model"));
            mControl.Scene.AddEntity(mTop);

            UpdateArm();
        }



        private void UpdateArm()
        {
            var matBottom = Matrix4.CreateRotationY((float)(mAngle1 * DegreesToRadians));


            var matRight = 
                Matrix4.CreateTranslation(0, (float)mLength1, 0) * 
                Matrix4.CreateRotationZ((float)(mAngle2 * DegreesToRadians));
            mRight.Transform.TransformMatrix = matRight;

            var matTop =
                Matrix4.CreateRotationZ((float)(mAngle3 * DegreesToRadians)) *
                Matrix4.CreateTranslation(0, (float)mLength2, 0);

            mTop.Transform.TransformMatrix = matTop * matRight;
        }
    }
}
