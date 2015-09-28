namespace MyArmUI
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.OutputTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OutputTextbox
            // 
            this.OutputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextbox.Location = new System.Drawing.Point(0, 0);
            this.OutputTextbox.Multiline = true;
            this.OutputTextbox.Name = "OutputTextbox";
            this.OutputTextbox.ReadOnly = true;
            this.OutputTextbox.Size = new System.Drawing.Size(666, 229);
            this.OutputTextbox.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 229);
            this.Controls.Add(this.OutputTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.Text = "MyArm out of band data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputTextbox;
    }
}