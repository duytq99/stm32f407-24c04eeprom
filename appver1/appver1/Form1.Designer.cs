
namespace appver1
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
            this.components = new System.ComponentModel.Container();
            this.btnFindPort = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.comboBoxNamePort = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStatusDisplay = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnReadMem = new System.Windows.Forms.Button();
            this.btnDelPort = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutputLogging = new System.Windows.Forms.RichTextBox();
            this.btnClearContent = new System.Windows.Forms.Button();
            this.labelContent = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.textBoxAddressTo = new System.Windows.Forms.TextBox();
            this.btnClearAddressFrom = new System.Windows.Forms.Button();
            this.textBoxAddressFrom = new System.Windows.Forms.TextBox();
            this.btnClearAddressTo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBoxMemMap = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnClearWindow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindPort
            // 
            this.btnFindPort.Location = new System.Drawing.Point(21, 145);
            this.btnFindPort.Name = "btnFindPort";
            this.btnFindPort.Size = new System.Drawing.Size(133, 25);
            this.btnFindPort.TabIndex = 0;
            this.btnFindPort.Text = "Find Port";
            this.btnFindPort.UseVisualStyleBackColor = true;
            this.btnFindPort.Click += new System.EventHandler(this.btnFindPort_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(21, 207);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 25);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(21, 238);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(133, 25);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Write ";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // comboBoxNamePort
            // 
            this.comboBoxNamePort.FormattingEnabled = true;
            this.comboBoxNamePort.Location = new System.Drawing.Point(6, 30);
            this.comboBoxNamePort.Name = "comboBoxNamePort";
            this.comboBoxNamePort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNamePort.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 14);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStatusDisplay);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.comboBoxBaudrate);
            this.groupBox1.Controls.Add(this.labelBaudrate);
            this.groupBox1.Controls.Add(this.comboBoxNamePort);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Location = new System.Drawing.Point(21, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial";
            // 
            // labelStatusDisplay
            // 
            this.labelStatusDisplay.AutoSize = true;
            this.labelStatusDisplay.Location = new System.Drawing.Point(6, 109);
            this.labelStatusDisplay.Name = "labelStatusDisplay";
            this.labelStatusDisplay.Size = new System.Drawing.Size(43, 13);
            this.labelStatusDisplay.TabIndex = 11;
            this.labelStatusDisplay.Text = "Waiting";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 96);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status:";
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Location = new System.Drawing.Point(6, 72);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudrate.TabIndex = 5;
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(6, 56);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(50, 13);
            this.labelBaudrate.TabIndex = 6;
            this.labelBaudrate.Text = "Baudrate";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // btnReadMem
            // 
            this.btnReadMem.Location = new System.Drawing.Point(21, 269);
            this.btnReadMem.Name = "btnReadMem";
            this.btnReadMem.Size = new System.Drawing.Size(133, 25);
            this.btnReadMem.TabIndex = 6;
            this.btnReadMem.Text = "Read Memory";
            this.btnReadMem.UseVisualStyleBackColor = true;
            this.btnReadMem.Click += new System.EventHandler(this.btnReadMem_Click);
            // 
            // btnDelPort
            // 
            this.btnDelPort.Location = new System.Drawing.Point(21, 176);
            this.btnDelPort.Name = "btnDelPort";
            this.btnDelPort.Size = new System.Drawing.Size(133, 25);
            this.btnDelPort.TabIndex = 7;
            this.btnDelPort.Text = "Delete Port";
            this.btnDelPort.UseVisualStyleBackColor = true;
            this.btnDelPort.Click += new System.EventHandler(this.btnDelPort_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(21, 300);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(133, 25);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxOutputLogging);
            this.groupBox2.Location = new System.Drawing.Point(176, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 201);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Window";
            // 
            // richTextBoxOutputLogging
            // 
            this.richTextBoxOutputLogging.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.richTextBoxOutputLogging.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxOutputLogging.Name = "richTextBoxOutputLogging";
            this.richTextBoxOutputLogging.Size = new System.Drawing.Size(425, 176);
            this.richTextBoxOutputLogging.TabIndex = 0;
            this.richTextBoxOutputLogging.Text = "";
            this.richTextBoxOutputLogging.TextChanged += new System.EventHandler(this.richTextBoxOutputLogging_TextChanged);
            // 
            // btnClearContent
            // 
            this.btnClearContent.Location = new System.Drawing.Point(378, 28);
            this.btnClearContent.Name = "btnClearContent";
            this.btnClearContent.Size = new System.Drawing.Size(53, 20);
            this.btnClearContent.TabIndex = 11;
            this.btnClearContent.Text = "Clear";
            this.btnClearContent.UseVisualStyleBackColor = true;
            this.btnClearContent.Click += new System.EventHandler(this.btnClearContent_Click);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(6, 13);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(71, 13);
            this.labelContent.TabIndex = 3;
            this.labelContent.Text = "Char or String";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(6, 29);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(366, 20);
            this.textBoxContent.TabIndex = 1;
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBoxContent_TextChanged);
            // 
            // textBoxAddressTo
            // 
            this.textBoxAddressTo.Location = new System.Drawing.Point(6, 74);
            this.textBoxAddressTo.Name = "textBoxAddressTo";
            this.textBoxAddressTo.Size = new System.Drawing.Size(366, 20);
            this.textBoxAddressTo.TabIndex = 12;
            this.textBoxAddressTo.TextChanged += new System.EventHandler(this.textBoxAddressTo_TextChanged);
            // 
            // btnClearAddressFrom
            // 
            this.btnClearAddressFrom.Location = new System.Drawing.Point(378, 32);
            this.btnClearAddressFrom.Name = "btnClearAddressFrom";
            this.btnClearAddressFrom.Size = new System.Drawing.Size(53, 20);
            this.btnClearAddressFrom.TabIndex = 10;
            this.btnClearAddressFrom.Text = "Clear";
            this.btnClearAddressFrom.UseVisualStyleBackColor = true;
            this.btnClearAddressFrom.Click += new System.EventHandler(this.btnClearAddress_Click);
            // 
            // textBoxAddressFrom
            // 
            this.textBoxAddressFrom.Location = new System.Drawing.Point(6, 32);
            this.textBoxAddressFrom.Name = "textBoxAddressFrom";
            this.textBoxAddressFrom.Size = new System.Drawing.Size(366, 20);
            this.textBoxAddressFrom.TabIndex = 0;
            this.textBoxAddressFrom.TextChanged += new System.EventHandler(this.textBoxAddressFrom_TextChanged);
            // 
            // btnClearAddressTo
            // 
            this.btnClearAddressTo.Location = new System.Drawing.Point(378, 74);
            this.btnClearAddressTo.Name = "btnClearAddressTo";
            this.btnClearAddressTo.Size = new System.Drawing.Size(53, 20);
            this.btnClearAddressTo.TabIndex = 13;
            this.btnClearAddressTo.Text = "Clear";
            this.btnClearAddressTo.UseVisualStyleBackColor = true;
            this.btnClearAddressTo.Click += new System.EventHandler(this.btnClearAddressTo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "To (0x)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "From (0x)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearAddressTo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxAddressTo);
            this.groupBox3.Controls.Add(this.textBoxAddressFrom);
            this.groupBox3.Controls.Add(this.btnClearAddressFrom);
            this.groupBox3.Location = new System.Drawing.Point(176, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 104);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // btnDelAll
            // 
            this.btnDelAll.Location = new System.Drawing.Point(21, 331);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(133, 25);
            this.btnDelAll.TabIndex = 17;
            this.btnDelAll.Text = "Delete All";
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelContent);
            this.groupBox4.Controls.Add(this.btnClearContent);
            this.groupBox4.Controls.Add(this.textBoxContent);
            this.groupBox4.Location = new System.Drawing.Point(176, 331);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(440, 56);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Content";
            // 
            // richTextBoxMemMap
            // 
            this.richTextBoxMemMap.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxMemMap.Name = "richTextBoxMemMap";
            this.richTextBoxMemMap.Size = new System.Drawing.Size(169, 314);
            this.richTextBoxMemMap.TabIndex = 18;
            this.richTextBoxMemMap.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnScan);
            this.groupBox5.Controls.Add(this.richTextBoxMemMap);
            this.groupBox5.Location = new System.Drawing.Point(622, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 373);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Memory map";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(6, 339);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(169, 25);
            this.btnScan.TabIndex = 21;
            this.btnScan.Text = "Scan Memory Map";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnClearWindow
            // 
            this.btnClearWindow.Location = new System.Drawing.Point(21, 362);
            this.btnClearWindow.Name = "btnClearWindow";
            this.btnClearWindow.Size = new System.Drawing.Size(133, 25);
            this.btnClearWindow.TabIndex = 20;
            this.btnClearWindow.Text = "Clear Window";
            this.btnClearWindow.UseVisualStyleBackColor = true;
            this.btnClearWindow.Click += new System.EventHandler(this.btnClearWindow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 400);
            this.Controls.Add(this.btnClearWindow);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnDelAll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnDelPort);
            this.Controls.Add(this.btnReadMem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnFindPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox comboBoxNamePort;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.Label labelStatusDisplay;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnReadMem;
        private System.Windows.Forms.Button btnDelPort;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxOutputLogging;
        private System.Windows.Forms.TextBox textBoxAddressFrom;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button btnClearContent;
        private System.Windows.Forms.Button btnClearAddressFrom;
        private System.Windows.Forms.TextBox textBoxAddressTo;
        private System.Windows.Forms.Button btnClearAddressTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBoxMemMap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClearWindow;
        private System.Windows.Forms.Button btnScan;
    }
}

