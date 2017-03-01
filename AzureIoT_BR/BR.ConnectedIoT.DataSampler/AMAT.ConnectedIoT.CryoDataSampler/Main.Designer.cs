namespace AMAT.ConnectedIoT.CryoDataSampler
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxDeviceKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxIotHubHostname = new System.Windows.Forms.TextBox();
            this.TextBoxDeviceID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelT2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TrackBarT2 = new System.Windows.Forms.TrackBar();
            this.LabelPressure = new System.Windows.Forms.Label();
            this.LabelFrequency = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelTemp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TrackBarFrequency = new System.Windows.Forms.TrackBar();
            this.TrackBarPressure = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackBarTemp = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PeriodTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxMessagesSent = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TextboxLongitude = new System.Windows.Forms.TextBox();
            this.TextboxLatitude = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTemp)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(34, 39);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(939, 709);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TextBoxDeviceKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBoxIotHubHostname);
            this.groupBox1.Controls.Add(this.TextBoxDeviceID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(29, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1434, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Identify Device and Hub";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(28, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 33);
            this.label8.TabIndex = 6;
            this.label8.Text = "Device Key";
            // 
            // TextBoxDeviceKey
            // 
            this.TextBoxDeviceKey.Location = new System.Drawing.Point(277, 181);
            this.TextBoxDeviceKey.Name = "TextBoxDeviceKey";
            this.TextBoxDeviceKey.Size = new System.Drawing.Size(420, 40);
            this.TextBoxDeviceKey.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "IoT Hub Hostname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device ID";
            // 
            // TextBoxIotHubHostname
            // 
            this.TextBoxIotHubHostname.Location = new System.Drawing.Point(277, 123);
            this.TextBoxIotHubHostname.Name = "TextBoxIotHubHostname";
            this.TextBoxIotHubHostname.Size = new System.Drawing.Size(421, 40);
            this.TextBoxIotHubHostname.TabIndex = 1;
            // 
            // TextBoxDeviceID
            // 
            this.TextBoxDeviceID.Location = new System.Drawing.Point(277, 65);
            this.TextBoxDeviceID.Name = "TextBoxDeviceID";
            this.TextBoxDeviceID.Size = new System.Drawing.Size(420, 40);
            this.TextBoxDeviceID.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LabelT2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TrackBarT2);
            this.groupBox2.Controls.Add(this.LabelPressure);
            this.groupBox2.Controls.Add(this.LabelFrequency);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LabelTemp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TrackBarFrequency);
            this.groupBox2.Controls.Add(this.TrackBarPressure);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TrackBarTemp);
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(29, 528);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1434, 770);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4. Set Values and Begin Sending";
            // 
            // LabelT2
            // 
            this.LabelT2.AutoSize = true;
            this.LabelT2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelT2.ForeColor = System.Drawing.Color.White;
            this.LabelT2.Location = new System.Drawing.Point(1104, 67);
            this.LabelT2.Name = "LabelT2";
            this.LabelT2.Size = new System.Drawing.Size(73, 29);
            this.LabelT2.TabIndex = 17;
            this.LabelT2.Text = "xxxxxx";
            this.LabelT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1105, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 29);
            this.label11.TabIndex = 16;
            this.label11.Text = "Temp2";
            // 
            // TrackBarT2
            // 
            this.TrackBarT2.Location = new System.Drawing.Point(1120, 116);
            this.TrackBarT2.Maximum = 300;
            this.TrackBarT2.Name = "TrackBarT2";
            this.TrackBarT2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBarT2.Size = new System.Drawing.Size(90, 578);
            this.TrackBarT2.TabIndex = 15;
            this.TrackBarT2.Scroll += new System.EventHandler(this.TrackBarT2_Scroll);
            // 
            // LabelPressure
            // 
            this.LabelPressure.AutoSize = true;
            this.LabelPressure.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPressure.ForeColor = System.Drawing.Color.White;
            this.LabelPressure.Location = new System.Drawing.Point(1331, 67);
            this.LabelPressure.Name = "LabelPressure";
            this.LabelPressure.Size = new System.Drawing.Size(73, 29);
            this.LabelPressure.TabIndex = 14;
            this.LabelPressure.Text = "xxxxxx";
            this.LabelPressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFrequency
            // 
            this.LabelFrequency.AutoSize = true;
            this.LabelFrequency.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrequency.ForeColor = System.Drawing.Color.White;
            this.LabelFrequency.Location = new System.Drawing.Point(1217, 67);
            this.LabelFrequency.Name = "LabelFrequency";
            this.LabelFrequency.Size = new System.Drawing.Size(73, 29);
            this.LabelFrequency.TabIndex = 13;
            this.LabelFrequency.Text = "xxxxxx";
            this.LabelFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(797, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 29);
            this.label6.TabIndex = 12;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTemp
            // 
            this.LabelTemp.AutoSize = true;
            this.LabelTemp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTemp.ForeColor = System.Drawing.Color.White;
            this.LabelTemp.Location = new System.Drawing.Point(1000, 67);
            this.LabelTemp.Name = "LabelTemp";
            this.LabelTemp.Size = new System.Drawing.Size(73, 29);
            this.LabelTemp.TabIndex = 11;
            this.LabelTemp.Text = "xxxxxx";
            this.LabelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1192, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Frequency";
            // 
            // TrackBarFrequency
            // 
            this.TrackBarFrequency.Location = new System.Drawing.Point(1231, 116);
            this.TrackBarFrequency.Maximum = 300;
            this.TrackBarFrequency.Name = "TrackBarFrequency";
            this.TrackBarFrequency.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBarFrequency.Size = new System.Drawing.Size(90, 578);
            this.TrackBarFrequency.TabIndex = 9;
            this.TrackBarFrequency.Scroll += new System.EventHandler(this.TrackBarFrequency_Scroll);
            // 
            // TrackBarPressure
            // 
            this.TrackBarPressure.Location = new System.Drawing.Point(1331, 116);
            this.TrackBarPressure.Maximum = 300;
            this.TrackBarPressure.Name = "TrackBarPressure";
            this.TrackBarPressure.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBarPressure.Size = new System.Drawing.Size(90, 578);
            this.TrackBarPressure.TabIndex = 8;
            this.TrackBarPressure.Scroll += new System.EventHandler(this.TrackBarPressure_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1318, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pressure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1004, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Temp1";
            // 
            // TrackBarTemp
            // 
            this.TrackBarTemp.Location = new System.Drawing.Point(1019, 116);
            this.TrackBarTemp.Maximum = 300;
            this.TrackBarTemp.Name = "TrackBarTemp";
            this.TrackBarTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBarTemp.Size = new System.Drawing.Size(90, 578);
            this.TrackBarTemp.TabIndex = 1;
            this.TrackBarTemp.Scroll += new System.EventHandler(this.TrackBarTemp_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(39, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 61);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Sending";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.PeriodTextBox);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(785, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(678, 183);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Determine Sampling Period";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(28, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 33);
            this.label7.TabIndex = 3;
            this.label7.Text = "Period (in seconds)";
            // 
            // PeriodTextBox
            // 
            this.PeriodTextBox.Location = new System.Drawing.Point(286, 52);
            this.PeriodTextBox.Name = "PeriodTextBox";
            this.PeriodTextBox.Size = new System.Drawing.Size(161, 40);
            this.PeriodTextBox.TabIndex = 0;
            this.PeriodTextBox.Text = "5";
            this.PeriodTextBox.TextChanged += new System.EventHandler(this.PeriodTextBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.TextBoxMessagesSent);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(29, 1321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1434, 178);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. Start Sending Sample Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(290, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 33);
            this.label9.TabIndex = 8;
            this.label9.Text = "Messages Sent";
            // 
            // TextBoxMessagesSent
            // 
            this.TextBoxMessagesSent.Location = new System.Drawing.Point(478, 84);
            this.TextBoxMessagesSent.Name = "TextBoxMessagesSent";
            this.TextBoxMessagesSent.ReadOnly = true;
            this.TextBoxMessagesSent.Size = new System.Drawing.Size(283, 40);
            this.TextBoxMessagesSent.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.TextboxLongitude);
            this.groupBox5.Controls.Add(this.TextboxLatitude);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(29, 312);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(732, 183);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "2. Device Location";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(28, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 33);
            this.label12.TabIndex = 4;
            this.label12.Text = "Longitude";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(28, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 33);
            this.label13.TabIndex = 3;
            this.label13.Text = "Latitude";
            // 
            // TextboxLongitude
            // 
            this.TextboxLongitude.Location = new System.Drawing.Point(277, 108);
            this.TextboxLongitude.Name = "TextboxLongitude";
            this.TextboxLongitude.Size = new System.Drawing.Size(170, 40);
            this.TextboxLongitude.TabIndex = 1;
            // 
            // TextboxLatitude
            // 
            this.TextboxLatitude.Location = new System.Drawing.Point(277, 50);
            this.TextboxLatitude.Name = "TextboxLatitude";
            this.TextboxLatitude.Size = new System.Drawing.Size(170, 40);
            this.TextboxLatitude.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1577, 1668);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Bio-Rad Device Sample Data Generator";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTemp)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxIotHubHostname;
        private System.Windows.Forms.TextBox TextBoxDeviceID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar TrackBarTemp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar TrackBarFrequency;
        private System.Windows.Forms.TrackBar TrackBarPressure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PeriodTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LabelTemp;
        private System.Windows.Forms.Label LabelPressure;
        private System.Windows.Forms.Label LabelFrequency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBoxMessagesSent;
        private System.Windows.Forms.Label LabelT2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar TrackBarT2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxDeviceKey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TextboxLongitude;
        private System.Windows.Forms.TextBox TextboxLatitude;
    }
}

