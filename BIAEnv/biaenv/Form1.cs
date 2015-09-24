using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Tasks;

namespace biaenv
{
    public partial class Form1 : Form
    {
        Task01 task01;

        public Form1()
        {
            InitializeComponent();
        }


        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas.Init();
        }

        private void cv01btnCount_Click(object sender, EventArgs e)
        {
            canvas.Init();
            task01 = new Task01(GUI.GetWidth(), GUI.GetHeight(), GUI.GetPointSize());
            task01.GeneratePoints((int)cv01numPoints.Value);
            cv01txtBenchmark.Text = "";
            cv01txtTotal.Text = String.Format("{0}", task01.EdgeCount);
            //foreach (Tasks.Point p in task01.Points)
            //    cv01txtBenchmark.Text += String.Format("X={0}, Y={1}\r\n", p.X, p.Y);
            canvas.DrawPoints(task01.Points);
            canvas.DrawPath(new Path(task01.Points), true, false);
         
        }

        private void cv01btnBenchmark_Click(object sender, EventArgs e)
        {

        }

        private void cv01btnBenchmark_Click_1(object sender, EventArgs e)
        {
            cv01txtBenchmark.Text += String.Format("Starting benchmark for {0} points...\r\n", task01.Points.Count);
            Stopwatch s = new Stopwatch();
            StringBuilder sb = new StringBuilder();
            s.Start();

            //task01.Benchmark(sb); //I don't want debug mode...
            task01.Benchmark(null);

            s.Stop();
            double ms = s.Elapsed.TotalMilliseconds;
            cv01txtBenchmark.Text += sb.ToString();
            cv01txtBenchmark.Text += String.Format("Benchmark finished! {0} points permuted in {1} ms.\r\n", task01.Points.Count, ms);
        }


    }
}
