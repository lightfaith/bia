using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks;

namespace biaenv
{
    public static class GUI
    {
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
            width = pb.Width-pointsize;
            height = pb.Height-pointsize;
            b = new Bitmap(width+pointsize, height+pointsize);
            g = Graphics.FromImage(b);
            pb.Clear();
            pb.Image = b;
            
        }
        public static void Clear(this PictureBox pb)
        {
            g.Clear(colors[0]);
            pb.Invalidate();
        }

        public static void DrawPoints(this PictureBox pb, List<Point> points, bool clear = true)
        {
            if (points == null)
                return;
            if (clear)
                pb.Clear();
            foreach (Point p in points)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= width || p.Y >= height)
                    continue;
                g.FillEllipse(brushes[1], p.X - (pointsize / 2)+xoffset, p.Y - (pointsize / 2)+yoffset, pointsize, pointsize);
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
            Point[] points = path.Points.ToArray();
            for (int i = 0; i < count - 1; i++) //edge
            {
                int x1 = points[i].X;
                int x2 = points[(i+1)%count].X;
                int y1 = points[i].Y;
                int y2 = points[(i + 1) % count].Y; 
                g.DrawLine(pens[3], x1 + xoffset, y1 + yoffset, x2 + xoffset, y2 + yoffset);
            }
            if(closed) //last edge
                g.DrawLine(pens[4], points[count-1].X + xoffset, points[count-1].Y + yoffset, points[0].X + xoffset, points[0].Y + yoffset);
            g.DrawLine(pens[2], points[0].X+xoffset, points[0].Y+yoffset, points[1].X+xoffset, points[1].Y+yoffset); //first edge
            pb.Invalidate();
        }
    }
}
