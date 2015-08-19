namespace Verda
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.updateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.camBruteTimer = new System.Windows.Forms.Timer(this.components);
            this.NmapLocationDialog = new System.Windows.Forms.OpenFileDialog();
            this.reportTimer = new System.Windows.Forms.Timer(this.components);
            this.busyPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAboutNmap = new System.Windows.Forms.Label();
            this.nmapPath = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.camTargetsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customArgTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.presetRangeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.presetComboBox = new System.Windows.Forms.ComboBox();
            this.debugTab = new System.Windows.Forms.TabPage();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.resultsBox = new System.Windows.Forms.RichTextBox();
            this.smartTab = new System.Windows.Forms.TabPage();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.statsLabel = new System.Windows.Forms.Label();
            this.outputTabsControl = new System.Windows.Forms.TabControl();
            this.cancelScanButton = new System.Windows.Forms.Button();
            this.debugBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.busyPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.optionsTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.debugTab.SuspendLayout();
            this.smartTab.SuspendLayout();
            this.outputTabsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.updateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateLabel.Location = new System.Drawing.Point(906, 0);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(163, 20);
            this.updateLabel.TabIndex = 26;
            this.updateLabel.Text = "checkin\' 4 updates...";
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Targets in check queue:";
            // 
            // camBruteTimer
            // 
            this.camBruteTimer.Enabled = true;
            this.camBruteTimer.Interval = 1000;
            this.camBruteTimer.Tick += new System.EventHandler(this.camBruteTimer_Tick);
            // 
            // NmapLocationDialog
            // 
            this.NmapLocationDialog.FileName = "nmap.exe";
            this.NmapLocationDialog.Filter = "nmap.exe|nmap.exe";
            this.NmapLocationDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.NmapLocationDialog_FileOk);
            // 
            // reportTimer
            // 
            this.reportTimer.Interval = 10000;
            this.reportTimer.Tick += new System.EventHandler(this.reportTimer_Tick);
            // 
            // busyPic
            // 
            this.busyPic.BackColor = System.Drawing.Color.Transparent;
            this.busyPic.Location = new System.Drawing.Point(126, 14);
            this.busyPic.Name = "busyPic";
            this.busyPic.Size = new System.Drawing.Size(30, 30);
            this.busyPic.TabIndex = 20;
            this.busyPic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Verda.Properties.Resources.verda_pic;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 69);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // labelAboutNmap
            // 
            this.labelAboutNmap.Location = new System.Drawing.Point(9, 32);
            this.labelAboutNmap.Name = "labelAboutNmap";
            this.labelAboutNmap.Size = new System.Drawing.Size(298, 43);
            this.labelAboutNmap.TabIndex = 1;
            this.labelAboutNmap.Text = "...";
            // 
            // nmapPath
            // 
            this.nmapPath.Location = new System.Drawing.Point(73, 6);
            this.nmapPath.Name = "nmapPath";
            this.nmapPath.Size = new System.Drawing.Size(164, 23);
            this.nmapPath.TabIndex = 0;
            this.nmapPath.Text = "Set path to NMAP.EXE";
            this.nmapPath.UseVisualStyleBackColor = true;
            this.nmapPath.Click += new System.EventHandler(this.nmapPath_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelAboutNmap);
            this.tabPage1.Controls.Add(this.nmapPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(310, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // camTargetsLabel
            // 
            this.camTargetsLabel.AutoSize = true;
            this.camTargetsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.camTargetsLabel.Location = new System.Drawing.Point(693, 9);
            this.camTargetsLabel.Name = "camTargetsLabel";
            this.camTargetsLabel.Size = new System.Drawing.Size(21, 24);
            this.camTargetsLabel.TabIndex = 25;
            this.camTargetsLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Customs args:";
            // 
            // customArgTextBox
            // 
            this.customArgTextBox.Location = new System.Drawing.Point(27, 355);
            this.customArgTextBox.Name = "customArgTextBox";
            this.customArgTextBox.Size = new System.Drawing.Size(265, 20);
            this.customArgTextBox.TabIndex = 4;
            this.customArgTextBox.TextChanged += new System.EventHandler(this.customArgTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Target:";
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.tabPage2);
            this.optionsTabControl.Controls.Add(this.tabPage1);
            this.optionsTabControl.Location = new System.Drawing.Point(742, 38);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(318, 455);
            this.optionsTabControl.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.customArgTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.presetRangeBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.presetComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(310, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scan";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // presetRangeBox
            // 
            this.presetRangeBox.Location = new System.Drawing.Point(49, 408);
            this.presetRangeBox.Name = "presetRangeBox";
            this.presetRangeBox.Size = new System.Drawing.Size(259, 20);
            this.presetRangeBox.TabIndex = 2;
            this.presetRangeBox.TextChanged += new System.EventHandler(this.presetRangeBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Preset:";
            // 
            // presetComboBox
            // 
            this.presetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetComboBox.FormattingEnabled = true;
            this.presetComboBox.Items.AddRange(new object[] {
            "http-заголовки",
            "тест",
            "тест2"});
            this.presetComboBox.Location = new System.Drawing.Point(49, 381);
            this.presetComboBox.Name = "presetComboBox";
            this.presetComboBox.Size = new System.Drawing.Size(259, 21);
            this.presetComboBox.TabIndex = 0;
            this.presetComboBox.SelectedIndexChanged += new System.EventHandler(this.presetComboBox_SelectedIndexChanged);
            // 
            // debugTab
            // 
            this.debugTab.Controls.Add(this.outputBox);
            this.debugTab.Location = new System.Drawing.Point(4, 22);
            this.debugTab.Name = "debugTab";
            this.debugTab.Padding = new System.Windows.Forms.Padding(3);
            this.debugTab.Size = new System.Drawing.Size(503, 481);
            this.debugTab.TabIndex = 0;
            this.debugTab.Text = "NMAP";
            this.debugTab.UseVisualStyleBackColor = true;
            // 
            // outputBox
            // 
            this.outputBox.DetectUrls = false;
            this.outputBox.Location = new System.Drawing.Point(3, 3);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(497, 478);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // resultsBox
            // 
            this.resultsBox.Location = new System.Drawing.Point(1, 1);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.ReadOnly = true;
            this.resultsBox.Size = new System.Drawing.Size(500, 478);
            this.resultsBox.TabIndex = 9;
            this.resultsBox.Text = "";
            this.resultsBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.resultsBox_LinkClicked);
            // 
            // smartTab
            // 
            this.smartTab.Controls.Add(this.resultsBox);
            this.smartTab.Location = new System.Drawing.Point(4, 22);
            this.smartTab.Name = "smartTab";
            this.smartTab.Padding = new System.Windows.Forms.Padding(3);
            this.smartTab.Size = new System.Drawing.Size(503, 481);
            this.smartTab.TabIndex = 1;
            this.smartTab.Text = "Verda";
            this.smartTab.UseVisualStyleBackColor = true;
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.inputBox.Location = new System.Drawing.Point(742, 499);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ReadOnly = true;
            this.inputBox.Size = new System.Drawing.Size(318, 68);
            this.inputBox.TabIndex = 15;
            // 
            // statsLabel
            // 
            this.statsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statsLabel.Location = new System.Drawing.Point(155, 9);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(365, 57);
            this.statsLabel.TabIndex = 17;
            this.statsLabel.Text = "Waiting for launch...";
            // 
            // outputTabsControl
            // 
            this.outputTabsControl.Controls.Add(this.smartTab);
            this.outputTabsControl.Controls.Add(this.debugTab);
            this.outputTabsControl.Location = new System.Drawing.Point(9, 60);
            this.outputTabsControl.Name = "outputTabsControl";
            this.outputTabsControl.SelectedIndex = 0;
            this.outputTabsControl.Size = new System.Drawing.Size(511, 507);
            this.outputTabsControl.TabIndex = 21;
            // 
            // cancelScanButton
            // 
            this.cancelScanButton.Enabled = false;
            this.cancelScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelScanButton.Location = new System.Drawing.Point(634, 499);
            this.cancelScanButton.Name = "cancelScanButton";
            this.cancelScanButton.Size = new System.Drawing.Size(102, 68);
            this.cancelScanButton.TabIndex = 16;
            this.cancelScanButton.Text = "Stop";
            this.cancelScanButton.UseVisualStyleBackColor = true;
            this.cancelScanButton.Click += new System.EventHandler(this.cancelScanButton_Click);
            // 
            // debugBox
            // 
            this.debugBox.DetectUrls = false;
            this.debugBox.Location = new System.Drawing.Point(526, 38);
            this.debugBox.Name = "debugBox";
            this.debugBox.ReadOnly = true;
            this.debugBox.Size = new System.Drawing.Size(210, 455);
            this.debugBox.TabIndex = 19;
            this.debugBox.Text = "";
            this.debugBox.TextChanged += new System.EventHandler(this.debugBox_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.Location = new System.Drawing.Point(526, 499);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(102, 68);
            this.sendButton.TabIndex = 18;
            this.sendButton.Text = "Launch";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 575);
            this.Controls.Add(this.busyPic);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.camTargetsLabel);
            this.Controls.Add(this.optionsTabControl);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.outputTabsControl);
            this.Controls.Add(this.cancelScanButton);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Verda FFFFFFFF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.busyPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.optionsTabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.debugTab.ResumeLayout(false);
            this.smartTab.ResumeLayout(false);
            this.outputTabsControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer camBruteTimer;
        private System.Windows.Forms.OpenFileDialog NmapLocationDialog;
        private System.Windows.Forms.Timer reportTimer;
        private System.Windows.Forms.PictureBox busyPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelAboutNmap;
        private System.Windows.Forms.Button nmapPath;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label camTargetsLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox customArgTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox presetRangeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox presetComboBox;
        private System.Windows.Forms.TabPage debugTab;
        public System.Windows.Forms.RichTextBox outputBox;
        public System.Windows.Forms.RichTextBox resultsBox;
        private System.Windows.Forms.TabPage smartTab;
        private System.Windows.Forms.TextBox inputBox;
        public System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.TabControl outputTabsControl;
        private System.Windows.Forms.Button cancelScanButton;
        private System.Windows.Forms.RichTextBox debugBox;
        private System.Windows.Forms.Button sendButton;
    }
}

