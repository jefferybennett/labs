using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using Newtonsoft.Json;

namespace AMAT.ConnectedIoT.CryoDataSampler
{
    public partial class Main : Form
    {

        int T1 = 0;
        int T2 = 0;
        int Frequency = 0;
        int Pressure = 0;
        double Latitude = 38.027203;
        double Longitude = -122.287987;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TextBoxMessagesSent.Text = "0";
            TextboxLatitude.Text = Latitude.ToString();
            TextboxLongitude.Text = Longitude.ToString();

            this.chart1.Series.Clear();

            this.chart1.Titles.Add("Data Generated");

            chart1.Series.Add("T1");
            chart1.Series["T1"].ChartType = SeriesChartType.Line;
            chart1.Series["T1"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["T1"].MarkerColor = Color.Green;
            chart1.Series["T1"].Color = Color.Green;

            chart1.Series.Add("T2");
            chart1.Series["T2"].ChartType = SeriesChartType.Line;
            chart1.Series["T2"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["T2"].MarkerColor = Color.LightGreen;
            chart1.Series["T2"].Color = Color.LightGreen;

            chart1.Series.Add("Pressure");
            chart1.Series["Pressure"].ChartType = SeriesChartType.Line;
            chart1.Series["Pressure"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["Pressure"].MarkerColor = Color.Brown;
            chart1.Series["Pressure"].Color = Color.Brown;

            chart1.Series.Add("Inverter Frequency");
            chart1.Series["Inverter Frequency"].ChartType = SeriesChartType.Line;
            chart1.Series["Inverter Frequency"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["Inverter Frequency"].MarkerColor = Color.Black;
            chart1.Series["Inverter Frequency"].Color = Color.Black;

            chart1.Series.Add("Pressure Threshold");
            chart1.Series["Pressure Threshold"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Pressure Threshold"].MarkerStyle = MarkerStyle.None;
            chart1.Series["Pressure Threshold"].MarkerColor = Color.Red;
            chart1.Series["Pressure Threshold"].Color = Color.Red;

            chart1.Series.Add("Frequency Threshold");
            chart1.Series["Frequency Threshold"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Frequency Threshold"].MarkerStyle = MarkerStyle.None;
            chart1.Series["Frequency Threshold"].MarkerColor = Color.Blue;
            chart1.Series["Frequency Threshold"].Color = Color.Blue;

            LabelTemp.Text = "0";
            LabelT2.Text = "0";
            LabelPressure.Text = "0";
            LabelFrequency.Text = "0";
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await EventTelemetry(T1, T2, Pressure, Frequency);
            TextBoxMessagesSent.Text = (Convert.ToInt32(TextBoxMessagesSent.Text)+4).ToString();

            // Data array
            int[] temp1Array = { T1, 1 };
            int[] temp2Array = { T2, 1 };
            int[] pressureArray = { Pressure, 1 };
            int[] frequencyArray = { Frequency, 1 };
            int[] sv1Array = { 75, 1 };
            int[] resetArray = { 60, 1 };

            chart1.Series[0].Points.AddY(temp1Array[0]);
            chart1.Series[1].Points.AddY(temp2Array[0]);
            chart1.Series[2].Points.AddY(pressureArray[0]);
            chart1.Series[3].Points.AddY(frequencyArray[0]);
            chart1.Series[4].Points.AddY(sv1Array[0]);
            chart1.Series[5].Points.AddY(resetArray[0]);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "Stop Sending")
            {
                button1.Text = "Stop Sending";
                button1.ForeColor = Color.Red;
                timer1.Start();
            }
            else
            {
                button1.Text = "Start Sending";
                button1.ForeColor = Color.Green;
                timer1.Stop();
            }
        }

        private void TrackBarTemp_Scroll(object sender, EventArgs e)
        {
            T1 = TrackBarTemp.Value;
            LabelTemp.Text = TrackBarTemp.Value.ToString();
        }

        private void TrackBarFrequency_Scroll(object sender, EventArgs e)
        {
            Frequency = TrackBarFrequency.Value;
            LabelFrequency.Text = TrackBarFrequency.Value.ToString();
        }

        private void TrackBarPressure_Scroll(object sender, EventArgs e)
        {
            Pressure = TrackBarPressure.Value;
            LabelPressure.Text = TrackBarPressure.Value.ToString();
        }

        private void PeriodTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PeriodTextBox.Text != string.Empty)
            {
                timer1.Interval = Convert.ToInt32(PeriodTextBox.Text) * 1000;
            }
        }

        private async Task<bool> EventTelemetry(double _t1, double _t2, double _pressure, double _frequency)
        {
            BRDeviceTelemetry telemetry;
            string messageString;
            Microsoft.Azure.Devices.Client.Message message;

            DeviceClient deviceClient = DeviceClient.Create(TextBoxIotHubHostname.Text,
                new DeviceAuthenticationWithRegistrySymmetricKey(
                    TextBoxDeviceID.Text.Trim(),
                    TextBoxDeviceKey.Text));

            telemetry = new BRDeviceTelemetry
            {
                DeviceId = TextBoxDeviceID.Text.Trim(),
                Temperature1 = _t1,
                Temperature2 = _t2,
                Pressure = _pressure,
                Frequency = _frequency,
                Latitude = Latitude,
                Longitude = Longitude
            };

            messageString = JsonConvert.SerializeObject(telemetry);
            message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));

            try
            {
                await deviceClient.SendEventAsync(message);
            }
            catch (Exception ex)
            {
                return true;
            }

            return true;

        }

        private void TrackBarT2_Scroll(object sender, EventArgs e)
        {
            T2 = TrackBarT2.Value;
            LabelT2.Text = TrackBarT2.Value.ToString();
        }

    }

    public class BRDeviceTelemetry
    {
        public string DeviceId { get; set; }
        public double Temperature1 { get; set; }
        public double Temperature2 { get; set; }
        public double Pressure { get; set; }
        public double Frequency { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
