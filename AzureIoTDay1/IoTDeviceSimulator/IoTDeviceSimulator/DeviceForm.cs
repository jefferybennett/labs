using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace IoTDeviceSimulator
{
    public partial class DeviceForm : Form
    {

        public DeviceForm()
        {
            InitializeComponent();
        }

        private async void ButtonSendOnce_Click(object sender, EventArgs e)
        {
            bool successful = false;

            try
            {
                successful = await SendTelemetry(Convert.ToDecimal(TextBoxTemperature.Text),
                                                 Convert.ToDecimal(TextboxHumidity.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (successful)
            {
                LabelSendStatus.Text = "Telemetry message sent successfully.";
            }
            else
            {
                LabelSendStatus.Text = "Telemetry message failed.";
            }
        }

        private async Task<bool> SendTelemetry(decimal temperature, decimal humidity)
        {
            DeviceClient deviceClient;
            string messageString;
            Microsoft.Azure.Devices.Client.Message message;

            deviceClient = DeviceClient.Create(TextboxIoTHubHostname.Text,
                new DeviceAuthenticationWithRegistrySymmetricKey(
                    TextboxDeviceId.Text,
                    TextboxPrimaryKey.Text));

            IoTDeviceTelemetryMessage telemetry = new IoTDeviceTelemetryMessage
            {
                Temperature = temperature,
                Humidity = humidity
            };

            messageString = JsonConvert.SerializeObject(telemetry);
            message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));

            await deviceClient.SendEventAsync(message);

            return true;
        }
    }

    public class IoTDeviceTelemetryMessage
    {
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}
