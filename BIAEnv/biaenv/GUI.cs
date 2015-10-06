using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System.Windows.Forms.DataVisualization.Charting;

namespace biaenv
{
    public static class GUI
    {
        #region PICTUREBOX

        private const int pointsize = 16;
        private const int edgewidth = 3;
        private static Color[] colors = { Color.BlanchedAlmond,  // background
                                          Color.CornflowerBlue,  // point
                                          Color.LimeGreen,       // first edge
                                          Color.Gray,            // edge
                                          Color.Orange           // last edge
                                        };
        private static Brush[] brushes = { new SolidBrush(colors[0]),
                                           new SolidBrush(colors[1]),
                                           new SolidBrush(colors[2]),
                                           new SolidBrush(colors[3]),
                                           new SolidBrush(colors[4])
                                         };
        private static Pen[] pens = { new Pen(colors[0], edgewidth),
                                      new Pen(colors[1], edgewidth),
                                      new Pen(colors[2], edgewidth), 
                                      new Pen(colors[3], edgewidth),
                                      new Pen(colors[4], edgewidth) 
                                    };

        private static PictureBox pb;
        private static Bitmap b;
        private static Graphics g;
        private static int width;
        private static int height;
        private static int xoffset;
        private static int yoffset;

        public static int GetPointSize() { return pointsize; }
        public static int GetWidth() { return width; }
        public static int GetHeight() { return height; }

        // - - - - - - - - - - - - - - - - - - - - - - - - 

        public static void Init(this PictureBox pb)
        {
            GUI.pb = pb;
            xoffset = yoffset = pointsize / 2;
            width = pb.Width - pointsize;
            height = pb.Height - pointsize;
            b = new Bitmap(width + pointsize, height + pointsize);
            g = Graphics.FromImage(b);
            pb.Clear();
            pb.Image = b;

        }
        public static void Clear(this PictureBox pb)
        {
            g.Clear(colors[0]);
            pb.Invalidate();
        }

