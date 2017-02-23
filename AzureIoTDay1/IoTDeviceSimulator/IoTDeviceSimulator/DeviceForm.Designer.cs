namespace IoTDeviceSimulator
{
    partial class DeviceForm
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
            this.TextboxDeviceId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxPrimaryKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextboxIoTHubHostname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxTemperature = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextboxHumidity = new System.Windows.Forms.TextBox();
            this.ButtonSendOnce = new System.Windows.Forms.Button();
            this.LabelSendStatus = new System.Windows.Forms.Label();
            this.ButtonConnectDevice = new System.Windows.Forms.Button();
            this.TextBoxReceivedCommands = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextboxDeviceId
            // 
            this.TextboxDeviceId.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxDeviceId.Location = new System.Drawing.Point(286, 36);
            this.TextboxDeviceId.Name = "TextboxDeviceId";
            this.TextboxDeviceId.Size = new System.Drawing.Size(660, 40);
            this.TextboxDeviceId.TabIndex = 0;
            this.TextboxDeviceId.Text = "JeffTestDevice1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primary Key";
            // 
            // TextboxPrimaryKey
            // 
            this.TextboxPrimaryKey.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPrimaryKey.Location = new System.Drawing.Point(286, 82);
            this.TextboxPrimaryKey.Name = "TextboxPrimaryKey";
            this.TextboxPrimaryKey.Size = new System.Drawing.Size(660, 40);
            this.TextboxPrimaryKey.TabIndex = 2;
            this.TextboxPrimaryKey.Text = "lZo6vO3XbdGEP/Q/QPSkLg==";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "IoT Hub Hostname";
            // 
            // TextboxIoTHubHostname
            // 
            this.TextboxIoTHubHostname.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxIoTHubHostname.Location = new System.Drawing.Point(286, 128);
            this.TextboxIoTHubHostname.Name = "TextboxIoTHubHostname";
            this.TextboxIoTHubHostname.Size = new System.Drawing.Size(660, 40);
            this.TextboxIoTHubHostname.TabIndex = 4;
            this.TextboxIoTHubHostname.Text = "dprrm0220175c9e3.azure-devices.net";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "Temperature";
            // 
            // TextBoxTemperature
            // 
            this.TextBoxTemperature.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTemperature.Location = new System.Drawing.Point(286, 330);
            this.TextBoxTemperature.Name = "TextBoxTemperature";
            this.TextBoxTemperature.Size = new System.Drawing.Size(153, 40);
            this.TextBoxTemperature.TabIndex = 6;
            this.TextBoxTemperature.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "Humidity";
            // 
            // TextboxHumidity
            // 
            this.TextboxHumidity.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxHumidity.Location = new System.Drawing.Point(286, 376);
            this.TextboxHumidity.Name = "TextboxHumidity";
            this.TextboxHumidity.Size = new System.Drawing.Size(153, 40);
            this.TextboxHumidity.TabIndex = 8;
            this.TextboxHumidity.Text = "0";
            // 
            // ButtonSendOnce
            // 
            this.ButtonSendOnce.Enabled = false;
            this.ButtonSendOnce.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSendOnce.Location = new System.Drawing.Point(286, 446);
            this.ButtonSendOnce.Name = "ButtonSendOnce";
            this.ButtonSendOnce.Size = new System.Drawing.Size(160, 58);
            this.ButtonSendOnce.TabIndex = 10;
            this.ButtonSendOnce.Text = "Send Once";
            this.ButtonSendOnce.UseVisualStyleBackColor = true;
            this.ButtonSendOnce.Click += new System.EventHandler(this.ButtonSendOnce_Click);
            // 
            // LabelSendStatus
            // 
            this.LabelSendStatus.AutoSize = true;
            this.LabelSendStatus.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSendStatus.Location = new System.Drawing.Point(468, 459);
            this.LabelSendStatus.Name = "LabelSendStatus";
            this.LabelSendStatus.Size = new System.Drawing.Size(0, 33);
            this.LabelSendStatus.TabIndex = 11;
            // 
            // ButtonConnectDevice
            // 
            this.ButtonConnectDevice.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonConnectDevice.Location = new System.Drawing.Point(286, 185);
            this.ButtonConnectDevice.Name = "ButtonConnectDevice";
            this.ButtonConnectDevice.Size = new System.Drawing.Size(160, 58);
            this.ButtonConnectDevice.TabIndex = 12;
            this.ButtonConnectDevice.Text = "Connect Device";
            this.ButtonConnectDevice.UseVisualStyleBackColor = true;
            this.ButtonConnectDevice.Click += new System.EventHandler(this.ButtonConnectDevice_Click);
            // 
            // TextBoxReceivedCommands
            // 
            this.TextBoxReceivedCommands.Location = new System.Drawing.Point(286, 544);
            this.TextBoxReceivedCommands.Multiline = true;
            this.TextBoxReceivedCommands.Name = "TextBoxReceivedCommands";
            this.TextBoxReceivedCommands.Size = new System.Drawing.Size(660, 172);
            this.TextBoxReceivedCommands.TabIndex = 13;
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1326, 906);
            this.Controls.Add(this.TextBoxReceivedCommands);
            this.Controls.Add(this.ButtonConnectDevice);
            this.Controls.Add(this.LabelSendStatus);
            this.Controls.Add(this.ButtonSendOnce);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextboxHumidity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxTemperature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextboxIoTHubHostname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextboxPrimaryKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextboxDeviceId);
            this.Name = "DeviceForm";
            this.Text = "IoT Hub Device Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxDeviceId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxPrimaryKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextboxIoTHubHostname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxTemperature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextboxHumidity;
        private System.Windows.Forms.Button ButtonSendOnce;
        private System.Windows.Forms.Label LabelSendStatus;
        private System.Windows.Forms.Button ButtonConnectDevice;
        private System.Windows.Forms.TextBox TextBoxReceivedCommands;
    }
}

