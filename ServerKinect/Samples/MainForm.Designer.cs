namespace ServerKinect.Samples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.labelFramework = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxKinect = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxKinectStatus = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxSkeleton = new System.Windows.Forms.CheckBox();
            this.checkBoxRGBImage = new System.Windows.Forms.CheckBox();
            this.checkBoxHand = new System.Windows.Forms.CheckBox();
            this.checkBoxDepthImage = new System.Windows.Forms.CheckBox();
            this.labelSkeletonDetected = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelClientConnected = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPPS = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxGesture = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxLOG = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxConnection = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.videoControl = new VideoControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKinect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Framework Detected";
            // 
            // labelFramework
            // 
            this.labelFramework.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFramework.AutoSize = true;
            this.labelFramework.Location = new System.Drawing.Point(98, 28);
            this.labelFramework.Name = "labelFramework";
            this.labelFramework.Size = new System.Drawing.Size(71, 13);
            this.labelFramework.TabIndex = 16;
            this.labelFramework.Text = "Not Detected";
            this.labelFramework.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Kinect Status";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(9, 8);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxKinect);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.labelFramework);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxKinectStatus);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Size = new System.Drawing.Size(271, 347);
            this.splitContainer2.SplitterDistance = 120;
            this.splitContainer2.TabIndex = 37;
            // 
            // pictureBoxKinect
            // 
            this.pictureBoxKinect.Image = global:: ServerKinect.Properties.Resources.openNI1;
            this.pictureBoxKinect.Location = new System.Drawing.Point(87, 48);
            this.pictureBoxKinect.Name = "pictureBoxKinect";
            this.pictureBoxKinect.Size = new System.Drawing.Size(96, 64);
            this.pictureBoxKinect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxKinect.TabIndex = 22;
            this.pictureBoxKinect.TabStop = false;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::ServerKinect.Properties.Resources.Reload_icon;
            this.button1.Location = new System.Drawing.Point(231, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 29);
            this.button1.TabIndex = 24;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxKinectStatus
            // 
            this.listBoxKinectStatus.FormattingEnabled = true;
            this.listBoxKinectStatus.HorizontalScrollbar = true;
            this.listBoxKinectStatus.Location = new System.Drawing.Point(11, 29);
            this.listBoxKinectStatus.Name = "listBoxKinectStatus";
            this.listBoxKinectStatus.Size = new System.Drawing.Size(246, 186);
            this.listBoxKinectStatus.TabIndex = 36;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer3.Location = new System.Drawing.Point(558, 8);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.button3);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.checkBoxSkeleton);
            this.splitContainer3.Panel1.Controls.Add(this.checkBoxRGBImage);
            this.splitContainer3.Panel1.Controls.Add(this.checkBoxHand);
            this.splitContainer3.Panel1.Controls.Add(this.checkBoxDepthImage);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.labelSkeletonDetected);
            this.splitContainer3.Panel2.Controls.Add(this.label8);
            this.splitContainer3.Size = new System.Drawing.Size(216, 229);
            this.splitContainer3.SplitterDistance = 169;
            this.splitContainer3.TabIndex = 38;
            // 
            // button3
            // 
            this.button3.Image = global::ServerKinect.Properties.Resources.diagram_v2_13_1_;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(50, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 35);
            this.button3.TabIndex = 22;
            this.button3.Text = "Setting";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "OSC DataToSend";
            // 
            // checkBoxSkeleton
            // 
            this.checkBoxSkeleton.AutoSize = true;
            this.checkBoxSkeleton.Location = new System.Drawing.Point(50, 75);
            this.checkBoxSkeleton.Name = "checkBoxSkeleton";
            this.checkBoxSkeleton.Size = new System.Drawing.Size(117, 17);
            this.checkBoxSkeleton.TabIndex = 20;
            this.checkBoxSkeleton.Text = "Skeleton && Gesture";
            this.checkBoxSkeleton.UseVisualStyleBackColor = true;
            this.checkBoxSkeleton.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBoxRGBImage
            // 
            this.checkBoxRGBImage.AutoSize = true;
            this.checkBoxRGBImage.Location = new System.Drawing.Point(50, 29);
            this.checkBoxRGBImage.Name = "checkBoxRGBImage";
            this.checkBoxRGBImage.Size = new System.Drawing.Size(81, 17);
            this.checkBoxRGBImage.TabIndex = 17;
            this.checkBoxRGBImage.Text = "RGB Image";
            this.checkBoxRGBImage.UseVisualStyleBackColor = true;
            this.checkBoxRGBImage.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxHand
            // 
            this.checkBoxHand.AutoSize = true;
            this.checkBoxHand.Enabled = false;
            this.checkBoxHand.Location = new System.Drawing.Point(74, 95);
            this.checkBoxHand.Name = "checkBoxHand";
            this.checkBoxHand.Size = new System.Drawing.Size(93, 17);
            this.checkBoxHand.TabIndex = 19;
            this.checkBoxHand.Text = "Hand && Finger";
            this.checkBoxHand.UseVisualStyleBackColor = true;
            this.checkBoxHand.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBoxDepthImage
            // 
            this.checkBoxDepthImage.AutoSize = true;
            this.checkBoxDepthImage.Location = new System.Drawing.Point(50, 52);
            this.checkBoxDepthImage.Name = "checkBoxDepthImage";
            this.checkBoxDepthImage.Size = new System.Drawing.Size(87, 17);
            this.checkBoxDepthImage.TabIndex = 18;
            this.checkBoxDepthImage.Text = "Depth Image";
            this.checkBoxDepthImage.UseVisualStyleBackColor = true;
            this.checkBoxDepthImage.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // labelSkeletonDetected
            // 
            this.labelSkeletonDetected.AutoSize = true;
            this.labelSkeletonDetected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkeletonDetected.Location = new System.Drawing.Point(95, 24);
            this.labelSkeletonDetected.Name = "labelSkeletonDetected";
            this.labelSkeletonDetected.Size = new System.Drawing.Size(24, 26);
            this.labelSkeletonDetected.TabIndex = 38;
            this.labelSkeletonDetected.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Skeleton Detected";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(77, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "OSC UPD Information";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Location = new System.Drawing.Point(289, 8);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxConnection);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxHost);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.labelServerStatus);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSend);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.videoControl);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelClientConnected);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.labelPPS);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Size = new System.Drawing.Size(263, 347);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "OSC UDP Connection:";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(90, 27);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(156, 20);
            this.textBoxHost.TabIndex = 31;
            this.textBoxHost.Text = "127.0.0.1";
            // 
            // button2
            // 
            this.button2.Image = global::ServerKinect.Properties.Resources.connect_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(45, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 35);
            this.button2.TabIndex = 34;
            this.button2.Text = "New Connection";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerStatus.Location = new System.Drawing.Point(151, 7);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(73, 13);
            this.labelServerStatus.TabIndex = 35;
            this.labelServerStatus.Text = "Disconnected";
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(90, 58);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(156, 20);
            this.textBoxSend.TabIndex = 32;
            this.textBoxSend.Text = "3001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Send";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Host";
            // 
            // labelClientConnected
            // 
            this.labelClientConnected.AutoSize = true;
            this.labelClientConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientConnected.Location = new System.Drawing.Point(193, 45);
            this.labelClientConnected.Name = "labelClientConnected";
            this.labelClientConnected.Size = new System.Drawing.Size(13, 13);
            this.labelClientConnected.TabIndex = 41;
            this.labelClientConnected.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Client Connected";
            // 
            // labelPPS
            // 
            this.labelPPS.AutoSize = true;
            this.labelPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPPS.Location = new System.Drawing.Point(193, 78);
            this.labelPPS.Name = "labelPPS";
            this.labelPPS.Size = new System.Drawing.Size(13, 13);
            this.labelPPS.TabIndex = 39;
            this.labelPPS.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Package Per Second (PPS)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBoxGesture);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(558, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 111);
            this.panel1.TabIndex = 39;
            // 
            // listBoxGesture
            // 
            this.listBoxGesture.FormattingEnabled = true;
            this.listBoxGesture.HorizontalScrollbar = true;
            this.listBoxGesture.Location = new System.Drawing.Point(9, 23);
            this.listBoxGesture.Name = "listBoxGesture";
            this.listBoxGesture.Size = new System.Drawing.Size(195, 82);
            this.listBoxGesture.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(50, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Gesture Detected";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listBoxLOG);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(777, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 346);
            this.panel2.TabIndex = 40;
            // 
            // listBoxLOG
            // 
            this.listBoxLOG.FormattingEnabled = true;
            this.listBoxLOG.HorizontalScrollbar = true;
            this.listBoxLOG.Location = new System.Drawing.Point(12, 27);
            this.listBoxLOG.Name = "listBoxLOG";
            this.listBoxLOG.Size = new System.Drawing.Size(210, 264);
            this.listBoxLOG.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(65, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Information LOG";
            // 
            // button4
            // 
            this.button4.Image = global::ServerKinect.Properties.Resources.edit_clear__1_;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(68, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 37);
            this.button4.TabIndex = 38;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 134);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(261, 103);
            this.splitter1.TabIndex = 36;
            this.splitter1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "OSC UDP Connection List:";
            // 
            // comboBoxConnection
            // 
            this.comboBoxConnection.FormattingEnabled = true;
            this.comboBoxConnection.Location = new System.Drawing.Point(17, 167);
            this.comboBoxConnection.Name = "comboBoxConnection";
            this.comboBoxConnection.Size = new System.Drawing.Size(229, 21);
            this.comboBoxConnection.TabIndex = 38;
            // 
            // button5
            // 
            this.button5.Image = global::ServerKinect.Properties.Resources.disconnect;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(51, 194);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 35);
            this.button5.TabIndex = 39;
            this.button5.Text = "Disconnect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // videoControl
            // 
            this.videoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoControl.BackColor = System.Drawing.Color.Black;
            this.videoControl.Location = new System.Drawing.Point(45, 29);
            this.videoControl.Name = "videoControl";
            this.videoControl.Size = new System.Drawing.Size(0, 204);
            this.videoControl.Stretch = false;
            this.videoControl.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1020, 360);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Kinect Server ";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKinect)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VideoControl videoControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFramework;
        private System.Windows.Forms.CheckBox checkBoxRGBImage;
        private System.Windows.Forms.CheckBox checkBoxDepthImage;
        private System.Windows.Forms.CheckBox checkBoxHand;
        private System.Windows.Forms.CheckBox checkBoxSkeleton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBoxKinect;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxKinectStatus;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelSkeletonDetected;
        private System.Windows.Forms.Label labelPPS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelClientConnected;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxGesture;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxLOG;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBoxConnection;
    }
}

