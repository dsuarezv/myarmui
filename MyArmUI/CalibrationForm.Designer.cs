namespace MyArmUI
{
    partial class CalibrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButt = new System.Windows.Forms.Button();
            this.AngleTrackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.CurrentAxisLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AngleTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Enabled = false;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(497, 336);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Finish";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButt
            // 
            this.CancelButt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButt.Location = new System.Drawing.Point(579, 336);
            this.CancelButt.Name = "CancelButt";
            this.CancelButt.Size = new System.Drawing.Size(75, 23);
            this.CancelButt.TabIndex = 2;
            this.CancelButt.Text = "Cancel";
            this.CancelButt.UseVisualStyleBackColor = true;
            // 
            // AngleTrackbar
            // 
            this.AngleTrackbar.LargeChange = 10;
            this.AngleTrackbar.Location = new System.Drawing.Point(6, 189);
            this.AngleTrackbar.Maximum = 2800;
            this.AngleTrackbar.Minimum = 500;
            this.AngleTrackbar.Name = "AngleTrackbar";
            this.AngleTrackbar.Size = new System.Drawing.Size(287, 45);
            this.AngleTrackbar.TabIndex = 4;
            this.AngleTrackbar.TickFrequency = 10;
            this.AngleTrackbar.Value = 1500;
            this.AngleTrackbar.ValueChanged += new System.EventHandler(this.AngleTrackbar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pulse width";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Set arm position as close as possible to the picture on the right. Use the slider" +
    " below to move the axis being calibrated.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current axis:";
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Location = new System.Drawing.Point(299, 197);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(13, 15);
            this.AngleLabel.TabIndex = 8;
            this.AngleLabel.Text = "0";
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Location = new System.Drawing.Point(416, 336);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviousButton.Enabled = false;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.Location = new System.Drawing.Point(335, 336);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 10;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // CurrentAxisLabel
            // 
            this.CurrentAxisLabel.AutoSize = true;
            this.CurrentAxisLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentAxisLabel.Location = new System.Drawing.Point(110, 132);
            this.CurrentAxisLabel.Name = "CurrentAxisLabel";
            this.CurrentAxisLabel.Size = new System.Drawing.Size(102, 21);
            this.CurrentAxisLabel.TabIndex = 11;
            this.CurrentAxisLabel.Text = "Rotation 90º";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "When your are happy with the current setting, click Next to continue.";
            // 
            // EndLabel
            // 
            this.EndLabel.Location = new System.Drawing.Point(13, 247);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(331, 39);
            this.EndLabel.TabIndex = 6;
            this.EndLabel.Text = "Ok, you are done with the calibration. click Finish to set the new parameters.";
            this.EndLabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MyArmUI.Properties.Resources.rot0;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(350, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 257);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // CalibrationForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.CancelButton = this.CancelButt;
            this.ClientSize = new System.Drawing.Size(667, 367);
            this.Controls.Add(this.CurrentAxisLabel);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.AngleLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AngleTrackbar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CancelButt);
            this.Controls.Add(this.OkButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrationForm";
            this.Text = "Calibration";
            ((System.ComponentModel.ISupportInitialize)(this.AngleTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar AngleTrackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AngleLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Label CurrentAxisLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EndLabel;
    }
}