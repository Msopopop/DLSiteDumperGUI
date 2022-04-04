
namespace DLSiteDumperCS
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
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rip = new System.Windows.Forms.Button();
            this.autoDetectPidButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pidTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startPageInput = new System.Windows.Forms.NumericUpDown();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.effectivePathTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imageExtSelect = new System.Windows.Forms.ComboBox();
            this.testButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.betweenPageDelay = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openHtmlOption = new System.Windows.Forms.CheckBox();
            this.genHtmlButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.readStyleSelect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pageZoomPercent = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.startPageInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betweenPageDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageZoomPercent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rip
            // 
            this.rip.Location = new System.Drawing.Point(16, 344);
            this.rip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rip.Name = "rip";
            this.rip.Size = new System.Drawing.Size(182, 38);
            this.rip.TabIndex = 0;
            this.rip.Text = "Batch dump from current to last page";
            this.rip.UseVisualStyleBackColor = true;
            this.rip.Click += new System.EventHandler(this.OnRipClick);
            // 
            // autoDetectPidButton
            // 
            this.autoDetectPidButton.Location = new System.Drawing.Point(243, 18);
            this.autoDetectPidButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoDetectPidButton.Name = "autoDetectPidButton";
            this.autoDetectPidButton.Size = new System.Drawing.Size(75, 22);
            this.autoDetectPidButton.TabIndex = 1;
            this.autoDetectPidButton.Text = "Auto detect";
            this.autoDetectPidButton.UseVisualStyleBackColor = true;
            this.autoDetectPidButton.Click += new System.EventHandler(this.autoDetectPidButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "DLSite Viewer process id (PID)";
            // 
            // pidTextBox
            // 
            this.pidTextBox.Location = new System.Drawing.Point(82, 20);
            this.pidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pidTextBox.Name = "pidTextBox";
            this.pidTextBox.Size = new System.Drawing.Size(155, 21);
            this.pidTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Not satisfied? Mod it yourself, fork this bad boy.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "Have problem?\r\nIf you have too new viewer version.\r\nYou might need an older versi" +
    "on of DLSite viewer. \r\nTested with 1.0.34 (1.0.4.2) Someone left a link in forum" +
    " below:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(449, 48);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Write first file as page No.";
            // 
            // startPageInput
            // 
            this.startPageInput.Location = new System.Drawing.Point(150, 104);
            this.startPageInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startPageInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.startPageInput.Name = "startPageInput";
            this.startPageInput.Size = new System.Drawing.Size(74, 21);
            this.startPageInput.TabIndex = 9;
            this.startPageInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startPageInput.ValueChanged += new System.EventHandler(this.startPageInput_ValueChanged);
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(16, 200);
            this.savePathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(334, 21);
            this.savePathTextBox.TabIndex = 3;
            this.savePathTextBox.TextChanged += new System.EventHandler(this.savePathTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Image save location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(275, 174);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 22);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Original author project: Thanks!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Preview effective save location:";
            // 
            // effectivePathTextBox
            // 
            this.effectivePathTextBox.Location = new System.Drawing.Point(16, 236);
            this.effectivePathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.effectivePathTextBox.Multiline = true;
            this.effectivePathTextBox.Name = "effectivePathTextBox";
            this.effectivePathTextBox.ReadOnly = true;
            this.effectivePathTextBox.Size = new System.Drawing.Size(334, 42);
            this.effectivePathTextBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Save as image";
            // 
            // imageExtSelect
            // 
            this.imageExtSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageExtSelect.FormattingEnabled = true;
            this.imageExtSelect.Items.AddRange(new object[] {
            "jpg 80%",
            "jpg 50%",
            "png"});
            this.imageExtSelect.Location = new System.Drawing.Point(150, 128);
            this.imageExtSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageExtSelect.Name = "imageExtSelect";
            this.imageExtSelect.Size = new System.Drawing.Size(74, 20);
            this.imageExtSelect.TabIndex = 10;
            this.imageExtSelect.SelectedIndexChanged += new System.EventHandler(this.imageExtSelect_SelectedIndexChanged);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(204, 344);
            this.testButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(146, 38);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test dump 1 current page in viewer";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.OnTestButton);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(258, 50);
            this.label10.TabIndex = 2;
            this.label10.Text = "Wait N milisecond before capture.\r\nViewer needs some time between page to redraw," +
    " \r\nif captured too fast you will get garbaged image.\r\nSafe is 1000ms. Can try lo" +
    "wer this to 300ms with fast PC.";
            // 
            // betweenPageDelay
            // 
            this.betweenPageDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.betweenPageDelay.Location = new System.Drawing.Point(277, 288);
            this.betweenPageDelay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.betweenPageDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.betweenPageDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.betweenPageDelay.Name = "betweenPageDelay";
            this.betweenPageDelay.Size = new System.Drawing.Size(74, 21);
            this.betweenPageDelay.TabIndex = 9;
            this.betweenPageDelay.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openHtmlOption);
            this.groupBox1.Controls.Add(this.genHtmlButton);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.readStyleSelect);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pageZoomPercent);
            this.groupBox1.Location = new System.Drawing.Point(407, 182);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(374, 306);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HTML Generator";
            // 
            // openHtmlOption
            // 
            this.openHtmlOption.AutoSize = true;
            this.openHtmlOption.Checked = true;
            this.openHtmlOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openHtmlOption.Location = new System.Drawing.Point(22, 222);
            this.openHtmlOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openHtmlOption.Name = "openHtmlOption";
            this.openHtmlOption.Size = new System.Drawing.Size(168, 16);
            this.openHtmlOption.TabIndex = 12;
            this.openHtmlOption.Text = "Open HTML after generate";
            this.openHtmlOption.UseVisualStyleBackColor = true;
            // 
            // genHtmlButton
            // 
            this.genHtmlButton.Location = new System.Drawing.Point(22, 246);
            this.genHtmlButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genHtmlButton.Name = "genHtmlButton";
            this.genHtmlButton.Size = new System.Drawing.Size(337, 40);
            this.genHtmlButton.TabIndex = 11;
            this.genHtmlButton.Text = "Generate HTML";
            this.genHtmlButton.UseVisualStyleBackColor = true;
            this.genHtmlButton.Click += new System.EventHandler(this.genHtmlButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(431, 48);
            this.label13.TabIndex = 10;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "Image zoom vs page width (%)";
            // 
            // readStyleSelect
            // 
            this.readStyleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readStyleSelect.FormattingEnabled = true;
            this.readStyleSelect.Items.AddRange(new object[] {
            "Right to Left (Manga)",
            "Left to Right (Comic)"});
            this.readStyleSelect.Location = new System.Drawing.Point(21, 188);
            this.readStyleSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.readStyleSelect.Name = "readStyleSelect";
            this.readStyleSelect.Size = new System.Drawing.Size(337, 20);
            this.readStyleSelect.TabIndex = 10;
            this.readStyleSelect.SelectedIndexChanged += new System.EventHandler(this.readStyleSelect_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(443, 72);
            this.label11.TabIndex = 0;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // pageZoomPercent
            // 
            this.pageZoomPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pageZoomPercent.Location = new System.Drawing.Point(174, 103);
            this.pageZoomPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pageZoomPercent.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pageZoomPercent.Name = "pageZoomPercent";
            this.pageZoomPercent.Size = new System.Drawing.Size(74, 21);
            this.pageZoomPercent.TabIndex = 9;
            this.pageZoomPercent.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(15, 38);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(269, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/wappenull/DLSiteDumperGUI";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(13, 442);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(349, 30);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://forums.e-hentai.org/index.php?s=&showtopic=92167&view=findpost&p=5878056";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(15, 71);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(227, 12);
            this.linkLabel3.TabIndex = 12;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://github.com/typcn/DLSiteDumper";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.linkLabel4);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Location = new System.Drawing.Point(407, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(374, 163);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credit and acknowledgement";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(15, 106);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(239, 12);
            this.linkLabel4.TabIndex = 12;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "https://github.com/fuzetsu/manga-loader";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenUrlFromLinkLabel);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(383, 24);
            this.label14.TabIndex = 6;
            this.label14.Text = "This GUI is designed by programmer who has no sense with UI/UX.\r\nPlease dont hate" +
    " me.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(197, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "HTML reader template stolen from";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.imageExtSelect);
            this.groupBox3.Controls.Add(this.betweenPageDelay);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.startPageInput);
            this.groupBox3.Controls.Add(this.effectivePathTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.savePathTextBox);
            this.groupBox3.Controls.Add(this.pidTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.testButton);
            this.groupBox3.Controls.Add(this.autoDetectPidButton);
            this.groupBox3.Controls.Add(this.rip);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(16, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(374, 474);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dumper";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(311, 24);
            this.label17.TabIndex = 14;
            this.label17.Text = "jpg 50% quality makes 2x smaller file for B&&W page.\r\n10x smaller for color page " +
    "vs PNG!";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 13;
            this.label16.Text = "Viewer PID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DLSite Viewer Dumper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startPageInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betweenPageDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageZoomPercent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rip;
        private System.Windows.Forms.Button autoDetectPidButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pidTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown startPageInput;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox effectivePathTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox imageExtSelect;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown betweenPageDelay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox readStyleSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown pageZoomPercent;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox openHtmlOption;
        private System.Windows.Forms.Button genHtmlButton;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

