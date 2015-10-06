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
using System.Diagnostics;
using Tasks;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;

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
            //cv01txtBenchmark.Text = "";
            cv01txtTotal.Text = String.Format("{0}", task01.EdgeCount);
            //foreach (Tasks.Point p in task01.Points)
            //    cv01txtBenchmark.Text += String.Format("X={0}, Y={1}\r\n", p.X, p.Y);
            //canvas.DrawPoints(task01.Points);
            //canvas.DrawPath(new Path(task01.Points), true, false);

        }

        private void cv01btnBenchmark_Click(object sender, EventArgs e)
        {

        }

        private void cv01btnBenchmark_Click_1(object sender, EventArgs e)
        {
            int LASTTOMEASURE = 11;
            Dictionary<int, float> times = new Dictionary<int, float>();

            cv01txtBenchmark.Text = "";
            task01 = new Task01(GUI.GetWidth(), GUI.GetHeight(), GUI.GetPointSize());

            //run one simple benchmark to avoid startup delays in statistics
            task01.GeneratePoints(3);
            task01.Benchmark(null);

            for (int i = 3; i <= LASTTOMEASURE; i++)
            {
                task01.GeneratePoints(i);
                cv01txtBenchmark.Text += String.Format("Starting benchmark for {0} points...\r\n", i);
                cv01txtBenchmark.ScrollToCaret();
                cv01txtBenchmark.Refresh();
                Stopwatch s = new Stopwatch();
                StringBuilder sb = new StringBuilder();
                s.Start();

                bool debugmode = false;
                if(task01.Points.Count<8 && debugmode)
                    task01.Benchmark(sb); //debug mode
                else
                    task01.Benchmark(null); //no debug mode

                s.Stop();
                double ms = s.Elapsed.TotalMilliseconds;
                cv01txtBenchmark.Text += sb.ToString();
                cv01txtBenchmark.Text += String.Format("Benchmark for {0} points finished in {1} ms.\r\n", i, ms);
                cv01txtBenchmark.ScrollToCaret(); 
                cv01txtBenchmark.Refresh();
                times[i] = (float)Math.Round(ms/1000, 3);
                chart.Plot(times);
                chart.Refresh();
            }
            //estimate the rest
            for (int i = LASTTOMEASURE+1; i <= 15; i++)
            {
                times[i] = times[(i - 1)] * i;
                chart.Plot(times);
                cv01txtBenchmark.Text += String.Format("Approximated results for {0} points: {1} ms.\r\n", i, times[i]*1000);
                chart.Refresh();
            }
            chart.Plot(times);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                canvas.Visible = false;
                chart.Visible = true;
                il.Visible = false;
            }
            else
            {
                canvas.Visible = false;
                chart.Visible = false;
                il.Visible = true;
            }
        }

        private void il_Load(object sender, EventArgs e)
        {

        }

        private void Draw(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(il.Scene.First<ILPlotCube>().Rotation.ToString());
            //il.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(Convert.ToDouble(cv02txtMin.Text), Convert.ToDouble(cv02txtMax.Text), Convert.ToDouble(cv02txtStep.Text)), Math.PI / 2);
            Task02.SetMeasures((float)Double.Parse(cv02txtMin.Text), (float)Double.Parse(cv02txtMax.Text), (float)Double.Parse(cv02txtStep.Text));


            //MessageBox.Show(cv02cmbFunction.SelectedIndex.ToString());
            switch (cv02cmbFunction.SelectedIndex)
            {
                case 0: //NOTHING
                    {
                        il.Scene = null;
                        break;
                    }
                case 1: //FIRST DE JONG
                    {
                        il.Plot(Task02.FirstDeJong(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 2:
                    {
                        //TODO
                        il.Plot(Task02.RosenbrockSaddle(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 3:
                    {
                        //3rd De Jong
                        il.Plot(Task02.ThirdDeJong(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 4:
                    {
                        //4th De Jong
                        il.Plot(Task02.FourthDeJong(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 5:
                    {
                        //Rastrigin's Function
                        il.Plot(Task02.Rastrigin(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 6:
                    {
                        //Schwefel's Function
                        il.Plot(Task02.Schwefel(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 7:
                    {
                        //Griewangk's Function
                        il.Plot(Task02.Griewangk(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 8:
                    {
                        //Sine Envelope Sine Wave Function
                        il.Plot(Task02.SineEnvelopeSineWave(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 9:
                    {
                        //Stretched V Sine Wave Function
                        il.Plot(Task02.StretchedVSineWave(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 10:
                    {
                        //Ackley's Function I
                        il.Plot(Task02.AckleyI(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 11:
                    {
                        //Ackley's Function II
                        il.Plot(Task02.AckleyII(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 12:
                    {
                        //Egg Holder
                        il.Plot(Task02.EggHolder(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 13:
                    {
                        //Rana's Function
                        il.Plot(Task02.Rana(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 14:
                    {
                        //Pathological Function
                        il.Plot(Task02.Pathological(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 15:
                    {
                        //Michalewicz's Function
                        il.Plot(Task02.Michalewicz(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 16:
                    {
                        //Master's Cosine Wave Function
                        il.Plot(Task02.MastersCosineWave(), Task02.Min, Task02.Max, Task02.Step);
                        break;
                    }
                case 17:
                    {
                        //Tea Division
                        il.Plot(Task02.TeaDivision());
                        break;
                    }
                case 18:
                    {
                        //Shekel's Foxhole
                        //TODO
                        break;
                    }
                case 19:
                    {
                        //Pseudo-Dirak's Function
                        //TODO
                        break;
                    }
                case 20:
                    {
                        //Fractal Function
                        //TODO
                        break;
                    }
            } //end of switch
            //il.Refresh();
        }

        private void cv03btnDraw_Click(object sender, EventArgs e)
        {
            Task03.SetParameters((float)Convert.ToDouble(cv03txtMin.Text), (float)Convert.ToDouble(cv03txtMax.Text), Task03.Step, (float)Convert.ToDouble(cv03txtFreq.Text));
            il.Plot(Task03.VOF(), Task03.Min, Task03.Max, Task03.Step);
        }
    }
}
