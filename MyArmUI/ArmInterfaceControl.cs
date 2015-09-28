using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyArmClient;
using System.IO;

namespace MyArmUI
{
    public partial class ArmInterfaceControl : UserControl
    {
        private string mCalibrationFileName = "ArmConfigurations/HDPowerServos.arm.xml";
        private StringBuilder mOutOfBandData = new StringBuilder();
        private LogForm mLogForm;


        public Client Arm { get; private set; }


        public ArmInterfaceControl()
        {
            InitializeComponent();

            Arm = new Client();
            Arm.OutOfBandDataReceived += Arm_OutOfBandDataReceived;

            LoadConfigButton_Click(null, null);
        }

        void Arm_OutOfBandDataReceived(object sender, byte val)
        {
            mOutOfBandData.Append(Encoding.ASCII.GetChars(new byte[] { val }));
            if (mLogForm != null) mLogForm.AddData(val);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(PortsCombo.Text)) return;

            Arm.Attach(PortsCombo.Text);

            EnableControls(true);
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Arm.Detach();
            EnableControls(false);
        }

        private void EngageButton_Click(object sender, EventArgs e)
        {
            Arm.Engage();
        }

        private void DisengageButton_Click(object sender, EventArgs e)
        {
            Arm.Disengage();
        }

        private void RefreshPortsButton_Click(object sender, EventArgs e)
        {
            UpdatePorts();
        }

        private void ArmInterfaceControl_Load(object sender, EventArgs e)
        {
            UpdatePorts();
        }

        private void EnableControls(bool connected)
        {
            ConnectButton.Enabled = !connected;
            DisconnectButton.Enabled = connected;
            SecondaryActionsPanel.Visible = connected;
        }

        private void UpdatePorts()
        {   
            PortsCombo.BeginUpdate();
            PortsCombo.Items.Clear();

            foreach (var port in Client.GetComPorts()) PortsCombo.Items.Add(port);

            PortsCombo.EndUpdate();

            if (PortsCombo.Items.Count == 0) return;

            PortsCombo.SelectedIndex = 0;
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(mCalibrationFileName)) return;

            Arm.LoadConfiguration(mCalibrationFileName);
        }

        private void CalibrateButton_Click(object sender, EventArgs e)
        {
            CalibrationForm.LaunchCalibration(Arm);
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            Arm.SaveConfiguration(mCalibrationFileName);
        }

        private void VersionButton_Click(object sender, EventArgs e)
        {
            Arm.GetVersion();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            if (mLogForm == null) mLogForm = new LogForm();

            mLogForm.Show();
        }
    }
}
