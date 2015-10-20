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
        public float Fitness {get; set;}

        
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
            elements.Clear();
            elements.AddRange(result);
        }

        public static void ComputeFitness(this List<Element> elements) 
        {
            float total = 0;
            foreach (Element e in elements)
                total += e.Z;
            foreach (Element e in elements)
                e.Fitness = 1-(e.Z / total);
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
                    x = r.Next() % ((Functions.Max - Functions.Min) * 1000) / 1000 + Functions.Min;
                    y = r.Next() % ((Functions.Max - Functions.Min) * 1000) / 1000 + Functions.Min;
                }
                population.Add(new Element(x, y, f(new float[] { x, y })));
            }
            population.ComputeFitness();
        }
    }

}
