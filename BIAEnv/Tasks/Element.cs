using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Element
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Fitness { get; set; }


        public Element(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Element(float x, float y, Lib.func f)
        {
            X = x;
            Y = y;
            Z = f(new float[] { x, y });
        }

        public bool IsInInterval()
        {
            if (X < Functions.Min || Y < Functions.Min)
                return false;
            if (X > Functions.Max || Y > Functions.Max)
                return false;
            return true;
        }

        private static float GetExtreme(Lib.func f, int n = 3)
        {
            if (f == Functions.FirstDeJong) return (float)0.00001;
            if (f == Functions.RosenbrockSaddle) return 0;
            if (f == Functions.ThirdDeJong) return 0;
            if (f == Functions.FourthDeJong) return 0;
            if (f == Functions.Rastrigin) return -200 * n;
            if (f == Functions.Schwefel) return (float)-418.983 * n;
            if (f == Functions.Griewangk) return 0;
            if (f == Functions.SineEnvelopeSineWave) return (float)-1.4915 * (n - 1);
            if (f == Functions.StretchedVSineWave) return 0;
            if (f == Functions.AckleyI) return (float)(-7.54276 - 2.91867 * (n - 3));
            if (f == Functions.AckleyII) return 0;
            if (f == Functions.EggHolder) return 0; //... ???
            if (f == Functions.Rana) return 0; //... ???
            if (f == Functions.Pathological) return 0; //... ???
            if (f == Functions.Michalewicz) return (float)1.00098 * (n - 2);
            if (f == Functions.MastersCosineWave) return -n;

            return 0; //default
        }

        public override string ToString()
        {
            return String.Format("X={0}  Y={1}  Z={2}", X, Y, Z);
        }
    }

    public class ElementComparer : IComparer<Element>
    {

        public int Compare(Element x, Element y)
        {
            float diff = x.Z - y.Z;
            return Math.Sign(diff);
        }
    }

    public static class Elements
    {
        public static float[,] Array3D(this List<Element> elements)
        {
            float[,] result = new float[elements.Count, 3];
            for (int i = 0; i < elements.Count; i++)
            {
                result[i, 0] = elements[i].X;
                result[i, 1] = elements[i].Y;
                result[i, 2] = elements[i].Z;
            }
            return result;
        }

        public static void Evolve(this List<Element> elements, Algorithm algo, Lib.func f, bool integer)
        {
            List<Element> result = new List<Element>();
            if (algo is Algorithm)
            {
                result = algo.Run(elements, f, integer);
            }
            if (elements != result)
            {
                elements.Clear();
                elements.AddRange(result);
            }
        }

        public static void ComputeFitness(this List<Element> elements)
        {
            float total = 0;
            float sum = 0;
            float best = elements[0].Z;
            foreach (Element e in elements)
            {
                sum += e.Z;
                total += Math.Abs(e.Z);
                if (best > e.Z)
                    best = e.Z;
            }
            float avg = sum / elements.Count;
            foreach (Element e in elements)
            {
                if (total == 0)
                    e.Fitness = 1;
                else
                     e.Fitness = 1 - Math.Abs((best - e.Z) / total) - Math.Abs((best - avg) / total);
            }
        }

        public static void AddPopulation(this List<Element> population, int count, Lib.func f, bool integer)
        {
            Random r = new Random();

            if (f == null)
                return;
            for (int i = 0; i < count; i++)
            {
                float x;
                float y;
                if (integer)
                {
                    x = r.Next() % (Functions.Max - Functions.Min) + Functions.Min;
                    y = r.Next() % (Functions.Max - Functions.Min) + Functions.Min;
                }
                else
                {
                    x = r.Next() % ((Functions.Max - Functions.Min) * 100000) / 100000 + Functions.Min;
                    y = r.Next() % ((Functions.Max - Functions.Min) * 100000) / 100000 + Functions.Min;
                }
                population.Add(new Element(x, y, f(new float[] { x, y })));
            }
            //fitness computed when shown
        }
    }

}
