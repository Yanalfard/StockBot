using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Frame03
{
    public partial class Main : Form
    {
        //---Global
        private DateTime _timeToHit;
        private Config _config;
        private int _millisecond = 0;
        private List<double> _delays = new List<double>(5);
        private List<double> _sDelays = new List<double>(5);
        private TimeSpan _nowTimeSub = new TimeSpan();
        private bool _isManual = false;
        private DateTime _timeOfHit = new DateTime();
        //---Flags
        private bool _isHit = true;
        private bool _first = true;
        private bool _second = true;
        private bool _third = true;
        private bool _last = true;

        public Main()
        {
            InitializeComponent();
        }

        #region Mouse Click

        //----Mouse click
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;

        private const int MOUSEEVENTF_WHEEL = 0x0800;

        private static void Scroll(int Xposition, int Yposition, int amount)
        {
            SetCursorPos(Xposition, Yposition);
            mouse_event(MOUSEEVENTF_WHEEL, Xposition, Yposition, amount, 0);
        }

        private static void LeftMouseClick(int Xposition, int Yposition)
        {
            SetCursorPos(Xposition, Yposition);
            mouse_event(MOUSEEVENTF_LEFTDOWN, Xposition, Yposition, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Xposition, Yposition, 0, 0);
        }

        private static void RightMouseClick(int Xposition, int Yposition)
        {
            SetCursorPos(Xposition, Yposition);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Xposition, Yposition, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, Xposition, Yposition, 0, 0);
        }
        #endregion

        #region Util

        private void GetConfig()
        {
            string config = File.ReadAllText($@"{Application.StartupPath}\Config.json");
            _config = JsonConvert.DeserializeObject<Config>(config);
        }

        private void SaveConfig()
        {
            File.WriteAllText($@"{Application.StartupPath}\Config.json", JsonConvert.SerializeObject(_config));
        }

        private void Wait(int milliseconds)
        {
            var time = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            time.Interval = milliseconds;
            time.Enabled = true;
            time.Start();

            time.Tick += (s, e) =>
            {
                time.Enabled = false;
                time.Stop();
            };

            while (time.Enabled)
                Application.DoEvents();
        }

        private void Inspect(int x, int y)
        {
            RightMouseClick(x, y);
            Wait(500);
            LeftMouseClick(x + 20, y + _config.InspectPoint);
        }

        private void CopyAll(int x, int y)
        {
            RightMouseClick(x, y);
            Wait(500);
            SetCursorPos(x + 10, y + 10);
            Wait(500);
            LeftMouseClick(x + 15, y + 10);
        }

        private string Between(string source, string firstString, string lastString)
        {
            try
            {
                int pos1 = source.IndexOf(firstString, StringComparison.Ordinal) + firstString.Length;
                source = source.Remove(0, pos1);
                int pos2 = source.IndexOf(lastString, StringComparison.Ordinal);
                string finalString = source.Remove(pos2, source.Length - pos2);
                return finalString;
            }
            catch
            {
                return string.Empty;
            }
        }

        private double SortDateStrings(string sortable, out double noToWrite)
        {
            try
            {
                string[] c = sortable.Split(':');
                double timeOfLanding = Convert.ToDouble(c[c.Length - 1]);
                double timeOfHit = Convert.ToDouble(_timeOfHit.Second + "." + _timeOfHit.Millisecond);
                noToWrite = Math.Round(timeOfHit - timeOfLanding, 3);
                //if (timeOfHit % 15 > 0)
                //{
                return Math.Round(timeOfHit % 15, 3);
                //}
                //return Math.Round(timeOfHit - timeOfLanding, 3);
            }
            catch
            {
                noToWrite = 0;
                return 0;
            }
        }

        private double Average(List<double> arr)
        {
            double sum = 0;
            int count = 0;
            foreach (double i in arr)
                if (i != 0 && i < 2 && i > -2)
                {
                    sum += i;
                    count++;
                }

            return sum / count;
        }

        private DateTime GetTime()
        {
            return DateTime.Now.Subtract(_nowTimeSub);
        }

        private static DateTime GetNetworkTime()
        {
            try
            {
                const string ntpServer = "3.ir.pool.ntp.org";
                var ntpData = new byte[48];
                ntpData[0] = 0x1B;
                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
                var ipEndPoint = new IPEndPoint(addresses[0], 123);
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect(ipEndPoint);
                    socket.ReceiveTimeout = 3000;
                    socket.Send(ntpData);
                    socket.Receive(ntpData);
                    socket.Close();
                }

                const byte serverReplyTime = 40;
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);
                var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                var networkDateTime =
                    (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
                return networkDateTime.ToLocalTime();
            }
            catch
            {
                return new DateTime(0, 0, 0, 0, 0, 0, 0);
            }
        }

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                          ((x & 0x0000ff00) << 8) +
                          ((x & 0x00ff0000) >> 8) +
                          ((x & 0xff000000) >> 24));
        }

        #endregion

        #region Settings

        private void RdIr_CheckedChanged(object sender, EventArgs e)
        {
            _config.IsIr = true;
            SaveConfig();
            Application.Restart();
        }

        private void RdNorm_CheckedChanged(object sender, EventArgs e)
        {
            _config.IsNormal = true;
            SaveConfig();
        }

        private void RdReg_CheckedChanged(object sender, EventArgs e)
        {
            _config.IsNormal = false;
            SaveConfig();
        }

        private void RdEu_CheckedChanged(object sender, EventArgs e)
        {
            _config.IsIr = false;
            SaveConfig();
            Application.Restart();
        }

        private void NumConfig_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumConfig.Text != "-")
                    _millisecond = Convert.ToInt32(NumConfig.Text);
            }
            catch (FormatException)
            {
                NumConfig.Text = NumConfig.Text == string.Empty ? "0" : _millisecond.ToString();
            }
        }

        private void TxtInspect_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _config.InspectPoint = Convert.ToInt32(TxtInspect.Text);
                SaveConfig();
            }
            catch
            {
                // >ignored
            }
        }

        private void BtnStartPoint_Click(object sender, EventArgs e)
        {
            try
            {
                _config.TopPointsX = new int[5];
                _config.TopPointsY = new int[5];
                Opacity = .1;
                WindowState = FormWindowState.Maximized;
                for (int i = 0; i < 5; i++)
                {
                    Wait(2300);
                    BackColor = Color.LimeGreen;
                    Wait(200);
                    _config.TopPointsX[i] = MousePosition.X;
                    _config.TopPointsY[i] = MousePosition.Y;
                    BackColor = Color.FromKnownColor(KnownColor.Control);
                }

                WindowState = FormWindowState.Normal;
                Opacity = 1;
                SaveConfig();
            }
            catch
            {
                // >ignored
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            (int X, int Y) pos = GetPoint();
            _config.SendX = pos.X;
            _config.SendY = pos.Y;
            SaveConfig();
        }

        private void BtnHeader_Click(object sender, EventArgs e)
        {
            (int X, int Y) pos = GetPoint();
            _config.SearchPointX = pos.X;
            _config.SearchPointY = pos.Y;
            SaveConfig();
        }

        private void BtnEndPoint_Click(object sender, EventArgs e)
        {
            (int X, int Y) pos = GetPoint();
            _config.BottomPointX = pos.X;
            _config.BottomPointY = pos.Y;
            SaveConfig();
        }

        private void BtnLastPoint_Click(object sender, EventArgs e)
        {
            (int X, int Y) pos = GetPoint();
            _config.LastPointX = pos.X;
            _config.LastPointY = pos.Y;
            SaveConfig();
        }

        private void BtnInspect_Click(object sender, EventArgs e)
        {
            (int X, int Y) pos = GetPoint();
            _config.RightClickX = pos.X;
            _config.RightClickY = pos.Y;
            SaveConfig();
        }

        #endregion

        private (int X, int Y) GetPoint()
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Opacity = 0;
                Wait(2500);
                (int X, int Y) position = (MousePosition.X, MousePosition.Y);
                WindowState = FormWindowState.Normal;
                Opacity = 1;
                return position;
            }
            catch
            {
                return (0, 0);
            }
        }

        private void Fire()
        {
            try
            {
                LeftMouseClick(_config.SendX, _config.SendY);
                if (_isManual)
                {
                    DateTime time = GetTime();
                    _timeOfHit = time;
                    Rich.Text +=
                        $"{time.Hour}:{time.Minute}:{time.Second}.{time.Millisecond} | ";

                }
                else if (_last)
                {
                    DateTime time = GetTime();
                    _timeOfHit = time;
                    Rich.Text +=
                        $"{time.Hour}:{time.Minute}:{time.Second}.{time.Millisecond} | ";
                }
                else
                {
                    DateTime time = DateTime.Parse(DtTimeToHit.Text).Add(new TimeSpan(0, 0, 0, 0, -1 * (int)((RdNorm.Checked ? _delays.Max(i => i) : Average(_delays)) * 1000)));
                    _timeOfHit = time;
                    Rich.Text +=
                        $"{time.Hour}:{time.Minute}:{time.Second}.{time.Millisecond} | ";
                }
            }
            catch
            {
                // >ignored
            }
        }

        private double FireAndRecordShot(out string time, out double noToWrite)
        {
            try
            {
                noToWrite = 0;
                time = "";
                Wait(300);
                SendKeys.Send("^1");
                Wait(300);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(500);
                LeftMouseClick(_config.SearchPointX, _config.SearchPointY);
                Wait(3000);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                Wait(500);
                LeftMouseClick(_config.LastPointX, _config.LastPointY);
                Wait(300);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);
                Wait(100);
                Scroll(_config.TopPointsX[0], _config.TopPointsY[0], 100000);

                Wait(300);
                LeftMouseClick(_config.RightClickX, _config.RightClickY);
                Wait(300);
                Inspect(_config.RightClickX, _config.RightClickY);
                Wait(300);
                CopyAll(_config.RightClickX, _config.RightClickY);
                Wait(300);
                LeftMouseClick(_config.RightClickX, _config.RightClickY);
                Wait(300);

                string source = Clipboard.GetText();

                int count = Regex.Matches(source, "خطا").Count;
                //#if DEBUG
                //            Rich.Text += $"{count}\n";
                //#endif
                double result = 0;
                if (count <= 5)
                {
                    switch (count)
                    {
                        case 1:
                            Wait(300);
                            LeftMouseClick(_config.TopPointsX[0] - 20, _config.TopPointsY[0]);
                            Wait(300);
                            LeftMouseClick(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            Inspect(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            CopyAll(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            string src1 = Clipboard.GetText();
                            string dateTime1 = Between(src1, "شرح", "محدودیت");
                            time = dateTime1;
                            result = SortDateStrings(dateTime1, out noToWrite);
                            break;
                        case 2:
                            Wait(300);
                            LeftMouseClick(_config.TopPointsX[1] - 20, _config.TopPointsY[1]);
                            Wait(300);
                            LeftMouseClick(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            Inspect(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            CopyAll(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            string src2 = Clipboard.GetText();
                            string dateTime2 = Between(src2, "شرح", "محدودیت");
                            time = dateTime2;
                            result = SortDateStrings(dateTime2, out noToWrite);
                            break;
                        case 3:
                            Wait(300);
                            LeftMouseClick(_config.TopPointsX[2] - 20, _config.TopPointsY[3]);
                            Wait(300);
                            LeftMouseClick(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            Inspect(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            CopyAll(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            string src3 = Clipboard.GetText();
                            string dateTime3 = Between(src3, "شرح", "محدودیت");
                            time = dateTime3;
                            result = SortDateStrings(dateTime3, out noToWrite);
                            break;
                        case 4:
                            Wait(300);
                            LeftMouseClick(_config.TopPointsX[3] - 20, _config.TopPointsY[3]);
                            Wait(300);
                            LeftMouseClick(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            Inspect(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            CopyAll(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            string src4 = Clipboard.GetText();
                            string dateTime4 = Between(src4, "شرح", "محدودیت");
                            time = dateTime4;
                            result = SortDateStrings(dateTime4, out noToWrite);
                            break;
                        case 5:
                            Wait(300);
                            LeftMouseClick(_config.TopPointsX[4], _config.TopPointsY[4]);
                            Wait(300);
                            LeftMouseClick(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            Inspect(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            CopyAll(_config.RightClickX, _config.RightClickY);
                            Wait(300);
                            string src5 = Clipboard.GetText();
                            string dateTime5 = Between(src5, "شرح", "محدودیت");
                            time = dateTime5;
                            result = SortDateStrings(dateTime5, out noToWrite);
                            break;
                    }
                }
                else
                {
                    Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                    Wait(100);
                    Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                    Wait(100);
                    Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                    Wait(100);
                    Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                    Wait(100);
                    Scroll(_config.TopPointsX[0], _config.TopPointsY[0], -100000);
                    Wait(300);
                    LeftMouseClick(_config.BottomPointX, _config.BottomPointY);

                    Wait(300);
                    LeftMouseClick(_config.RightClickX, _config.RightClickY);
                    Wait(300);
                    Inspect(_config.RightClickX, _config.RightClickY);
                    Wait(300);
                    CopyAll(_config.RightClickX, _config.RightClickY);
                    Wait(300);
                    string src = Clipboard.GetText();
                    string dateTime = Between(src, "شرح", "محدودیت");
                    time = dateTime;
                    result = SortDateStrings(dateTime, out noToWrite);
                }
                LeftMouseClick(_config.RightClickX, _config.RightClickY);
                return result;
            }
            catch
            {
                time = "";
                noToWrite = 0;
                return 0;
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime time = GetTime();
                LblTime.Text = time.ToLongTimeString();
                if (!_isHit)
                    if (_isManual)
                    {
                        if (_timeToHit.Subtract(new TimeSpan(0, 0, 0, 0, 50)) <= time)
                        {
                            Fire();
                            _isHit = true;
                            FireAndRecordShot(out _, out _);
                        }
                    }
                    else
                    {
                        if (_timeToHit.AddSeconds(-45) <= time && _first && _second && _third)
                        {
                            Time.Stop();
                            _first = false;
                            SendKeys.Send("^2");
                            Wait(300);
                            Fire();
                            _delays.Add(FireAndRecordShot(out string resStr, out double delay));
                            _sDelays.Add(delay);
                            if (resStr == "")
                                Rich.Text += $"ERROR\n";
                            else
                                Rich.Text += $"{resStr.Split('-')[1].Trim()} | {delay}\n";
                            Time.Start();
                        }
                        else if (_timeToHit.AddSeconds(-30) <= time && !_first && _second && _third)
                        {
                            Time.Stop();
                            _second = false;
                            SendKeys.Send("^2");
                            Wait(300);
                            Fire();
                            _delays.Add(FireAndRecordShot(out string resStr, out double delay));
                            _sDelays.Add(delay);
                            if (resStr == "")
                                Rich.Text += $"ERROR\n";
                            else
                                Rich.Text += $"{resStr.Split('-')[1].Trim()} | {delay}\n";
                            Time.Start();
                        }
                        else if (_timeToHit.AddSeconds(-15) <= time && !_first && !_second && _third)
                        {
                            Time.Stop();
                            SendKeys.Send("^2");
                            Wait(300);
                            Fire();
                            _delays.Add(FireAndRecordShot(out string resStr, out double delay));
                            _sDelays.Add(delay);
                            if (resStr == "")
                                Rich.Text += $"ERROR\n";
                            else
                            {
                                if (_last)
                                    Rich.Text += $"{resStr.Split('-')[1].Trim()} | {delay}\n";
                                else
                                    Rich.Text += $"{resStr.Split('-')[1].Trim()} | {delay}\n";

                            }

                            _third = false;
                            Time.Start();
                        }
                        else if (!_first && !_second && !_third && _last)
                        {
                            int c = (int)((RdNorm.Checked ? _delays.Max(i => i) : Average(_delays)) * 1000) + Convert.ToInt32(_millisecond);
                            //int k = Math.Abs(Math.Abs(c) - Math.Abs((int)(_delays[2] * 1000)));
                            if (_timeToHit.AddMilliseconds(c) <= time)
                            {
                                Time.Stop();
                                _last = false;
                                SendKeys.Send("^2");
                                Wait(300);
                                Fire();
                                FireAndRecordShot(out _, out _);
                                Rich.Text += $"{(int)(Average(_sDelays) * 1000) + _millisecond}\n" +
                                             $"---------------------------\n";
                                Wait(300);
                                WindowState = FormWindowState.Normal;
                                _delays = new List<double>();
                                _isHit = true;
                                _first = true;
                                _second = true;
                                _third = true;
                                _last = true;
                                Time.Start();
                            }
                        }
                    }
            }
            catch
            {
                // >ignored
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                GetConfig();
                if (_config.IsNormal)
                    RdNorm.Checked = true;
                else
                    RdReg.Checked = true;
                if (_config.IsIr)
                    RdIr.Checked = true;
                else
                    RdEu.Checked = true;
                TxtInspect.Text = _config.InspectPoint.ToString();
                _nowTimeSub = _config.IsIr ? DateTime.Now.Subtract(GetNetworkTime()) : new TimeSpan(0, 0, 0, 0);
            }
            catch
            {
                // >ignored
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
                _timeToHit = DateTime.Parse($"{GetTime().ToShortDateString()} {DtTimeToHit.Text}");
                _timeToHit = _timeToHit.AddMilliseconds(_millisecond);
                _delays = new List<double>();
                _sDelays = new List<double>();
                _isHit = false;
                _first = true;
                _second = true;
                _third = true;
                _last = true;
                _isManual = false;
            }
            catch
            {
                // >ignored
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RightMouseClick(_config.SearchPointX, _config.SearchPointY);
                Wait(300);
                SetCursorPos(_config.SearchPointX + 20, _config.SearchPointY + _config.InspectPoint);
            }
            catch (FormatException)
            {
                // >ignored
            }
        }

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtPass.Text == "BoursePort@9923")
                {
                    PnlPassword.Visible = false;
                    PnlMain.Visible = true;
                }
            }
            catch
            {
                // >ignored
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
                _timeToHit = DateTime.Parse($"{GetTime().ToShortDateString()} {DtTimeToHit.Text}");
                _timeToHit = _timeToHit.AddMilliseconds(_millisecond);
                _delays = new List<double>();
                _sDelays = new List<double>();
                _isHit = false;
                _first = true;
                _second = true;
                _third = true;
                _last = true;
                _isManual = true;
            }
            catch
            {
                // >ignored
            }
        }
    }
}
