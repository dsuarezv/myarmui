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
            this.A1Track = new System.Windows.Forms.TrackBar();
            this.A2Track = new System.Windows.Forms.TrackBar();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.Pingbutton = new System.Windows.Forms.Button();
            this.Offset2Trackbar = new System.Windows.Forms.TrackBar();
            this.Offset1Trackbar = new System.Windows.Forms.TrackBar();
            this.OffsetsLabel = new System.Windows.Forms.Label();
            this.ArmButton = new System.Windows.Forms.Button();
            this.DisarmButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AnglesLabel = new System.Windows.Forms.Label();
            this.Pulse1Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse2Trackbar = new System.Windows.Forms.TrackBar();
            this.Pulse3Trackbar = new System.Windows.Forms.TrackBar();
            this.PulsesLabel = new System.Windows.Forms.Label();
            this.SensorsLabel = new System.Windows.Forms.Label();
            this.Loadbutton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.xyControl1 = new AngleChecker.XYControl();
            ((System.ComponentModel.ISupportInitialize)(this.A1Track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A2Track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset2Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset1Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse1Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse2Trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse3Trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // A1Track
            // 
            this.A1Track.Location = new System.Drawing.Point(12, 32);
            this.A1Track.Maximum = 180;
            this.A1Track.Minimum = -180;
            this.A1Track.Name = "A1Track";
            this.A1Track.Size = new System.Drawing.Size(158, 45);
            this.A1Track.TabIndex = 1;
            this.A1Track.Scroll += new System.EventHandler(this.A1Track_Scroll);
            this.A1Track.ValueChanged += new System.EventHandler(this.A1Track_Scroll);
            // 
            // A2Track
            // 
            this.A2Track.Location = new System.Drawing.Point(12, 71);
            this.A2Track.Maximum = 180;
            this.A2Track.Minimum = -180;
            this.A2Track.Name = "A2Track";
            this.A2Track.Size = new System.Drawing.Size(158, 45);
            this.A2Track.TabIndex = 2;
            this.A2Track.Scroll += new System.EventHandler(this.A2Track_Scroll);
            this.A2Track.ValueChanged += new System.EventHandler(this.A2Track_Scroll);
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
            this.Pingbutton.Text = "Ping";
            this.Pingbutton.UseVisualStyleBackColor = true;
            this.Pingbutton.Click += new System.EventHandler(this.Pingbutton_Click);
            // 
            // Offset2Trackbar
            // 
            this.Offset2Trackbar.Location = new System.Drawing.Point(176, 71);
            this.Offset2Trackbar.Maximum = 100;
            this.Offset2Trackbar.Minimum = -100;
            this.Offset2Trackbar.Name = "Offset2Trackbar";
            this.Offset2Trackbar.Size = new System.Drawing.Size(234, 45);
            this.Offset2Trackbar.TabIndex = 8;
            this.Offset2Trackbar.TickFrequency = 10;
            this.Offset2Trackbar.Value = -60;
            this.Offset2Trackbar.ValueChanged += new System.EventHandler(this.Offset2Trackbar_ValueChanged);
            // 
            // Offset1Trackbar
            // 
            this.Offset1Trackbar.Location = new System.Drawing.Point(176, 32);
            this.Offset1Trackbar.Maximum = 100;
            this.Offset1Trackbar.Minimum = -100;
            this.Offset1Trackbar.Name = "Offset1Trackbar";
            this.Offset1Trackbar.Size = new System.Drawing.Size(234, 45);
            this.Offset1Trackbar.TabIndex = 7;
            this.Offset1Trackbar.TickFrequency = 10;
            this.Offset1Trackbar.Value = -30;
            this.Offset1Trackbar.ValueChanged += new System.EventHandler(this.Offset1Trackbar_ValueChanged);
            // 
            // OffsetsLabel
            // 
            this.OffsetsLabel.AutoSize = true;
            this.OffsetsLabel.Location = new System.Drawing.Point(185, 109);
            this.OffsetsLabel.Name = "OffsetsLabel";
            this.OffsetsLabel.Size = new System.Drawing.Size(69, 13);
            this.OffsetsLabel.TabIndex = 9;
            this.OffsetsLabel.Text = "Offset values";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Angles";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Offsets";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // AnglesLabel
            // 
            this.AnglesLabel.AutoSize = true;
            this.AnglesLabel.Location = new System.Drawing.Point(22, 109);
            this.AnglesLabel.Name = "AnglesLabel";
            this.AnglesLabel.Size = new System.Drawing.Size(73, 13);
            this.AnglesLabel.TabIndex = 9;
            this.AnglesLabel.Text = "Angles values";
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DisarmButton);
            this.Controls.Add(this.ArmButton);
            this.Controls.Add(this.AnglesLabel);
            this.Controls.Add(this.SensorsLabel);
            this.Controls.Add(this.PulsesLabel);
            this.Controls.Add(this.OffsetsLabel);
            this.Controls.Add(this.Offset2Trackbar);
            this.Controls.Add(this.Offset1Trackbar);
            this.Controls.Add(this.Pingbutton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.A2Track);
            this.Controls.Add(this.A1Track);
            this.Controls.Add(this.xyControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.A1Track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A2Track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset2Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset1Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse1Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse2Trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pulse3Trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XYControl xyControl1;
        private System.Windows.Forms.TrackBar A1Track;
        private System.Windows.Forms.TrackBar A2Track;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button Pingbutton;
        private System.Windows.Forms.TrackBar Offset2Trackbar;
        private System.Windows.Forms.TrackBar Offset1Trackbar;
        private System.Windows.Forms.Label OffsetsLabel;
        private System.Windows.Forms.Button ArmButton;
        private System.Windows.Forms.Button DisarmButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AnglesLabel;
        private System.Windows.Forms.TrackBar Pulse1Trackbar;
        private System.Windows.Forms.TrackBar Pulse2Trackbar;
        private System.Windows.Forms.TrackBar Pulse3Trackbar;
        private System.Windows.Forms.Label PulsesLabel;
        private System.Windows.Forms.Label SensorsLabel;
        private System.Windows.Forms.Button Loadbutton;
        private System.Windows.Forms.Button SaveButton;
    }
}

