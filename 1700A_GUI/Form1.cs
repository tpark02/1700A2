﻿using ScottPlot.MinMaxSearchStrategies;
using ScottPlot.Renderable;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace _1700A_GUI
{
    public partial class Form1 : Form
    {
        int cnt = 1;
        string currentLine = string.Empty;        
        //StringBuilder sb = new StringBuilder();
        string commandinput = string.Empty;
        private ConcurrentQueue<string> q = new ConcurrentQueue<string>();
        ConcurrentQueue<Tuple<string, string>> tq = new ConcurrentQueue<Tuple<string, string>>();
        bool[] modeonoff = new bool[] { false, false, false, false, false, false, false, false };
        public int delay = 100;
        bool isIP = false, isCom = true;
        TcpClient client = null;
        bool isIPstart = false;
        int send_buf_size = 388;
        int download_porgress = 0;
        int extra_length = 0;
        bool isUpdatePortOpen = false;
        int send_file_cycle = 0;
        bool isGraphON = false, isGraphOn2 = false;
        bool isPS = true;
        bool icTCP = true;
        enum mode
        {
            CM1_RUN = 0, CM2_RUN = 1, PS1_RUN = 2, PS2_RUN = 3, CM1_MODE = 4, CM2_MODE = 5, PS1_MODE = 6, PS2_MODE = 7
        }
        int currentIdxPage = 0;
        string[] displaycmd = new string[] { "cm#:run?", "ps#:run?", "cm#:mode?", "ps#:mode?", "ALL:MEAS?", "PS#:VOLT?" };
        string[] displaycmdip = new string[] { "LOOP;cm#:run?", "LOOP;ps#:run?", "LOOP;cm#:mode?", "LOOP;ps#:mode?", "LOOP;ALL:MEAS?", "LOOP;PS#:VOLT?" };
        public Form1()
        {
            InitializeComponent();

            cmText.Text = "-.--- - mA";
            //wattText.Text = "-.--- - mW" + Environment.NewLine;
            //wattText.Text += Environment.NewLine;
            //wattText.Text += "--.--- -- V" + Environment.NewLine;
            //wattText.Text += Environment.NewLine;
            //wattText.Text += "-.--- - mA";

            connect_button.Enabled = true;
            disconnect_button.Enabled = false;

            numpadTextBox.Text = string.Empty;

            PlotController.f = this;
            CalController.f = this;

            PlotController.init();
            CalController.init();
            delay = 50;
            period_textbox.Text = "100";
            warningMsg.Visible = false;

            tabControl1.Selecting += (( async (object o, TabControlCancelEventArgs e) => {
                var control = (TabControl)o;
                int idx = control.SelectedIndex;
                currentIdxPage = control.SelectedIndex;
                Console.WriteLine(idx.ToString());
                
                isMeasRunning = false;
                send_button.Enabled = false;
                hiddenPanel.Visible = false;

                if (!serialPort.IsOpen && (client == null || !client.Connected))
                {
                    Util.showPopup(this, "Please Connect with 1700A");
                    e.Cancel = true;
                    return;
                }

                if (isGraphON || isGraphOn2)
                {
                    Util.showPopup(this, "Please Stop Graph");
                    e.Cancel = true;
                    return;
                }


                if (currentIdxPage == 0)
                {
                    //await Task.Delay(3000);                    
                    measStartButton_Click(null, null);
                }

                if (idx == 1)
                {
                    sampleDelay = prevSampleDelay;
                    START1.Enabled = false;
                    START2.Enabled = false;

                    await Task.Delay(3000);
                    
                    START1.Enabled = true;
                    START2.Enabled = true;
                }
            }));
                       
        }
        
        private void loopGraphCom()
        {
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    Tuple<string, string> p = null;
                    string temp = string.Empty;
                    while (!q.IsEmpty)
                        q.TryDequeue(out temp);

                    Tuple<string, string> t = null;
                    while (!tq.IsEmpty)
                        tq.TryDequeue(out t);


                    Console.WriteLine("bool : " + isGraphON + ":" + isGraphOn2);

                    while (serialPort.IsOpen && (isGraphON || isGraphOn2))
                    {
                        if (!serialPort.IsOpen)
                        {                            
                            break;
                        }
                        //tq.TryDequeue(out p);                        
                        //if (p != null)
                        {
                            q.Enqueue("ALL:MEAS?" + "\r");

                            if (serialPort.IsOpen)
                            {
                                Console.WriteLine("graph com : " + "ALL:MEAS?");
                                serialPort.Write("ALL:MEAS?" + "\r");
                            }

                            await Task.Delay(sampleDelay);
                            p = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Util.showPopup(this, "loop grap : " + ex.ToString());
                }
            });
        }

        private void loopCOM()
        {
            Task.Factory.StartNew(async () =>
            {               
                while ((serialPort.IsOpen && !isUpdatePortOpen) && isMeasRunning)
                {
                    try
                    {                        
                        Tuple<string, string> p = null;

                        while (!tq.IsEmpty && isMeasRunning)
                        {
                            tq.TryDequeue(out p);                              

                            if (p != null)
                            {
                                q.Enqueue(p.Item1 + "\r");

                                if (serialPort.IsOpen)
                                {
                                    Console.WriteLine("sent : " + p.Item1);
                                    serialPort.Write(p.Item2 + "\r");
                                }
                                    
                                await Task.Delay(delay);
                                p = null;
                            }
                        }

                        if (!isMeasRunning)
                            break;

                        Console.WriteLine("thread running");

                        if (tq.IsEmpty)
                        {
                            foreach (string d in displaycmd)
                            {
                                string cmd = d.Replace('#', '1');
                                tq.Enqueue(new Tuple<string, string>(cmd, cmd));
                            }
                        }                        
                    }
                    catch (Exception ex)
                    {
                        Util.showPopup(this, ex.ToString());
                    }
                }
               
            });
        }
        
        private void commandSend_Click(object sender, EventArgs e)
        {
            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (!connect_button.Enabled)
            {
                if (isCom)
                {
                    if (!commandInput.Text.Equals(""))
                    {
                        //tq.Enqueue(new Tuple<string, string>("output", commandInput.Text));
                        q.Enqueue("output;" + commandInput.Text);
                        serialPort.Write(commandInput.Text + "\r");
                    }                    
                }
                else if (isIP)
                {
                    if (!commandInput.Text.Equals(""))
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            //string message = "CMD;" + commandInput.Text + '\r';
                            //q.Enqueue(message);
                            string res = await sendCmdIP(commandInput.Text);
                            
                            if (logBox.InvokeRequired)
                            {                                                                
                                Console.WriteLine(res);
                                logBox.BeginInvoke(new Action(() =>
                                {
                                    if (res == "" || res.Contains("INVALID"))
                                    {
                                        logBox.AppendText("INVALID", Color.Red);
                                        logBox.ScrollToCaret();
                                        return;
                                    }
                                    res = res.Substring(0, res.Length - 1);
                                    logBox.Text += Environment.NewLine;
                                    logBox.AppendText(commandInput.Text + Environment.NewLine, Color.Black);
                                    logBox.AppendText(res, Color.Green);
                                    logBox.ScrollToCaret();
                                }));
                            }
                            else
                            {
                                if (res == "" || res.Contains("INVALID"))
                                {
                                    logBox.AppendText("INVALID", Color.Red);
                                    logBox.ScrollToCaret();
                                    return;
                                }
                                res = res.Substring(0, res.Length - 1);
                                logBox.Text += Environment.NewLine;
                                logBox.AppendText(commandInput.Text + Environment.NewLine, Color.Black);
                                logBox.AppendText(res, Color.Green);
                                logBox.ScrollToCaret();
                            }
                        });
                    }
                }
            }
            else
            {
                Util.showPopup(this, "Please connect first");
            }
        }

        void connectCOM(bool isFirmware = false)
        {
            try
            {
                if (!serialPort.IsOpen)  //시리얼포트가 열려 있지 않으면
                {

                    serialPort.PortName = comboBox_port.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                    serialPort.BaudRate = 115200;  //보레이트 변경이 필요하면 숫자 변경하기
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Parity = Parity.None;

                    if (!isFirmware)
                    {
                        serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); //이것이 꼭 필요하다
                        serialPort.NewLine = "\r";
                        isUpdatePortOpen = false;
                    }
                    else
                    {
                        //serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived_Update); //이것이 꼭 필요하다
                        isUpdatePortOpen = true;
                    }
                    serialPort.Open();  //시리얼포트 열기

                    //label_status.Text = "포트가 열렸습니다.";
                    comboBox_port.Enabled = false;  //COM포트설정 콤보박스 비활성화

                    if (logBox.Text == "")
                    {
                        logBox.AppendText("OPEN : " + serialPort.PortName, Color.Green);
                    }
                    else
                    {
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText("OPEN : " + serialPort.PortName, Color.Green);
                        logBox.ScrollToCaret();
                    }

                    modeonoff = new bool[8];
                    comboBox_port.Enabled = false;
                    connect_button.Enabled = false;
                    disconnect_button.Enabled = true;

                    string temp = string.Empty;
                    while (!q.IsEmpty)
                        q.TryDequeue(out temp);

                    Tuple<string, string> t = null;
                    while (!tq.IsEmpty)
                        tq.TryDequeue(out t);

                    ipradio.Enabled = false;
                    comradio.Enabled = false;
                }
                else  //시리얼포트가 열려 있으면
                {
                    //label_status.Text = "포트가 이미 열려 있습니다.";
                    //comboBox_port.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Util.showPopup(this, "Please Press Refresh Button and connect");
                return;
            }
        }
        private TaskScheduler _uiTaskScheduler;
        void loopGraphIP()
        {
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    string temp = string.Empty;
                    while (!q.IsEmpty)
                        q.TryDequeue(out temp);

                    Tuple<string, string> t = null;
                    while (!tq.IsEmpty)
                        tq.TryDequeue(out t);

                    isIPstart = true;

                    q.Enqueue("LOOP;ALL:MEAS?");

                    while (client != null && client.Connected && (isGraphON || isGraphOn2))
                    {
                    
                        string res = string.Empty;
                        q.TryPeek(out res);

                        var cmd = res.Split(';');

                        Byte[] data = Encoding.UTF8.GetBytes(cmd[1] + "\r");
                        NetworkStream stream = client.GetStream();
                        if (stream == null) break;

                        stream.Write(data, 0, data.Length);
                        Console.WriteLine("Sent: {0}", cmd[1]);

                        await Task.Delay(sampleDelay);
                        // Receive the server response.
                        // Buffer to store the response bytes.
                        data = new Byte[256];
                        // String to store the response ASCII representation.
                        String responseData = String.Empty;

                        // Read the first batch of the TcpServer response bytes.
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        if (bytes <= 0)
                        {
                            continue;
                        }
                        responseData = Encoding.UTF8.GetString(data, 0, bytes);
                        Console.WriteLine("Received: {0}", responseData);

                        res = string.Empty;
                        //q.TryDequeue(out res);

                        //Console.WriteLine(cmd);                        

                        if (InvokeRequired)
                        {
                            Task uiTask = new Task(() => PlotController.executePlotCommand(responseData));
                            uiTask.RunSynchronously(_uiTaskScheduler);
                        }
                        else
                        {
                            // Do async work
                        }                                                                  
                    }
                }
                catch (Exception ex)
                {
                    //Util.showPopup(this, ex.ToString());
                    return;
                }
            });
        }

        async void loopIP()
        {

            isIPstart = true;

            int idx = 0;
            string c = displaycmdip[0].Replace('#', '1');
            q.Enqueue(c);
            //idx++;

            while (isIPstart && isMeasRunning)
            {
                try
                {
                    string res = string.Empty;
                    q.TryPeek(out res);

                    var cmd = res.Split(';');

                    Byte[] data = Encoding.UTF8.GetBytes(cmd[1] + "\r");
                    NetworkStream stream = client.GetStream();
                    if (stream == null) break;

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", cmd[1]);

                    await Task.Delay(delay);
                    // Receive the server response.
                    // Buffer to store the response bytes.
                    data = new Byte[256];
                    // String to store the response ASCII representation.
                    String responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    if (bytes <= 0)
                    {
                        continue;
                    }
                    responseData = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);

                    res = string.Empty;
                    q.TryDequeue(out res);

                    Console.WriteLine(cmd[1]);

                    if (cmd[0] == "LOOP")
                    {
                        if (res.Contains("cm1:run?"))     // CM 1 ON/OFF
                        {
                            modeonoff[(int)mode.CM1_RUN] = responseData.Contains("ON") ? true : false;
                            if (cmSwitch.InvokeRequired)
                            {
                                cmSwitch.Invoke(new Action(() =>
                                {
                                    cmSwitch.Text = responseData;
                                    cmSwitch.BackColor = responseData.Contains("ON") ? Color.Orange : Color.Gray;
                                }));
                            }
                            else
                            {
                                cmSwitch.Text = responseData;
                                cmSwitch.BackColor = responseData.Contains("ON") ? Color.Orange : Color.Gray;
                            }

                        }
                        else if (res.Contains("cm2:run?"))    // CM 2 ON/OFF
                        {
                            modeonoff[(int)mode.CM2_RUN] = responseData.Contains("ON") ? true : false;
                        }
                        else if (res.Contains("ps1:run?"))    // PS 1 on/off/ocp
                        {
                            modeonoff[(int)mode.PS1_RUN] = responseData.Contains("ON") ? true : false;

                            if (psSwitch.InvokeRequired)
                            {
                                psSwitch.Invoke(new Action(() =>
                                {
                                    psSwitch.Text = responseData;
                                    psSwitch.BackColor = responseData.Contains("ON") ? Color.Orange : Color.Gray;
                                }));
                            }
                            else
                            {
                                psSwitch.Text = responseData;
                                psSwitch.BackColor = responseData.Contains("ON") ? Color.Orange : Color.Gray;
                            }
                        }
                        else if (res.Contains("ps2:run?"))    // PS 2 on/off/ocp
                        {
                            modeonoff[(int)mode.PS2_RUN] = responseData.Contains("ON") ? true : false;
                        }
                        else if (res.Contains("cm1:mode?"))   // CM 1 HI : A / LO : MA
                        {
                            modeonoff[(int)mode.CM1_MODE] = responseData.Contains("HI") ? true : false;
                        }
                        else if (res.Contains("cm2:mode?"))   // CM 2 HI : A/ LO : MA
                        {
                            modeonoff[(int)mode.CM2_MODE] = responseData.Contains("HI") ? true : false;
                        }
                        else if (res.Contains("ps1:mode?"))   // 1 HI : A / LO : MA
                        {
                            modeonoff[(int)mode.PS1_MODE] = responseData.Contains("HI") ? true : false;
                        }
                        else if (res.Contains("ps2:mode?"))   // 2 HI : A / LO : MA
                        {
                            modeonoff[(int)mode.PS2_MODE] = responseData.Contains("HI") ? true : false;
                        }
                        else if (res.Contains("PS1:VOLT?"))
                        {
                            if (voltLabel.InvokeRequired)
                            {
                                voltLabel.Invoke(new Action(() =>
                                {
                                    var v = responseData.Split('\r');
                                    voltLabel.Text = v[0];
                                }));
                            }
                            else
                            {
                                var v = responseData.Split('\r');
                                voltLabel.Text = v[0];
                            }
                        }
                        else if (res.Contains("ALL"))
                        {
                            var arr = responseData.Split(',');
                            Console.WriteLine("1");
                            if (mainPanel.InvokeRequired)
                            {
                                mainPanel.BeginInvoke(new Action(() =>
                                {
                                    if (modeonoff[(int)mode.CM1_RUN] == true)
                                    {
                                        Console.WriteLine("3");
                                        string str1 = double.Parse(arr[0]).ToString("F4") + " mA";
                                        str1 = str1[0] == '-' ? str1 : "  " + str1;
                                        cmText.Text = str1;
                                    }
                                    else
                                    {
                                        cmText.Text = "-.--- - mA";

                                    }

                                    if (modeonoff[(int)mode.PS1_RUN] == true)
                                    {
                                        Console.WriteLine("4");
                                        double watt = (Double.Parse(arr[1]) * Double.Parse(arr[2]));
                                        setMainText(true, watt, arr[1], arr[2]);
                                    }
                                    else
                                    {
                                        setMainText(false, 0.0, "", "");
                                    }
                                }));
                            }
                            else
                            {
                                if (modeonoff[(int)mode.CM1_RUN] == true)
                                {
                                    //Console.WriteLine("3");
                                    string str1 = double.Parse(arr[0]).ToString("F4") + " mA";
                                    str1 = str1[0] == '-' ? str1 : "  " + str1;
                                    cmText.Text = str1;
                                }
                                else
                                {
                                    cmText.Text = "-.--- - mA";

                                }

                                if (modeonoff[(int)mode.PS1_RUN] == true)
                                {
                                    //Console.WriteLine("4");
                                    double watt = (Double.Parse(arr[1]) * Double.Parse(arr[2]));
                                    setMainText(true, watt, arr[1], arr[2]);
                                }
                                else
                                {
                                    setMainText(false, 0.0, "", "");
                                }
                            }

                            if (InvokeRequired)
                            {
                                Console.WriteLine("5");
                                Task uiTask = new Task(() => PlotController.executePlotCommand(responseData));
                                uiTask.RunSynchronously(_uiTaskScheduler);
                            }
                            else
                            {
                                // Do async work
                            }
                        }                       
                    }
                    else
                    {
                        if (logBox.InvokeRequired)
                        {
                            logBox.BeginInvoke(new Action(() =>
                            {
                                //logBox.Text += Environment.NewLine;
                                //logBox.AppendText("CMD : " + commandInput.Text + Environment.NewLine);
                                //logBox.AppendText("RES : " + responseData.Substring(0, responseData.Length - 1), Color.Green);
                                //logBox.ScrollToCaret();
                            }));
                        }
                        else
                        {
                            //logBox.Text += Environment.NewLine;
                            //logBox.AppendText("CMD : " + commandInput.Text + Environment.NewLine);
                            //logBox.AppendText("RES : " + responseData.Substring(0, responseData.Length - 1), Color.Green);
                            //logBox.ScrollToCaret();
                        }

                    }

                    idx = idx > displaycmdip.Length - 1 ? 0 : idx + 1;
                    //Console.WriteLine("idx:" + idx);
                    c = displaycmdip[idx % 6].Replace('#', '1');
                    q.Enqueue(c);
                }
                catch (Exception ex)
                {
                    //Util.showPopup(this, ex.ToString());
                    return;
                }
            }

        }
        void connectIP()
        {
            try
            {
                string ip = iptextbox.Text;
                if (ip == string.Empty)
                {
                    Util.showPopup(this, "Please enter IP.");
                    return;
                }

                if (ipport.Text == string.Empty)
                {
                    Util.showPopup(this, "Please enter port.");
                    return;
                }

                int port = -1;
                Int32.TryParse(ipport.Text, out port);

                if (port == -1)
                {
                    Util.showPopup(this, "Please enter port.");
                    return;
                }

                _uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
                client = new TcpClient();
                client.Connect(ip, port);
                NetworkStream stream = client.GetStream();
                if (stream == null) return;

                disconnect_button.Enabled = true;
                connect_button.Enabled = false;

                string temp = string.Empty;
                while (!q.IsEmpty)
                    q.TryDequeue(out temp);

                Tuple<string, string> t = null;
                while (!tq.IsEmpty)
                    tq.TryDequeue(out t);

                ipradio.Enabled = false;
                comradio.Enabled = false;
            }
            catch (Exception ex)
            {
                Util.showPopup(this, "IP is not connected");
                return;
            }
        }
        private void showMeasCOM()
        {
            try
            {
                cnt = 1;
                currentLine = string.Empty;
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.NewLine = "\r";

                //if (!isUpdate)
                {
                    string temp = string.Empty;
                    while (!q.IsEmpty)
                        q.TryDequeue(out temp);

                    Tuple<string, string> t = null;
                    while (!tq.IsEmpty)
                        tq.TryDequeue(out t);


                    connect_button.Enabled = false;
                    disconnect_button.Enabled = true;
                    isMeasRunning = true;

                    loopCOM();
                    //PS<CH>:VOLT?
                    string cmd = ("PS#:VOLT?").Replace('#', '1');
                    tq.Enqueue(new Tuple<string, string>("VOLT", cmd));
                    //logBox.AppendText(cmd);
                    //PlotController.startGraph();
                }

                
            }
            catch (Exception ex)
            {
                isMeasRunning = false;
                Util.showPopup(this, "Measuring Failed. Please Check the Connection.");
                return;
            }           
        }
        //private async void checkPS(string c)
        //{
        //    string cmd = (c).Replace('#', '1');

        //    Byte[] data = Encoding.UTF8.GetBytes(cmd + "\r");
        //    NetworkStream stream = client.GetStream();
        //    stream.Write(data, 0, data.Length);
        //    Console.WriteLine("Sent: {0}", cmd[1]);
        //    await Task.Delay(30);
        //    // Receive the server response.
        //    // Buffer to store the response bytes.
        //    data = new Byte[256];
        //    // String to store the response ASCII representation.
        //    String responseData = String.Empty;

        //    // Read the first batch of the TcpServer response bytes.
        //    Int32 bytes = stream.Read(data, 0, data.Length);
        //    if (bytes <= 0)
        //    {
        //        return;
        //    }
        //    responseData = Encoding.UTF8.GetString(data, 0, bytes);
        //    Console.WriteLine("Received: {0}", responseData);
        //    Console.WriteLine(cmd);

        //    if (cmd.Contains("ps1:run?"))    // PS 1 on/off/ocp
        //    {
        //        modeonoff[(int)mode.PS1_RUN] = responseData.Contains("ON") ? true : false;
        //    }
        //    else if (cmd.Contains("ps2:run?"))    // PS 2 on/off/ocp
        //    {
        //        modeonoff[(int)mode.PS2_RUN] = responseData.Contains("ON") ? true : false;
        //    }
        //}

        private async Task<string> sendCmdIP(string c)
        {
            string cmd = (c).Replace('#', '1');

            Byte[] data = Encoding.UTF8.GetBytes(cmd + "\r");
            if (client == null) return string.Empty; 
            NetworkStream stream = client.GetStream();
            if (stream == null) return string.Empty;

            stream.Flush();       
            stream.Write(data, 0, data.Length);         
            await Task.Delay(30);
            //Receive the server response.
            // Buffer to store the response bytes.
            data = new Byte[512];
            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            if (bytes <= 0)
            {
                return string.Empty;
            }
            responseData = Encoding.UTF8.GetString(data, 0, bytes);

            Console.WriteLine("Received: {0}", responseData);

            if (cmd.Contains("cm1:run?"))     // CM 1 ON/OFF
            {
                modeonoff[(int)mode.CM1_RUN] = responseData.Contains("ON") ? true : false;
            }
            else if (cmd.Contains("cm2:run?"))    // CM 2 ON/OFF
            {
                modeonoff[(int)mode.CM2_RUN] = responseData.Contains("ON") ? true : false;
            }
            return responseData;
        }
        private async void button_connect_Click(object sender, EventArgs e)  //통신 연결하기 버튼
        {
            if (isCom)
            {
                connectCOM();
                if (!connect_button.Enabled && serialPort.IsOpen)
                {                                                          
                    //Task.Factory.StartNew(async () =>
                    //{
                        string cm = ("cm#:run?").Replace('#', '1');
                        q.Enqueue(cm + "\r");
                        serialPort.Write(cm + "\r");
                        await Task.Delay(30);
                        string ps = ("ps#:run?").Replace('#', '1');
                        q.Enqueue(ps + "\r");
                        serialPort.Write(ps + "\r");
                        await Task.Delay(30);

                        q.Enqueue("*IDN?" + "\r");
                        serialPort.Write("*IDN?" + "\r");

                        // ETH:<IP/SMASK/GWAY/PORT>? 
                        await Task.Delay(30);
                        q.Enqueue("ETH:IP?" + "\r");
                        serialPort.Write("ETH:IP?" + "\r");

                        await Task.Delay(30);
                        q.Enqueue("ETH:SMASK?" + "\r");
                        serialPort.Write("ETH:SMASK?" + "\r");

                        await Task.Delay(30);
                        q.Enqueue("ETH:GWAY?" + "\r");
                        serialPort.Write("ETH:GWAY?" + "\r");

                        await Task.Delay(30);
                        q.Enqueue("ETH:PORT?" + "\r");
                        serialPort.Write("ETH:PORT?" + "\r");
                    //});
                    //
                    await Task.Delay(30);
                    isMeasRunning = false;
                    measStartButton_Click(null, null);
                }
            }
            else if (isIP)
            {
                connectIP();

                if (!connect_button.Enabled && (client != null && client.Connected))
                {
                    //Task.Run(async () =>
                    //{
                    string cmon = await sendCmdIP("cm#:run?");
                    modeonoff[(int)mode.CM1_RUN] = cmon.Contains("ON") ? true : false;
                    cmSwitch.Text = cmon;
                    cmSwitch.BackColor = cmon.Contains("ON") ? Color.Orange : Color.Gray;

                    await Task.Delay(1);
                    string pson = await sendCmdIP("ps#:run?");

                    if (pson.Contains("INVALID"))
                    {
                        isPS = false;
                        //if (psSwitch.InvokeRequired)
                        //{
                        //    psSwitch.Invoke(new Action(() =>
                        //    {
                        //        psSwitch.Enabled = false;
                        //    }));
                        //}
                        //else
                        //{
                            
                        //}

                        psSwitch.Enabled = false;
                        psSwitch.Text = "N/A";
                            START2.Enabled = false;
                            STOP2.Enabled = false;
                            cal5.Enabled = false;
                            cal3.Enabled = false;
                            cal4.Enabled = false;
                            cal6.Enabled = false;
                            cal7.Enabled = false;
                            cal8.Enabled = false;
                            cal9.Enabled = false;
                            cal10.Enabled = false;
                            cal11.Enabled = false;
                            cal12.Enabled = false;                            
                    }
                    else
                    {
                        isPS = true;
                        modeonoff[(int)mode.PS1_RUN] = pson.Contains("ON") ? true : false;
                        psSwitch.Text = pson;
                        psSwitch.BackColor = pson.Contains("ON") ? Color.Orange : Color.Gray;

                        psSwitch.Enabled = true;
                        //psSwitch.Text = "N/A";
                        START2.Enabled = true;
                        STOP2.Enabled = true;
                        cal5.Enabled = true;
                        cal3.Enabled = true;
                        cal4.Enabled = true;
                        cal6.Enabled = true;
                        cal7.Enabled = true;
                        cal8.Enabled = true;
                        cal9.Enabled = true;
                        cal10.Enabled = true;
                        cal11.Enabled = true;
                        cal12.Enabled = true;
                    }

                        await Task.Delay(1);
                        string s = await sendCmdIP("*IDN?");
                        var arr = s.Split(',');

                        string sn = arr[2];
                        string fw = arr[3];
                        string modelName = arr[1];

                        if (serialNumber.InvokeRequired)
                        {
                            serialNumber.BeginInvoke(new Action(() => {
                                serialNumber.Text = sn;                                
                            }));
                        }
                        else
                        {
                            serialNumber.Text = sn;
                        }
                        if (fwNumber.InvokeRequired)
                        {
                            fwNumber.BeginInvoke(new Action(() => {
                                fwNumber.Text = fw;
                            }));
                        }
                        else
                        {
                            fwNumber.Text = fw;
                        }
                        if (modelname.InvokeRequired)
                        {
                            modelname.BeginInvoke(new Action(() => {
                                modelname.Text = modelName;
                            }));
                        }
                        else
                        {
                            modelname.Text = modelName;
                        }

                        await Task.Delay(1);
                        string localip = await sendCmdIP("ETH:IP?");

                        await Task.Delay(1);
                        string smask = await sendCmdIP("ETH:SMASK?");

                        await Task.Delay(1);
                        string gway = await sendCmdIP("ETH:GWAY?");

                        await Task.Delay(1);
                        string ipport = await sendCmdIP("ETH:PORT?");

                        if (ip1700.InvokeRequired)
                        {
                            ip1700.BeginInvoke(new Action(() => {
                                ip1700.Text = localip;
                            }));
                        }
                        else
                        {
                            ip1700.Text = localip;
                        }

                        if (subnetlabel.InvokeRequired)
                        {
                            subnetlabel.BeginInvoke(new Action(() => {
                                subnetlabel.Text = smask;
                            }));
                        }
                        else
                        {
                            subnetlabel.Text = smask;
                        }

                        if (gatewaylabel.InvokeRequired)
                        {
                            gatewaylabel.BeginInvoke(new Action(() => {
                                gatewaylabel.Text = gway;
                            }));
                        }
                        else
                        {
                            gatewaylabel.Text = gway;
                        }

                        if (port1700.InvokeRequired)
                        {
                            port1700.BeginInvoke(new Action(() => {
                                port1700.Text = ipport;
                            }));
                        }
                        else
                        {
                            port1700.Text = ipport;
                        }
                    //});
                    //
                    isMeasRunning = false;
                    measStartButton_Click(null, null);
                }
            }
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            this.Invoke(new EventHandler(serialRecv));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
        }

        bool download_start_flag = false;
        private async void updateRcv(string s)
        {
            try
            {
                string recv_msg = s;

                if (updateCmd == "CONF:UPGRADE:ENABLE")
                {
                    if (recv_msg == "ACK")
                    {
                        updateCmd = string.Empty;
                        initFirmwareUpdate();
                        download_start_flag = true;
                        Task.Run(() => sendFirmwarePacket(recv_msg));
                    }
                    else if (recv_msg == "")
                    {
                    }
                }
                else if (updateCmd == "CONF:UPGRADE:DISABLE")
                {
                    Console.WriteLine("UPDATE ENDED");
                    isUpdatePortOpen = false;
                    download_start_flag = false;
                    download_porgress = 0;
                    serialPort.NewLine = "\r";
                }
                else
                {
                    Task.Run(() => sendFirmwarePacket(recv_msg));
                }
            }
            catch (Exception ex)
            {
                Util.showPopup(this, "An error occurred while updating");
                return;
            }
        }
        private void serialRecv(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            try
            {
                if (isUpdatePortOpen)
                {
                    updateRcv(serialPort.ReadLine());
                    return;
                }

                string cmd = string.Empty;
                q.TryDequeue(out cmd);
                Console.WriteLine("cmd : " + cmd);

                if (cmd == "" || cmd == null)
                {
                    return;
                }

                string currentLine =  serialPort.ReadLine();

                if (currentIdxPage == 1)
                {
                    if (!(isGraphON || isGraphOn2)) return;

                    if (cmd.Contains("ALL:MEAS?\r"))
                    {
                        if (currentLine == "" || currentLine.Contains("INVALID"))
                        {
                            string temp = cmd.Substring(0, cmd.IndexOf('\r'));
                            logBox.Text += Environment.NewLine;
                            logBox.AppendText(temp + Environment.NewLine, Color.Blue);
                            logBox.AppendText("INVALID", Color.Red);
                            logBox.ScrollToCaret();
                            return;
                        }
                        Console.Write("graph :" + currentLine);

                        PlotController.executePlotCommand(currentLine);
                    }
                    return;
                }

                if (cmd.Contains("ETH:IP?"))
                {
                    ip1700.Text = currentLine;
                }
                else if(cmd.Contains("ETH:SMASK?"))
                {
                    subnetlabel.Text = currentLine;
                }
                else if(cmd.Contains("ETH:GWAY?"))
                {
                    gatewaylabel.Text = currentLine;
                }
                else if(cmd.Contains("ETH:PORT?"))
                {
                    port1700.Text = currentLine;
                }
                else if (cmd.Contains("*IDN?\r"))
                {
                    var arr = currentLine.Split(',');

                    string sn = arr[2];
                    string fw = arr[3];
                    string modelName = arr[1];

                    if (serialNumber.InvokeRequired)
                    {
                        serialNumber.BeginInvoke(new Action(() => {
                            serialNumber.Text = sn;
                        }));
                    }
                    else
                    {
                        serialNumber.Text = sn;
                    }
                    if (fwNumber.InvokeRequired)
                    {
                        fwNumber.BeginInvoke(new Action(() => {
                            fwNumber.Text = fw;
                        }));
                    }
                    else
                    {
                        fwNumber.Text = fw;
                    }
                    if (modelname.InvokeRequired)
                    {
                        modelname.BeginInvoke(new Action(() => {
                            modelname.Text = modelName;
                        }));
                    }
                    else
                    {
                        modelname.Text = modelName;
                    }
                }
                else if (cmd.Contains("cm1:run?\r"))     // CM 1 ON/OFF
                {
                    modeonoff[(int) mode.CM1_RUN] = currentLine.Contains("ON") ?  true: false;
                    cmSwitch.Text = currentLine;
                    cmSwitch.BackColor = currentLine.Contains("ON") ? Color.Orange : Color.Gray;

                }
                else if (cmd.Contains("cm2:run?\r"))    // CM 2 ON/OFF
                {
                    modeonoff[(int) mode.CM2_RUN] = currentLine.Contains("ON") ? true : false;
                }
                else if (cmd.Contains("ps1:run?\r"))    // PS 1 on/off/ocp
                {
                    if (currentLine.Contains("INVALID"))
                    {
                        isPS = false;
                        psSwitch.Enabled = false;
                        psSwitch.Text = "N/A";
                        START2.Enabled = false;
                        STOP2.Enabled = false;
                        cal5.Enabled = false;
                        cal3.Enabled = false;
                        cal4.Enabled = false;
                        cal6.Enabled = false;
                        cal7.Enabled = false;
                        cal8.Enabled = false;
                        cal9.Enabled = false;
                        cal10.Enabled = false;
                        cal11.Enabled = false;
                        cal12.Enabled = false;
                        return;
                    }
                    else
                    {
                        isPS = true;
                        psSwitch.Enabled = true;
                        //psSwitch.Text = "N/A";
                        START2.Enabled = true;
                        STOP2.Enabled = true;
                        cal5.Enabled = true;
                        cal3.Enabled = true;
                        cal4.Enabled = true;
                        cal6.Enabled = true;
                        cal7.Enabled = true;
                        cal8.Enabled = true;
                        cal9.Enabled = true;
                        cal10.Enabled = true;
                        cal11.Enabled = true;
                        cal12.Enabled = true;
                    }
                    modeonoff[(int) mode.PS1_RUN] = currentLine.Contains("ON") ? true : false;
                    psSwitch.Text = currentLine;
                    psSwitch.BackColor = currentLine.Contains("ON") ? Color.Orange : Color.Gray;
                }
                else if (cmd.Contains("ps2:run?\r"))    // PS 2 on/off/ocp
                {
                    modeonoff[(int) mode.PS2_RUN] = currentLine.Contains("ON") ? true : false;
                }
                else if (cmd.Contains("cm1:mode?\r"))   // CM 1 HI : A / LO : MA
                {
                    modeonoff[(int) mode.CM1_MODE] = currentLine.Contains("HI") ? true : false;
                }
                else if (cmd.Contains("cm2:mode?\r"))   // CM 2 HI : A/ LO : MA
                {
                    modeonoff[(int) mode.CM2_MODE] = currentLine.Contains("HI") ? true : false;
                }
                else if (cmd.Contains("ps1:mode?\r"))   // 1 HI : A / LO : MA
                {
                    modeonoff[(int) mode.PS1_MODE] = currentLine.Contains("HI") ? true : false;
                }
                else if (cmd.Contains("ps2:mode?\r"))   // 2 HI : A / LO : MA
                {
                    modeonoff[(int) mode.PS2_MODE] = currentLine.Contains("HI") ? true : false;
                }
                else if (cmd.Contains("ALL:MEAS?\r"))
                {
                    if (currentLine == "" || currentLine.Contains("INVALID"))
                    {
                        string temp = cmd.Substring(0, cmd.IndexOf('\r'));
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText(temp + Environment.NewLine, Color.Blue);
                        logBox.AppendText("INVALID", Color.Red);
                        logBox.ScrollToCaret();
                        return;
                    }

                    var arr = currentLine.Split(',');

                    if (arr.Length != 3)
                        return;

                    if (modeonoff[(int) mode.CM1_RUN] == true)
                    {
                        string str1 = double.Parse(arr[0]).ToString("F4") + " mA";
                        str1 = str1[0] == '-' ? str1 : "  " + str1;
                        cmText.Text = str1;                        
                    }
                    else
                    {
                        cmText.Text = "-.--- - mA";
                      
                    }

                    if (modeonoff[(int) mode.PS1_RUN] == true)
                    {
                        double watt = (Double.Parse(arr[1]) * Double.Parse(arr[2]));
                        setMainText(true, watt, arr[1], arr[2]);
                    }
                    else
                    {
                        setMainText(false, 0.0, "", "");
                    }

                    //PlotController.executePlotCommand(currentLine);

                }
                else if (cmd.Contains("output") && !cmd.Contains("cal_output"))
                {
                    if (currentLine == "" || currentLine.Contains("INVALID"))
                    {
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText("INVALID", Color.Red);
                        logBox.ScrollToCaret();
                        return;
                    }
                    var c = cmd.Split(';');
                    if (c.Length >= 2)
                    {
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText(c[1], Color.Black);
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText(currentLine, Color.Green);
                        logBox.ScrollToCaret();
                    }
                }
                else if (cmd.Contains("cal_output"))
                {
                    if (currentLine == "" || currentLine.Contains("INVALID"))
                    {
                        cal_resultbox.Text += Environment.NewLine;
                        cal_resultbox.AppendText("INVALID", Color.Red);
                        cal_resultbox.ScrollToCaret();
                        return;
                    }
                    var c = cmd.Split(';');
                    if (c.Length >= 2)
                    {
                        cal_resultbox.Text += Environment.NewLine;
                        cal_resultbox.AppendText(c[1], Color.Black);
                        cal_resultbox.Text += Environment.NewLine;
                        cal_resultbox.AppendText(currentLine, Color.Green);
                        cal_resultbox.ScrollToCaret();
                    }
                }
                else if (cmd.Contains("cal") && !cmd.Contains("cal_output"))
                {
                    var c = cmd.Split(';');
                    string t = string.Format("[{0}]", DateTime.Now);
                    cal_resultbox.AppendText(t + " " + c[1] + Environment.NewLine);
                    cal_resultbox.AppendText(t + " " + currentLine + Environment.NewLine);
                    cal_resultbox.ScrollToCaret();
                    //logBox.Text += Environment.NewLine;
                    //logBox.AppendText(cmd, Color.Black);
                    //logBox.AppendText(currentLine, Color.Green);
                    //logBox.ScrollToCaret();
                }
                else if (!cmd.Contains("cal") && cmd.Contains("VOLT"))
                {
                    voltLabel.Text = currentLine + " V";
                    //logBox.Text += Environment.NewLine;
                    //logBox.AppendText(cmd, Color.Black);
                    //logBox.AppendText(currentLine, Color.Green);
                    //logBox.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                Util.showPopup(this, ex.ToString());
            }
        }
        
        void initFirmwareUpdate()
        {
            send_file_cycle = filebuffer.Length / send_buf_size;
            extra_length = filebuffer.Length - (send_buf_size * (send_file_cycle));
        }
        void sendFirmwarePacket(string msg)
        {
            updateCmd = string.Empty;
            if (send_file_cycle != 0)
            {
                if (download_porgress > (send_file_cycle))
                {
                    updateCmd = "CONF:UPGRADE:DISABLE";
                    serialPort.Write(updateCmd + "\n");
                    send_file_cycle = 0;
                    download_start_flag = false;

                    return;
                }
                else
                {
                    if (msg == "ACK")
                    {                        
                        byte[] packet = new byte[391];
                        packet[0] = 0x3D;
                        packet[1] = 0x2A;
                        byte checksum_data = 0;

                        if (download_porgress == send_file_cycle)
                        {
                            for (int i = 0; i < send_buf_size; i++)
                            {
                                if (i < extra_length)
                                {
                                    packet[i + 2] = filebuffer[(download_porgress * send_buf_size) + i];
                                    checksum_data ^= packet[i + 2];
                                }
                                else
                                {
                                    packet[i + 2] = 255;
                                    checksum_data ^= packet[i + 2];
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < send_buf_size; i++)
                            {
                                packet[i + 2] = filebuffer[(download_porgress * send_buf_size) + i];
                                checksum_data ^= packet[i + 2];
                            }
                        }
                        packet[390] = checksum_data;

                        serialPort.Write(packet, 0, packet.Length);
                        download_porgress += 1;
                    }
                    else if (currentLine == "NAK")
                        Console.WriteLine("CONF:UPGRADE:ENABLE : NAK");
                    else if (currentLine == "Timeout")
                        Console.WriteLine("No Response");
                }              
            }
        }
        void setMainText(bool isOn, double w, string v, string c)
        {
            if (isOn)
            {
                v_dot.Visible = true;
                var ep = w.ToString("F4").Split('.');
                var volt = double.Parse(v).ToString("F5").Split('.');
                var ec = double.Parse(c).ToString("F4").Split('.');

                voltageOutLabel.Text = double.Parse(v).ToString("F5") + " V";

                ep1.Text = ep[0]; ep2.Text = ep[1];
                v1.Text = volt[0]; v2.Text = volt[1];
                ec1.Text = ec[0]; ec2.Text = ec[1];
            }
            else
            {
                if (currentLine.Contains("OCP"))
                {
                    v_dot.Visible = false;

                    ep1.Text = "-"; ep2.Text = "--- -";
                    v1.Text = ""; v2.Text = "OCP TRIP";
                    voltageOutLabel.Text = "OCP TRIP";
                    ec1.Text = "-"; ec2.Text = "--- -";
                }
                else
                {
                    ep1.Text = "-"; ep2.Text = "--- -";
                    v1.Text = "--"; v2.Text = "--- --";
                    voltageOutLabel.Text = "--. --- -- V";
                    ec1.Text = "-"; ec2.Text = "--- -";
                }
            }
        }
        void disconnectCOM()
        {
            if (isIPstart)
            {
                Util.showPopup(this, "Ethernet is connected.");
                return;
            }
            Console.WriteLine("Disonnect COm");
            try
            {
                if (serialPort.IsOpen)  //시리얼포트가 열려 있으면
                {
                    if (isUpdatePortOpen)
                    {
                        //serialPort.DataReceived -= serialPort_DataReceived_Update;
                    }
                    else
                        serialPort.DataReceived -= serialPort_DataReceived;

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();                   
                }                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (logBox.InvokeRequired)
                {
                    logBox.BeginInvoke(new Action (() => {
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText("CLOSED : " + serialPort.PortName, Color.Red);
                        logBox.ScrollToCaret();

                        connect_button.Enabled = true;
                        disconnect_button.Enabled = false;
                        isUpdatePortOpen = false;
                        comboBox_port.Enabled = true;  //COM포트설정 콤보박스 비활성화

                        isMeasRunning = false;
                        measStartButton.Text = "START";
                        serialPort.Close();  //시리얼포트 닫기

                        ipradio.Enabled = true;
                        comradio.Enabled = true;
                    }));
                }
                else
                {
                    logBox.Text += Environment.NewLine;
                    logBox.AppendText("CLOSED : " + serialPort.PortName, Color.Red);
                    logBox.ScrollToCaret();

                    connect_button.Enabled = true;
                    disconnect_button.Enabled = false;
                    isUpdatePortOpen = false;
                    comboBox_port.Enabled = true;  //COM포트설정 콤보박스 비활성화

                    isMeasRunning = false;
                    measStartButton.Text = "START";
                    serialPort.Close();  //시리얼포트 닫기

                    ipradio.Enabled = true;
                    comradio.Enabled = true;
                }
                
            }
        }

        void disconnectIP()
        {
            if (serialPort.IsOpen)
            {
                Util.showPopup(this, "Serial Port is connected.");
                return;
            }
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                isIPstart = false;
                disconnect_button.Enabled = false;
                connect_button.Enabled = true;
                isMeasRunning = false;
                measStartButton.Text = "START";               
                client.Close();
                client = null;

                ipradio.Enabled = true;
                comradio.Enabled = true;
            }
        }
        private void button_disconnect_Click(object sender, EventArgs e)
        {            
            if (isCom)
            {
                disconnectCOM();
            }
            else if (isIP)
            {
                disconnectIP();
            }                  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_port.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
        }

        private void keypad_Click(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            
            bool isnum = button.Text.IsNumber();

            if (isnum || button.Text.Equals("."))
            {
                Console.WriteLine("number : " + button.Text);
                if (numpadTextBox.Text.Length > 9) return;
                numpadTextBox.Text += button.Text;
            }
            else 
            {
                Console.WriteLine("not number : " + button.Text);

                if (button.Text.Equals("<") && numpadTextBox.Text.Length > 0)
                {
                    numpadTextBox.Text = numpadTextBox.Text.Substring(0, numpadTextBox.Text.Length - 1);
                }
            //    else if (button.Text.Equals("ENT"))
            //    {
            //        double num = -1.0;
            //        double.TryParse(numpadTextBox.Text, out num);

            //        if (numpadTextBox.Text.Equals("") || num < 0) return;

            //        if (num <= 0 || num > 16)
            //        {
            //            Util.showPopup(this, "INVALID NUMBER");
            //            return;
            //        }

            //        if (isCom)
            //        {
            //            string cmd = ("PS#:VOLT ").Replace('#', '1');
            //            cmd += numpadTextBox.Text;
            //            logBox.Text += Environment.NewLine;
            //            logBox.AppendText(cmd);

            //            tq.Enqueue(new Tuple<string, string>("output", cmd));
                       
            //        }
            //        else if (isIP)
            //        {
            //            //PS<CH>:VOLT<space> < 1.5~16 >
            //            Task.Factory.StartNew(async () =>
            //            {
            //                string cmd = ("PS#:VOLT ").Replace('#', '1');
            //                cmd += numpadTextBox.Text;
            //                string message = "CMD;" + cmd + '\r';
            //                logBox.Text += Environment.NewLine;
            //                logBox.AppendText(cmd);

            //                q.Enqueue(message);

            //            });
            //        }
            //    }
            //    numpadTextBox.Text = string.Empty;
            }
        }

        private void ipradio_CheckedChanged(object sender, EventArgs e)
        {
            if (comradio.Checked)
            {
                isCom = true;
                isIP = false;
            }
            else
            {
                isCom = false;
                isIP = true;
            }
        }

        private void START1_Click(object sender, EventArgs e)
        {
            if ((isCom && !serialPort.IsOpen) || (isIP && (client == null || !client.Connected)))
            {
                Util.showPopup(this, "Please connect with 1700A");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }
            // TODO q reset 시켜야함.
            if (!isGraphON)
            {
                if (!isGraphON && !isGraphOn2)
                    PlotController.startGraph();

                isGraphON = true;

                if (serialPort.IsOpen)
                {
                    if (!isGraphOn2)
                    {
                        loopGraphCom();
                    }
                }                    
                else if (client != null && client.Connected)
                {
                    if (!isGraphOn2)
                    {
                        Console.WriteLine("Graph Loop IP 1 START");

                        loopGraphIP();
                    }
                }
                
            }
            PlotController.start1_Click(this, e);

        }

        private async void STOP1_Click(object sender, EventArgs e)
        {
            if ((isCom && !serialPort.IsOpen) || (isIP && (client == null || !client.Connected)))
            {
                Util.showPopup(this, "Please connect with 1700A");
                return;
            }
            isGraphON = false;
            PlotController.stop1_Click(this, e);

            START1.Enabled = false;
            await Task.Delay(3000);
            START1.Enabled = true;

        }

        private void START2_Click(object sender, EventArgs e)
        {
            if ((isCom && !serialPort.IsOpen) || (isIP && (client == null || !client.Connected)))
            {
                Util.showPopup(this, "Please connect with 1700A");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (!isGraphOn2)
            {
                if (!isGraphON && !isGraphOn2)
                    PlotController.startGraph();

                isGraphOn2 = true;

                if (serialPort.IsOpen)
                {
                    if (!isGraphON)
                        loopGraphCom();
                }
                else if (client != null && client.Connected)
                {
                    if (!isGraphON)
                    {
                        Console.WriteLine("Graph Loop IP 2 START");
                        loopGraphIP();
                    }
                }                
            }
            PlotController.start2_Click(this, e);

        }

        private async void STOP2_Click(object sender, EventArgs e)
        {
            if ((isCom && !serialPort.IsOpen) || (isIP && (client == null || !client.Connected)))
            {
                Util.showPopup(this, "Please connect with 1700A");
                return;
            }
            isGraphOn2 = false;
            PlotController.stop2_Click(this, e);

            START2.Enabled = false;
            await Task.Delay(3000);
            START2.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void comradio_CheckedChanged(object sender, EventArgs e)
        {          
            if (ipradio.Checked)
            {
                isCom = false;
                isIP = true;
            }
            else
            {
                isCom = true;
                isIP = false;
            }
        }

        private void cal5_Click(object sender, EventArgs e)
        {
            if (cal_textbox.Text == string.Empty)
            {
                Util.showPopup(this, "Please enter number.");
                return;
            }

            var str = CalController.cmd[4].Split('#');
            string cmd = str[0] + " " + cal_textbox.Text;

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                //tq.Enqueue(new Tuple<string, string>("cal", cmd));
                q.Enqueue("cal;" + cmd);
                serialPort.Write(cmd + "\r");
            }
            else if (isIP)
            {
                //PS<CH>:VOLT<space> < 1.5~16 >
                Task.Factory.StartNew(async () =>
                {                    
                    string res = await sendCmdIP(cmd);
                    if (cal_resultbox.InvokeRequired)
                    {

                        Console.WriteLine(res);
                        cal_resultbox.BeginInvoke(new Action(() =>
                        {
                            var c = cmd;
                            cal_resultbox.Text += Environment.NewLine;

                            string t = string.Format("[{0}]", DateTime.Now);
                            cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                            cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                            cal_resultbox.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        var c = cmd;
                        cal_resultbox.Text += Environment.NewLine;

                        string t = string.Format("[{0}]", DateTime.Now);
                        cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                        cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                        cal_resultbox.ScrollToCaret();
                    }                
                });
            }
        }

        private void cal_textbox_Leave(object sender, EventArgs e)
        {            
        }

        private void period_textbox_Leave(object sender, EventArgs e)
        {
            
        }

        private void period_enter_Click(object sender, EventArgs e)
        {
            int temp = -1;
            bool isnumber = Int32.TryParse(period_textbox.Text, out temp);
            if (!isnumber)
            {
                Util.showPopup(this, "Please enter numbers");
                return;
            }
            delay = temp;
        }
        string updateCmd = string.Empty;
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                Util.showPopup(this, "Please connect with COM");
                return;
            }

            if (client != null && client.Connected)
            {
                Util.showPopup(this, "Please connect with COM");
                return;
            }
            //connectCOM(true);
            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isGraphON || isGraphOn2)
            {
                Util.showPopup(this, "Please Stop Graph");
                return;
            }
            
            var data = Util.OpenFile(fpath);

            if (data != null)
            {
                filebuffer = data;
                //selectedFileName.Text = fpath;
            }
            else
            {
                //selectedFileName.Text = "Not Selected";
                Util.showPopup(this, "Please select a file to update");
                return;
            }

            if (filebuffer != null && serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                //disconnectCOM();

                //if (isUpdatePortOpen)
                //    serialPort.DataReceived -= serialPort_DataReceived_Update;
                //else               
                //serialPort.DataReceived -= serialPort_DataReceived;
                //serialPort.DataReceived += serialPort_DataReceived_Update;
                serialPort.NewLine = "\n";
                isUpdatePortOpen = true;
                updateCmd = "CONF:UPGRADE:ENABLE";
                serialPort.Write(updateCmd + "\n");
                               
            }
        }
        byte[] filebuffer = null;
        string fpath = string.Empty;

        private void openFileButton_Click(object sender, EventArgs e)
        {
            string filename = ShowFileOpenDialog();
            fpath = filename;
            
            if (fpath == string.Empty)
            {
                Util.showPopup(this, "Please select a file");
                return;
            }

            selectedFileName.Text = fpath;
            //var data = Util.OpenFile(filename);

            //if (data != null)
            //{
            //    filebuffer = data;
            //    selectedFileName.Text = filename;
            //}
            //else
            //{
            //    selectedFileName.Text = "Not Selected";
            //}
        }

        public string ShowFileOpenDialog()
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "File Open";
            ofd.FileName = "";
            ofd.Filter = "모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");

                //출력 예제용 로직
                //label1.Text = "File Name  : " + fileName;
                //label2.Text = "Full Name  : " + fileFullName;
                //label3.Text = "File Path  : " + filePath;
                //File경로 + 파일명 리턴
                return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }
        bool isMeasRunning = false;
        private void showMeasIP()
        {
            Task.Factory.StartNew(async () => 
            {
                try
                {
                    string temp = string.Empty;
                    while (!q.IsEmpty)
                        q.TryDequeue(out temp);

                    Tuple<string, string> t = null;
                    while (!tq.IsEmpty)
                        tq.TryDequeue(out t);


                    if (InvokeRequired)
                    {
                        Task uiTask = new Task(() => PlotController.startGraph());
                        uiTask.RunSynchronously(_uiTaskScheduler);
                    }
                    else
                    {
                        // Do async work
                    }
                    isMeasRunning = true;

                    loopIP();
                }
                catch (Exception ex)
                {
                    isMeasRunning=false;
                    Util.showPopup(this, "An error occurred while updating");
                    return;
                }
            });
        }
        private void measStartButton_Click(object sender, EventArgs e)
        {
            if (isGraphON || isGraphOn2)
            {
                Util.showPopup(this, "Please Stop Graph");
                return;
            }
            if (isCom && !serialPort.IsOpen)
            {
                Util.showPopup(this, "Please Connect to 1700A");
                return;
            }

            if (isIP && (client == null || (client != null && !client.Connected)))
            {
                Util.showPopup(this, "Please Connect to 1700A");
                return;
            }

            if (isCom)
            {
                if (!isMeasRunning)
                {
                    showMeasCOM();
                    measStartButton.Text = "STOP";
                    panel1.Enabled = true;
                    send_button.Enabled = false;
                }
                else
                {
                    isMeasRunning = false;
                    measStartButton.Text = "START";
                    panel1.Enabled = false;
                    send_button.Enabled= true;
                }
            }
            else if (isIP)
            {
                if (!isMeasRunning)
                {
                    showMeasIP();
                    measStartButton.Text = "STOP";
                    panel1.Enabled = true;
                    send_button.Enabled = false;
                }
                else
                {
                    isMeasRunning = false;
                    measStartButton.Text = "START";
                    panel1.Enabled = false;
                    send_button.Enabled = true;
                }
            }
        }
        
        private void cmSwitch_Click(object sender, EventArgs e)
        {
            if (!connect_button.Enabled)
            {
                modeonoff[(int)mode.CM1_RUN] = !modeonoff[(int)mode.CM1_RUN];
                cmSwitch.BackColor = modeonoff[(int)mode.CM1_RUN] ? Color.Orange : Color.Gray;
                cmSwitch.Text = modeonoff[(int)mode.CM1_RUN] ? "ON" : "OFF";

                if (isCom)
                {
                    if (isMeasRunning)
                    {
                        bool ison = modeonoff[(int)mode.CM1_RUN];
                        string cmd = ("CM#:RUN ").Replace('#', '1');
                        cmd += ison ? "ON" : "OFF";
                        tq.Enqueue(new Tuple<string, string>("output", cmd));                        
                    }
                    else
                    {
                        bool ison = modeonoff[(int)mode.CM1_RUN];
                        string cm = ("cm#:run ").Replace('#', '1');
                        cm += ison ? "ON" : "OFF";
                        q.Enqueue(cm + "\r");
                        serialPort.Write(cm + "\r");                                                
                    }
                }
                else if (isIP)
                {
                    if (isMeasRunning)
                    {                        
                        Task.Factory.StartNew(async () =>
                        {
                            bool ison = modeonoff[(int)mode.CM1_RUN];
                            string cmd = ("CM#:RUN ").Replace('#', '1');
                            cmd += ison ? "ON" : "OFF";
                            string message = "CMD;" + cmd;
                            q.Enqueue(message);
                        });                        
                    }
                    else
                    {
                        bool ison = modeonoff[(int)mode.CM1_RUN];
                        string cmd = ("CM#:RUN ").Replace('#', '1');
                        cmd += ison ? "ON" : "OFF";
                        sendCmdIP(cmd);            
                    }
                }
            }
            else
            {
                Util.showPopup(this, "Please connect first");
            }
        }

        private void psSwitch_Click(object sender, EventArgs e)
        {
            if (!isPS) return;

            if (!connect_button.Enabled)
            {
                modeonoff[(int)mode.PS1_RUN] = !modeonoff[(int)mode.PS1_RUN];

                psSwitch.BackColor = modeonoff[(int)mode.PS1_RUN] ? Color.Orange : Color.Gray;
                psSwitch.Text = modeonoff[(int)mode.PS1_RUN] ? "ON" : "OFF";

                if (isCom)
                {
                    if (isMeasRunning)
                    {
                        bool ison = modeonoff[(int)mode.PS1_RUN];
                        string cmd = ("PS#:RUN ").Replace('#', '1');
                        cmd += ison ? "ON" : "OFF";
                        tq.Enqueue(new Tuple<string, string>("output", cmd));                        
                    }
                    else
                    {
                        bool ison = modeonoff[(int)mode.PS1_RUN];
                        string ps = ("ps#:run ").Replace('#', '1');
                        ps += ison ? "ON" : "OFF";
                        q.Enqueue(ps + "\r");
                        serialPort.Write(ps + "\r");
                    }
                }
                else if (isIP)
                {                    
                    if (isMeasRunning)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            bool ison = modeonoff[(int)mode.PS1_RUN];
                            string cmd = ("PS#:RUN ").Replace('#', '1');
                            cmd += ison ? "ON" : "OFF";
                            string message = "CMD;" + cmd;
                            q.Enqueue(message);
                        });
                    } 
                    else
                    {
                        bool ison = modeonoff[(int)mode.PS1_RUN];
                        string cmd = ("PS#:RUN ").Replace('#', '1');
                        cmd += ison ? "ON" : "OFF";
                        sendCmdIP(cmd);
                    }
                }
            }
            else
            {
                Util.showPopup(this, "Please connect first");
            }
        }


        //ETH:IP<space><string> 

        //ETH:SMASK<space><string> 

        //ETH:GWAY<space><string> 

        //ETH:PORT<space><d> 


        private void ip1700button_Click(object sender, EventArgs e)
        {
            if (ip1700.Text == string.Empty)
            {
                Util.showPopup(this, "Please Enter ip");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }                
                                
                string cmd = ("ETH:IP ") + ip1700.Text;
                q.Enqueue(cmd + "\r");
                serialPort.Write(cmd + "\r");                
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }
                                                
                string cmd = ("ETH:IP ") + ip1700.Text;
                sendCmdIP(cmd);                
            }
        }

        private void subnetbutton_Click(object sender, EventArgs e)
        {
            if (subnetlabel.Text == string.Empty)
            {
                Util.showPopup(this, "Please Enter Subnet");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }
                                
                string cmd = ("ETH:SMASK ") + subnetlabel.Text;
                q.Enqueue(cmd + "\r");
                serialPort.Write(cmd + "\r");                
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }

                string cmd = ("ETH:SMASK ") + subnetlabel.Text;
                sendCmdIP(cmd);                
            }
        }

        private void gatewaybutton_Click(object sender, EventArgs e)
        {
            if (gatewaylabel.Text == string.Empty)
            {
                Util.showPopup(this, "Please Enter Gateway");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }
                
                string cmd = ("ETH:GWAY ") + gatewaylabel.Text;
                q.Enqueue(cmd + "\r");
                serialPort.Write(cmd + "\r");                
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }
                
                string cmd = ("ETH:GWAY ") + gatewaylabel.Text;
                sendCmdIP(cmd);                
            }
        }

        private void port1700button_Click(object sender, EventArgs e)
        {
            if (port1700.Text == string.Empty)
            {
                Util.showPopup(this, "Please Enter port");
                return;
            }

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }

                string cmd = ("ETH:PORT ") + port1700.Text;
                q.Enqueue(cmd + "\r");
                serialPort.Write(cmd + "\r");                
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }

                string cmd = ("ETH:PORT ") + port1700.Text;
                sendCmdIP(cmd);                
            }
        }
        string fileName = "IP_Change.ini";
        string ftpFilePath = "ftp://mymfg.dothome.co.kr/TC1700_FW/";
        private void ftpButton_Click(object sender, EventArgs e)
        {
            if (fileName == string.Empty)
            {
                Util.showPopup(this, "Please enter a file name");
                return;
            }
           
            download(ftpFilePath + fileName);
        }
        public void download(string p)
        {
            try
            {
                // Replace with your FTP server path
                // Create an FTP request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(p);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UsePassive = true;
                // Set credentials (you can use anonymous logon or provide specific credentials)
                request.Credentials = new NetworkCredential("mymfg", "youlovetescom2020!");
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Stream responseStream = response.GetResponseStream();

                //Get the response from the server
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        byte[] data;
                        using (StreamReader sr = new StreamReader(responseStream))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                sr.BaseStream.CopyTo(ms);
                                data = ms.ToArray();
                            }
                        }

                        /// Create Mode로 FileStream을 오픈합니다.

                        FileStream file = new FileStream(System.Windows.Forms.Application.StartupPath + "//" + fileName, FileMode.Create);



                        /// Byte에 있는 내용을 File에 씁니다.

                        file.Write(data, 0, data.Length);



                        /// 파일을 닫습니다.

                        file.Close();
                    }
                    //using (StreamReader reader = new StreamReader(responseStream))
                    //{
                    //    string fileContent = reader.ReadToEnd();
                    //    Console.WriteLine("Downloaded file content:");
                    //    Console.WriteLine(fileContent);

                    //    //string filePath = "path/to/your/file.txt";
                    //    //string contentToWrite = "This is the content to write into the file.";

                    //    System.IO.File.WriteAllText(System.Windows.Forms.Application.StartupPath + "//" + fileName, fileContent);
                    //}
                    Process.Start(System.Windows.Forms.Application.StartupPath);
                    //downloadMsg.Text = "COMPLETE";
                    //downloadMsg.ForeColor = Color.Green;
                    Console.WriteLine($"Download complete. Status: {response.StatusDescription}");
                    
                    downloadMsgLabel.Text = "Download Successful";
                    downloadMsgLabel.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                downloadMsg.Text = "INCOMPLETE";
                downloadMsg.ForeColor = Color.Red;
                //Util.showPopup(this, "FTP Download : " + ex.Message);
                downloadMsgLabel.Text = "Download Failed";
                downloadMsgLabel.ForeColor = Color.Red;
                return;
            }
        }

        private void enterFileButton_Click(object sender, EventArgs e)
        {
            enteredFileName.Text = fileName = downloadFileName.Text;
        }
        private int sampleDelay = 500, prevSampleDelay = 500;
        private void plotEnterButton_Click(object sender, EventArgs e)
        {
            PlotController.limitBoxTemp = limitBoxTemp.Text;
            prevSampleDelay = sampleDelay = Int32.Parse(sampleRateTextBox.Text);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            comboBox_port.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
        }

        private void logSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "텍스트 파일|*.txt|모든 파일|*.*";
            saveFileDialog1.FilterIndex = 1;

            // 대화상자를 닫기 전에 디렉토리를 이전에 선택한 디렉토리로
            // 복원한지의 여부를 나타납니다.
            saveFileDialog1.RestoreDirectory = true;

            // 확장명을 입력하지 않을 때, 자동으로 확장자를 추가할 수 있습니다.
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "txt";

            // 파일이 이미 존재하면 덮어쓰기 할지를 묻는 대화상자를 표시합니다.
            // 기본값: true
            saveFileDialog1.OverwritePrompt = true;

            // 저장할 위치의 초기 디렉토리를 설정합니다.
            // Environment.CurrentDirectory: 현재 디렉토리를 나타냅니다.
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = saveFileDialog1.FileName;
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(cal_resultbox.Text);
                }
            }
        }

        private void calLogClearButton_Click(object sender, EventArgs e)
        {
            cal_resultbox.Clear();
        }

        private void commandInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMeasRunning) return;

            if (e.KeyCode == Keys.Enter)
            {
                commandSend_Click(null, null);
            }
        }

        private void numpadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void entButton_Click(object sender, EventArgs e)
        {
            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }
               
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }
            }

            //if (button.Text.Equals("ENT"))
            {
                double num = -1.0;
                double.TryParse(numpadTextBox.Text, out num);

                if (numpadTextBox.Text.Equals("") || num < 0) return;

                if (num <= 1 || num > 16)
                {
                    //Util.showPopup(this, "INVALID NUMBER");
                    warningMsg.Visible = true;
                    numpadTextBox.Text = "";

                    Task.Run(async () =>
                    {
                        await Task.Delay(3000);
                        if (warningMsg.InvokeRequired)
                        {
                            warningMsg.BeginInvoke(new Action(() =>
                            {
                                warningMsg.Visible = false;
                            }));
                        }
                        else
                        {
                            warningMsg.Visible = false;
                        }
                    });
                    return;
                }

                if (isCom)
                {
                    string cmd = ("PS#:VOLT ").Replace('#', '1');
                    cmd += numpadTextBox.Text;
                    logBox.Text += Environment.NewLine;
                    logBox.AppendText(cmd);

                    tq.Enqueue(new Tuple<string, string>("output", cmd));

                }
                else if (isIP)
                {
                    //PS<CH>:VOLT<space> < 1.5~16 >
                    //Task.Factory.StartNew(async () =>
                    //{
                        string cmd = ("PS#:VOLT ").Replace('#', '1');
                        cmd += numpadTextBox.Text;
                        string message = "CMD;" + cmd + '\r';
                        logBox.Text += Environment.NewLine;
                        logBox.AppendText(cmd);

                        q.Enqueue(message);


                    //cmd = ("LOOP;PS#:VOLT?").Replace('#', '1');
                    //message = "CMD;" + cmd + '\r';
                    //logBox.Text += Environment.NewLine;
                    //logBox.AppendText(message);
                    //q.Enqueue(cmd + '\r');
                    //});
                }
            //}
            numpadTextBox.Text = string.Empty;
        }
    }
        private static int hiddenclickcnt = 0;
        private void modelname_Click(object sender, EventArgs e)
        {
            if (hiddenclickcnt == 3)
            {
                hiddenPanel.Visible = true;
                hiddenclickcnt = 0;
                Invalidate();
            }

            hiddenclickcnt++;

            Task.Run(async () => {
                await Task.Delay(3000);
                hiddenclickcnt = 0;
            });
        }

        private void cal_sendbutton_Click(object sender, EventArgs e)
        {
            if (cal_commandbox.Text == string.Empty)
            {
                //Util.showPopup(this, "Please enter number.");
                return;
            }            

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }
            string cmd = cal_commandbox.Text;
            string temp = "";

            while (!q.IsEmpty)
                q.TryDequeue(out temp);

            Tuple<string, string> tu = null;
            while (!tq.IsEmpty)
                tq.TryDequeue(out tu);

            if (isCom)
            {
                //tq.Enqueue(new Tuple<string, string>("cal", cmd));
                q.Enqueue("cal_output;" + cal_commandbox.Text);
                serialPort.Write(cal_commandbox.Text + "\r");
            }
            else if (isIP)
            {
                //PS<CH>:VOLT<space> < 1.5~16 >
                Task.Factory.StartNew(async () =>
                {
                    string res = await sendCmdIP(cmd);
                    if (cal_resultbox.InvokeRequired)
                    {

                        Console.WriteLine(res);
                        cal_resultbox.BeginInvoke(new Action(() =>
                        {
                            var c = cmd;
                            cal_resultbox.Text += Environment.NewLine;

                            string t = string.Format("[{0}]", DateTime.Now);
                            cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                            cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                            cal_resultbox.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        var c = cmd;
                        cal_resultbox.Text += Environment.NewLine;

                        string t = string.Format("[{0}]", DateTime.Now);
                        cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                        cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                        cal_resultbox.ScrollToCaret();
                    }
                });
            }
        }

        private void cal_commandbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMeasRunning) return;

            if (e.KeyCode == Keys.Enter)
            {
                cal_sendbutton_Click(null, null);
            }
        }

        private void btn7_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void downloadFileName_Leave(object sender, EventArgs e)
        {
            enteredFileName.Text = fileName = downloadFileName.Text;
        }

        private void cal_Click(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;

            if (isMeasRunning)
            {
                Util.showPopup(this, "Please Stop Auto Measuring");
                return;
            }

            if (isCom)
            {
                if (!serialPort.IsOpen)
                {
                    Util.showPopup(this, "Please Connect Serial Port");
                    return;
                }

                q.Enqueue("cal;" + button.Text);
                serialPort.Write(button.Text + "\r");
            }
            else if (isIP)
            {
                if (client == null || !client.Connected)
                {
                    Util.showPopup(this, "Please Connect IP");
                    return;
                }

                //string cmd = ("ETH:PORT ") + port1700.Text;
                Task.Run(async () => {

                    string res = await sendCmdIP(button.Text);
                    if (cal_resultbox.InvokeRequired)
                    {
                        
                        Console.WriteLine(res);
                        cal_resultbox.BeginInvoke(new Action(() =>
                        {
                            var c = button.Text;
                            cal_resultbox.Text += Environment.NewLine;
                            string t = string.Format("[{0}]", DateTime.Now);
                            cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                            cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                            cal_resultbox.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        var c = button.Text;
                        cal_resultbox.Text += Environment.NewLine;
                        string t = string.Format("[{0}]", DateTime.Now);
                        cal_resultbox.AppendText(t + " " + c + Environment.NewLine);
                        cal_resultbox.AppendText(t + " " + res + Environment.NewLine);
                        cal_resultbox.ScrollToCaret();
                    }
                });               
            }

            //if (isCom)
            //{
            //    if (!button.Text.Equals(""))
            //    {
            //        tq.Enqueue(new Tuple<string, string>("cal", button.Text));
            //    }
            //}
            //else if (isIP)
            //{
            //    if (!button.Text.Equals(""))
            //    {
            //        Task.Factory.StartNew(async () =>
            //        {
            //            string message = "CMD;" + button.Text + '\r';
            //            q.Enqueue(message);
            //        });
            //    }
            //}
        }        
    }
}
