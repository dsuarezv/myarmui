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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void AddData(byte b)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte>(AddData), b);
            }
            else
            {
                OutputTextbox.AppendText(new string(Encoding.ASCII.GetChars(new byte[] { b })));
            }
        }
    }
}
