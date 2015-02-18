using Engine.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArmUI
{
    public partial class Form1 : Form
    {
        private SceneHandler m3dScene;

        public Form1()
        {
            InitializeComponent();

            m3dScene = new SceneHandler(View3d);
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

    }
}
