using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task01
    {
        private int pointnum;
        private int diameter;
        public List<Point> Points { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public decimal EdgeCount { get; private set; }
        public List<Path> Paths { get; private set; }

        public Task01(int width, int height, int diam)
        {
            Width = width;
            Height = height;
            diameter = diam;

            Points = new List<Point>();
        }

        public void GeneratePoints(int pointnum)
        {
            Points.Clear();
            this.pointnum = pointnum;
            for (int i = 0; i < pointnum; i++)
            {
                Point p = new Point(new Random().Next() % Width, new Random().Next() % Height);
                //any collision?
                bool collision = false;
                foreach (Point p2 in Points)
                {
                    if (Math.Pow(p2.X - p.X, 2) + Math.Pow(p2.Y - p.Y, 2) <= Math.Pow(diameter, 2) * 2)
                    {
                        collision = true;
                        break;
                    }
                }
                if (collision)
                    i--;
                else
                    Points.Add(p);
            }
            EdgeCount = Lib.Factorial(pointnum - 1);
        }

        public String Benchmark(StringBuilder sb)
        {
            
            //now permute points to count all possible paths...


            /*foreach(List<Int32> list in Permute(l))
            {
                foreach (Int32 i in list)
                    sb.AppendFormat("{0}, ", i);
                sb.AppendFormat("\n");
            }*/
            List<Point> pointstopermutate = new List<Point>();
            pointstopermutate.AddRange(Points);
            Permute(pointstopermutate, 0, pointstopermutate.Count - 1, sb);

            if (sb == null)
                return "";
            else
                return sb.ToString();
        }

        private void Swap(List<Point> input, int i1, int i2)
        {
            Point tmp = input[i1];
            input[i1] = input[i2];
            input[i2] = tmp;
        }

        public List<Point> Permute(List<Point> input, int start, int end, StringBuilder sb)
        {
            if ((start == 0 && end - start > 7) && sb != null)
            {
                sb.Append("Logging is off...\r\n");
                sb = null;
            }
            if (start == end)
            {
                return input;
            }
            else
            {
                List<Point> result = new List<Point>();
                for (int i = start; i <= end; i++)
                {
                    Swap(input, start, i);
                    List<Point> tmp = Permute(input, start + 1, end, sb);
                    if (start > input.Count-2) // only working with part of array, return what you have
                        //TODO -2 determined by trial&error... why??
                        result.AddRange(tmp);
                    else //new complete permutation has been found, print it and work on a new one
                        if (tmp.Count > 1)
                        {
                            if (sb != null)
                            {
                                sb.Append("New permutation: ");
                                for (int j = 0; j < tmp.Count; j++)
                                {
                                    if (j == 0)
                                        sb.AppendFormat("{0}", Points.IndexOf(tmp[j])+1);
                                    else
                                        sb.AppendFormat(", {0}", Points.IndexOf(tmp[j]) + 1);
                                }
                                sb.AppendLine();
                            }
                            result.Clear();
                        }
                    Swap(input, start, i);
                }
                return result;
            }
        }
    }
}

