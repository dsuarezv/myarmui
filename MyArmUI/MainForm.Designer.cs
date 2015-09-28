namespace MyArmUI
{
    partial class MainForm
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
            MyArmClient.Point3 point31 = new MyArmClient.Point3();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.pathRecorderControl1 = new MyArmUI.PathRecorderControl();
            this.label1 = new System.Windows.Forms.Label();
            this.armIface = new MyArmUI.ArmInterfaceControl();
            this.speedControl1 = new MyArmUI.SpeedControl();
            this.A1Label = new System.Windows.Forms.Label();
            this.mouse3dController1 = new MyArmUI.Mouse3dController();
            this.GripperAngleTrackbar = new System.Windows.Forms.TrackBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.View3d = new Engine.WinFormsControl.EngineControl();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GripperAngleTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1266, 39);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Visible = false;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.pathRecorderControl1);
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Controls.Add(this.armIface);
            this.LeftPanel.Controls.Add(this.speedControl1);
            this.LeftPanel.Controls.Add(this.A1Label);
            this.LeftPanel.Controls.Add(this.mouse3dController1);
            this.LeftPanel.Controls.Add(this.GripperAngleTrackbar);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 39);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(485, 688);
            this.LeftPanel.TabIndex = 1;
            // 
            // pathRecorderControl1
            // 
            this.pathRecorderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathRecorderControl1.Arm = null;
            this.pathRecorderControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.pathRecorderControl1.CoordinatesProvider = null;
            this.pathRecorderControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathRecorderControl1.Location = new System.Drawing.Point(0, 436);
            this.pathRecorderControl1.MinimumSize = new System.Drawing.Size(300, 226);
            this.pathRecorderControl1.Name = "pathRecorderControl1";
            this.pathRecorderControl1.Size = new System.Drawing.Size(484, 252);
            this.pathRecorderControl1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Gripper";
            // 
            // armIface
            // 
            this.armIface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.armIface.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armIface.Location = new System.Drawing.Point(0, 0);
            this.armIface.Name = "armIface";
            this.armIface.Size = new System.Drawing.Size(484, 70);
            this.armIface.TabIndex = 14;
            // 
            // speedControl1
            // 
            this.speedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedControl1.Arm = null;
            this.speedControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedControl1.Location = new System.Drawing.Point(0, 371);
            this.speedControl1.Name = "speedControl1";
            this.speedControl1.Size = new System.Drawing.Size(479, 59);
            this.speedControl1.TabIndex = 13;
            // 
            // A1Label
            // 
            this.A1Label.AutoSize = true;
            this.A1Label.Location = new System.Drawing.Point(323, 104);
            this.A1Label.Name = "A1Label";
            this.A1Label.Size = new System.Drawing.Size(17, 15);
            this.A1Label.TabIndex = 10;
            this.A1Label.Text = "--";
            // 
            // mouse3dController1
            // 
            this.mouse3dController1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mouse3dController1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouse3dController1.Location = new System.Drawing.Point(4, 138);
            this.mouse3dController1.Name = "mouse3dController1";
            this.mouse3dController1.Position = point31;
            this.mouse3dController1.Size = new System.Drawing.Size(475, 250);
            this.mouse3dController1.TabIndex = 6;
            this.mouse3dController1.Text = "mouse3dController1";
            this.mouse3dController1.PositionChanged += new System.Action<object, MyArmClient.Point3>(this.mouse3dController1_PositionChanged);
            // 
            // GripperAngleTrackbar
            // 
            this.GripperAngleTrackbar.LargeChange = 45;
            this.GripperAngleTrackbar.Location = new System.Drawing.Point(136, 101);
            this.GripperAngleTrackbar.Maximum = 90;
            this.GripperAngleTrackbar.Minimum = -90;
            this.GripperAngleTrackbar.Name = "GripperAngleTrackbar";
            this.GripperAngleTrackbar.Size = new System.Drawing.Size(189, 45);
            this.GripperAngleTrackbar.TabIndex = 0;
            this.GripperAngleTrackbar.TickFrequency = 10;
            this.GripperAngleTrackbar.ValueChanged += new System.EventHandler(this.GripperAngleTrackbar_ValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.splitter1.Location = new System.Drawing.Point(485, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 688);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // View3d
            // 
            this.View3d.DepotPath = null;
            this.View3d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View3d.DrawGrid = true;
            this.View3d.Location = new System.Drawing.Point(489, 39);
            this.View3d.Name = "View3d";
            this.View3d.Size = new System.Drawing.Size(777, 688);
            this.View3d.TabIndex = 3;
            this.View3d.SceneLoad += new System.Action<object, System.EventArgs>(this.View3d_SceneLoad);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.ClientSize = new System.Drawing.Size(1266, 727);
            this.Controls.Add(this.View3d);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MyArm";
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GripperAngleTrackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Splitter splitter1;
        private Engine.WinFormsControl.EngineControl View3d;
        private System.Windows.Forms.TrackBar GripperAngleTrackbar;
        private Mouse3dController mouse3dController1;
        private System.Windows.Forms.Label A1Label;
        private SpeedControl speedControl1;
        private ArmInterfaceControl armIface;
        private System.Windows.Forms.Label label1;
        private PathRecorderControl pathRecorderControl1;
    }
}

