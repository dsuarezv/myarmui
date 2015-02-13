using MyArmClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleChecker
{
    public partial class Form1 : Form
    {
        private Client mArm = new Client("COM3");
        private bool mWantsReads;


        public Form1()
        {
            InitializeComponent();

            A1Track.Value = (int)xyControl1.Angle1;
            A2Track.Value = (int)xyControl1.Angle2;

            xyControl1.Solver += IkSolver;

            xyControl1.Angle1Limits.StartAngle = -20;
            xyControl1.Angle1Limits.EndAngle = 160;

            xyControl1.Angle2Limits.Inverted = true;
            xyControl1.Angle2Limits.StartAngle = -35;
            xyControl1.Angle2Limits.EndAngle = 135;

            mArm.AnglesReceived += mArm_AnglesReceived;
        }


        private void xyControl1_KinematicSolved()
        {
            if (xyControl1.Angle1 == double.NaN || xyControl1.Angle2 == double.NaN) return;

            mArm.SetAngles(xyControl1.Angle1, xyControl1.Angle2, 0, 0);
        }


        private void A1Track_Scroll(object sender, EventArgs e)
        {
            //xyControl1.Angle1 = A1Track.Value + Offset1Trackbar.Value;
            //UpdateCaption();
        }

        private void A2Track_Scroll(object sender, EventArgs e)
        {
            //xyControl1.Angle2 = A2Track.Value + Offset2Trackbar.Value;
            //UpdateCaption();
        }

        private void UpdateCaption()
        {
            OffsetsLabel.Text = string.Format(
                "{0}\n{1}",
                Offset1Trackbar.Value, 
                Offset2Trackbar.Value
                );
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            mArm.Attach();

            //LaunchReaderThread();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            mWantsReads = false;
            mArm.Detach();
        }


        private void Pingbutton_Click(object sender, EventArgs e)
        {
            //mArm.Ping();
            mArm.ReadAngles();
        }


        private int Constrain(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;

            return val;
        }

        private void mArm_AnglesReceived(short a1, short a2, short rot, short gripRot)
        {
            Invoke(() => {
                int va1 = 180 - a1;
                int va2 = 180 - a2;

                A1Track.Value = Constrain(va1, -180, 180);
                A2Track.Value = Constrain(va2, -180, 180);

                SensorsLabel.Text = string.Format("{0}, {1}, {2}", a1, a2, rot, gripRot);
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
                Thread.Sleep(33);
            }
        }


        // __Inverse kinematics _______________________________________________


        private const double RadiansToDegrees = 180 / Math.PI;

        private void IkSolver(int length, int height, double ArmA, double ArmC, out double rightAngle, out double leftAngle)
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


            //label1.Text = string.Format("delta: {0:0.00}, gamma: {1:0.00}, epsilon: {2:0.00}", delta, gamma, epsilon);
        }

        private void Offset1Trackbar_ValueChanged(object sender, EventArgs e)
        {
            //A1Track_Scroll(null, null);
        }

        private void Offset2Trackbar_ValueChanged(object sender, EventArgs e)
        {
            //A2Track_Scroll(null, null);
        }

        private void ArmButton_Click(object sender, EventArgs e)
        {
            mArm.Engage();
        }

        private void DisarmButton_Click(object sender, EventArgs e)
        {
            mArm.Disengage();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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
            mArm.SetPulses((Int16)Pulse1Trackbar.Value, (Int16)Pulse2Trackbar.Value, (Int16)Pulse3Trackbar.Value, 0);
            PulsesLabel.Text = string.Format("{0}, {1}, {2}", Pulse1Trackbar.Value, Pulse2Trackbar.Value, Pulse3Trackbar.Value);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mArm.Detach();
        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            mArm.LoadCalibrationData("myarm.xml");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            mArm.SaveCalibrationData("myarm.xml");
        }

    }
}

