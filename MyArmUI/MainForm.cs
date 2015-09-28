using AngleChecker;
using Engine.Core;
using MyArmClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArmUI
{
    public partial class MainForm : Form
    {
        private const int SamplesPerSecond = 10;

        private SceneHandler m3dScene;
        private bool mWantsReads;


        public MainForm()
        {
            InitializeComponent();
            m3dScene = new SceneHandler(View3d);
            speedControl1.Arm = armIface.Arm;
            pathRecorderControl1.Arm = armIface.Arm;
            pathRecorderControl1.CoordinatesProvider = mouse3dController1;
            armIface.Arm.AnglesReceived += mClient_AnglesReceived;
        }


        void mClient_AnglesReceived(short a1, short a2, short rot, short gripRot)
        {
            var a = armIface.Arm;
            
            m3dScene.Angle1 = a.CalibrationData.Rotation.GetAngleForSensorReading(rot);
            m3dScene.Angle2 = a.CalibrationData.Right.GetAngleForSensorReading(a1);
            m3dScene.Angle3 = a.CalibrationData.Left.GetAngleForSensorReading(a2);
        }

        private void View3d_SceneLoad(object arg1, EventArgs arg2)
        {
            m3dScene.Setup();
        }

        private void GripperAngleTrackbar_ValueChanged(object sender, EventArgs e)
        {
            A1Label.Text = GripperAngleTrackbar.Value.ToString();

            var angles = armIface.Arm.CurrentAngles;
            angles.A4 = GripperAngleTrackbar.Value;

            armIface.Arm.SetAngles(angles);
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mArm.Detach();
        }

        private void LaunchReaderThread()
        {
            mWantsReads = true;
            var t = new Thread(ReaderWorker);
            t.IsBackground = true;
            t.Start();
        }

        private void ReaderWorker()
        {
            while (mWantsReads)
            {
                armIface.Arm.ReadAngles();
                Thread.Sleep((int)(1000.0 / SamplesPerSecond));
            }
        }

        private void mouse3dController1_PositionChanged(object sender, Point3 newPosition)
        {
            // DAVE: calculate time based on the distance. 
            // Move this code to the client to a function MoveEffector(x, y, z, rx, ry, rz) (6 axis)
            // the function will do its best to approximate the required position with the robot axes. 
            // This will make it work in future setups. The function may return a struct with the calculated angles.
            var angles = IkSolver.GetAnglesForXYZ(newPosition, 148, 161);
            //armIface.Arm.SetAngles(a1, a2, a3, GripperAngleTrackbar.Value);
            armIface.Arm.SetAngles(angles, 100);



            m3dScene.Angle1 = angles.A1;
            m3dScene.Angle2 = angles.A2;
            m3dScene.Angle3 = angles.A3;

            //label1.Text = string.Format("Location ({3:0},{4:0},{5:0})  Angles: {0:0.}, {1:0.}, {2:0.}", a1, a2, a3, newPosition.X, newPosition.Y, newPosition.Z);
        }

    }
}
