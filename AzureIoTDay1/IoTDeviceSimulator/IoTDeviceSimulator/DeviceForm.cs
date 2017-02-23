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
        private static DeviceClient _deviceClient;

        public DeviceForm()
        {
            InitializeComponent();
        }

        private void ButtonConnectDevice_Click(object sender, EventArgs e)
        {
            _deviceClient = DeviceClient.Create(TextboxIoTHubHostname.Text,
                new DeviceAuthenticationWithRegistrySymmetricKey(
                    TextboxDeviceId.Text,
                    TextboxPrimaryKey.Text), TransportType.Mqtt);
            ButtonSendOnce.Enabled = true;

            _deviceClient.OpenAsync();
            ReceiveCommands(_deviceClient);
        }

        static async Task ReceiveCommands(DeviceClient deviceClient)
        {
            Microsoft.Azure.Devices.Client.Message receivedMessage = null;

            while (true)
            {
                try
                {
                    receivedMessage = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1));

                    if (receivedMessage != null)
                    {
                        string messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                        
                        MessageBox.Show(string.Format("\t{0}> Received message: {1}", DateTime.Now.ToLocalTime(), messageData));

                        int propCount = 0;
                        foreach (var prop in receivedMessage.Properties)
                        {
                            MessageBox.Show(string.Format("\t\tProperty[{0}> Key={1} : Value={2}", propCount++, prop.Key, prop.Value));
                        }

                        await deviceClient.CompleteAsync(receivedMessage);
                    }
                }
                finally
                {
                    if (receivedMessage != null)
                    {
                        receivedMessage.Dispose();
                    }
                }
            }
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
            string messageString;
            Microsoft.Azure.Devices.Client.Message message;

            _deviceClient = DeviceClient.Create(TextboxIoTHubHostname.Text,
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

            await _deviceClient.SendEventAsync(message);

            return true;
        }
    }

    public class IoTDeviceTelemetryMessage
    {
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}
