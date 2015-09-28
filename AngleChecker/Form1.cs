using MyArmClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleChecker
{
    public partial class Form1 : Form
    {
        private string mCalibrationFileName = "MG995servos.xml";


        private Client mArm = new Client();
        private bool mWantsReads;


        public Form1()
        {
            InitializeComponent();

            xyControl.Angle1Limits.StartAngle = -20;
            xyControl.Angle1Limits.EndAngle = 160;
            xyControl.Angle2Limits.Inverted = true;
            xyControl.Angle2Limits.StartAngle = -35;
            xyControl.Angle2Limits.EndAngle = 135;

            rotControl.Angle1Limits.StartAngle = -90;
            rotControl.Angle1Limits.EndAngle = 90;
            rotControl.Angle2Limits.StartAngle = -180;
            rotControl.Angle2Limits.EndAngle = 180;

            mArm.AnglesReceived += mArm_AnglesReceived;

            LoadConfiguration();
        }


        private void ConnectButton_Click(object sender, EventArgs e)
        {
            mArm.Attach("COM3");

            //LaunchReaderThread();
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

        private void ReadButton_Click(object sender, EventArgs e)
        {
            mArm.ReadAngles();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void mArm_AnglesReceived(short a1, short a2, short rot, short gripRot)
        {
            Invoke(() => {
                SensorPulsesLabel.Text = string.Format(
                    "Sensor pulses: {0}, {1}, {2}",
                    mArm.CalibrationData.Right.GetPulsesForSensorReading(a1),
                    mArm.CalibrationData.Left.GetPulsesForSensorReading(a2),
                    mArm.CalibrationData.Rotation.GetPulsesForSensorReading(rot));

                SensorAnglesLabel.Text = string.Format(
                    "Sensor angles: {0:.}, {1:.}, {2:.}",
                    mArm.CalibrationData.Right.GetAngleForSensorReading(a1),
                    mArm.CalibrationData.Left.GetAngleForSensorReading(a2),
                    mArm.CalibrationData.Rotation.GetAngleForSensorReading(rot));
            });
        }

        private void Invoke(Action methodToInvoke)
        {
            this.Invoke((Delegate)methodToInvoke);
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
                Thread.Sleep(200);
            }
        }


        // __Inverse kinematics _______________________________________________


        private const double RadiansToDegrees = 180 / Math.PI;

        public void xyControl_InverseKinematicsSolver(int length, int height, double ArmA, double ArmC, out double rightAngle, out double leftAngle)
        {
            double ArmA2 = ArmA * ArmA;
            double ArmC2 = ArmC * ArmC;
            double ArmA2C2 = ArmA * ArmA + ArmC * ArmC;
            double Arm2AC = 2 * ArmA * ArmC;


            double x2y2 = length * length + height * height;
            double delta = Math.Atan((double)height / (double)length) * RadiansToDegrees;
            double gamma = Math.Acos((ArmA2 + x2y2 - ArmC2) / (2 * ArmA * Math.Sqrt(x2y2))) * RadiansToDegrees;
            double epsilon = Math.Acos((ArmA2C2 - x2y2) / (Arm2AC)) * RadiansToDegrees;


            leftAngle = 180 - delta - gamma - epsilon;
            rightAngle = delta + gamma;
        }

        private void xyControl_KinematicSolved()
        {
            var angles = new RobotAngles() { A1 = rotControl.Angle1, A2 = xyControl.Angle1, A3 = xyControl.Angle2 };

            mArm.SetAngles(angles);

            UpdateAnglesLabels();

            int length = (int)xyControl.TargetPosition.X;
            rotControl.Length1 = length / 2;
            rotControl.Length2 = rotControl.Length1;
        }

        private void UpdateAnglesLabels()
        {
            PulsesLabel.Text = string.Format("{0}, {1}, {2}, 0",
                mArm.CalibrationData.Right.GetPulsesForAngle(xyControl.Angle1),
                mArm.CalibrationData.Left.GetPulsesForAngle(xyControl.Angle2),
                mArm.CalibrationData.Rotation.GetPulsesForAngle(rotControl.Angle1));

            AnglesLabel.Text = string.Format(
                    "Angles set: {0:.}, {1:.}, {2:.}",
                    xyControl.Angle1, xyControl.Angle2, rotControl.Angle1);
        }
        
        
        // __ Rotation kinematics _____________________________________________


        private void rotControl_KinematicSolutionNeeded(int x, int y, double l1, double l2, out double a1, out double a2)
        {
            int length = (int)Math.Sqrt(x * x + y * y);

            rotControl.Length1 = length / 2;
            rotControl.Length2 = rotControl.Length1;

            a1 = Math.Atan2(y, x) * RadiansToDegrees;
            a2 = -a1;
        }

        private void rotControl_KinematicSolved()
        {
            var x = rotControl.TargetPosition.X;
            var y = rotControl.TargetPosition.Y;

            int length = (int)Math.Sqrt(x * x + y * y);

            double a1, a2;
            xyControl_InverseKinematicsSolver(length, (int)xyControl.TargetPosition.Y, xyControl.Length1, xyControl.Length2, out a1, out a2);

            var angles = new RobotAngles() { A1 = rotControl.Angle1, A2 = a1, A3 = a2 };
            mArm.SetAngles(angles);

            UpdateAnglesLabels();

            xyControl.Angle1 = a1;
            xyControl.Angle2 = a2;
        }

        // __ UI events _______________________________________________________


        private void ArmButton_Click(object sender, EventArgs e)
        {
            mArm.Engage();
        }

        private void DisarmButton_Click(object sender, EventArgs e)
        {
            mArm.Disengage();
        }


        // __ Calibration _____________________________________________________


        private void Pulse1Trackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulses();
        }

        private void Pulse2Trackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulses();
        }

        private void Pulse3Trackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulses();
        }

        private void UpdatePulses()
        {
            mArm.SetPulses((Int16)Pulse1Trackbar.Value, (Int16)Pulse2Trackbar.Value, (Int16)Pulse3Trackbar.Value, 0, 0, 0, 500);
            PulsesLabel.Text = string.Format("{0}, {1}, {2}", Pulse1Trackbar.Value, Pulse2Trackbar.Value, Pulse3Trackbar.Value);
        }

        private void LoadConfiguration()
        {
            if (!File.Exists(mCalibrationFileName)) return;

            mArm.LoadConfiguration(mCalibrationFileName);


        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            mArm.SaveConfiguration(mCalibrationFileName);
        }


    }
}

