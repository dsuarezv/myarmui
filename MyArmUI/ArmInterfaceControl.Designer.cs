namespace MyArmUI
{
    partial class ArmInterfaceControl
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
            this.DisengageButton = new System.Windows.Forms.Button();
            this.EngageButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondaryActionsPanel = new System.Windows.Forms.Panel();
            this.CalibrateButton = new System.Windows.Forms.Button();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.PortsCombo = new System.Windows.Forms.ComboBox();
            this.RefreshPortsButton = new System.Windows.Forms.Button();
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.VersionButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.SecondaryActionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisengageButton
            // 
            this.DisengageButton.BackColor = System.Drawing.Color.Gold;
            this.DisengageButton.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.DisengageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisengageButton.Location = new System.Drawing.Point(76, 5);
            this.DisengageButton.Name = "DisengageButton";
            this.DisengageButton.Size = new System.Drawing.Size(72, 25);
            this.DisengageButton.TabIndex = 12;
            this.DisengageButton.Text = "Disengage";
            this.DisengageButton.UseVisualStyleBackColor = false;
            this.DisengageButton.Click += new System.EventHandler(this.DisengageButton_Click);
            // 
            // EngageButton
            // 
            this.EngageButton.BackColor = System.Drawing.Color.GreenYellow;
            this.EngageButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.EngageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngageButton.Location = new System.Drawing.Point(6, 5);
            this.EngageButton.Name = "EngageButton";
            this.EngageButton.Size = new System.Drawing.Size(65, 25);
            this.EngageButton.TabIndex = 11;
            this.EngageButton.Text = "Engage";
            this.EngageButton.UseVisualStyleBackColor = false;
            this.EngageButton.Click += new System.EventHandler(this.EngageButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisconnectButton.Location = new System.Drawing.Point(349, 5);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(77, 23);
            this.DisconnectButton.TabIndex = 10;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(276, 5);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(67, 23);
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "COM port";
            // 
            // SecondaryActionsPanel
            // 
            this.SecondaryActionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondaryActionsPanel.Controls.Add(this.LogButton);
            this.SecondaryActionsPanel.Controls.Add(this.VersionButton);
            this.SecondaryActionsPanel.Controls.Add(this.CalibrateButton);
            this.SecondaryActionsPanel.Controls.Add(this.SaveConfigButton);
            this.SecondaryActionsPanel.Controls.Add(this.LoadConfigButton);
            this.SecondaryActionsPanel.Controls.Add(this.EngageButton);
            this.SecondaryActionsPanel.Controls.Add(this.DisengageButton);
            this.SecondaryActionsPanel.Location = new System.Drawing.Point(0, 32);
            this.SecondaryActionsPanel.Name = "SecondaryActionsPanel";
            this.SecondaryActionsPanel.Size = new System.Drawing.Size(431, 36);
            this.SecondaryActionsPanel.TabIndex = 14;
            this.SecondaryActionsPanel.Visible = false;
            // 
            // CalibrateButton
            // 
            this.CalibrateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalibrateButton.Location = new System.Drawing.Point(291, 5);
            this.CalibrateButton.Name = "CalibrateButton";
            this.CalibrateButton.Size = new System.Drawing.Size(65, 25);
            this.CalibrateButton.TabIndex = 14;
            this.CalibrateButton.Text = "Calibrate";
            this.CalibrateButton.UseVisualStyleBackColor = true;
            this.CalibrateButton.Click += new System.EventHandler(this.CalibrateButton_Click);
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadConfigButton.Location = new System.Drawing.Point(153, 5);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(64, 25);
            this.LoadConfigButton.TabIndex = 13;
            this.LoadConfigButton.Text = "Load cfg";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // PortsCombo
            // 
            this.PortsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PortsCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PortsCombo.FormattingEnabled = true;
            this.PortsCombo.Location = new System.Drawing.Point(70, 5);
            this.PortsCombo.Name = "PortsCombo";
            this.PortsCombo.Size = new System.Drawing.Size(170, 23);
            this.PortsCombo.TabIndex = 15;
            // 
            // RefreshPortsButton
            // 
            this.RefreshPortsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshPortsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshPortsButton.Location = new System.Drawing.Point(247, 5);
            this.RefreshPortsButton.Name = "RefreshPortsButton";
            this.RefreshPortsButton.Size = new System.Drawing.Size(24, 23);
            this.RefreshPortsButton.TabIndex = 16;
            this.RefreshPortsButton.Text = "R";
            this.RefreshPortsButton.UseVisualStyleBackColor = true;
            this.RefreshPortsButton.Click += new System.EventHandler(this.RefreshPortsButton_Click);
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveConfigButton.Location = new System.Drawing.Point(222, 5);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(64, 25);
            this.SaveConfigButton.TabIndex = 13;
            this.SaveConfigButton.Text = "Save cfg";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // VersionButton
            // 
            this.VersionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VersionButton.Location = new System.Drawing.Point(361, 5);
            this.VersionButton.Name = "VersionButton";
            this.VersionButton.Size = new System.Drawing.Size(27, 25);
            this.VersionButton.TabIndex = 15;
            this.VersionButton.Text = "V";
            this.VersionButton.UseVisualStyleBackColor = true;
            this.VersionButton.Click += new System.EventHandler(this.VersionButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Location = new System.Drawing.Point(394, 5);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(31, 25);
            this.LogButton.TabIndex = 16;
            this.LogButton.Text = "Lg";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // ArmInterfaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RefreshPortsButton);
            this.Controls.Add(this.PortsCombo);
            this.Controls.Add(this.SecondaryActionsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ArmInterfaceControl";
            this.Size = new System.Drawing.Size(431, 68);
            this.Load += new System.EventHandler(this.ArmInterfaceControl_Load);
            this.SecondaryActionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisengageButton;
        private System.Windows.Forms.Button EngageButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SecondaryActionsPanel;
        private System.Windows.Forms.ComboBox PortsCombo;
        private System.Windows.Forms.Button RefreshPortsButton;
        private System.Windows.Forms.Button LoadConfigButton;
        private System.Windows.Forms.Button CalibrateButton;
        private System.Windows.Forms.Button SaveConfigButton;
        private System.Windows.Forms.Button VersionButton;
        private System.Windows.Forms.Button LogButton;
    }
}
