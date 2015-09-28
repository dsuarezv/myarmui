namespace MyArmUI
{
    partial class SpeedControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SpeedTrackbar = new System.Windows.Forms.TrackBar();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.FullSpeedCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed:";
            // 
            // SpeedTrackbar
            // 
            this.SpeedTrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedTrackbar.Location = new System.Drawing.Point(0, 24);
            this.SpeedTrackbar.Maximum = 255;
            this.SpeedTrackbar.Minimum = 1;
            this.SpeedTrackbar.Name = "SpeedTrackbar";
            this.SpeedTrackbar.Size = new System.Drawing.Size(277, 45);
            this.SpeedTrackbar.TabIndex = 1;
            this.SpeedTrackbar.TickFrequency = 5;
            this.SpeedTrackbar.Value = 1;
            this.SpeedTrackbar.ValueChanged += new System.EventHandler(this.SpeedTrackbar_ValueChanged);
            // 
            // ValueLabel
            // 
            this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(276, 27);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(13, 15);
            this.ValueLabel.TabIndex = 2;
            this.ValueLabel.Text = "0";
            // 
            // FullSpeedCheckbox
            // 
            this.FullSpeedCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullSpeedCheckbox.AutoSize = true;
            this.FullSpeedCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullSpeedCheckbox.Location = new System.Drawing.Point(278, 3);
            this.FullSpeedCheckbox.Name = "FullSpeedCheckbox";
            this.FullSpeedCheckbox.Size = new System.Drawing.Size(76, 19);
            this.FullSpeedCheckbox.TabIndex = 3;
            this.FullSpeedCheckbox.Text = "Full speed";
            this.FullSpeedCheckbox.UseVisualStyleBackColor = true;
            this.FullSpeedCheckbox.CheckedChanged += new System.EventHandler(this.FullSpeedCheckbox_CheckedChanged);
            // 
            // SpeedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FullSpeedCheckbox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.SpeedTrackbar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SpeedControl";
            this.Size = new System.Drawing.Size(357, 68);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar SpeedTrackbar;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.CheckBox FullSpeedCheckbox;
    }
}
