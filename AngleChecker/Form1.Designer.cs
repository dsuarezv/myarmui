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
            AngleChecker.ArcDescriptor arcDescriptor1 = new AngleChecker.ArcDescriptor();
            AngleChecker.ArcDescriptor arcDescriptor2 = new AngleChecker.ArcDescriptor();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.Pingbutton = new System.Windows.Forms.Button();
            this.ArmButton = new System.Windows.Forms.Button();
            this.DisarmButton = new System.Windows.Forms.Button();
            this.Pulse1Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse2Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse3Trackbar = new System.Windows.Forms.TrackBar();
            this.PulsesLabel = new System.Windows.Forms.Label();
            this.SensorsLabel = new System.Windows.Forms.Label();
            this.Loadbutton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.xyControl1 = new AngleChecker.XYControl();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse1Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse2Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse3Trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(419, 28);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(419, 55);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 5;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // Pingbutton
            // 
            this.Pingbutton.Location = new System.Drawing.Point(419, 84);
            this.Pingbutton.Name = "Pingbutton";
            this.Pingbutton.Size = new System.Drawing.Size(75, 23);
            this.Pingbutton.TabIndex = 6;
            this.Pingbutton.Text = "Read sensors";
            this.Pingbutton.UseVisualStyleBackColor = true;
            this.Pingbutton.Click += new System.EventHandler(this.Pingbutton_Click);
            // 
            // ArmButton
            // 
            this.ArmButton.Location = new System.Drawing.Point(514, 28);
            this.ArmButton.Name = "ArmButton";
            this.ArmButton.Size = new System.Drawing.Size(75, 23);
            this.ArmButton.TabIndex = 10;
            this.ArmButton.Text = "Engage motors";
            this.ArmButton.UseVisualStyleBackColor = true;
            this.ArmButton.Click += new System.EventHandler(this.ArmButton_Click);
            // 
            // DisarmButton
            // 
            this.DisarmButton.Location = new System.Drawing.Point(514, 55);
            this.DisarmButton.Name = "DisarmButton";
            this.DisarmButton.Size = new System.Drawing.Size(75, 23);
            this.DisarmButton.TabIndex = 11;
            this.DisarmButton.Text = "Disengage motors";
            this.DisarmButton.UseVisualStyleBackColor = true;
            this.DisarmButton.Click += new System.EventHandler(this.DisarmButton_Click);
            // 
            // Pulse1Trackbar
            // 
            this.Pulse1Trackbar.Location = new System.Drawing.Point(25, 139);
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
            this.Pulse2Trackbar.Location = new System.Drawing.Point(213, 139);
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
            this.Pulse3Trackbar.Location = new System.Drawing.Point(401, 139);
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
            this.PulsesLabel.Location = new System.Drawing.Point(213, 187);
            this.PulsesLabel.Name = "PulsesLabel";
            this.PulsesLabel.Size = new System.Drawing.Size(182, 15);
            this.PulsesLabel.TabIndex = 9;
            this.PulsesLabel.Text = "Pulses values";
            this.PulsesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SensorsLabel
            // 
            this.SensorsLabel.Location = new System.Drawing.Point(213, 202);
            this.SensorsLabel.Name = "SensorsLabel";
            this.SensorsLabel.Size = new System.Drawing.Size(182, 15);
            this.SensorsLabel.TabIndex = 9;
            this.SensorsLabel.Text = "Sensor values";
            this.SensorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Loadbutton
            // 
            this.Loadbutton.Location = new System.Drawing.Point(402, 178);
            this.Loadbutton.Name = "Loadbutton";
            this.Loadbutton.Size = new System.Drawing.Size(112, 23);
            this.Loadbutton.TabIndex = 14;
            this.Loadbutton.Text = "Load calibration";
            this.Loadbutton.UseVisualStyleBackColor = true;
            this.Loadbutton.Click += new System.EventHandler(this.Loadbutton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(402, 202);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save calibration";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // xyControl1
            // 
            this.xyControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xyControl1.Angle1 = 70D;
            arcDescriptor1.Color = System.Drawing.Color.DarkOrange;
            arcDescriptor1.EndAngle = 180D;
            arcDescriptor1.Length = 20D;
            arcDescriptor1.StartAngle = 0D;
            this.xyControl1.Angle1Limits = arcDescriptor1;
            this.xyControl1.Angle2 = 10D;
            arcDescriptor2.Color = System.Drawing.Color.DarkOrange;
            arcDescriptor2.EndAngle = 180D;
            arcDescriptor2.Length = 20D;
            arcDescriptor2.StartAngle = 0D;
            this.xyControl1.Angle2Limits = arcDescriptor2;
            this.xyControl1.GroundLevel = -100;
            this.xyControl1.Length1 = 148D;
            this.xyControl1.Length2 = 161D;
            this.xyControl1.Location = new System.Drawing.Point(12, 315);
            this.xyControl1.Name = "xyControl1";
            this.xyControl1.Size = new System.Drawing.Size(627, 497);
            this.xyControl1.TabIndex = 0;
            this.xyControl1.Text = "xyControl1";
            this.xyControl1.KinematicSolved += new AngleChecker.KinematicClickDelegate(this.xyControl1_KinematicSolved);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 824);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Loadbutton);
            this.Controls.Add(this.Pulse3Trackbar);
            this.Controls.Add(this.Pulse2Trackbar);
            this.Controls.Add(this.Pulse1Trackbar);
            this.Controls.Add(this.DisarmButton);
            this.Controls.Add(this.ArmButton);
            this.Controls.Add(this.SensorsLabel);
            this.Controls.Add(this.PulsesLabel);
            this.Controls.Add(this.Pingbutton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.xyControl1);
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

        private XYControl xyControl1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button Pingbutton;
        private System.Windows.Forms.Button ArmButton;
        private System.Windows.Forms.Button DisarmButton;
        private System.Windows.Forms.TrackBar Pulse1Trackbar;
        private System.Windows.Forms.TrackBar Pulse2Trackbar;
        private System.Windows.Forms.TrackBar Pulse3Trackbar;
        private System.Windows.Forms.Label PulsesLabel;
        private System.Windows.Forms.Label SensorsLabel;
        private System.Windows.Forms.Button Loadbutton;
        private System.Windows.Forms.Button SaveButton;
    }
}

