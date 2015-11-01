﻿using System;
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



        public static void Plot(this ILPanel panel, Lib.func f, float min, float max, float step, bool refresh=true)
        {
            ILScene scene = null;
            //bool resetcam=false;
            Matrix4 rotation = default(Matrix4);
            try
            {
                rotation = panel.GetCurrentScene().First<ILPlotCube>().Rotation;
            }
            catch 
            {
                rotation = Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2);
            }
            //if (panel.Scene.First<ILPlotCube>() == null)
            //    resetcam = true;
            //else
            //    rotation = panel.Scene.First<ILPlotCube>().Rotation;
            
            // setup the scene + plot cube + surface 
            scene = new ILScene() 
            {
                new ILPlotCube(twoDMode: false) 
                {
                    
                     new ILSurface(new Func<float,float,float>(f.Encapsulation3D),
                         min, max, (int)((max-min)*step+1),
                         min, max, (int)((max-min)*step+1),
                         colormap: Colormaps.Hsv) 
                     {
                        UseLighting = true, 
                     },
                }
            };
            panel.Scene = scene;
            //if (resetcam)
            //    panel.ResetCamera(refresh);
            panel.ResetCamera(rotation, refresh);
        }


        public static void DrawPoints(this ILPanel panel, List<Element> population, float min, float max, float step)
        {
            ILScene scene = null;

            // setup the scene + plot cube + surface 

            ILArray<float> ilar = population.Array3D();

            ILPoints ilpoints = new ILPoints { Positions = ilar, Color = Color.Black };

            scene = panel.Scene;
            scene.First<ILPlotCube>().Add(ilpoints);
            
            //scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2);

            panel.Scene = scene;
            panel.Refresh();
        }

        public static void ResetCamera(this ILPanel panel, Matrix4 rotation, bool refresh = true)
        {
            try
            {
                panel.Scene.First<ILPlotCube>().Rotation = rotation;
                panel.GetCurrentScene().First<ILPlotCube>().Rotation = rotation;
            }
            catch { }
            /*if(panel.Scene.First<ILPlotCube>()!=null)
                panel.Scene.First<ILPlotCube>().Rotation = rotation;
            */
            if(refresh)
                panel.Refresh();
             
        }

        /*public static void ResetCamera(this ILPanel panel, bool refresh=true) 
        {
            ResetCamera(panel, Matrix4.Rotation(new Vector3(2, 0.55, 0.64), Math.PI / 2), refresh);
        }*/

        public static void EmphasizeFitness(this DataGridView g) 
        {
            float bestfitness=0;
            int bestindex=0;

            List<Element> source = (List<Element>)g.DataSource;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i].Fitness > bestfitness)
                {
                    bestindex = i;
                    bestfitness = source[i].Fitness;
                }
                g.Rows[i].Selected = false;
            }
            g.Rows[bestindex].Selected = true;
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
