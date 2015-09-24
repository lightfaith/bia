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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cv01txtBenchmark = new System.Windows.Forms.TextBox();
            this.cv01txtTotal = new System.Windows.Forms.TextBox();
            this.cv011lblPermutations = new System.Windows.Forms.Label();
            this.cv01lblPoints = new System.Windows.Forms.Label();
            this.cv01btnCount = new System.Windows.Forms.Button();
            this.cv01numPoints = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.cv01btnBenchmark = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv01numPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(601, 114);
            this.tabControl.TabIndex = 0;
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
            this.tabPage1.Size = new System.Drawing.Size(593, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "01 - Limity";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cv01txtBenchmark
            // 
            this.cv01txtBenchmark.Location = new System.Drawing.Point(177, 6);
            this.cv01txtBenchmark.Multiline = true;
            this.cv01txtBenchmark.Name = "cv01txtBenchmark";
            this.cv01txtBenchmark.ReadOnly = true;
            this.cv01txtBenchmark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cv01txtBenchmark.Size = new System.Drawing.Size(410, 75);
            this.cv01txtBenchmark.TabIndex = 7;
            // 
            // cv01txtTotal
            // 
            this.cv01txtTotal.Location = new System.Drawing.Point(83, 61);
            this.cv01txtTotal.Name = "cv01txtTotal";
            this.cv01txtTotal.ReadOnly = true;
            this.cv01txtTotal.Size = new System.Drawing.Size(88, 20);
            this.cv01txtTotal.TabIndex = 6;
            // 
            // cv011lblPermutations
            // 
            this.cv011lblPermutations.AutoSize = true;
            this.cv011lblPermutations.Location = new System.Drawing.Point(6, 64);
            this.cv011lblPermutations.Name = "cv011lblPermutations";
            this.cv011lblPermutations.Size = new System.Drawing.Size(71, 13);
            this.cv011lblPermutations.TabIndex = 5;
            this.cv011lblPermutations.Text = "Permutations:";
            // 
            // cv01lblPoints
            // 
            this.cv01lblPoints.AutoSize = true;
            this.cv01lblPoints.Location = new System.Drawing.Point(6, 8);
            this.cv01lblPoints.Name = "cv01lblPoints";
            this.cv01lblPoints.Size = new System.Drawing.Size(39, 13);
            this.cv01lblPoints.TabIndex = 4;
            this.cv01lblPoints.Text = "Points:";
            // 
            // cv01btnCount
            // 
            this.cv01btnCount.Location = new System.Drawing.Point(6, 32);
            this.cv01btnCount.Name = "cv01btnCount";
            this.cv01btnCount.Size = new System.Drawing.Size(81, 23);
            this.cv01btnCount.TabIndex = 2;
            this.cv01btnCount.Text = "Count";
            this.cv01btnCount.UseVisualStyleBackColor = true;
            this.cv01btnCount.Click += new System.EventHandler(this.cv01btnCount_Click);
            // 
            // cv01numPoints
            // 
            this.cv01numPoints.Location = new System.Drawing.Point(51, 6);
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
            this.cv01numPoints.Size = new System.Drawing.Size(120, 20);
            this.cv01numPoints.TabIndex = 0;
            this.cv01numPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 112);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "02 - ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(12, 132);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(601, 243);
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // cv01btnBenchmark
            // 
            this.cv01btnBenchmark.Location = new System.Drawing.Point(93, 32);
            this.cv01btnBenchmark.Name = "cv01btnBenchmark";
            this.cv01btnBenchmark.Size = new System.Drawing.Size(78, 23);
            this.cv01btnBenchmark.TabIndex = 8;
            this.cv01btnBenchmark.Text = "Benchmark";
            this.cv01btnBenchmark.UseVisualStyleBackColor = true;
            this.cv01btnBenchmark.Click += new System.EventHandler(this.cv01btnBenchmark_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 387);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "BIA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cv01numPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
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
    }
}

