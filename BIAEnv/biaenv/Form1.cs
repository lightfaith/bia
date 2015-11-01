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
        List<Element> population;
        List<Algorithm> algos;

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
            cv02cmbFunction.SelectedIndex = 1;

            algos = new List<Algorithm>();
            algos.Add(new Blind());
            algos.Add(new SimulatedAnnealing());

            cv02cmbAlgo.DataSource = algos;
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
                if (task01.Points.Count < 8 && debugmode)
                    task01.Benchmark(sb); //debug mode
                else
                    task01.Benchmark(null); //no debug mode

                s.Stop();
                double ms = s.Elapsed.TotalMilliseconds;
                cv01txtBenchmark.Text += sb.ToString();
                cv01txtBenchmark.Text += String.Format("Benchmark for {0} points finished in {1} ms.\r\n", i, ms);
                cv01txtBenchmark.ScrollToCaret();
                cv01txtBenchmark.Refresh();
                times[i] = (float)Math.Round(ms / 1000, 3);
                chart.Plot(times);
                chart.Refresh();
            }
            //estimate the rest
            for (int i = LASTTOMEASURE + 1; i <= 15; i++)
            {
                times[i] = times[(i - 1)] * i;
                chart.Plot(times);
                cv01txtBenchmark.Text += String.Format("Approximated results for {0} points: {1} ms.\r\n", i, times[i] * 1000);
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

        //cv02btnDraw
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(il.Scene.First<ILPlotCube>().Rotation.ToString());
            //il.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(Convert.ToDouble(cv02txtMin.Text), Convert.ToDouble(cv02txtMax.Text), Convert.ToDouble(cv02txtStep.Text)), Math.PI / 2);
            Functions.SetMeasures(cv02txtMin.Text, cv02txtMax.Text, cv02txtStep.Text);

            int index = cv02cmbFunction.SelectedIndex;
            if (index > 0 && index <= 16 || index == 21)
                il.Plot(Functions.GetFunctionByIndex(index), Functions.Min, Functions.Max, Functions.Precision);
            else
            {
                il.Scene = new ILScene();
                il.Refresh();
            }

        }

        private void cv03btnDraw_Click(object sender, EventArgs e)
        {
            //Task03.SetParameters((float)Convert.ToDouble(cv03txtMin.Text), (float)Convert.ToDouble(cv03txtMax.Text), Task03.Step, (float)Convert.ToDouble(cv03txtFreq.Text));
            //il.Plot(Task03.VOF(), Task03.Min, Task03.Max, Task03.Step);
        }

        private void cv02btnPopulate_Click(object sender, EventArgs e)
        {
            Functions.SetMeasures(cv02txtMin.Text, cv02txtMax.Text, cv02txtStep.Text);

            int populsize;
            try { populsize = Int32.Parse(cv02txtPopulation.Text); }
            catch (Exception) { populsize = 10; }

            Lib.func f = Functions.GetFunctionByIndex(cv02cmbFunction.SelectedIndex);
            population = new List<Element>();
            population.AddPopulation(populsize, f, cv02checkInteger.Checked);
            population.ComputeFitness();

            cv02gridPopulation.DataSource = population;
            //foreach (DataGridViewColumn c in cv02gridPopulation.Columns)
            //    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cv02gridPopulation.EmphasizeFitness();
            cv02gridPopulation.Refresh();
            il.Plot(f, Functions.Min, Functions.Max, Functions.Precision, false);
            il.DrawPoints(population, Functions.Min, Functions.Max, Functions.Precision);
        }

        private void cv02btnStep_Click(object sender, EventArgs e)
        {
            Lib.func f = Functions.GetFunctionByIndex(cv02cmbFunction.SelectedIndex);
            if (f == null)
                return;

            int generations;
            try { generations = Int32.Parse(cv02txtIteration.Text); }
            catch (FormatException) { generations = 1; }
            Algorithm a = (Algorithm)cv02cmbAlgo.SelectedItem;
            a.UpdateParameters(cv02txtParameters.Text);
            for (int i = 0; i < generations; i++)
                population.Evolve(a, f, cv02checkInteger.Checked);
            population.ComputeFitness();

            cv02gridPopulation.DataSource = population;
            cv02gridPopulation.EmphasizeFitness();
            cv02gridPopulation.Refresh();

            il.Plot(f, Functions.Min, Functions.Max, Functions.Precision, false);
            il.DrawPoints(population, Functions.Min, Functions.Max, Functions.Precision);
        }

        private void cv02btnPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                cv02btnStep_Click(sender, e);
                Thread.Sleep(1000);
            }
        }

        private void cv02btnCamera_Click(object sender, EventArgs e)
        {
            il.ResetCamera(Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2), true);
        }

        private void cv02cmbAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cv02txtParameters.Text = ((Algorithm)cv02cmbAlgo.SelectedItem).GetParameters();
        }
    }
}
