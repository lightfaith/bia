namespace biaenv
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cv01btnBenchmark = new System.Windows.Forms.Button();
            this.cv01txtBenchmark = new System.Windows.Forms.TextBox();
            this.cv01txtTotal = new System.Windows.Forms.TextBox();
            this.cv011lblPermutations = new System.Windows.Forms.Label();
            this.cv01lblPoints = new System.Windows.Forms.Label();
            this.cv01btnCount = new System.Windows.Forms.Button();
            this.cv01numPoints = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cv02lblStep = new System.Windows.Forms.Label();
            this.cv02lblMax = new System.Windows.Forms.Label();
            this.cv02lblMin = new System.Windows.Forms.Label();
            this.cv02txtStep = new System.Windows.Forms.TextBox();
            this.cv02txtMax = new System.Windows.Forms.TextBox();
            this.cv02txtMin = new System.Windows.Forms.TextBox();
            this.cv02btnSettings = new System.Windows.Forms.Button();
            this.cv02cmbFunction = new System.Windows.Forms.ComboBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.il = new ILNumerics.Drawing.ILPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv01numPoints)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(439, 114);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cv01btnBenchmark);
            this.tabPage1.Controls.Add(this.cv01txtBenchmark);
            this.tabPage1.Controls.Add(this.cv01txtTotal);
            this.tabPage1.Controls.Add(this.cv011lblPermutations);
            this.tabPage1.Controls.Add(this.cv01lblPoints);
            this.tabPage1.Controls.Add(this.cv01btnCount);
            this.tabPage1.Controls.Add(this.cv01numPoints);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "01 - Trajektorie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cv01btnBenchmark
            // 
            this.cv01btnBenchmark.Location = new System.Drawing.Point(9, 58);
            this.cv01btnBenchmark.Name = "cv01btnBenchmark";
            this.cv01btnBenchmark.Size = new System.Drawing.Size(162, 23);
            this.cv01btnBenchmark.TabIndex = 8;
            this.cv01btnBenchmark.Text = "Benchmark";
            this.cv01btnBenchmark.UseVisualStyleBackColor = true;
            this.cv01btnBenchmark.Click += new System.EventHandler(this.cv01btnBenchmark_Click_1);
            // 
            // cv01txtBenchmark
            // 
            this.cv01txtBenchmark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cv01txtBenchmark.Location = new System.Drawing.Point(177, 6);
            this.cv01txtBenchmark.Multiline = true;
            this.cv01txtBenchmark.Name = "cv01txtBenchmark";
            this.cv01txtBenchmark.ReadOnly = true;
            this.cv01txtBenchmark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cv01txtBenchmark.Size = new System.Drawing.Size(248, 75);
            this.cv01txtBenchmark.TabIndex = 7;
            // 
            // cv01txtTotal
            // 
            this.cv01txtTotal.Location = new System.Drawing.Point(83, 35);
            this.cv01txtTotal.Name = "cv01txtTotal";
            this.cv01txtTotal.ReadOnly = true;
            this.cv01txtTotal.Size = new System.Drawing.Size(88, 20);
            this.cv01txtTotal.TabIndex = 6;
            // 
            // cv011lblPermutations
            // 
            this.cv011lblPermutations.AutoSize = true;
            this.cv011lblPermutations.Location = new System.Drawing.Point(6, 38);
            this.cv011lblPermutations.Name = "cv011lblPermutations";
            this.cv011lblPermutations.Size = new System.Drawing.Size(71, 13);
            this.cv011lblPermutations.TabIndex = 5;
            this.cv011lblPermutations.Text = "Permutations:";
            // 
            // cv01lblPoints
            // 
            this.cv01lblPoints.AutoSize = true;
            this.cv01lblPoints.Location = new System.Drawing.Point(6, 11);
            this.cv01lblPoints.Name = "cv01lblPoints";
            this.cv01lblPoints.Size = new System.Drawing.Size(39, 13);
            this.cv01lblPoints.TabIndex = 4;
            this.cv01lblPoints.Text = "Points:";
            // 
            // cv01btnCount
            // 
            this.cv01btnCount.Location = new System.Drawing.Point(90, 6);
            this.cv01btnCount.Name = "cv01btnCount";
            this.cv01btnCount.Size = new System.Drawing.Size(81, 23);
            this.cv01btnCount.TabIndex = 2;
            this.cv01btnCount.Text = "Count";
            this.cv01btnCount.UseVisualStyleBackColor = true;
            this.cv01btnCount.Click += new System.EventHandler(this.cv01btnCount_Click);
            // 
            // cv01numPoints
            // 
            this.cv01numPoints.Location = new System.Drawing.Point(51, 9);
            this.cv01numPoints.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.cv01numPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cv01numPoints.Name = "cv01numPoints";
            this.cv01numPoints.Size = new System.Drawing.Size(33, 20);
            this.cv01numPoints.TabIndex = 0;
            this.cv01numPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cv02lblStep);
            this.tabPage2.Controls.Add(this.cv02lblMax);
            this.tabPage2.Controls.Add(this.cv02lblMin);
            this.tabPage2.Controls.Add(this.cv02txtStep);
            this.tabPage2.Controls.Add(this.cv02txtMax);
            this.tabPage2.Controls.Add(this.cv02txtMin);
            this.tabPage2.Controls.Add(this.cv02btnSettings);
            this.tabPage2.Controls.Add(this.cv02cmbFunction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 88);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02 - Funkce";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cv02lblStep
            // 
            this.cv02lblStep.AutoSize = true;
            this.cv02lblStep.Location = new System.Drawing.Point(342, 9);
            this.cv02lblStep.Name = "cv02lblStep";
            this.cv02lblStep.Size = new System.Drawing.Size(32, 13);
            this.cv02lblStep.TabIndex = 7;
            this.cv02lblStep.Text = "Step:";
            // 
            // cv02lblMax
            // 
            this.cv02lblMax.AutoSize = true;
            this.cv02lblMax.Location = new System.Drawing.Point(271, 9);
            this.cv02lblMax.Name = "cv02lblMax";
            this.cv02lblMax.Size = new System.Drawing.Size(30, 13);
            this.cv02lblMax.TabIndex = 6;
            this.cv02lblMax.Text = "Max:";
            // 
            // cv02lblMin
            // 
            this.cv02lblMin.AutoSize = true;
            this.cv02lblMin.Location = new System.Drawing.Point(202, 9);
            this.cv02lblMin.Name = "cv02lblMin";
            this.cv02lblMin.Size = new System.Drawing.Size(27, 13);
            this.cv02lblMin.TabIndex = 5;
            this.cv02lblMin.Text = "Min:";
            // 
            // cv02txtStep
            // 
            this.cv02txtStep.Location = new System.Drawing.Point(380, 6);
            this.cv02txtStep.Name = "cv02txtStep";
            this.cv02txtStep.Size = new System.Drawing.Size(34, 20);
            this.cv02txtStep.TabIndex = 4;
            this.cv02txtStep.Text = "1";
            // 
            // cv02txtMax
            // 
            this.cv02txtMax.Location = new System.Drawing.Point(302, 6);
            this.cv02txtMax.Name = "cv02txtMax";
            this.cv02txtMax.Size = new System.Drawing.Size(34, 20);
            this.cv02txtMax.TabIndex = 3;
            this.cv02txtMax.Text = "20";
            // 
            // cv02txtMin
            // 
            this.cv02txtMin.Location = new System.Drawing.Point(231, 6);
            this.cv02txtMin.Name = "cv02txtMin";
            this.cv02txtMin.Size = new System.Drawing.Size(34, 20);
            this.cv02txtMin.TabIndex = 2;
            this.cv02txtMin.Text = "-20";
            // 
            // cv02btnSettings
            // 
            this.cv02btnSettings.Location = new System.Drawing.Point(205, 32);
            this.cv02btnSettings.Name = "cv02btnSettings";
            this.cv02btnSettings.Size = new System.Drawing.Size(209, 23);
            this.cv02btnSettings.TabIndex = 1;
            this.cv02btnSettings.Text = "Draw";
            this.cv02btnSettings.UseVisualStyleBackColor = true;
            this.cv02btnSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // cv02cmbFunction
            // 
            this.cv02cmbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cv02cmbFunction.FormattingEnabled = true;
            this.cv02cmbFunction.Items.AddRange(new object[] {
            "",
            "1st De Jong",
            "Rosenbrock\'s Saddle",
            "3rd De Jong",
            "4th De Jong",
            "Rastrigin\'s Function",
            "Schwefel\'s Function",
            "Griewangk\'s Function",
            "Sine Envelope Sine Wave Function",
            "Stretched V Sine Wave Function",
            "Ackley\'s Function I",
            "Ackley\'s Function II",
            "Egg Holder",
            "Rana\'s Function",
            "Pathological Function",
            "Michalewicz\'s Function",
            "Master\'s Cosine Wave Function",
            "Tea Division",
            "Shekel\'s Foxhole",
            "Pseudo-Dirak\'s Function",
            "Fractal Function"});
            this.cv02cmbFunction.Location = new System.Drawing.Point(6, 6);
            this.cv02cmbFunction.Name = "cv02cmbFunction";
            this.cv02cmbFunction.Size = new System.Drawing.Size(190, 21);
            this.cv02cmbFunction.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(439, 373);
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            this.canvas.Visible = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // il
            // 
            this.il.Dock = System.Windows.Forms.DockStyle.Fill;
            this.il.Driver = ILNumerics.Drawing.RendererTypes.GDI;
            this.il.Editor = null;
            this.il.Location = new System.Drawing.Point(0, 0);
            this.il.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.il.Name = "il";
            this.il.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("il.Rectangle")));
            this.il.ShowUIControls = false;
            this.il.Size = new System.Drawing.Size(439, 373);
            this.il.TabIndex = 3;
            this.il.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart);
            this.panel1.Controls.Add(this.canvas);
            this.panel1.Controls.Add(this.il);
            this.panel1.Location = new System.Drawing.Point(12, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 373);
            this.panel1.TabIndex = 4;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.chart.Size = new System.Drawing.Size(439, 373);
            this.chart.TabIndex = 4;
            this.chart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BIA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv01numPoints)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox cv01txtBenchmark;
        private System.Windows.Forms.TextBox cv01txtTotal;
        private System.Windows.Forms.Label cv011lblPermutations;
        private System.Windows.Forms.Label cv01lblPoints;
        private System.Windows.Forms.Button cv01btnCount;
        private System.Windows.Forms.NumericUpDown cv01numPoints;
        private System.Windows.Forms.Button cv01btnBenchmark;
        private ILNumerics.Drawing.ILPanel il;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cv02cmbFunction;
        private System.Windows.Forms.Button cv02btnSettings;
        private System.Windows.Forms.TextBox cv02txtStep;
        private System.Windows.Forms.TextBox cv02txtMax;
        private System.Windows.Forms.TextBox cv02txtMin;
        private System.Windows.Forms.Label cv02lblStep;
        private System.Windows.Forms.Label cv02lblMax;
        private System.Windows.Forms.Label cv02lblMin;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