        public static void DrawPoints(this PictureBox pb, List<System.Drawing.Point> points, bool clear = true)
        {
            if (points == null)
                return;
            if (clear)
                pb.Clear();
            foreach (System.Drawing.Point p in points)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= width || p.Y >= height)
                    continue;
                g.FillEllipse(brushes[1], p.X - (pointsize / 2) + xoffset, p.Y - (pointsize / 2) + yoffset, pointsize, pointsize);
            }
            pb.Invalidate();
        }

        public static void DrawPath(this PictureBox pb, Path path, bool closed = true, bool clear = true)
        {
            int count = path.Points.Count;
            if (path == null)
                return;
            if (clear)
                pb.Clear();
            System.Drawing.Point[] points = path.Points.ToArray();
            for (int i = 0; i < count - 1; i++) //edge
            {
                int x1 = points[i].X;
                int x2 = points[(i + 1) % count].X;
                int y1 = points[i].Y;
                int y2 = points[(i + 1) % count].Y;
                g.DrawLine(pens[3], x1 + xoffset, y1 + yoffset, x2 + xoffset, y2 + yoffset);
            }
            if (closed) //last edge
                g.DrawLine(pens[4], points[count - 1].X + xoffset, points[count - 1].Y + yoffset, points[0].X + xoffset, points[0].Y + yoffset);
            g.DrawLine(pens[2], points[0].X + xoffset, points[0].Y + yoffset, points[1].X + xoffset, points[1].Y + yoffset); //first edge
            pb.Invalidate();
        }

        #endregion



        public static void Plot(this ILPanel panel, Lib.func f, float min, float max, float step)
        {
            ILScene scene = null;
            // define X and Y range
            //ILArray<float> X = ILMath.vec<float>(Task02.Min, Task02.Step, Task02.Max);
            //ILArray<float> Y = ILMath.vec<float>(Task02.Min, Task02.Step, Task02.Max);

            // compute X and Y coordinates for every grid point
            //ILArray<float> YMat = 1; // provide YMat as output to meshgrid
            //ILArray<float> XMat = ILMath.meshgrid(X, Y, YMat); // only need mesh for 2D function here

            
            // setup the scene + plot cube + surface 
            scene = new ILScene() {
                new ILPlotCube(twoDMode: false) {
                     new ILSurface(new Func<float,float,float>(f), 
                         min, max, (int)((max-min)*step+1),
                         min, max, (int)((max-min)*step+1),
                         colormap: Colormaps.Hsv) {
                        UseLighting = true, 
                        
                 }
                }
            };
            scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2);

            panel.Scene = scene;
            panel.Refresh();
        }

        public static void Plot(this ILPanel panel, Lib.func4D input)
        {
            ILScene scene = null;
            // define X and Y range
            ILArray<float> X = ILMath.vec<float>(-5.0, 1, 5.0);
            ILArray<float> Y = ILMath.vec<float>(-5.0, 1, 5.0);

            // compute X and Y coordinates for every grid point
            ILArray<float> YMat = 1; // provide YMat as output to meshgrid
            ILArray<float> XMat = ILMath.meshgrid(X, Y, YMat); // only need mesh for 2D function here

            // preallocate data array for ILSurface: X by Y by 3
            // Note the order: 3 matrix slices of X by Y each, for Z,X,Y coordinates of every grid point
            /*ILArray<float> A = ILMath.zeros<float>(Y.Length, X.Length, 1);

            // fill in Z values (replace this with your own function / data!!)
            A[":;:;0"] = ILMath.multiply(XMat,XMat)+ILMath.multiply(YMat, YMat);
            A[":;:;1"] = XMat; // X coordinates for every grid point
            A[":;:;2"] = YMat; // Y coordinates for every grid point*/
            
            
            /*ILArray<float> A = input;

            // setup the scene + plot cube + surface 
            scene = new ILScene() {
                new ILPlotCube(twoDMode: false) {
                     new ILSurface(A, colormap: Colormaps.Hsv) {
                        UseLighting = true, 
                        
                 }
                }
            */
            scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2);

            /*scene = new ILScene()
            {
                new ILPlotCube(twoDMode: false)
                {
                    //new ILSurface((x, y) => (float)(Math.Sin(x) * Math.Cos(y) * Math.Exp(-(x * x * y * y) / 4)), 
                    new ILSurface((x, y) => (float)(x*x+y*y), 
                    xmin: -5, xmax: 5, xlen: 20,
                    ymin: -5, ymax: 5, ylen: 20,              
                    //CFunc: (x,y) => x * y * (float)Math.Tanh(x * y), 
                    colormap: Colormaps.Hsv) 
                    { 
                        UseLighting = true, 
                        //Children = { new ILColorbar() }
                    }
                }
            };
            scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(1, 1, 1), 1f);*/
            panel.Scene = scene;
            panel.Refresh();
        }
        public static void Plot(this Chart chart, Dictionary<int, float> input)
        {
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Titles.Add("Hledání trajektorií");

            Series s = new Series();
            foreach (KeyValuePair<int, float> kv in input)
                s.Points.AddXY(kv.Key, kv.Value);

            //Series s = chart.Series.Add(series[i].ToShortDateString());

            s.XValueType = ChartValueType.String;
            //s.IsValueShownAsLabel = true;

            s.BackGradientStyle = GradientStyle.TopBottom;
            s.IsXValueIndexed = true;
            s.IsVisibleInLegend = false;

            s.Palette = ChartColorPalette.BrightPastel;
            s.ChartType = SeriesChartType.Line;
            s.CustomProperties = "DrawingStyle=Emboss";
            s.IsVisibleInLegend = false;

            chart.Series.Add(s);
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.Title = "Time [s]";
            chart.ChartAreas[0].AxisX.Title = "Points";
        }
    }

          
  
}
