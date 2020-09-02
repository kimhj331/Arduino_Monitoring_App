using ArduinoWPF.Helpers;
using ArduinoWPF.Models;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using SeriesCollection = LiveCharts.SeriesCollection;
using Timer = System.Timers.Timer;

namespace ArduinoWPF.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        #region 생성자
        public ShellViewModel()
        {
            DisplayName = "Arduino Monitoring App";

            Ports = new BindableCollection<string>();
            Values = new ChartValues<double> { 0 };

            Values.Clear();
            InitControls();
        }
        #endregion

        #region 속성
        public CartesianChart SensorValues = new CartesianChart();

        //selectedPort를 포트명으로 갖는 serial
        SerialPort serial { get; set; }
        private short maxPhotoVal = 1023;

        public ChartValues<double> Values { get; set; }
        List<SensorData> photoDatas = new List<SensorData>();

        Random rand = new Random();
        private double photoValue;
        Timer timer;

        string rtbLog { get; set; }
        public string RtbLog {
            get => rtbLog;
            set
            {
                rtbLog = value;
                NotifyOfPropertyChange(() => RtbLog);
            }
        }

        //연결시간
        string connet_Time { get; set; }
        public string Connet_Time
        {
            get => connet_Time;
            set
            {
                connet_Time = value;
                NotifyOfPropertyChange(() => Connet_Time);
            }
        }


        //연결 가능한 PORT명
        public BindableCollection<string> Ports { get; set; }

        //선택된 port
        string selectedPort;
        public string SelectedPort
        {
            get => selectedPort;
            set
            {
                selectedPort = value;

                NotifyOfPropertyChange(() => SelectedPort);
                NotifyOfPropertyChange(() => CanConnect_Click);
            }
        }

        string portv;
        public string Portv
        {
            get => portv;
            set
            {
                portv = value;
                NotifyOfPropertyChange(() => Portv);
            }
        }

        string serialProt;
        public string SerialProt
        {
            get => serialProt;
            set
            {
                serialProt = value;
                NotifyOfPropertyChange(() => SerialProt);
            }
        }

        DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }


        string txtSensorCount { get; set; }
        public string TxtSensorCount
        {
            get => txtSensorCount;
            set
            {
                txtSensorCount = value;
                NotifyOfPropertyChange(() => TxtSensorCount);
            }
        }

        string btnPortValue { get; set; }
        public string BtnPortValue
        {
            get => btnPortValue;
            set
            {
                btnPortValue = value;
                NotifyOfPropertyChange(() => BtnPortValue);
            }
        }

        public string strPause { get; set; }
        public string StrPause
        {
            get => strPause;
            set
            {
                strPause = value;
                NotifyOfPropertyChange(() => StrPause);
            }
        }

        #endregion

        #region 메소드

        public void InitControls()
        {
            Ports.Clear();
            Values.Clear();
            PhotoValue = 0;

            TxtSensorCount=RtbLog = Connet_Time = SelectedPort = string.Empty;
            BtnPortValue = "PORT";

            if (SerialPort.GetPortNames().Length == 0) Ports.Add("기기를 연결해주세요");
            else 
            {
                foreach (string item in SerialPort.GetPortNames())
                {
                    Ports.Add(item);
                }
            }
            if (Commons.IsPortOpen == true) { serial.Close(); Commons.IsPortOpen = false; }
            if (Commons.IsSimul == true) { timer.Stop(); Commons.IsSimul = false; }

            Commons.NotPause = true;
            Pause_Chart();
            NotifyOfPropertyChange(() => CanDisconnect);
            NotifyOfPropertyChange(() => CanPause_Chart);
            NotifyOfPropertyChange(() => CanClear_Chart);
            NotifyOfPropertyChange(() => StrPause);

        }

        public void DisplayValue(string sVal)
        {
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal) { return; }

                if (Commons.NotPause == false) 
                {
                    SensorData data = new SensorData(DateTime.Now, v);
                    photoDatas.Add(data);
                    InsertDataToDB(data);

                    TxtSensorCount = photoDatas.Count.ToString();
                    PhotoValue = v;

                    string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}\n";

                    RtbLog += $"{item}";
                    BtnPortValue = v.ToString();

                    Values.Add(PhotoValue);

                    BtnPortValue = Commons.IsSimul == false ?  $"{serial.PortName}\n{sVal}": $"{sVal}";

                    NotifyOfPropertyChange(() => Values);
                }
            }
            catch (Exception) { }
        }
        
        public void InsertDataToDB(SensorData data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONN))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };

                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }

        public SeriesCollection PhotoValueSeries { get; set; }

        public double PhotoValue
        {
            get =>photoValue; 
            set
            {
                photoValue = value;
                NotifyOfPropertyChange(() => PhotoValue);
            }
        }

        public void Connect_Click()
        {

            serial = new SerialPort(selectedPort);

            try
            {
                if (selectedPort.Contains("COM1")||selectedPort.Contains("COM2")||selectedPort.Contains("기기를"))
                {
                    MessageBox.Show("포트 연결을 확인하세요");
                    InitControls();
                    return;
                }
                serial.Open();
                Commons.IsPortOpen = true;

                this.Connet_Time = $" {DateTime.Now.ToString($"연결시간 :" + "yyyy-MM-dd hh:mm:ss")}";
                serial.DataReceived += Serial_DataReceived;

                NotifyOfPropertyChange(() => Connet_Time);
                NotifyOfPropertyChange(() => CanConnect_Click);
                NotifyOfPropertyChange(() => CanDisconnect);
                NotifyOfPropertyChange(() => CanPause_Chart);
                NotifyOfPropertyChange(() => CanClear_Chart);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                InitControls();
                return;
            }
           
        }
        public void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            DisplayValue(sVal);
        }
        public bool CanConnect_Click
        {
            get { return ((!string.IsNullOrEmpty(SelectedPort))
                    &&string.IsNullOrEmpty(Connet_Time)); } 
        }

        public void Disconnect()
        {
            InitControls();
            NotifyOfPropertyChange(() => CanDisconnect);
        }
        public bool CanDisconnect
        {
            get { return !(string.IsNullOrEmpty(Connet_Time)); }
        }

        //도움말 창 열기
        IWindowManager manager = new WindowManager();
        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic settings = new ExpandoObject();
            //새창 크기조절
            settings.Height = 300;
            settings.Width = 580;
            settings.SizeToContent = SizeToContent.Manual;

            manager.ShowWindow(new HelpViewModel(), null, settings);
        }

        public void SimulItem_Click(object sender, RoutedEventArgs e)
        {
            timer = new Timer();

            Commons.IsSimul = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
            timer.Start(); 

            this.Connet_Time = $" {DateTime.Now.ToString("시뮬레이션시작: " + "yyyy-MM-dd hh:mm:ss")}";
            NotifyOfPropertyChange(() => CanPause_Chart);
            NotifyOfPropertyChange(() => CanClear_Chart);
        }
        

        public void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        public void Stop_Click(object sender, RoutedEventArgs e)
        {
            InitControls();
        }

        public void Port_Click(object sender, RoutedEventArgs e)
        {
            InitControls();
        }
        public void Pause_Chart()
        {
            StrPause = Commons.NotPause ? "PAUSE" : "RESTART";
            Commons.NotPause = !Commons.NotPause;
            // NotifyOfPropertyChange(DisplayValue(Commons.IsPause));
        }
        public bool CanPause_Chart
        {
            get { return (Commons.IsSimul || Commons.IsPortOpen); }
        }

        public void Clear_Chart()
        {
            InitControls();
        }
        public bool CanClear_Chart
        {
            get { return (Commons.IsSimul || Commons.IsPortOpen); }
        }
        public void Close_App()
        {
            ALL_Close();
        }
        public void Exit_Menu()
        {
            ALL_Close();
        }
        public void ALL_Close()
        {
            InitControls();
            var res = MessageBox.Show("앱을 종료합니다.", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK) { Environment.Exit(0); }
        }
        #endregion
    }

}
