namespace AngleChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.Pingbutton = new System.Windows.Forms.Button();
            this.ArmButton = new System.Windows.Forms.Button();
            this.DisarmButton = new System.Windows.Forms.Button();
            this.Pulse1Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse2Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse3Trackbar = new System.Windows.Forms.TrackBar();
            this.PulsesLabel = new System.Windows.Forms.Label();
            this.SensorPulsesLabel = new System.Windows.Forms.Label();
            this.Loadbutton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.xyControl = new AngleChecker.XYControl();
            this.AnglesLabel = new System.Windows.Forms.Label();
            this.SensorAnglesLabel = new System.Windows.Forms.Label();
            this.rotControl = new AngleChecker.XYControl();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse1Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse2Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse3Trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 12);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(93, 12);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 5;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // Pingbutton
            // 
            this.Pingbutton.Location = new System.Drawing.Point(174, 55);
            this.Pingbutton.Name = "Pingbutton";
            this.Pingbutton.Size = new System.Drawing.Size(75, 23);
            this.Pingbutton.TabIndex = 6;
            this.Pingbutton.Text = "Read sensors";
            this.Pingbutton.UseVisualStyleBackColor = true;
            this.Pingbutton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // ArmButton
            // 
            this.ArmButton.Location = new System.Drawing.Point(12, 55);
            this.ArmButton.Name = "ArmButton";
            this.ArmButton.Size = new System.Drawing.Size(75, 23);
            this.ArmButton.TabIndex = 10;
            this.ArmButton.Text = "Engage motors";
            this.ArmButton.UseVisualStyleBackColor = true;
            this.ArmButton.Click += new System.EventHandler(this.ArmButton_Click);
            // 
            // DisarmButton
            // 
            this.DisarmButton.Location = new System.Drawing.Point(93, 55);
            this.DisarmButton.Name = "DisarmButton";
            this.DisarmButton.Size = new System.Drawing.Size(75, 23);
            this.DisarmButton.TabIndex = 11;
            this.DisarmButton.Text = "Disengage motors";
            this.DisarmButton.UseVisualStyleBackColor = true;
            this.DisarmButton.Click += new System.EventHandler(this.DisarmButton_Click);
            // 
            // Pulse1Trackbar
            // 
            this.Pulse1Trackbar.Location = new System.Drawing.Point(25, 96);
            this.Pulse1Trackbar.Maximum = 2400;
            this.Pulse1Trackbar.Minimum = 600;
            this.Pulse1Trackbar.Name = "Pulse1Trackbar";
            this.Pulse1Trackbar.Size = new System.Drawing.Size(182, 45);
            this.Pulse1Trackbar.TabIndex = 13;
            this.Pulse1Trackbar.TickFrequency = 100;
            this.Pulse1Trackbar.Value = 1500;
            this.Pulse1Trackbar.ValueChanged += new System.EventHandler(this.Pulse1Trackbar_ValueChanged);
            // 
            // Pulse2Trackbar
            // 
            this.Pulse2Trackbar.Location = new System.Drawing.Point(213, 96);
            this.Pulse2Trackbar.Maximum = 2400;
            this.Pulse2Trackbar.Minimum = 600;
            this.Pulse2Trackbar.Name = "Pulse2Trackbar";
            this.Pulse2Trackbar.Size = new System.Drawing.Size(182, 45);
            this.Pulse2Trackbar.TabIndex = 13;
            this.Pulse2Trackbar.TickFrequency = 100;
            this.Pulse2Trackbar.Value = 1500;
            this.Pulse2Trackbar.ValueChanged += new System.EventHandler(this.Pulse2Trackbar_ValueChanged);
            // 
            // Pulse3Trackbar
            // 
            this.Pulse3Trackbar.Location = new System.Drawing.Point(401, 96);
            this.Pulse3Trackbar.Maximum = 2400;
            this.Pulse3Trackbar.Minimum = 600;
            this.Pulse3Trackbar.Name = "Pulse3Trackbar";
            this.Pulse3Trackbar.Size = new System.Drawing.Size(182, 45);
            this.Pulse3Trackbar.TabIndex = 13;
            this.Pulse3Trackbar.TickFrequency = 100;
            this.Pulse3Trackbar.Value = 1500;
            this.Pulse3Trackbar.ValueChanged += new System.EventHandler(this.Pulse3Trackbar_ValueChanged);
            // 
            // PulsesLabel
            // 
            this.PulsesLabel.Location = new System.Drawing.Point(213, 144);
            this.PulsesLabel.Name = "PulsesLabel";
            this.PulsesLabel.Size = new System.Drawing.Size(182, 15);
            this.PulsesLabel.TabIndex = 9;
            this.PulsesLabel.Text = "Pulses set";
            this.PulsesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SensorPulsesLabel
            // 
            this.SensorPulsesLabel.Location = new System.Drawing.Point(213, 159);
            this.SensorPulsesLabel.Name = "SensorPulsesLabel";
            this.SensorPulsesLabel.Size = new System.Drawing.Size(182, 15);
            this.SensorPulsesLabel.TabIndex = 9;
            this.SensorPulsesLabel.Text = "Sensor pulses read";
            this.SensorPulsesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Loadbutton
            // 
            this.Loadbutton.Location = new System.Drawing.Point(402, 135);
            this.Loadbutton.Name = "Loadbutton";
            this.Loadbutton.Size = new System.Drawing.Size(112, 23);
            this.Loadbutton.TabIndex = 14;
            this.Loadbutton.Text = "Load calibration";
            this.Loadbutton.UseVisualStyleBackColor = true;
            this.Loadbutton.Click += new System.EventHandler(this.Loadbutton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(402, 159);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save calibration";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // xyControl
            // 
            this.xyControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xyControl.Angle1 = 70D;
            this.xyControl.Angle2 = 10D;
            this.xyControl.AngleCorrection = 0;
            this.xyControl.GroundLevel = -100;
            this.xyControl.Length1 = 148D;
            this.xyControl.Length2 = 161D;
            this.xyControl.Location = new System.Drawing.Point(562, 223);
            this.xyControl.MinimumX = 25;
            this.xyControl.Name = "xyControl";
            this.xyControl.ShowDebugInfo = true;
            this.xyControl.Size = new System.Drawing.Size(488, 504);
            this.xyControl.TabIndex = 0;
            this.xyControl.TargetPosition = ((System.Drawing.PointF)(resources.GetObject("xyControl.TargetPosition")));
            this.xyControl.Text = "xyControl1";
            this.xyControl.KinematicSolutionNeeded += new AngleChecker.KinematicSolverDelegate(this.xyControl1_InverseKinematicsSolver);
            this.xyControl.KinematicSolved += new AngleChecker.KinematicClickDelegate(this.xyControl1_KinematicSolved);
            // 
            // AnglesLabel
            // 
            this.AnglesLabel.AutoSize = true;
            this.AnglesLabel.Location = new System.Drawing.Point(25, 144);
            this.AnglesLabel.Name = "AnglesLabel";
            this.AnglesLabel.Size = new System.Drawing.Size(56, 13);
            this.AnglesLabel.TabIndex = 16;
            this.AnglesLabel.Text = "Angles set";
            // 
            // SensorAnglesLabel
            // 
            this.SensorAnglesLabel.AutoSize = true;
            this.SensorAnglesLabel.Location = new System.Drawing.Point(25, 160);
            this.SensorAnglesLabel.Name = "SensorAnglesLabel";
            this.SensorAnglesLabel.Size = new System.Drawing.Size(98, 13);
            this.SensorAnglesLabel.TabIndex = 17;
            this.SensorAnglesLabel.Text = "Sensor angles read";
            // 
            // rotControl
            // 
            this.rotControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rotControl.Angle1 = 0D;
            this.rotControl.Angle2 = 0D;
            this.rotControl.AngleCorrection = 90;
            this.rotControl.GroundLevel = -1000;
            this.rotControl.Length1 = 100D;
            this.rotControl.Length2 = 100D;
            this.rotControl.Location = new System.Drawing.Point(12, 223);
            this.rotControl.MinimumX = 0;
            this.rotControl.Name = "rotControl";
            this.rotControl.ShowDebugInfo = true;
            this.rotControl.Size = new System.Drawing.Size(544, 504);
            this.rotControl.TabIndex = 18;
            this.rotControl.TargetPosition = ((System.Drawing.PointF)(resources.GetObject("rotControl.TargetPosition")));
            this.rotControl.Text = "xyControl2";
            this.rotControl.KinematicSolutionNeeded += new AngleChecker.KinematicSolverDelegate(this.rotControl_KinematicSolutionNeeded);
            this.rotControl.KinematicSolved += new AngleChecker.KinematicClickDelegate(this.rotControl_KinematicSolved);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 739);
            this.Controls.Add(this.rotControl);
            this.Controls.Add(this.SensorAnglesLabel);
            this.Controls.Add(this.AnglesLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Loadbutton);
            this.Controls.Add(this.Pulse3Trackbar);
            this.Controls.Add(this.Pulse2Trackbar);
            this.Controls.Add(this.Pulse1Trackbar);
            this.Controls.Add(this.DisarmButton);
            this.Controls.Add(this.ArmButton);
            this.Controls.Add(this.SensorPulsesLabel);
            this.Controls.Add(this.PulsesLabel);
            this.Controls.Add(this.Pingbutton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.xyControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Pulse1Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse2Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse3Trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XYControl xyControl;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button Pingbutton;
        private System.Windows.Forms.Button ArmButton;
        private System.Windows.Forms.Button DisarmButton;
        private System.Windows.Forms.TrackBar Pulse1Trackbar;
        private System.Windows.Forms.TrackBar Pulse2Trackbar;
        private System.Windows.Forms.TrackBar Pulse3Trackbar;
        private System.Windows.Forms.Label PulsesLabel;
        private System.Windows.Forms.Label SensorPulsesLabel;
        private System.Windows.Forms.Button Loadbutton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label AnglesLabel;
        private System.Windows.Forms.Label SensorAnglesLabel;
        private XYControl rotControl;
    }
}

