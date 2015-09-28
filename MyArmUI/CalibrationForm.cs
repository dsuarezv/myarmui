using MyArmClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArmUI
{
    public partial class CalibrationForm : Form
    {
        private enum Step
        {
            RotationPlus90,
            RotationMinus90,
            RightZero,
            RightPlus135,
            LeftMinus45,
            LeftPlus90
        };

        private Client mArm;
        private const int DefaultPulsesValue = 1500;
        private AxesCalibration mCalibrationData = new AxesCalibration();
        private StepData[] mSteps;
        private int mCurrentStepIndex = 0;


        private CalibrationForm()
        {
            InitializeComponent();

            InitStepData();

            SetCurrentStep(0);
        }

        public static void LaunchCalibration(Client armClient)
        {
            if (armClient == null) return;

            using (var f = new CalibrationForm() { mArm = armClient })
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                    
                // Set calibration data in the client and save to the specified file.
                // Watch out for the build process overwriting the file in bin/debug with the one in the project.
                f.mArm.CalibrationData = f.mCalibrationData;
            }
        }

        private void InitStepData()
        { 
            mSteps = new StepData[] {
                new StepData() { Name = "Rotation 90º", Angle = 90, Image = MyArmUI.Properties.Resources.rotplus90, Data = mCalibrationData.Rotation.Max, AxisIndex = 0, DefaultPosition = new Position(1500, 1500, 1500, 1500), IsFirst = true },
                new StepData() { Name = "Rotation -90º", Angle = -90, Image = MyArmUI.Properties.Resources.rotminus90, Data = mCalibrationData.Rotation.Min, AxisIndex = 0,DefaultPosition = new Position(1500, 1500, 1500, 1500) },
                new StepData() { Name = "Right axis 0º", Angle = 0, Image = MyArmUI.Properties.Resources.right0, Data = mCalibrationData.Right.Min, AxisIndex = 1, DefaultPosition = new Position(1500, 1500, 1500, 1500) },
                new StepData() { Name = "Right axis 135º", Angle = 135, Image = MyArmUI.Properties.Resources.right135, Data = mCalibrationData.Right.Max, AxisIndex = 1, DefaultPosition = new Position(1500, 1500, 2000, 1500), },
                new StepData() { Name = "Left axis -35º", Angle = -35, Image = MyArmUI.Properties.Resources.left45, Data = mCalibrationData.Left.Min, AxisIndex = 2, DefaultPosition = new Position(1500, 1500, 1500, 1500) },
                new StepData() { Name = "Left axis 90º", Angle = 90, Image = MyArmUI.Properties.Resources.leftminus90, Data = mCalibrationData.Left.Max, AxisIndex = 2, DefaultPosition = new Position(1500, 2000, 1500, 1500) },
                new StepData() { Name = "Effector axis -90º", Angle = -90, Image = MyArmUI.Properties.Resources.rot0, Data = mCalibrationData.Gripper.Min, AxisIndex = 3, DefaultPosition = new Position(1500, 1500, 1500, 1500) },
                new StepData() { Name = "Effector axis 90º", Angle = 90, Image = MyArmUI.Properties.Resources.rot0, Data = mCalibrationData.Gripper.Max, AxisIndex = 3, DefaultPosition = new Position(1500, 1500, 1500, 1500), IsLast = true },

            };
        }

        private void AngleTrackbar_ValueChanged(object sender, EventArgs e)
        {
            AngleLabel.Text = AngleTrackbar.Value.ToString();

            var p = GetDefaultPosition(AngleTrackbar.Value);

            mArm.SetPulses(p.A2, p.A3, p.A1, p.A4, 0, 0, 200);
        }

        private Position GetDefaultPosition(int val)
        {
            var data = mSteps[mCurrentStepIndex];

            switch (data.AxisIndex)
            {
                case 0: data.DefaultPosition.A1 = (short)val; break;
                case 1: data.DefaultPosition.A2 = (short)val; break;
                case 2: data.DefaultPosition.A3 = (short)val; break;
                case 3: data.DefaultPosition.A4 = (short)val; break;
            }

            return data.DefaultPosition;
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            SetCurrentStep(mCurrentStepIndex - 1);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            SetCurrentStep(mCurrentStepIndex + 1);
        }

        private void SetCurrentStep(int index)
        {
            // Save current value
            var oldData = mSteps[mCurrentStepIndex];
            oldData.Data.Pulses = AngleTrackbar.Value;
            oldData.Data.Angle = oldData.Angle;

            mCurrentStepIndex = index;

            // Set next value (read from data if available)
            var data = mSteps[mCurrentStepIndex];

            CurrentAxisLabel.Text = data.Name;
            pictureBox1.BackgroundImage = data.Image;

            var val = data.Data.Pulses;
            if (val == 0) val = DefaultPulsesValue;

            AngleTrackbar.Value = val;

            PreviousButton.Enabled = !data.IsFirst;
            NextButton.Enabled = !data.IsLast;
            OkButton.Enabled = data.IsLast;
        }


        private class StepData
        {
            public string Name;
            public Image Image;
            public bool IsLast;
            public bool IsFirst;
            public int AxisIndex;
            public int Angle;
            public CalibrationData Data;
            public Position DefaultPosition;
        }

        private class Position
        {
            public short A1;
            public short A2;
            public short A3;
            public short A4;

            public Position(short a1, short a2, short a3, short a4)
            {
                A1 = a1;
                A2 = a2;
                A3 = a3;
                A4 = a4;
            }
        }
    }
}
