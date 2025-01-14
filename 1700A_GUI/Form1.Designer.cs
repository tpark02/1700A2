﻿namespace _1700A_GUI
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.commandInput = new System.Windows.Forms.TextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.connect_button = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cmText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.voltLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.voltageOutLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.warningMsg = new System.Windows.Forms.Label();
            this.numpadTextBox = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.entButton = new System.Windows.Forms.Button();
            this.btnPeriod = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.ipport = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.period_enter = new System.Windows.Forms.Button();
            this.period_textbox = new System.Windows.Forms.TextBox();
            this.ipradio = new System.Windows.Forms.RadioButton();
            this.measStartButton = new System.Windows.Forms.Button();
            this.comradio = new System.Windows.Forms.RadioButton();
            this.iptextbox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.cmSwitch = new System.Windows.Forms.Button();
            this.psSwitch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ep1 = new System.Windows.Forms.Label();
            this.ec2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.v2 = new System.Windows.Forms.Label();
            this.v_dot = new System.Windows.Forms.Label();
            this.ep2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ec1 = new System.Windows.Forms.Label();
            this.v1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.sampleRateTextBox = new System.Windows.Forms.TextBox();
            this.plotEnterButton = new System.Windows.Forms.Button();
            this.limitBoxTemp = new System.Windows.Forms.TextBox();
            this.STOP1 = new System.Windows.Forms.Button();
            this.START1 = new System.Windows.Forms.Button();
            this.numberLabel3 = new System.Windows.Forms.Label();
            this.numberLabel2 = new System.Windows.Forms.Label();
            this.numberLabel1 = new System.Windows.Forms.Label();
            this.STOP2 = new System.Windows.Forms.Button();
            this.START2 = new System.Windows.Forms.Button();
            this.FormPlot2 = new ScottPlot.FormsPlot();
            this.FormPlot = new ScottPlot.FormsPlot();
            this.tabpage3 = new System.Windows.Forms.TabPage();
            this.downloadLinkGroup = new System.Windows.Forms.GroupBox();
            this.hiddenPanel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.enterFileButton = new System.Windows.Forms.Button();
            this.downloadMsg = new System.Windows.Forms.Label();
            this.enteredFileName = new System.Windows.Forms.Label();
            this.downloadFileName = new System.Windows.Forms.TextBox();
            this.ftpButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.port1700button = new System.Windows.Forms.Button();
            this.gatewaylabel = new System.Windows.Forms.TextBox();
            this.subnetlabel = new System.Windows.Forms.TextBox();
            this.gatewaybutton = new System.Windows.Forms.Button();
            this.subnetbutton = new System.Windows.Forms.Button();
            this.ip1700button = new System.Windows.Forms.Button();
            this.port1700 = new System.Windows.Forms.TextBox();
            this.ip1700 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.selectedFileName = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.modelname = new System.Windows.Forms.Label();
            this.fwNumber = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.serialNumber = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.calLogClearButton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.logSaveButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cal_textbox = new System.Windows.Forms.TextBox();
            this.cal5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cal19 = new System.Windows.Forms.Button();
            this.cal18 = new System.Windows.Forms.Button();
            this.cal13 = new System.Windows.Forms.Button();
            this.cal16 = new System.Windows.Forms.Button();
            this.cal17 = new System.Windows.Forms.Button();
            this.cal14 = new System.Windows.Forms.Button();
            this.cal15 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cal3 = new System.Windows.Forms.Button();
            this.cal8 = new System.Windows.Forms.Button();
            this.cal7 = new System.Windows.Forms.Button();
            this.cal9 = new System.Windows.Forms.Button();
            this.cal6 = new System.Windows.Forms.Button();
            this.cal10 = new System.Windows.Forms.Button();
            this.cal4 = new System.Windows.Forms.Button();
            this.cal12 = new System.Windows.Forms.Button();
            this.cal11 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cal1 = new System.Windows.Forms.Button();
            this.cal2 = new System.Windows.Forms.Button();
            this.cal_resultbox = new System.Windows.Forms.RichTextBox();
            this.downloadMsgLabel = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cal_commandbox = new System.Windows.Forms.TextBox();
            this.cal_sendbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabpage3.SuspendLayout();
            this.downloadLinkGroup.SuspendLayout();
            this.hiddenPanel.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(17, 611);
            this.logBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.logBox.Size = new System.Drawing.Size(908, 131);
            this.logBox.TabIndex = 4;
            this.logBox.Text = "";
            // 
            // commandInput
            // 
            this.commandInput.Location = new System.Drawing.Point(17, 573);
            this.commandInput.Margin = new System.Windows.Forms.Padding(4);
            this.commandInput.Name = "commandInput";
            this.commandInput.Size = new System.Drawing.Size(908, 28);
            this.commandInput.TabIndex = 83;
            this.commandInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandInput_KeyDown);
            // 
            // send_button
            // 
            this.send_button.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.send_button.Location = new System.Drawing.Point(933, 573);
            this.send_button.Margin = new System.Windows.Forms.Padding(4);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(77, 177);
            this.send_button.TabIndex = 84;
            this.send_button.Text = "ENT";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.commandSend_Click);
            // 
            // comboBox_port
            // 
            this.comboBox_port.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(122, 42);
            this.comboBox_port.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(154, 28);
            this.comboBox_port.TabIndex = 85;
            // 
            // disconnect_button
            // 
            this.disconnect_button.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.disconnect_button.Location = new System.Drawing.Point(435, 107);
            this.disconnect_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(134, 82);
            this.disconnect_button.TabIndex = 87;
            this.disconnect_button.Text = "DISCONNECT";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // connect_button
            // 
            this.connect_button.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connect_button.Location = new System.Drawing.Point(436, 12);
            this.connect_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(134, 82);
            this.connect_button.TabIndex = 88;
            this.connect_button.Text = "CONNECT";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // cmText
            // 
            this.cmText.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmText.Location = new System.Drawing.Point(132, 62);
            this.cmText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cmText.Name = "cmText";
            this.cmText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmText.Size = new System.Drawing.Size(243, 60);
            this.cmText.TabIndex = 89;
            this.cmText.Text = "-.--- - A";
            this.cmText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(11, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 28);
            this.label1.TabIndex = 93;
            this.label1.Text = "SET Voltage (1.5 ~ 16)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // voltLabel
            // 
            this.voltLabel.AutoSize = true;
            this.voltLabel.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.voltLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.voltLabel.Location = new System.Drawing.Point(234, 138);
            this.voltLabel.Name = "voltLabel";
            this.voltLabel.Size = new System.Drawing.Size(79, 28);
            this.voltLabel.TabIndex = 94;
            this.voltLabel.Text = "0.0 V";
            this.voltLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(139, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 28);
            this.label2.TabIndex = 95;
            this.label2.Text = "Voltage OUT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // voltageOutLabel
            // 
            this.voltageOutLabel.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.voltageOutLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.voltageOutLabel.Location = new System.Drawing.Point(6, 248);
            this.voltageOutLabel.Name = "voltageOutLabel";
            this.voltageOutLabel.Size = new System.Drawing.Size(310, 40);
            this.voltageOutLabel.TabIndex = 96;
            this.voltageOutLabel.Text = "0.0 V";
            this.voltageOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.warningMsg);
            this.panel1.Controls.Add(this.numpadTextBox);
            this.panel1.Controls.Add(this.voltageOutLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.voltLabel);
            this.panel1.Controls.Add(this.entButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPeriod);
            this.panel1.Controls.Add(this.btn0);
            this.panel1.Controls.Add(this.btn3);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.btn6);
            this.panel1.Controls.Add(this.btn5);
            this.panel1.Controls.Add(this.btn4);
            this.panel1.Controls.Add(this.btn9);
            this.panel1.Controls.Add(this.btn8);
            this.panel1.Controls.Add(this.btn7);
            this.panel1.Location = new System.Drawing.Point(1017, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 732);
            this.panel1.TabIndex = 97;
            // 
            // warningMsg
            // 
            this.warningMsg.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.warningMsg.ForeColor = System.Drawing.Color.Red;
            this.warningMsg.Location = new System.Drawing.Point(16, 314);
            this.warningMsg.Name = "warningMsg";
            this.warningMsg.Size = new System.Drawing.Size(302, 44);
            this.warningMsg.TabIndex = 112;
            this.warningMsg.Text = "Please enter range 1.5~16";
            this.warningMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numpadTextBox
            // 
            this.numpadTextBox.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numpadTextBox.Location = new System.Drawing.Point(14, 370);
            this.numpadTextBox.Name = "numpadTextBox";
            this.numpadTextBox.Size = new System.Drawing.Size(298, 40);
            this.numpadTextBox.TabIndex = 111;
            this.numpadTextBox.Text = "1234567890";
            this.numpadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numpadTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numpadTextBox_KeyDown);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBack.Location = new System.Drawing.Point(240, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 222);
            this.btnBack.TabIndex = 110;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.keypad_Click);
            // 
            // entButton
            // 
            this.entButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.entButton.Location = new System.Drawing.Point(166, 658);
            this.entButton.Name = "entButton";
            this.entButton.Size = new System.Drawing.Size(147, 70);
            this.entButton.TabIndex = 109;
            this.entButton.Text = "ENT";
            this.entButton.UseVisualStyleBackColor = true;
            this.entButton.Click += new System.EventHandler(this.entButton_Click);
            // 
            // btnPeriod
            // 
            this.btnPeriod.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPeriod.Location = new System.Drawing.Point(91, 658);
            this.btnPeriod.Name = "btnPeriod";
            this.btnPeriod.Size = new System.Drawing.Size(69, 70);
            this.btnPeriod.TabIndex = 108;
            this.btnPeriod.Text = ".";
            this.btnPeriod.UseVisualStyleBackColor = true;
            this.btnPeriod.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn0.Location = new System.Drawing.Point(19, 658);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(69, 70);
            this.btn0.TabIndex = 107;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn3.Location = new System.Drawing.Point(166, 582);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(69, 70);
            this.btn3.TabIndex = 106;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn2.Location = new System.Drawing.Point(91, 582);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(69, 70);
            this.btn2.TabIndex = 105;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn1.Location = new System.Drawing.Point(19, 582);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(69, 70);
            this.btn1.TabIndex = 104;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn6.Location = new System.Drawing.Point(166, 506);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(69, 70);
            this.btn6.TabIndex = 103;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn5.Location = new System.Drawing.Point(91, 506);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(69, 70);
            this.btn5.TabIndex = 102;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn4.Location = new System.Drawing.Point(19, 506);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(69, 70);
            this.btn4.TabIndex = 101;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn9.Location = new System.Drawing.Point(166, 430);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(69, 70);
            this.btn9.TabIndex = 100;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn8.Location = new System.Drawing.Point(91, 430);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(69, 70);
            this.btn8.TabIndex = 99;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.keypad_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn7.Location = new System.Drawing.Point(19, 430);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(69, 70);
            this.btn7.TabIndex = 98;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.keypad_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.ipport);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.period_enter);
            this.panel2.Controls.Add(this.period_textbox);
            this.panel2.Controls.Add(this.ipradio);
            this.panel2.Controls.Add(this.measStartButton);
            this.panel2.Controls.Add(this.comradio);
            this.panel2.Controls.Add(this.iptextbox);
            this.panel2.Controls.Add(this.comboBox_port);
            this.panel2.Controls.Add(this.connect_button);
            this.panel2.Controls.Add(this.disconnect_button);
            this.panel2.Location = new System.Drawing.Point(17, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 204);
            this.panel2.TabIndex = 98;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(751, 53);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 18);
            this.label20.TabIndex = 109;
            this.label20.Text = "ms";
            this.label20.Visible = false;
            // 
            // ipport
            // 
            this.ipport.Location = new System.Drawing.Point(321, 132);
            this.ipport.Margin = new System.Windows.Forms.Padding(4);
            this.ipport.Name = "ipport";
            this.ipport.Size = new System.Drawing.Size(81, 28);
            this.ipport.TabIndex = 108;
            this.ipport.Text = "1001";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(639, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 18);
            this.label10.TabIndex = 107;
            this.label10.Text = "Delay";
            this.label10.Visible = false;
            // 
            // period_enter
            // 
            this.period_enter.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.period_enter.Location = new System.Drawing.Point(807, 15);
            this.period_enter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.period_enter.Name = "period_enter";
            this.period_enter.Size = new System.Drawing.Size(134, 82);
            this.period_enter.TabIndex = 106;
            this.period_enter.Text = "ENTER";
            this.period_enter.UseVisualStyleBackColor = true;
            this.period_enter.Visible = false;
            this.period_enter.Click += new System.EventHandler(this.period_enter_Click);
            // 
            // period_textbox
            // 
            this.period_textbox.Location = new System.Drawing.Point(642, 53);
            this.period_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.period_textbox.Name = "period_textbox";
            this.period_textbox.Size = new System.Drawing.Size(98, 28);
            this.period_textbox.TabIndex = 104;
            this.period_textbox.Text = "100";
            this.period_textbox.Visible = false;
            this.period_textbox.Leave += new System.EventHandler(this.period_textbox_Leave);
            // 
            // ipradio
            // 
            this.ipradio.AutoSize = true;
            this.ipradio.Location = new System.Drawing.Point(27, 132);
            this.ipradio.Name = "ipradio";
            this.ipradio.Size = new System.Drawing.Size(47, 22);
            this.ipradio.TabIndex = 103;
            this.ipradio.Text = "IP";
            this.ipradio.UseVisualStyleBackColor = true;
            this.ipradio.CheckedChanged += new System.EventHandler(this.ipradio_CheckedChanged);
            // 
            // measStartButton
            // 
            this.measStartButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.measStartButton.Location = new System.Drawing.Point(720, 77);
            this.measStartButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.measStartButton.Name = "measStartButton";
            this.measStartButton.Size = new System.Drawing.Size(134, 77);
            this.measStartButton.TabIndex = 108;
            this.measStartButton.Text = "START";
            this.measStartButton.UseVisualStyleBackColor = true;
            this.measStartButton.Click += new System.EventHandler(this.measStartButton_Click);
            // 
            // comradio
            // 
            this.comradio.AutoSize = true;
            this.comradio.Checked = true;
            this.comradio.Location = new System.Drawing.Point(27, 45);
            this.comradio.Name = "comradio";
            this.comradio.Size = new System.Drawing.Size(73, 22);
            this.comradio.TabIndex = 102;
            this.comradio.TabStop = true;
            this.comradio.Text = "COM";
            this.comradio.UseVisualStyleBackColor = true;
            this.comradio.CheckedChanged += new System.EventHandler(this.comradio_CheckedChanged);
            // 
            // iptextbox
            // 
            this.iptextbox.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.iptextbox.Location = new System.Drawing.Point(99, 132);
            this.iptextbox.Name = "iptextbox";
            this.iptextbox.Size = new System.Drawing.Size(193, 30);
            this.iptextbox.TabIndex = 100;
            this.iptextbox.Text = "192.168.100.170";
            this.iptextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.cmSwitch);
            this.mainPanel.Controls.Add(this.psSwitch);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.panel5);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Location = new System.Drawing.Point(17, 230);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(994, 336);
            this.mainPanel.TabIndex = 99;
            // 
            // cmSwitch
            // 
            this.cmSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmSwitch.Location = new System.Drawing.Point(379, 31);
            this.cmSwitch.Name = "cmSwitch";
            this.cmSwitch.Size = new System.Drawing.Size(75, 44);
            this.cmSwitch.TabIndex = 4;
            this.cmSwitch.Text = "ON";
            this.cmSwitch.UseVisualStyleBackColor = true;
            this.cmSwitch.Click += new System.EventHandler(this.cmSwitch_Click);
            // 
            // psSwitch
            // 
            this.psSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.psSwitch.Location = new System.Drawing.Point(898, 31);
            this.psSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.psSwitch.Name = "psSwitch";
            this.psSwitch.Size = new System.Drawing.Size(75, 44);
            this.psSwitch.TabIndex = 3;
            this.psSwitch.Text = "ON";
            this.psSwitch.UseVisualStyleBackColor = true;
            this.psSwitch.Click += new System.EventHandler(this.psSwitch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(159, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 28);
            this.label7.TabIndex = 109;
            this.label7.Text = "Current Meter";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmText);
            this.panel4.Location = new System.Drawing.Point(27, 112);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 196);
            this.panel4.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(664, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 28);
            this.label9.TabIndex = 110;
            this.label9.Text = "Power Supply";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(807, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 252);
            this.panel5.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(21, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "mA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(46, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "V";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "mW";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ep1);
            this.panel3.Controls.Add(this.ec2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.v2);
            this.panel3.Controls.Add(this.v_dot);
            this.panel3.Controls.Add(this.ep2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ec1);
            this.panel3.Controls.Add(this.v1);
            this.panel3.Location = new System.Drawing.Point(515, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 252);
            this.panel3.TabIndex = 107;
            // 
            // ep1
            // 
            this.ep1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ep1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ep1.Location = new System.Drawing.Point(19, 45);
            this.ep1.Name = "ep1";
            this.ep1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ep1.Size = new System.Drawing.Size(134, 44);
            this.ep1.TabIndex = 93;
            this.ep1.Text = "-";
            this.ep1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ec2
            // 
            this.ec2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ec2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ec2.Location = new System.Drawing.Point(169, 182);
            this.ec2.Name = "ec2";
            this.ec2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ec2.Size = new System.Drawing.Size(134, 44);
            this.ec2.TabIndex = 106;
            this.ec2.Text = "--- -";
            this.ec2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(146, 46);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(30, 40);
            this.label8.TabIndex = 96;
            this.label8.Text = ".";
            // 
            // v2
            // 
            this.v2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.v2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.v2.Location = new System.Drawing.Point(169, 116);
            this.v2.Name = "v2";
            this.v2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.v2.Size = new System.Drawing.Size(157, 44);
            this.v2.TabIndex = 105;
            this.v2.Text = "--- --";
            this.v2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // v_dot
            // 
            this.v_dot.AutoSize = true;
            this.v_dot.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.v_dot.Location = new System.Drawing.Point(146, 118);
            this.v_dot.Name = "v_dot";
            this.v_dot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.v_dot.Size = new System.Drawing.Size(30, 40);
            this.v_dot.TabIndex = 97;
            this.v_dot.Text = ".";
            // 
            // ep2
            // 
            this.ep2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ep2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ep2.Location = new System.Drawing.Point(169, 45);
            this.ep2.Name = "ep2";
            this.ep2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ep2.Size = new System.Drawing.Size(134, 44);
            this.ep2.TabIndex = 104;
            this.ep2.Text = "--- -";
            this.ep2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(146, 183);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(30, 40);
            this.label6.TabIndex = 98;
            this.label6.Text = ".";
            // 
            // ec1
            // 
            this.ec1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ec1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ec1.Location = new System.Drawing.Point(19, 182);
            this.ec1.Name = "ec1";
            this.ec1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ec1.Size = new System.Drawing.Size(134, 44);
            this.ec1.TabIndex = 103;
            this.ec1.Text = "-";
            this.ec1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v1
            // 
            this.v1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.v1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.v1.Location = new System.Drawing.Point(19, 116);
            this.v1.Name = "v1";
            this.v1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.v1.Size = new System.Drawing.Size(134, 44);
            this.v1.TabIndex = 102;
            this.v1.Text = "--";
            this.v1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabpage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1364, 789);
            this.tabControl1.TabIndex = 102;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.logBox);
            this.tabPage1.Controls.Add(this.commandInput);
            this.tabPage1.Controls.Add(this.mainPanel);
            this.tabPage1.Controls.Add(this.send_button);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1356, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.STOP1);
            this.tabPage2.Controls.Add(this.START1);
            this.tabPage2.Controls.Add(this.numberLabel3);
            this.tabPage2.Controls.Add(this.numberLabel2);
            this.tabPage2.Controls.Add(this.numberLabel1);
            this.tabPage2.Controls.Add(this.STOP2);
            this.tabPage2.Controls.Add(this.START2);
            this.tabPage2.Controls.Add(this.FormPlot2);
            this.tabPage2.Controls.Add(this.FormPlot);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1356, 757);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Measurement";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.sampleRateTextBox);
            this.panel6.Controls.Add(this.plotEnterButton);
            this.panel6.Controls.Add(this.limitBoxTemp);
            this.panel6.Location = new System.Drawing.Point(268, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(745, 87);
            this.panel6.TabIndex = 102;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(295, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 18);
            this.label22.TabIndex = 103;
            this.label22.Text = "Max Count";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(52, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 18);
            this.label21.TabIndex = 102;
            this.label21.Text = "Sample Rate";
            // 
            // sampleRateTextBox
            // 
            this.sampleRateTextBox.Location = new System.Drawing.Point(167, 33);
            this.sampleRateTextBox.Name = "sampleRateTextBox";
            this.sampleRateTextBox.Size = new System.Drawing.Size(104, 28);
            this.sampleRateTextBox.TabIndex = 99;
            this.sampleRateTextBox.Text = "500";
            // 
            // plotEnterButton
            // 
            this.plotEnterButton.Location = new System.Drawing.Point(540, 11);
            this.plotEnterButton.Name = "plotEnterButton";
            this.plotEnterButton.Size = new System.Drawing.Size(135, 68);
            this.plotEnterButton.TabIndex = 101;
            this.plotEnterButton.Text = "Enter";
            this.plotEnterButton.UseVisualStyleBackColor = true;
            this.plotEnterButton.Click += new System.EventHandler(this.plotEnterButton_Click);
            // 
            // limitBoxTemp
            // 
            this.limitBoxTemp.Location = new System.Drawing.Point(409, 33);
            this.limitBoxTemp.Name = "limitBoxTemp";
            this.limitBoxTemp.Size = new System.Drawing.Size(102, 28);
            this.limitBoxTemp.TabIndex = 100;
            this.limitBoxTemp.Text = "30000";
            // 
            // STOP1
            // 
            this.STOP1.Location = new System.Drawing.Point(26, 224);
            this.STOP1.Name = "STOP1";
            this.STOP1.Size = new System.Drawing.Size(109, 68);
            this.STOP1.TabIndex = 98;
            this.STOP1.Text = "STOP";
            this.STOP1.UseVisualStyleBackColor = true;
            this.STOP1.Click += new System.EventHandler(this.STOP1_Click);
            // 
            // START1
            // 
            this.START1.Location = new System.Drawing.Point(24, 131);
            this.START1.Name = "START1";
            this.START1.Size = new System.Drawing.Size(109, 68);
            this.START1.TabIndex = 97;
            this.START1.Text = "START";
            this.START1.UseVisualStyleBackColor = true;
            this.START1.Click += new System.EventHandler(this.START1_Click);
            // 
            // numberLabel3
            // 
            this.numberLabel3.AutoSize = true;
            this.numberLabel3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numberLabel3.Location = new System.Drawing.Point(1129, 589);
            this.numberLabel3.Name = "numberLabel3";
            this.numberLabel3.Size = new System.Drawing.Size(69, 36);
            this.numberLabel3.TabIndex = 83;
            this.numberLabel3.Text = "0.0";
            // 
            // numberLabel2
            // 
            this.numberLabel2.AutoSize = true;
            this.numberLabel2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numberLabel2.Location = new System.Drawing.Point(1129, 400);
            this.numberLabel2.Name = "numberLabel2";
            this.numberLabel2.Size = new System.Drawing.Size(69, 36);
            this.numberLabel2.TabIndex = 81;
            this.numberLabel2.Text = "0.0";
            // 
            // numberLabel1
            // 
            this.numberLabel1.AutoSize = true;
            this.numberLabel1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numberLabel1.Location = new System.Drawing.Point(1124, 173);
            this.numberLabel1.Name = "numberLabel1";
            this.numberLabel1.Size = new System.Drawing.Size(69, 36);
            this.numberLabel1.TabIndex = 80;
            this.numberLabel1.Text = "0.0";
            // 
            // STOP2
            // 
            this.STOP2.Location = new System.Drawing.Point(26, 500);
            this.STOP2.Name = "STOP2";
            this.STOP2.Size = new System.Drawing.Size(109, 68);
            this.STOP2.TabIndex = 93;
            this.STOP2.Text = "STOP";
            this.STOP2.UseVisualStyleBackColor = true;
            this.STOP2.Click += new System.EventHandler(this.STOP2_Click);
            // 
            // START2
            // 
            this.START2.Location = new System.Drawing.Point(26, 410);
            this.START2.Name = "START2";
            this.START2.Size = new System.Drawing.Size(109, 68);
            this.START2.TabIndex = 92;
            this.START2.Text = "START";
            this.START2.UseVisualStyleBackColor = true;
            this.START2.Click += new System.EventHandler(this.START2_Click);
            // 
            // FormPlot2
            // 
            this.FormPlot2.Location = new System.Drawing.Point(104, 330);
            this.FormPlot2.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.FormPlot2.Name = "FormPlot2";
            this.FormPlot2.Size = new System.Drawing.Size(1016, 368);
            this.FormPlot2.TabIndex = 91;
            // 
            // FormPlot
            // 
            this.FormPlot.Location = new System.Drawing.Point(104, 97);
            this.FormPlot.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.FormPlot.Name = "FormPlot";
            this.FormPlot.Size = new System.Drawing.Size(1016, 213);
            this.FormPlot.TabIndex = 88;
            // 
            // tabpage3
            // 
            this.tabpage3.Controls.Add(this.downloadLinkGroup);
            this.tabpage3.Controls.Add(this.groupBox7);
            this.tabpage3.Controls.Add(this.groupBox6);
            this.tabpage3.Controls.Add(this.groupBox5);
            this.tabpage3.Location = new System.Drawing.Point(4, 28);
            this.tabpage3.Name = "tabpage3";
            this.tabpage3.Size = new System.Drawing.Size(1356, 757);
            this.tabpage3.TabIndex = 2;
            this.tabpage3.Text = "Info";
            this.tabpage3.UseVisualStyleBackColor = true;
            // 
            // downloadLinkGroup
            // 
            this.downloadLinkGroup.Controls.Add(this.hiddenPanel);
            this.downloadLinkGroup.Location = new System.Drawing.Point(804, 305);
            this.downloadLinkGroup.Name = "downloadLinkGroup";
            this.downloadLinkGroup.Size = new System.Drawing.Size(529, 431);
            this.downloadLinkGroup.TabIndex = 10;
            this.downloadLinkGroup.TabStop = false;
            this.downloadLinkGroup.Text = "Firmware Download Link";
            // 
            // hiddenPanel
            // 
            this.hiddenPanel.Controls.Add(this.downloadMsgLabel);
            this.hiddenPanel.Controls.Add(this.label17);
            this.hiddenPanel.Controls.Add(this.enterFileButton);
            this.hiddenPanel.Controls.Add(this.downloadMsg);
            this.hiddenPanel.Controls.Add(this.enteredFileName);
            this.hiddenPanel.Controls.Add(this.downloadFileName);
            this.hiddenPanel.Controls.Add(this.ftpButton);
            this.hiddenPanel.Controls.Add(this.label19);
            this.hiddenPanel.Location = new System.Drawing.Point(6, 175);
            this.hiddenPanel.Name = "hiddenPanel";
            this.hiddenPanel.Size = new System.Drawing.Size(517, 250);
            this.hiddenPanel.TabIndex = 11;
            this.hiddenPanel.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 18);
            this.label17.TabIndex = 4;
            this.label17.Text = "File";
            // 
            // enterFileButton
            // 
            this.enterFileButton.Location = new System.Drawing.Point(351, 67);
            this.enterFileButton.Name = "enterFileButton";
            this.enterFileButton.Size = new System.Drawing.Size(141, 79);
            this.enterFileButton.TabIndex = 10;
            this.enterFileButton.Text = "ENTER";
            this.enterFileButton.UseVisualStyleBackColor = true;
            this.enterFileButton.Click += new System.EventHandler(this.enterFileButton_Click);
            // 
            // downloadMsg
            // 
            this.downloadMsg.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.downloadMsg.Location = new System.Drawing.Point(24, 145);
            this.downloadMsg.Name = "downloadMsg";
            this.downloadMsg.Size = new System.Drawing.Size(321, 34);
            this.downloadMsg.TabIndex = 5;
            this.downloadMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enteredFileName
            // 
            this.enteredFileName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.enteredFileName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.enteredFileName.Location = new System.Drawing.Point(118, 110);
            this.enteredFileName.Name = "enteredFileName";
            this.enteredFileName.Size = new System.Drawing.Size(227, 34);
            this.enteredFileName.TabIndex = 9;
            this.enteredFileName.Text = "-";
            this.enteredFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // downloadFileName
            // 
            this.downloadFileName.Location = new System.Drawing.Point(24, 66);
            this.downloadFileName.Name = "downloadFileName";
            this.downloadFileName.Size = new System.Drawing.Size(321, 28);
            this.downloadFileName.TabIndex = 3;
            this.downloadFileName.Leave += new System.EventHandler(this.downloadFileName_Leave);
            // 
            // ftpButton
            // 
            this.ftpButton.Location = new System.Drawing.Point(350, 152);
            this.ftpButton.Name = "ftpButton";
            this.ftpButton.Size = new System.Drawing.Size(141, 79);
            this.ftpButton.TabIndex = 2;
            this.ftpButton.Text = "FTP";
            this.ftpButton.UseVisualStyleBackColor = true;
            this.ftpButton.Click += new System.EventHandler(this.ftpButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 118);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 18);
            this.label19.TabIndex = 8;
            this.label19.Text = "File Name";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.port1700button);
            this.groupBox7.Controls.Add(this.gatewaylabel);
            this.groupBox7.Controls.Add(this.subnetlabel);
            this.groupBox7.Controls.Add(this.gatewaybutton);
            this.groupBox7.Controls.Add(this.subnetbutton);
            this.groupBox7.Controls.Add(this.ip1700button);
            this.groupBox7.Controls.Add(this.port1700);
            this.groupBox7.Controls.Add(this.ip1700);
            this.groupBox7.Location = new System.Drawing.Point(35, 305);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(751, 431);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ETH";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(51, 343);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 18);
            this.label16.TabIndex = 11;
            this.label16.Text = "GATTEWAY";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(78, 251);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 18);
            this.label15.TabIndex = 10;
            this.label15.Text = "SUBNET";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 18);
            this.label14.TabIndex = 9;
            this.label14.Text = "PORT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(130, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 18);
            this.label13.TabIndex = 8;
            this.label13.Text = "IP";
            // 
            // port1700button
            // 
            this.port1700button.Location = new System.Drawing.Point(559, 142);
            this.port1700button.Name = "port1700button";
            this.port1700button.Size = new System.Drawing.Size(138, 60);
            this.port1700button.TabIndex = 7;
            this.port1700button.Text = "ENTER";
            this.port1700button.UseVisualStyleBackColor = true;
            this.port1700button.Click += new System.EventHandler(this.port1700button_Click);
            // 
            // gatewaylabel
            // 
            this.gatewaylabel.Location = new System.Drawing.Point(206, 333);
            this.gatewaylabel.Name = "gatewaylabel";
            this.gatewaylabel.Size = new System.Drawing.Size(275, 28);
            this.gatewaylabel.TabIndex = 6;
            // 
            // subnetlabel
            // 
            this.subnetlabel.Location = new System.Drawing.Point(206, 241);
            this.subnetlabel.Name = "subnetlabel";
            this.subnetlabel.Size = new System.Drawing.Size(275, 28);
            this.subnetlabel.TabIndex = 5;
            // 
            // gatewaybutton
            // 
            this.gatewaybutton.Location = new System.Drawing.Point(559, 315);
            this.gatewaybutton.Name = "gatewaybutton";
            this.gatewaybutton.Size = new System.Drawing.Size(138, 60);
            this.gatewaybutton.TabIndex = 4;
            this.gatewaybutton.Text = "ENTER";
            this.gatewaybutton.UseVisualStyleBackColor = true;
            this.gatewaybutton.Click += new System.EventHandler(this.gatewaybutton_Click);
            // 
            // subnetbutton
            // 
            this.subnetbutton.Location = new System.Drawing.Point(559, 223);
            this.subnetbutton.Name = "subnetbutton";
            this.subnetbutton.Size = new System.Drawing.Size(138, 60);
            this.subnetbutton.TabIndex = 3;
            this.subnetbutton.Text = "ENTER";
            this.subnetbutton.UseVisualStyleBackColor = true;
            this.subnetbutton.Click += new System.EventHandler(this.subnetbutton_Click);
            // 
            // ip1700button
            // 
            this.ip1700button.Location = new System.Drawing.Point(559, 41);
            this.ip1700button.Name = "ip1700button";
            this.ip1700button.Size = new System.Drawing.Size(138, 60);
            this.ip1700button.TabIndex = 2;
            this.ip1700button.Text = "ENTER";
            this.ip1700button.UseVisualStyleBackColor = true;
            this.ip1700button.Click += new System.EventHandler(this.ip1700button_Click);
            // 
            // port1700
            // 
            this.port1700.Location = new System.Drawing.Point(206, 160);
            this.port1700.Name = "port1700";
            this.port1700.Size = new System.Drawing.Size(275, 28);
            this.port1700.TabIndex = 1;
            // 
            // ip1700
            // 
            this.ip1700.Location = new System.Drawing.Point(204, 59);
            this.ip1700.Name = "ip1700";
            this.ip1700.Size = new System.Drawing.Size(277, 28);
            this.ip1700.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.selectedFileName);
            this.groupBox6.Controls.Add(this.updateButton);
            this.groupBox6.Controls.Add(this.openFileButton);
            this.groupBox6.Location = new System.Drawing.Point(804, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(542, 272);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Firmware Update";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(39, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(161, 18);
            this.label18.TabIndex = 7;
            this.label18.Text = "Selected File Name";
            // 
            // selectedFileName
            // 
            this.selectedFileName.Location = new System.Drawing.Point(42, 73);
            this.selectedFileName.Name = "selectedFileName";
            this.selectedFileName.Size = new System.Drawing.Size(321, 49);
            this.selectedFileName.TabIndex = 6;
            this.selectedFileName.Text = "-";
            this.selectedFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(369, 143);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(141, 79);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(369, 43);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(142, 79);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "OPEN";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.modelname);
            this.groupBox5.Controls.Add(this.fwNumber);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.serialNumber);
            this.groupBox5.Location = new System.Drawing.Point(35, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(751, 272);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Device INFO";
            // 
            // modelname
            // 
            this.modelname.AutoSize = true;
            this.modelname.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modelname.ForeColor = System.Drawing.Color.Lime;
            this.modelname.Location = new System.Drawing.Point(198, 42);
            this.modelname.Name = "modelname";
            this.modelname.Size = new System.Drawing.Size(122, 36);
            this.modelname.TabIndex = 4;
            this.modelname.Text = "1700A";
            this.modelname.Click += new System.EventHandler(this.modelname_Click);
            // 
            // fwNumber
            // 
            this.fwNumber.AutoSize = true;
            this.fwNumber.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fwNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.fwNumber.Location = new System.Drawing.Point(376, 179);
            this.fwNumber.Name = "fwNumber";
            this.fwNumber.Size = new System.Drawing.Size(89, 28);
            this.fwNumber.TabIndex = 3;
            this.fwNumber.Text = "ABCD";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(199, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 28);
            this.label12.TabIndex = 6;
            this.label12.Text = "F/W";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(199, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 28);
            this.label11.TabIndex = 5;
            this.label11.Text = "S/N";
            // 
            // serialNumber
            // 
            this.serialNumber.AutoSize = true;
            this.serialNumber.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serialNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.serialNumber.Location = new System.Drawing.Point(376, 118);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(89, 28);
            this.serialNumber.TabIndex = 2;
            this.serialNumber.Text = "ABCD";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.calLogClearButton);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.cal_resultbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1356, 757);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cal";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // calLogClearButton
            // 
            this.calLogClearButton.Location = new System.Drawing.Point(1202, 189);
            this.calLogClearButton.Name = "calLogClearButton";
            this.calLogClearButton.Size = new System.Drawing.Size(99, 35);
            this.calLogClearButton.TabIndex = 39;
            this.calLogClearButton.Text = "clear";
            this.calLogClearButton.UseVisualStyleBackColor = true;
            this.calLogClearButton.Click += new System.EventHandler(this.calLogClearButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.logSaveButton);
            this.groupBox9.Location = new System.Drawing.Point(663, 224);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(141, 124);
            this.groupBox9.TabIndex = 38;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Log";
            // 
            // logSaveButton
            // 
            this.logSaveButton.Location = new System.Drawing.Point(20, 28);
            this.logSaveButton.Name = "logSaveButton";
            this.logSaveButton.Size = new System.Drawing.Size(100, 63);
            this.logSaveButton.TabIndex = 0;
            this.logSaveButton.Text = "SAVE";
            this.logSaveButton.UseVisualStyleBackColor = true;
            this.logSaveButton.Click += new System.EventHandler(this.logSaveButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cal_textbox);
            this.groupBox4.Controls.Add(this.cal5);
            this.groupBox4.Location = new System.Drawing.Point(324, 224);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(332, 124);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "VOLT";
            // 
            // cal_textbox
            // 
            this.cal_textbox.Location = new System.Drawing.Point(152, 49);
            this.cal_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.cal_textbox.Name = "cal_textbox";
            this.cal_textbox.Size = new System.Drawing.Size(141, 28);
            this.cal_textbox.TabIndex = 26;
            this.cal_textbox.Leave += new System.EventHandler(this.cal_textbox_Leave);
            // 
            // cal5
            // 
            this.cal5.Location = new System.Drawing.Point(19, 31);
            this.cal5.Name = "cal5";
            this.cal5.Size = new System.Drawing.Size(110, 66);
            this.cal5.TabIndex = 25;
            this.cal5.Text = "button5";
            this.cal5.UseVisualStyleBackColor = true;
            this.cal5.Click += new System.EventHandler(this.cal5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cal19);
            this.groupBox3.Controls.Add(this.cal18);
            this.groupBox3.Controls.Add(this.cal13);
            this.groupBox3.Controls.Add(this.cal16);
            this.groupBox3.Controls.Add(this.cal17);
            this.groupBox3.Controls.Add(this.cal14);
            this.groupBox3.Controls.Add(this.cal15);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(54, 564);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(750, 169);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Meter";
            // 
            // cal19
            // 
            this.cal19.Location = new System.Drawing.Point(24, 97);
            this.cal19.Name = "cal19";
            this.cal19.Size = new System.Drawing.Size(106, 63);
            this.cal19.TabIndex = 32;
            this.cal19.Text = "button19";
            this.cal19.UseVisualStyleBackColor = true;
            this.cal19.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal18
            // 
            this.cal18.Location = new System.Drawing.Point(248, 97);
            this.cal18.Name = "cal18";
            this.cal18.Size = new System.Drawing.Size(106, 63);
            this.cal18.TabIndex = 31;
            this.cal18.Text = "button18";
            this.cal18.UseVisualStyleBackColor = true;
            this.cal18.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal13
            // 
            this.cal13.Location = new System.Drawing.Point(20, 28);
            this.cal13.Name = "cal13";
            this.cal13.Size = new System.Drawing.Size(106, 63);
            this.cal13.TabIndex = 26;
            this.cal13.Text = "button13";
            this.cal13.UseVisualStyleBackColor = true;
            this.cal13.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal16
            // 
            this.cal16.Location = new System.Drawing.Point(360, 28);
            this.cal16.Name = "cal16";
            this.cal16.Size = new System.Drawing.Size(106, 63);
            this.cal16.TabIndex = 29;
            this.cal16.Text = "button16";
            this.cal16.UseVisualStyleBackColor = true;
            this.cal16.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal17
            // 
            this.cal17.Location = new System.Drawing.Point(132, 97);
            this.cal17.Name = "cal17";
            this.cal17.Size = new System.Drawing.Size(106, 63);
            this.cal17.TabIndex = 30;
            this.cal17.Text = "button17";
            this.cal17.UseVisualStyleBackColor = true;
            this.cal17.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal14
            // 
            this.cal14.Location = new System.Drawing.Point(136, 28);
            this.cal14.Name = "cal14";
            this.cal14.Size = new System.Drawing.Size(106, 63);
            this.cal14.TabIndex = 27;
            this.cal14.Text = "button14";
            this.cal14.UseVisualStyleBackColor = true;
            this.cal14.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal15
            // 
            this.cal15.Location = new System.Drawing.Point(248, 28);
            this.cal15.Name = "cal15";
            this.cal15.Size = new System.Drawing.Size(106, 63);
            this.cal15.TabIndex = 28;
            this.cal15.Text = "button15";
            this.cal15.UseVisualStyleBackColor = true;
            this.cal15.Click += new System.EventHandler(this.cal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cal3);
            this.groupBox2.Controls.Add(this.cal8);
            this.groupBox2.Controls.Add(this.cal7);
            this.groupBox2.Controls.Add(this.cal9);
            this.groupBox2.Controls.Add(this.cal6);
            this.groupBox2.Controls.Add(this.cal10);
            this.groupBox2.Controls.Add(this.cal4);
            this.groupBox2.Controls.Add(this.cal12);
            this.groupBox2.Controls.Add(this.cal11);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(54, 358);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(750, 198);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Power Supply";
            // 
            // cal3
            // 
            this.cal3.Location = new System.Drawing.Point(20, 28);
            this.cal3.Name = "cal3";
            this.cal3.Size = new System.Drawing.Size(110, 61);
            this.cal3.TabIndex = 8;
            this.cal3.Text = "button3";
            this.cal3.UseVisualStyleBackColor = true;
            this.cal3.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal8
            // 
            this.cal8.Location = new System.Drawing.Point(492, 28);
            this.cal8.Name = "cal8";
            this.cal8.Size = new System.Drawing.Size(110, 61);
            this.cal8.TabIndex = 22;
            this.cal8.Text = "button8";
            this.cal8.UseVisualStyleBackColor = true;
            this.cal8.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal7
            // 
            this.cal7.Location = new System.Drawing.Point(369, 28);
            this.cal7.Name = "cal7";
            this.cal7.Size = new System.Drawing.Size(110, 61);
            this.cal7.TabIndex = 23;
            this.cal7.Text = "button7";
            this.cal7.UseVisualStyleBackColor = true;
            this.cal7.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal9
            // 
            this.cal9.Location = new System.Drawing.Point(20, 109);
            this.cal9.Name = "cal9";
            this.cal9.Size = new System.Drawing.Size(110, 61);
            this.cal9.TabIndex = 15;
            this.cal9.Text = "button9";
            this.cal9.UseVisualStyleBackColor = true;
            this.cal9.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal6
            // 
            this.cal6.Location = new System.Drawing.Point(253, 28);
            this.cal6.Name = "cal6";
            this.cal6.Size = new System.Drawing.Size(110, 61);
            this.cal6.TabIndex = 24;
            this.cal6.Text = "button6";
            this.cal6.UseVisualStyleBackColor = true;
            this.cal6.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal10
            // 
            this.cal10.Location = new System.Drawing.Point(136, 110);
            this.cal10.Name = "cal10";
            this.cal10.Size = new System.Drawing.Size(110, 61);
            this.cal10.TabIndex = 14;
            this.cal10.Text = "button10";
            this.cal10.UseVisualStyleBackColor = true;
            this.cal10.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal4
            // 
            this.cal4.Location = new System.Drawing.Point(136, 28);
            this.cal4.Name = "cal4";
            this.cal4.Size = new System.Drawing.Size(110, 61);
            this.cal4.TabIndex = 9;
            this.cal4.Text = "button4";
            this.cal4.UseVisualStyleBackColor = true;
            this.cal4.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal12
            // 
            this.cal12.Location = new System.Drawing.Point(369, 108);
            this.cal12.Name = "cal12";
            this.cal12.Size = new System.Drawing.Size(110, 61);
            this.cal12.TabIndex = 12;
            this.cal12.Text = "button12";
            this.cal12.UseVisualStyleBackColor = true;
            this.cal12.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal11
            // 
            this.cal11.Location = new System.Drawing.Point(253, 108);
            this.cal11.Name = "cal11";
            this.cal11.Size = new System.Drawing.Size(110, 61);
            this.cal11.TabIndex = 13;
            this.cal11.Text = "button11";
            this.cal11.UseVisualStyleBackColor = true;
            this.cal11.Click += new System.EventHandler(this.cal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cal1);
            this.groupBox1.Controls.Add(this.cal2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(54, 224);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(262, 124);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cal Mode ON/OFF";
            // 
            // cal1
            // 
            this.cal1.Location = new System.Drawing.Point(20, 34);
            this.cal1.Name = "cal1";
            this.cal1.Size = new System.Drawing.Size(110, 62);
            this.cal1.TabIndex = 6;
            this.cal1.Text = "button1";
            this.cal1.UseVisualStyleBackColor = true;
            this.cal1.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal2
            // 
            this.cal2.Location = new System.Drawing.Point(136, 33);
            this.cal2.Name = "cal2";
            this.cal2.Size = new System.Drawing.Size(110, 63);
            this.cal2.TabIndex = 7;
            this.cal2.Text = "button2";
            this.cal2.UseVisualStyleBackColor = true;
            this.cal2.Click += new System.EventHandler(this.cal_Click);
            // 
            // cal_resultbox
            // 
            this.cal_resultbox.Location = new System.Drawing.Point(54, 46);
            this.cal_resultbox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cal_resultbox.Name = "cal_resultbox";
            this.cal_resultbox.ReadOnly = true;
            this.cal_resultbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.cal_resultbox.Size = new System.Drawing.Size(1251, 139);
            this.cal_resultbox.TabIndex = 5;
            this.cal_resultbox.Text = "";
            // 
            // downloadMsgLabel
            // 
            this.downloadMsgLabel.Location = new System.Drawing.Point(21, 182);
            this.downloadMsgLabel.Name = "downloadMsgLabel";
            this.downloadMsgLabel.Size = new System.Drawing.Size(323, 49);
            this.downloadMsgLabel.TabIndex = 11;
            this.downloadMsgLabel.Text = "-";
            this.downloadMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cal_sendbutton);
            this.groupBox8.Controls.Add(this.cal_commandbox);
            this.groupBox8.Location = new System.Drawing.Point(825, 238);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(513, 109);
            this.groupBox8.TabIndex = 89;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Command";
            // 
            // cal_commandbox
            // 
            this.cal_commandbox.Location = new System.Drawing.Point(23, 48);
            this.cal_commandbox.Margin = new System.Windows.Forms.Padding(4);
            this.cal_commandbox.Name = "cal_commandbox";
            this.cal_commandbox.Size = new System.Drawing.Size(385, 28);
            this.cal_commandbox.TabIndex = 87;
            this.cal_commandbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cal_commandbox_KeyDown);
            // 
            // cal_sendbutton
            // 
            this.cal_sendbutton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cal_sendbutton.Location = new System.Drawing.Point(426, 28);
            this.cal_sendbutton.Margin = new System.Windows.Forms.Padding(4);
            this.cal_sendbutton.Name = "cal_sendbutton";
            this.cal_sendbutton.Size = new System.Drawing.Size(80, 65);
            this.cal_sendbutton.TabIndex = 88;
            this.cal_sendbutton.Text = "ENT";
            this.cal_sendbutton.UseVisualStyleBackColor = true;
            this.cal_sendbutton.Click += new System.EventHandler(this.cal_sendbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 809);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TESCOM (v.1.0)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabpage3.ResumeLayout(false);
            this.downloadLinkGroup.ResumeLayout(false);
            this.hiddenPanel.ResumeLayout(false);
            this.hiddenPanel.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TextBox commandInput;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Button connect_button;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label cmText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label voltLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label voltageOutLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnPeriod;
        private System.Windows.Forms.Button entButton;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox numpadTextBox;
        private System.Windows.Forms.TextBox iptextbox;
        private System.Windows.Forms.RadioButton ipradio;
        private System.Windows.Forms.RadioButton comradio;
        private System.Windows.Forms.Label ep1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label v_dot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ec2;
        private System.Windows.Forms.Label v2;
        private System.Windows.Forms.Label ep2;
        private System.Windows.Forms.Label ec1;
        private System.Windows.Forms.Label v1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabpage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label numberLabel3;
        public System.Windows.Forms.Label numberLabel2;
        public System.Windows.Forms.Label numberLabel1;
        public System.Windows.Forms.Button STOP2;
        public System.Windows.Forms.Button START2;
        public ScottPlot.FormsPlot FormPlot2;
        public ScottPlot.FormsPlot FormPlot;
        public System.Windows.Forms.Button STOP1;
        public System.Windows.Forms.Button START1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox cal_resultbox;
        public System.Windows.Forms.Button cal13;
        public System.Windows.Forms.Button cal5;
        public System.Windows.Forms.Button cal6;
        public System.Windows.Forms.Button cal7;
        public System.Windows.Forms.Button cal8;
        public System.Windows.Forms.Button cal9;
        public System.Windows.Forms.Button cal10;
        public System.Windows.Forms.Button cal11;
        public System.Windows.Forms.Button cal12;
        public System.Windows.Forms.Button cal4;
        public System.Windows.Forms.Button cal3;
        public System.Windows.Forms.Button cal2;
        public System.Windows.Forms.Button cal1;
        public System.Windows.Forms.Button cal17;
        public System.Windows.Forms.Button cal16;
        public System.Windows.Forms.Button cal15;
        public System.Windows.Forms.Button cal14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox cal_textbox;
        public System.Windows.Forms.Button cal18;
        private System.Windows.Forms.Button period_enter;
        private System.Windows.Forms.TextBox period_textbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button measStartButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox ipport;
        private System.Windows.Forms.Button cmSwitch;
        private System.Windows.Forms.Button psSwitch;
        private System.Windows.Forms.Label serialNumber;
        private System.Windows.Forms.Label modelname;
        private System.Windows.Forms.Label fwNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox gatewaylabel;
        private System.Windows.Forms.TextBox subnetlabel;
        private System.Windows.Forms.Button gatewaybutton;
        private System.Windows.Forms.Button subnetbutton;
        private System.Windows.Forms.Button ip1700button;
        private System.Windows.Forms.TextBox port1700;
        private System.Windows.Forms.TextBox ip1700;
        private System.Windows.Forms.Button port1700button;
        public System.Windows.Forms.Button cal19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button ftpButton;
        private System.Windows.Forms.TextBox downloadFileName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label downloadMsg;
        private System.Windows.Forms.Label selectedFileName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label enteredFileName;
        private System.Windows.Forms.Button enterFileButton;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox sampleRateTextBox;
        public System.Windows.Forms.TextBox limitBoxTemp;
        private System.Windows.Forms.Button plotEnterButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox downloadLinkGroup;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button logSaveButton;
        private System.Windows.Forms.Button calLogClearButton;
        private System.Windows.Forms.Label warningMsg;
        private System.Windows.Forms.Panel hiddenPanel;
        private System.Windows.Forms.Label downloadMsgLabel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button cal_sendbutton;
        private System.Windows.Forms.TextBox cal_commandbox;
    }
}

