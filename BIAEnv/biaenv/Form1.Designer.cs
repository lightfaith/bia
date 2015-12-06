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
            this.cv02txtParameters = new System.Windows.Forms.TextBox();
            this.cv02btnCamera = new System.Windows.Forms.Button();
            this.cv02txtIteration = new System.Windows.Forms.TextBox();
            this.cv02cmbAlgo = new System.Windows.Forms.ComboBox();
            this.cv02txtPopulation = new System.Windows.Forms.TextBox();
            this.cv02btnStep = new System.Windows.Forms.Button();
            this.cv02checkInteger = new System.Windows.Forms.CheckBox();
            this.cv02btnPopulate = new System.Windows.Forms.Button();
            this.cv02lblStep = new System.Windows.Forms.Label();
            this.cv02lblMax = new System.Windows.Forms.Label();
            this.cv02lblMin = new System.Windows.Forms.Label();
            this.cv02txtStep = new System.Windows.Forms.TextBox();
            this.cv02txtMax = new System.Windows.Forms.TextBox();
            this.cv02txtMin = new System.Windows.Forms.TextBox();
            this.cv02btnSettings = new System.Windows.Forms.Button();
            this.cv02cmbFunction = new System.Windows.Forms.ComboBox();
            this.cv02gridPopulation = new System.Windows.Forms.DataGridView();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.il = new ILNumerics.Drawing.ILPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv01numPoints)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv02gridPopulation)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(723, 114);
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
            this.tabPage1.Size = new System.Drawing.Size(715, 88);
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
            this.cv01txtBenchmark.Size = new System.Drawing.Size(211, 75);
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
            this.tabPage2.Controls.Add(this.cv02txtParameters);
            this.tabPage2.Controls.Add(this.cv02btnCamera);
            this.tabPage2.Controls.Add(this.cv02txtIteration);
            this.tabPage2.Controls.Add(this.cv02cmbAlgo);
            this.tabPage2.Controls.Add(this.cv02txtPopulation);
            this.tabPage2.Controls.Add(this.cv02btnStep);
            this.tabPage2.Controls.Add(this.cv02checkInteger);
            this.tabPage2.Controls.Add(this.cv02btnPopulate);
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
            this.tabPage2.Size = new System.Drawing.Size(715, 88);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02 - Funkce";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cv02txtParameters
            // 
            this.cv02txtParameters.Location = new System.Drawing.Point(458, 6);
            this.cv02txtParameters.Multiline = true;
            this.cv02txtParameters.Name = "cv02txtParameters";
            this.cv02txtParameters.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cv02txtParameters.Size = new System.Drawing.Size(115, 76);
            this.cv02txtParameters.TabIndex = 18;
            // 
            // cv02btnCamera
            // 
            this.cv02btnCamera.Location = new System.Drawing.Point(144, 62);
            this.cv02btnCamera.Name = "cv02btnCamera";
            this.cv02btnCamera.Size = new System.Drawing.Size(52, 20);
            this.cv02btnCamera.TabIndex = 17;
            this.cv02btnCamera.Text = "Camera";
            this.cv02btnCamera.UseVisualStyleBackColor = true;
            this.cv02btnCamera.Click += new System.EventHandler(this.cv02btnCamera_Click);
            // 
            // cv02txtIteration
            // 
            this.cv02txtIteration.Location = new System.Drawing.Point(372, 6);
            this.cv02txtIteration.Name = "cv02txtIteration";
            this.cv02txtIteration.Size = new System.Drawing.Size(37, 20);
            this.cv02txtIteration.TabIndex = 16;
            this.cv02txtIteration.Text = "1";
            this.cv02txtIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cv02cmbAlgo
            // 
            this.cv02cmbAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cv02cmbAlgo.FormattingEnabled = true;
            this.cv02cmbAlgo.Location = new System.Drawing.Point(202, 33);
            this.cv02cmbAlgo.Name = "cv02cmbAlgo";
            this.cv02cmbAlgo.Size = new System.Drawing.Size(250, 21);
            this.cv02cmbAlgo.TabIndex = 15;
            this.cv02cmbAlgo.SelectedIndexChanged += new System.EventHandler(this.cv02cmbAlgo_SelectedIndexChanged);
            // 
            // cv02txtPopulation
            // 
            this.cv02txtPopulation.Location = new System.Drawing.Point(267, 6);
            this.cv02txtPopulation.Name = "cv02txtPopulation";
            this.cv02txtPopulation.Size = new System.Drawing.Size(36, 20);
            this.cv02txtPopulation.TabIndex = 14;
            this.cv02txtPopulation.Text = "10";
            this.cv02txtPopulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cv02btnStep
            // 
            this.cv02btnStep.Location = new System.Drawing.Point(415, 5);
            this.cv02btnStep.Name = "cv02btnStep";
            this.cv02btnStep.Size = new System.Drawing.Size(37, 22);
            this.cv02btnStep.TabIndex = 12;
            this.cv02btnStep.Text = "Step";
            this.cv02btnStep.UseVisualStyleBackColor = true;
            this.cv02btnStep.Click += new System.EventHandler(this.cv02btnStep_Click);
            // 
            // cv02checkInteger
            // 
            this.cv02checkInteger.AutoSize = true;
            this.cv02checkInteger.Location = new System.Drawing.Point(202, 8);
            this.cv02checkInteger.Name = "cv02checkInteger";
            this.cv02checkInteger.Size = new System.Drawing.Size(59, 17);
            this.cv02checkInteger.TabIndex = 10;
            this.cv02checkInteger.Text = "Integer";
            this.cv02checkInteger.UseVisualStyleBackColor = true;
            // 
            // cv02btnPopulate
            // 
            this.cv02btnPopulate.Location = new System.Drawing.Point(309, 5);
            this.cv02btnPopulate.Name = "cv02btnPopulate";
            this.cv02btnPopulate.Size = new System.Drawing.Size(57, 22);
            this.cv02btnPopulate.TabIndex = 9;
            this.cv02btnPopulate.Text = "Populate";
            this.cv02btnPopulate.UseVisualStyleBackColor = true;
            this.cv02btnPopulate.Click += new System.EventHandler(this.cv02btnPopulate_Click);
            // 
            // cv02lblStep
            // 
            this.cv02lblStep.AutoSize = true;
            this.cv02lblStep.Location = new System.Drawing.Point(103, 37);
            this.cv02lblStep.Name = "cv02lblStep";
            this.cv02lblStep.Size = new System.Drawing.Size(53, 13);
            this.cv02lblStep.TabIndex = 7;
            this.cv02lblStep.Text = "Precision:";
            // 
            // cv02lblMax
            // 
            this.cv02lblMax.AutoSize = true;
            this.cv02lblMax.Location = new System.Drawing.Point(6, 65);
            this.cv02lblMax.Name = "cv02lblMax";
            this.cv02lblMax.Size = new System.Drawing.Size(30, 13);
            this.cv02lblMax.TabIndex = 6;
            this.cv02lblMax.Text = "Max:";
            // 
            // cv02lblMin
            // 
            this.cv02lblMin.AutoSize = true;
            this.cv02lblMin.Location = new System.Drawing.Point(6, 37);
            this.cv02lblMin.Name = "cv02lblMin";
            this.cv02lblMin.Size = new System.Drawing.Size(27, 13);
            this.cv02lblMin.TabIndex = 5;
            this.cv02lblMin.Text = "Min:";
            // 
            // cv02txtStep
            // 
            this.cv02txtStep.Location = new System.Drawing.Point(162, 34);
            this.cv02txtStep.Name = "cv02txtStep";
            this.cv02txtStep.Size = new System.Drawing.Size(34, 20);
            this.cv02txtStep.TabIndex = 4;
            this.cv02txtStep.Text = "1";
            // 
            // cv02txtMax
            // 
            this.cv02txtMax.Location = new System.Drawing.Point(39, 62);
            this.cv02txtMax.Name = "cv02txtMax";
            this.cv02txtMax.Size = new System.Drawing.Size(34, 20);
            this.cv02txtMax.TabIndex = 3;
            this.cv02txtMax.Text = "5";
            // 
            // cv02txtMin
            // 
            this.cv02txtMin.Location = new System.Drawing.Point(39, 33);
            this.cv02txtMin.Name = "cv02txtMin";
            this.cv02txtMin.Size = new System.Drawing.Size(34, 20);
            this.cv02txtMin.TabIndex = 2;
            this.cv02txtMin.Text = "-5";
            // 
            // cv02btnSettings
            // 
            this.cv02btnSettings.Location = new System.Drawing.Point(79, 62);
            this.cv02btnSettings.Name = "cv02btnSettings";
            this.cv02btnSettings.Size = new System.Drawing.Size(59, 20);
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
            "Pareto"});
            this.cv02cmbFunction.Location = new System.Drawing.Point(6, 6);
            this.cv02cmbFunction.Name = "cv02cmbFunction";
            this.cv02cmbFunction.Size = new System.Drawing.Size(190, 21);
            this.cv02cmbFunction.TabIndex = 0;
            // 
            // cv02gridPopulation
            // 
            this.cv02gridPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cv02gridPopulation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.cv02gridPopulation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.cv02gridPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cv02gridPopulation.Location = new System.Drawing.Point(446, 129);
            this.cv02gridPopulation.MultiSelect = false;
            this.cv02gridPopulation.Name = "cv02gridPopulation";
            this.cv02gridPopulation.ReadOnly = true;
            this.cv02gridPopulation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cv02gridPopulation.Size = new System.Drawing.Size(289, 371);
            this.cv02gridPopulation.TabIndex = 8;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(427, 371);
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
            this.il.Size = new System.Drawing.Size(427, 371);
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
            this.panel1.Size = new System.Drawing.Size(427, 371);
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
            this.chart.Size = new System.Drawing.Size(427, 371);
            this.chart.TabIndex = 4;
            this.chart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cv02gridPopulation);
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
            ((System.ComponentModel.ISupportInitialize)(this.cv02gridPopulation)).EndInit();
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
        private System.Windows.Forms.Button cv02btnPopulate;
        private System.Windows.Forms.DataGridView cv02gridPopulation;
        private System.Windows.Forms.TextBox cv02txtPopulation;
        private System.Windows.Forms.Button cv02btnStep;
        private System.Windows.Forms.CheckBox cv02checkInteger;
        private System.Windows.Forms.TextBox cv02txtIteration;
        private System.Windows.Forms.ComboBox cv02cmbAlgo;
        private System.Windows.Forms.Button cv02btnCamera;
        private System.Windows.Forms.TextBox cv02txtParameters;
    }
}

