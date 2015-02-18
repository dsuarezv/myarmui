namespace MyArmUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Angle3Trackbar = new System.Windows.Forms.TrackBar();
            this.Angle2Trackbar = new System.Windows.Forms.TrackBar();
            this.Angle1Trackbar = new System.Windows.Forms.TrackBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.View3d = new Engine.WinFormsControl.EngineControl();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Angle3Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle2Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle1Trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(650, 39);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Visible = false;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Angle3Trackbar);
            this.LeftPanel.Controls.Add(this.Angle2Trackbar);
            this.LeftPanel.Controls.Add(this.Angle1Trackbar);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 39);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(198, 498);
            this.LeftPanel.TabIndex = 1;
            // 
            // Angle3Trackbar
            // 
            this.Angle3Trackbar.LargeChange = 45;
            this.Angle3Trackbar.Location = new System.Drawing.Point(3, 109);
            this.Angle3Trackbar.Maximum = 180;
            this.Angle3Trackbar.Minimum = -180;
            this.Angle3Trackbar.Name = "Angle3Trackbar";
            this.Angle3Trackbar.Size = new System.Drawing.Size(189, 45);
            this.Angle3Trackbar.TabIndex = 2;
            this.Angle3Trackbar.TickFrequency = 45;
            this.Angle3Trackbar.ValueChanged += new System.EventHandler(this.Angle3Trackbar_ValueChanged);
            // 
            // Angle2Trackbar
            // 
            this.Angle2Trackbar.LargeChange = 45;
            this.Angle2Trackbar.Location = new System.Drawing.Point(3, 58);
            this.Angle2Trackbar.Maximum = 180;
            this.Angle2Trackbar.Minimum = -180;
            this.Angle2Trackbar.Name = "Angle2Trackbar";
            this.Angle2Trackbar.Size = new System.Drawing.Size(189, 45);
            this.Angle2Trackbar.TabIndex = 1;
            this.Angle2Trackbar.TickFrequency = 45;
            this.Angle2Trackbar.ValueChanged += new System.EventHandler(this.Angle2Trackbar_ValueChanged);
            // 
            // Angle1Trackbar
            // 
            this.Angle1Trackbar.LargeChange = 45;
            this.Angle1Trackbar.Location = new System.Drawing.Point(3, 7);
            this.Angle1Trackbar.Maximum = 180;
            this.Angle1Trackbar.Minimum = -180;
            this.Angle1Trackbar.Name = "Angle1Trackbar";
            this.Angle1Trackbar.Size = new System.Drawing.Size(189, 45);
            this.Angle1Trackbar.TabIndex = 0;
            this.Angle1Trackbar.TickFrequency = 45;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 498);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // View3d
            // 
            this.View3d.DepotPath = null;
            this.View3d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View3d.Location = new System.Drawing.Point(202, 39);
            this.View3d.Name = "View3d";
            this.View3d.Size = new System.Drawing.Size(448, 498);
            this.View3d.TabIndex = 3;
            this.View3d.SceneLoad += new System.Action<object, System.EventArgs>(this.View3d_SceneLoad);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 537);
            this.Controls.Add(this.View3d);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "Form1";
            this.Text = "MyArm";
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Angle3Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle2Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle1Trackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Splitter splitter1;
        private Engine.WinFormsControl.EngineControl View3d;
        private System.Windows.Forms.TrackBar Angle1Trackbar;
        private System.Windows.Forms.TrackBar Angle3Trackbar;
        private System.Windows.Forms.TrackBar Angle2Trackbar;
    }
}

