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

namespace MyArmUI
{
    public partial class SpeedControl : UserControl
    {
        public Client Arm { get; set; }

        public SpeedControl()
        {
            InitializeComponent();
        }

        private void SpeedTrackbar_ValueChanged(object sender, EventArgs e)
        {
            if (Arm == null) return;

            ValueLabel.Text = SpeedTrackbar.Value.ToString();

            Arm.SetSpeed((FullSpeedCheckbox.Checked) ? 0 : SpeedTrackbar.Value);
        }

        private void FullSpeedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SpeedTrackbar.Enabled = !FullSpeedCheckbox.Checked;
        }
    }
}
