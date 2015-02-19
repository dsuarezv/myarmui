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

        private string mCalibrationFileName = "MG995servos.xml";
        private SceneHandler m3dScene;
        private Client mArm;
        private bool mWantsReads;


        public MainForm()
        {
            InitializeComponent();

            m3dScene = new SceneHandler(View3d);
            mArm = new Client("COM3");
            mArm.AnglesReceived += mClient_AnglesReceived;

            LoadConfiguration();
        }

        void mClient_AnglesReceived(short a1, short a2, short rot, short gripRot)
        {
            m3dScene.Angle2 = 90 - mArm.CalibrationData.Right.GetAngleForSensorReading(a1);
            m3dScene.Angle3 = mArm.CalibrationData.Left.GetAngleForSensorReading(a2);
            m3dScene.Angle1 = mArm.CalibrationData.Rotation.GetAngleForSensorReading(rot);
        }

        private void View3d_SceneLoad(object arg1, EventArgs arg2)
        {
            m3dScene.Setup();
        }

        private void Angle1Trackbar_ValueChanged(object sender, EventArgs e)
        {
            m3dScene.Angle1 = Angle1Trackbar.Value;
        }

        private void Angle2Trackbar_ValueChanged(object sender, EventArgs e)
        {
            m3dScene.Angle2 = Angle2Trackbar.Value;
        }

        private void Angle3Trackbar_ValueChanged(object sender, EventArgs e)
        {
            m3dScene.Angle3 = Angle3Trackbar.Value;
        }


        private void LoadConfiguration()
        {
            if (!File.Exists(mCalibrationFileName)) return;

            mArm.LoadConfiguration(mCalibrationFileName);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            mArm.Attach();

            LaunchReaderThread();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            mWantsReads = false;
            mArm.Detach();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mArm.Detach();
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
                mArm.ReadAngles();
                Thread.Sleep((int)(1000.0 / SamplesPerSecond));
            }
        }


        private void EnumerateWebcams()
        {
            var c1 = new ManagementClass("Win32_VideoController");

            foreach (ManagementObject ob in c1.GetInstances())
            {
                foreach (PropertyData pd in ob.Properties)
                {

                    if (pd.Name != null)
                        Console.WriteLine(" Name " + pd.Name);

                    if (pd.Value != null)
                        Console.WriteLine(" Value " + pd.Value);
                }
            }
        }

        private void EvalBButton_click(object sender, EventArgs e)
        {
            EnumerateWebcams();
        }
    }
}
