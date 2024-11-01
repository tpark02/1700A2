using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace _1700A_GUI
{
    public static class PlotController
    {
        public static SignalPlot SignalPlot, SignalPlot2, SignalPlot3;
        static readonly double[] Values = new double[100000];
        static readonly double[] Values2 = new double[100000];
        static readonly double[] Values3 = new double[100000];
        public static readonly Dictionary<FormsPlot, double[]> valuesByPlot = new Dictionary<FormsPlot, double[]>();
        public static readonly Dictionary<FormsPlot, List<double[]>> valuesBy2 = new Dictionary<FormsPlot, List<double[]>>();
        public static bool isStop = true, isStop2 = true, isStop3 = true;
        public static bool isRunning = false;
        public static bool[] isPaused = new bool[3] { true, true, true };

        public static double maxLimitY = 0.0000001;
        public static double minLimitY = 0;
        public static double maxLimitY2 = 5;
        public static double minLimitY2 = 0;
        public static double maxLimitY3 = 20;
        public static double minLimitY3 = 0;

        public static int NextPointIndex = 0, NextPointIndex2 = 0, NextPointIndex3 = 0;
        public static int autoRange = 100, autoRange2 = 100, autoRange3 = 100;
        public static int prevRange = 0, prevRange2 = 0;
        public static string limitBoxTemp = "0";

        public static readonly Dictionary<FormsPlot, List<Crosshair>> crossBy2 = new Dictionary<FormsPlot, List<Crosshair>>();

        public static readonly Dictionary<FormsPlot, Crosshair> CrosshairsByPlot = new Dictionary<FormsPlot, Crosshair>();

        public static int flag1 = 0, flag2 = 0, flag3 = 0;
        public static Form1 f = null;

        public static void init()
        {
            // plot1
            //FormPlot.Plot.SetAxisLimits(0, 1, minLimitY, maxLimitY);
            SignalPlot = f.FormPlot.Plot.PlotSignal(Values);
            SignalPlot.YAxisIndex = f.FormPlot.Plot.LeftAxis.AxisIndex;
            f.FormPlot.Plot.LeftAxis.Ticks(true);
            f.FormPlot.Plot.Width = 1060;

            f.FormPlot.Refresh();

            // plot2
            // FormPlot2.Plot.SetAxisLimits(0, 1, minLimitY2, maxLimitY2);
            SignalPlot2 = f.FormPlot2.Plot.PlotSignal(Values2);
            SignalPlot2.YAxisIndex = f.FormPlot2.Plot.LeftAxis.AxisIndex;

            SignalPlot3 = f.FormPlot2.plt.PlotSignal(Values3);
            SignalPlot3.YAxisIndex = f.FormPlot2.Plot.RightAxis.AxisIndex;
            f.FormPlot2.Plot.RightAxis.Ticks(true);

            f.FormPlot2.Plot.Width = 1060;

            f.FormPlot2.Refresh();

            valuesByPlot.Add(f.FormPlot, Values);
            valuesBy2.Add(f.FormPlot2, new List<double[]>() { Values2, Values3 });

            isStop = true;
            isStop2 = true;
            isRunning = false;

            activateStartStop(true);
        }

        public static void activateStartStop(bool isOn)
        {
            f.START1.Enabled = isOn;
            f.START2.Enabled = isOn;
            f.STOP1.Enabled = isOn;
            f.STOP2.Enabled = isOn;
        }

        public static void resetPlot()
        {
            //stx = 0;
            //edx = Int32.Parse(limitBoxTemp);
            maxLimitY = 0.0005;
            minLimitY = -0.0005;
            f.FormPlot.Plot.Clear();

            NextPointIndex = 0;
            autoRange = 1;
            prevRange = 0;

            Array.Clear(Values, 0, Values.Length);
            SignalPlot = f.FormPlot.Plot.AddSignal(Values);

            f.FormPlot.Plot.SetAxisLimits(xMax: 100, xMin: 0, yMin: minLimitY, yMax: maxLimitY);

            f.FormPlot.Refresh();
            //q = new ConcurrentQueue<string>();
        }

        public static void resetPlot2()
        {
            //stx2 = 0;
            //edx2 = Int32.Parse(limitBoxTemp);
            maxLimitY2 = 0.0005;
            minLimitY2 = -0.0005;
            f.FormPlot2.Plot.Clear();

            prevRange2 = 0;
            NextPointIndex2 = 0;
            autoRange2 = 1;

            Array.Clear(Values2, 0, Values2.Length);
            Array.Clear(Values3, 0, Values3.Length);

            SignalPlot2 = f.FormPlot2.Plot.AddSignal(Values2);
            SignalPlot2.YAxisIndex = f.FormPlot2.Plot.LeftAxis.AxisIndex;

            SignalPlot3 = f.FormPlot2.plt.AddSignal(Values3);
            SignalPlot3.YAxisIndex = f.FormPlot2.Plot.RightAxis.AxisIndex;
            f.FormPlot2.Plot.RightAxis.Ticks(true);

            SignalPlot3.MaxRenderIndex = SignalPlot2.MaxRenderIndex = NextPointIndex2;


            f.FormPlot2.Plot.SetAxisLimits(xMax: 100, xMin: 0, yMin: minLimitY2, yMax: maxLimitY2, yAxisIndex: 0);
            f.FormPlot2.Plot.SetAxisLimits(xMax: 100, xMin: 0, yMin: minLimitY3, yMax: maxLimitY3, yAxisIndex: 1);
            f.FormPlot2.Refresh();
            //q = new ConcurrentQueue<string>();
        }

        public static void showGraph1(bool stopPressed = false)
        {
            //RichTextBoxExtensions.addLog("STOP1" + "\n", serialPort1.PortName, "-");

            f.FormPlot.Plot.Clear();
            SignalPlot = f.FormPlot.Plot.AddSignal(Values);

            Crosshair cross = f.FormPlot.Plot.AddCrosshair(0.0, 0.0);

            if (!CrosshairsByPlot.ContainsKey(f.FormPlot))
            {
                CrosshairsByPlot.Add(f.FormPlot, cross);
                f.FormPlot.MouseMove += FormsPlot_MouseMove;
                cross.HorizontalLine.PositionFormatter = customFormatter;
            }
            else
                CrosshairsByPlot[f.FormPlot] = cross;

            int maxRange = 0;
            if (stopPressed)
                maxRange = NextPointIndex == 0 ? 1 : NextPointIndex - 1;
            SignalPlot.MaxRenderIndex = maxRange;
            //FormPlot.Plot.SetAxisLimits(xMax: autoRange + prevRange, xMin: prevRange, yMin: minLimitY, yMax: maxLimitY, yAxisIndex: 0);
            f.FormPlot.Plot.SetAxisLimits(xMax: autoRange, xMin: 0, yMin: minLimitY, yMax: maxLimitY);
            f.FormPlot.Render();
        }
        public static void showGraph2(bool stopPressed = false)
        {
            //RichTextBoxExtensions.addLog("STOP2" + "\n", serialPort1.PortName, "-");

            f.FormPlot2.Plot.Clear();
            SignalPlot2 = f.FormPlot2.Plot.AddSignal(Values2);
            SignalPlot2.YAxisIndex = f.FormPlot2.Plot.LeftAxis.AxisIndex;

            SignalPlot3 = f.FormPlot2.plt.AddSignal(Values3);
            SignalPlot3.YAxisIndex = f.FormPlot2.Plot.RightAxis.AxisIndex;
            f.FormPlot2.Plot.RightAxis.Ticks(true);

            Crosshair c1 = f.FormPlot2.Plot.AddCrosshair(0.0, 0.0);
            c1.YAxisIndex = SignalPlot2.YAxisIndex;
            Crosshair c2 = f.FormPlot2.Plot.AddCrosshair(0.0, 0.0);
            c2.YAxisIndex = SignalPlot3.YAxisIndex;

            if (!crossBy2.ContainsKey(f.FormPlot2))
            {

                crossBy2.Add(f.FormPlot2, new List<Crosshair>() { c1, c2 });

                f.FormPlot2.MouseMove += FormsPlot_MouseMove2;
                c1.HorizontalLine.PositionLabelFont.Size = 11;
                c1.HorizontalLine.PositionFormatter = customFormatter;

                c2.HorizontalLine.PositionLabelFont.Size = 11;
                c2.HorizontalLine.PositionFormatter = customFormatter;
            }
            else
            {
                crossBy2[f.FormPlot2] = new List<Crosshair>() { c1, c2 };
            }

            autoRange2 = NextPointIndex2 % Int32.Parse(limitBoxTemp) == 0 ? 1 : NextPointIndex2 % Int32.Parse(limitBoxTemp);

            int maxRange = 0;
            if (stopPressed)
                maxRange = NextPointIndex2 == 0 ? 1 : NextPointIndex2 - 1;

            SignalPlot3.MaxRenderIndex = SignalPlot2.MaxRenderIndex = maxRange;

            //if (isStop)
            //{
            //    autoRange2 = autoRange2 == 0 ? 1 : autoRange2 - 1;
            //    SignalPlot3.MaxRenderIndex = SignalPlot2.MaxRenderIndex = NextPointIndex2 - 1;
            //}

            f.FormPlot2.Plot.SetAxisLimits(xMax: autoRange2, xMin: 0, yMin: minLimitY2, yMax: maxLimitY2, yAxisIndex: 0);
            f.FormPlot2.Plot.SetAxisLimits(xMax: autoRange2, xMin: 0, yMin: minLimitY3, yMax: maxLimitY3, yAxisIndex: 1);

            f.FormPlot2.Render();
        }

        private static void FormsPlot_MouseMove2(object sender, MouseEventArgs e)
        {
            FormsPlot f = (FormsPlot)sender;
            var c = crossBy2[f];
            var v = valuesBy2[f];

            (double x, double y) = f.GetMouseCoordinates(xAxisIndex: 0, yAxisIndex: 0);
            (double x2, double y2) = f.GetMouseCoordinates(xAxisIndex: 0, yAxisIndex: 1);

            int nx = Convert.ToInt32(x);

            c[0].X = x;

            if (x >= 0)
            {
                c[0].Y = v[0][nx];
                c[1].Y = v[1][nx];
            }

            f.Render();
        }

        private static void FormsPlot_MouseMove(object sender, MouseEventArgs e)
        {
            FormsPlot f = (FormsPlot)sender;
            Crosshair crosshair = CrosshairsByPlot[f];
            double[] v = valuesByPlot[f];
            (double x, double y) = f.GetMouseCoordinates();
            int nx = Convert.ToInt32(x);
            crosshair.X = x;
            if (x >= 0)
                crosshair.Y = v[nx];
            f.Render();
        }
        static string customFormatter(double position)
        {
            if (position == 0)
                return "zero";
            else if (position > 0)
                return position.ToString();
            else
                return position.ToString();
        }
        public static void startGraph()
        {
            limitBoxTemp = f.limitBoxTemp.Text;
            f.delay = f.delay;

            isStop = true;
            isStop2 = true;
            isRunning = false;
            activateStartStop(true);

            isPaused[0] = true;
            isPaused[1] = true;
            f.START1.Text = "START";
            f.START2.Text = "START";
            resetPlot();
            resetPlot2();
            showGraph1();
            showGraph2();
        }
        public static void stopGraph()
        {
            isPaused[0] = true;
            isPaused[1] = true;
            f.START1.Text = "START";
            f.START2.Text = "START";
            isStop = true;
            isStop2 = true;
            isRunning = false;
            activateStartStop(true);
            resetPlot();
            resetPlot2();
            showGraph1();
            showGraph2();
        }
        public static void executePlotCommand(string cmd)
        {
            try
            {
                var v = cmd.Split(',');
                if (v.Length < 3) return;

                if (!isPaused[0])
                {
                    double currMin = f.FormPlot.Plot.GetAxisLimits().XMin;
                    double res = 0;

                    var arr = cmd.Split(',');
                    bool isNum = double.TryParse(arr[0], out res);

                    if (isNum)
                    {
                        if (f.numberLabel1.InvokeRequired)
                        {
                            f.numberLabel1.BeginInvoke(new Action(() =>
                            {
                                f.numberLabel1.Text = res.ToString("0.0000");
                            }));
                        }
                        else
                        {
                            f.numberLabel1.Text = res.ToString("0.0000");
                        }

                        if (res > 0)
                            flag1 |= 2;
                        else
                            flag1 |= 1;

                        Console.WriteLine("flag1 : " + flag1);

                        if (flag1 == 2 && maxLimitY < res)
                        {
                            maxLimitY = Math.Max(maxLimitY, res);
                            maxLimitY = res + (res * .1);
                            minLimitY = 0;
                        }
                        else if (flag1 == 1 && minLimitY > res)
                        {
                            maxLimitY = 0.0000001;
                            minLimitY = Math.Min(minLimitY, res);
                            minLimitY = res + (res * .5);
                        }
                        else if (flag1 == 3)
                        {
                            if (maxLimitY < res)
                            {
                                maxLimitY = res + (res * .5);
                                minLimitY = res + (res * .5);
                                minLimitY = -minLimitY;
                            }

                            if (res < minLimitY)
                            {
                                minLimitY = res + (res * .5);
                                maxLimitY = -minLimitY;
                            }
                        }

                    }

                    if (NextPointIndex > 3600 || NextPointIndex > Int32.Parse(limitBoxTemp))
                    {
                        NextPointIndex = 0;
                        autoRange = 1;
                        prevRange = 0;
                        f.FormPlot.Plot.Clear();
                        Array.Clear(Values, 0, Values.Length);
                        SignalPlot = f.FormPlot.Plot.AddSignal(Values);

                        showGraph1();
                    }
                    Values[NextPointIndex] = res;
                    SignalPlot.MaxRenderIndex = NextPointIndex;
                    f.FormPlot.Plot.SetAxisLimits(xMax: autoRange, xMin: 0, yMin: minLimitY, yMax: maxLimitY, yAxisIndex: 0);
                    //FormPlot.Plot.SetAxisLimits(xMax: autoRange, xMin: 0, yMin: minLimitY, yMax: maxLimitY);

                    NextPointIndex += 1;
                    autoRange = NextPointIndex % Int32.Parse(limitBoxTemp) == 0 ? 1 : NextPointIndex % Int32.Parse(limitBoxTemp);

                    //if (NextPointIndex > autoRange + prevRange)
                    //{
                    //    prevRange = NextPointIndex;
                    //    autoRange = 1;
                    //}

                    f.FormPlot.Plot.Width = 1060;
                    f.FormPlot.Refresh();
                }

                if (!isPaused[1])
                {
                    //double currMin = FormPlot2.Plot.GetAxisLimits(0).XMin;
                    double res = 0;

                    var arr = cmd.Split(',');
                    bool isNum = double.TryParse(arr[1], out res);

                    if (isNum)
                    {
                        if (f.numberLabel2.InvokeRequired)
                        {
                            f.numberLabel2.BeginInvoke(new Action(() =>
                            {
                                f.numberLabel2.Text = res.ToString("0.0000");
                            }));
                        }
                        else
                        {
                            f.numberLabel2.Text = res.ToString("0.0000");
                        }

                        if (res > 0)
                            flag2 |= 2;
                        else if (res < 0)
                            flag2 |= 1;


                        if (flag2 == 2 && maxLimitY2 < res)
                        {
                            maxLimitY2 = Math.Max(maxLimitY2, res);
                            maxLimitY2 = res + (res * .1);
                            minLimitY2 = 0;
                        }
                        else if (flag2 == 1 && minLimitY2 > res)
                        {
                            maxLimitY2 = 0.0000001;
                            minLimitY2 = Math.Min(minLimitY2, res);
                            minLimitY2 = res;
                        }
                        else if (flag2 == 3)
                        {
                            if (maxLimitY2 < res)
                            {
                                maxLimitY2 = res + (res * .5);
                                minLimitY2 = -maxLimitY2;
                            }
                            if (res < minLimitY2)
                            {
                                minLimitY2 = res + (res * .5);
                                maxLimitY2 = -minLimitY2;
                            }
                        }
                    }

                    //currMin = FormPlot3.Plot.GetAxisLimits(1).XMin;
                    double res3 = 0;

                    arr = cmd.Split(',');
                    isNum = double.TryParse(arr[2], out res3);


                    Console.WriteLine("flag2 : " + flag2 + " res1 : " + res + " res2 : " + res3);


                    if (isNum)
                    {
                        f.numberLabel3.Text = res3.ToString("0.00000");
                        if (res3 > 0)
                            flag3 |= 2;
                        else if (res3 < 0)
                            flag3 |= 1;

                        Console.WriteLine("flag3 : " + flag3);

                        if (flag3 == 2 && maxLimitY3 < res3)
                        {
                            maxLimitY3 = Math.Max(maxLimitY3, res3);
                            maxLimitY3 = res3 + (res3 * .1);
                            minLimitY3 = 0;
                        }
                        else if (flag3 == 1 && minLimitY3 > res3)
                        {
                            maxLimitY3 = 0.0000001;
                            minLimitY3 = Math.Min(minLimitY3, res3);
                            minLimitY3 = res3 + (res3 * .5);
                        }
                        else if (flag3 == 3)
                        {
                            if (maxLimitY3 < res3)
                            {
                                maxLimitY3 = res3 + (res3 * .5);
                                minLimitY3 = -maxLimitY3;
                            }
                            if (res3 < minLimitY3)
                            {
                                minLimitY3 = res3 + (res3 * .5);
                                maxLimitY3 = -minLimitY3;
                            }
                        }
                    }

                    if (NextPointIndex2 > 3600 || NextPointIndex2 > Int32.Parse(limitBoxTemp))
                    {
                        NextPointIndex2 = 0;
                        autoRange2 = 1;
                        prevRange2 = 0;

                        Array.Clear(Values2, 0, Values2.Length);
                        Array.Clear(Values3, 0, Values3.Length);

                        f.FormPlot2.Plot.Clear();

                        SignalPlot2 = f.FormPlot2.Plot.AddSignal(Values2);
                        SignalPlot2.YAxisIndex = f.FormPlot2.Plot.LeftAxis.AxisIndex;

                        SignalPlot3 = f.FormPlot2.plt.AddSignal(Values3);
                        SignalPlot3.YAxisIndex = f.FormPlot2.Plot.RightAxis.AxisIndex;
                        f.FormPlot2.Plot.RightAxis.Ticks(true);

                        showGraph2();
                    }

                    Values2[NextPointIndex2] = res;
                    Values3[NextPointIndex2] = res3;
                    SignalPlot3.MaxRenderIndex = SignalPlot2.MaxRenderIndex = NextPointIndex2;

                    f.FormPlot2.Plot.SetAxisLimits(xMax: autoRange2, xMin: 0, yMin: minLimitY2, yMax: maxLimitY2, yAxisIndex: 0);
                    f.FormPlot2.Plot.SetAxisLimits(xMax: autoRange2, xMin: 0, yMin: minLimitY3, yMax: maxLimitY3, yAxisIndex: 1);


                    NextPointIndex2 += 1;
                    autoRange2 = NextPointIndex2 % Int32.Parse(limitBoxTemp) == 0 ? 1 : NextPointIndex2 % Int32.Parse(limitBoxTemp);

                    f.FormPlot2.Plot.Width = 1060;
                    f.FormPlot2.Refresh();
                }
            }
            catch (Exception ex)
            {
                Util.showPopup(Form1.ActiveForm, "execute Plot : " + ex.Message);
                return;
            }
        }
        public static void start1_Click(object sender, EventArgs e)
        {
            if (isStop)
            {
                resetPlot();
                showGraph1();
                isStop = false;
            }

            isPaused[0] = !isPaused[0];
            f.START1.Text = isPaused[0] ? "PAUSED" : "START";
        }

        public static void start2_Click(object sender, EventArgs e)
        {
            if (isStop2)
            {
                resetPlot2();
                showGraph2();
                isStop2 = false;
            }
            isPaused[1] = !isPaused[1];
            f.START2.Text = isPaused[1] ? "PAUSED" : "START";
        }

        public static void stop1_Click(object sender, EventArgs e)
        {
            isStop = true;
            isPaused[0] = true;
            f.START1.Text = "START";

            if (isStop && isStop2) isRunning = false;

            showGraph1(true);
        }

        public static void stop2_Click(object sender, EventArgs e)
        {
            isStop2 = true;
            isPaused[1] = true;
            f.START2.Text = "START";

            if (isStop && isStop2) isRunning = false;

            showGraph2(true);
        }
    }
}
