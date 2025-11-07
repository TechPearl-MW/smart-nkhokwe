namespace desktop_app.Forms
{
    partial class Home
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.labelAlert = new System.Windows.Forms.Label();
            this.labelAlerts = new System.Windows.Forms.Label();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2RadialGauge1 = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.panel4 = new System.Windows.Forms.Panel();
            this.guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2RadialGauge3 = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MapDisplay = new Guna.UI2.WinForms.Guna2Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelMoisture = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2RadialGauge4 = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.labelDistance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2RadialGauge2 = new Guna.UI2.WinForms.Guna2RadialGauge();
            this.panel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MapDisplay.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 151);
            this.panel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.tableLayoutPanel1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1067, 151);
            this.guna2Panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 151);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gunaPictureBox1);
            this.panel6.Controls.Add(this.labelAlert);
            this.panel6.Controls.Add(this.labelAlerts);
            this.panel6.Controls.Add(this.guna2VSeparator1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(750, 4);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(313, 143);
            this.panel6.TabIndex = 4;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPictureBox1.Image = global::desktop_app.Properties.Resources.home_page_white;
            this.gunaPictureBox1.Location = new System.Drawing.Point(13, 0);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(145, 143);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gunaPictureBox1.TabIndex = 3;
            this.gunaPictureBox1.TabStop = false;
            // 
            // labelAlert
            // 
            this.labelAlert.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAlert.AutoSize = true;
            this.labelAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlert.ForeColor = System.Drawing.Color.White;
            this.labelAlert.Location = new System.Drawing.Point(228, 53);
            this.labelAlert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlert.Name = "labelAlert";
            this.labelAlert.Size = new System.Drawing.Size(0, 76);
            this.labelAlert.TabIndex = 2;
            this.labelAlert.Click += new System.EventHandler(this.label5_Click);
            // 
            // labelAlerts
            // 
            this.labelAlerts.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAlerts.AutoSize = true;
            this.labelAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlerts.ForeColor = System.Drawing.Color.White;
            this.labelAlerts.Location = new System.Drawing.Point(168, 26);
            this.labelAlerts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlerts.Name = "labelAlerts";
            this.labelAlerts.Size = new System.Drawing.Size(59, 20);
            this.labelAlerts.TabIndex = 2;
            this.labelAlerts.Text = "Alerts";
            this.labelAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2VSeparator1.FillColor = System.Drawing.Color.White;
            this.guna2VSeparator1.Location = new System.Drawing.Point(0, 0);
            this.guna2VSeparator1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(13, 143);
            this.guna2VSeparator1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelHumidity);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.guna2RadialGauge1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(377, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(365, 143);
            this.panel5.TabIndex = 3;
            // 
            // labelHumidity
            // 
            this.labelHumidity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidity.ForeColor = System.Drawing.Color.White;
            this.labelHumidity.Location = new System.Drawing.Point(161, 47);
            this.labelHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(131, 67);
            this.labelHumidity.TabIndex = 2;
            this.labelHumidity.Text = "0m³";
            this.labelHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelHumidity.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(245, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Humidity";
            // 
            // guna2RadialGauge1
            // 
            this.guna2RadialGauge1.ArrowColor = System.Drawing.Color.White;
            this.guna2RadialGauge1.ArrowThickness = 1;
            this.guna2RadialGauge1.FillColor = System.Drawing.Color.White;
            this.guna2RadialGauge1.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.guna2RadialGauge1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2RadialGauge1.Location = new System.Drawing.Point(4, 2);
            this.guna2RadialGauge1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2RadialGauge1.MinimumSize = new System.Drawing.Size(40, 37);
            this.guna2RadialGauge1.Name = "guna2RadialGauge1";
            this.guna2RadialGauge1.ProgressColor = System.Drawing.Color.Cyan;
            this.guna2RadialGauge1.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2RadialGauge1.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge1.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge1.ProgressThickness = 10;
            this.guna2RadialGauge1.ShowPercentage = false;
            this.guna2RadialGauge1.Size = new System.Drawing.Size(149, 149);
            this.guna2RadialGauge1.TabIndex = 1;
            this.guna2RadialGauge1.Value = 60;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.guna2VSeparator2);
            this.panel4.Controls.Add(this.labelTemperature);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.guna2RadialGauge3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 143);
            this.panel4.TabIndex = 2;
            // 
            // guna2VSeparator2
            // 
            this.guna2VSeparator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2VSeparator2.FillColor = System.Drawing.Color.White;
            this.guna2VSeparator2.Location = new System.Drawing.Point(352, 0);
            this.guna2VSeparator2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2VSeparator2.Name = "guna2VSeparator2";
            this.guna2VSeparator2.Size = new System.Drawing.Size(13, 143);
            this.guna2VSeparator2.TabIndex = 4;
            // 
            // labelTemperature
            // 
            this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.White;
            this.labelTemperature.Location = new System.Drawing.Point(120, 47);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(129, 67);
            this.labelTemperature.TabIndex = 2;
            this.labelTemperature.Text = "0°C";
            this.labelTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelTemperature.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(181, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Temperature";
            // 
            // guna2RadialGauge3
            // 
            this.guna2RadialGauge3.ArrowColor = System.Drawing.Color.White;
            this.guna2RadialGauge3.ArrowThickness = 1;
            this.guna2RadialGauge3.FillColor = System.Drawing.Color.White;
            this.guna2RadialGauge3.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.guna2RadialGauge3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2RadialGauge3.Location = new System.Drawing.Point(4, 2);
            this.guna2RadialGauge3.Margin = new System.Windows.Forms.Padding(4);
            this.guna2RadialGauge3.MinimumSize = new System.Drawing.Size(40, 37);
            this.guna2RadialGauge3.Name = "guna2RadialGauge3";
            this.guna2RadialGauge3.ProgressColor = System.Drawing.Color.Cyan;
            this.guna2RadialGauge3.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2RadialGauge3.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge3.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge3.ProgressThickness = 10;
            this.guna2RadialGauge3.ShowPercentage = false;
            this.guna2RadialGauge3.Size = new System.Drawing.Size(149, 149);
            this.guna2RadialGauge3.TabIndex = 1;
            this.guna2RadialGauge3.Value = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MapDisplay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 403);
            this.panel2.TabIndex = 1;
            // 
            // MapDisplay
            // 
            this.MapDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapDisplay.BackColor = System.Drawing.Color.Transparent;
            this.MapDisplay.BorderColor = System.Drawing.Color.White;
            this.MapDisplay.Controls.Add(this.panel3);
            this.MapDisplay.ForeColor = System.Drawing.Color.White;
            this.MapDisplay.Location = new System.Drawing.Point(0, 60);
            this.MapDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.MapDisplay.Name = "MapDisplay";
            this.MapDisplay.Size = new System.Drawing.Size(1067, 336);
            this.MapDisplay.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelMoisture);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.guna2RadialGauge4);
            this.panel3.Controls.Add(this.labelDistance);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.guna2RadialGauge2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 336);
            this.panel3.TabIndex = 4;
            // 
            // labelMoisture
            // 
            this.labelMoisture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMoisture.AutoSize = true;
            this.labelMoisture.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoisture.ForeColor = System.Drawing.Color.White;
            this.labelMoisture.Location = new System.Drawing.Point(768, 139);
            this.labelMoisture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoisture.Name = "labelMoisture";
            this.labelMoisture.Size = new System.Drawing.Size(114, 67);
            this.labelMoisture.TabIndex = 5;
            this.labelMoisture.Text = "0%";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(768, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Moisture Content";
            // 
            // guna2RadialGauge4
            // 
            this.guna2RadialGauge4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2RadialGauge4.ArrowColor = System.Drawing.Color.White;
            this.guna2RadialGauge4.ArrowThickness = 1;
            this.guna2RadialGauge4.FillColor = System.Drawing.Color.White;
            this.guna2RadialGauge4.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.guna2RadialGauge4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2RadialGauge4.Location = new System.Drawing.Point(600, 99);
            this.guna2RadialGauge4.Margin = new System.Windows.Forms.Padding(4);
            this.guna2RadialGauge4.MinimumSize = new System.Drawing.Size(40, 37);
            this.guna2RadialGauge4.Name = "guna2RadialGauge4";
            this.guna2RadialGauge4.ProgressColor = System.Drawing.Color.Cyan;
            this.guna2RadialGauge4.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2RadialGauge4.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge4.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge4.ProgressThickness = 10;
            this.guna2RadialGauge4.ShowPercentage = false;
            this.guna2RadialGauge4.Size = new System.Drawing.Size(149, 149);
            this.guna2RadialGauge4.TabIndex = 3;
            this.guna2RadialGauge4.Value = 60;
            // 
            // labelDistance
            // 
            this.labelDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDistance.AutoSize = true;
            this.labelDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDistance.ForeColor = System.Drawing.Color.White;
            this.labelDistance.Location = new System.Drawing.Point(196, 139);
            this.labelDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(141, 67);
            this.labelDistance.TabIndex = 2;
            this.labelDistance.Text = "0cm";
            this.labelDistance.Click += new System.EventHandler(this.labelDistance_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(204, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grain Level";
            // 
            // guna2RadialGauge2
            // 
            this.guna2RadialGauge2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2RadialGauge2.ArrowColor = System.Drawing.Color.White;
            this.guna2RadialGauge2.ArrowThickness = 1;
            this.guna2RadialGauge2.FillColor = System.Drawing.Color.White;
            this.guna2RadialGauge2.Font = new System.Drawing.Font("Verdana", 8.2F);
            this.guna2RadialGauge2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2RadialGauge2.Location = new System.Drawing.Point(13, 99);
            this.guna2RadialGauge2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2RadialGauge2.MinimumSize = new System.Drawing.Size(40, 37);
            this.guna2RadialGauge2.Name = "guna2RadialGauge2";
            this.guna2RadialGauge2.ProgressColor = System.Drawing.Color.Cyan;
            this.guna2RadialGauge2.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2RadialGauge2.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge2.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2RadialGauge2.ProgressThickness = 10;
            this.guna2RadialGauge2.ShowPercentage = false;
            this.guna2RadialGauge2.Size = new System.Drawing.Size(149, 149);
            this.guna2RadialGauge2.TabIndex = 1;
            this.guna2RadialGauge2.Value = 60;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.MapDisplay.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label labelAlerts;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2RadialGauge guna2RadialGauge1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2RadialGauge guna2RadialGauge3;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator2;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI2.WinForms.Guna2Panel MapDisplay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2RadialGauge guna2RadialGauge2;
        private System.Windows.Forms.Label labelMoisture;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2RadialGauge guna2RadialGauge4;
        private System.Windows.Forms.Label labelAlert;
    }
}