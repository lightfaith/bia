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
        //public float Fitness {get; private set;}

        
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

        public static void Evolve(this List<Element> elements/*, algo*/) 
        {
        //task06
            foreach (Element e in elements)
                e.Z = e.Z + 1;
        }
    }

}
