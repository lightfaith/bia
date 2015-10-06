using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task03
    {
        private static float min = 0;
        private static float max = 1;
        private static float freq = 1; // or 0.5
        private static float step = 40;

        private static int gx = 11;
        private static int gxx = 12;
        
        public static float Min { get { return min; } set { min = value; } }
        public static float Max { get { return max; } set { max = value; } }
        public static float Freq { get { return freq; } set { freq = value; } }
        public static float Step { get { return step; } set { step = value; } }

        public static void SetParameters(float min, float max, float step, float freq)
        {
            Min = min;
            Max = max;
            Freq = freq;
            Step = step;
        }

        public static Lib.func VOF()
        {
            return h;
            //TODO
        }
        private static float h(float x1, float x2)
        {
            float f = x1;
            float g = 10 + x2;

            float alfa = (float)(0.25+3.75*(g-gxx)/(gx-gxx));
            return (float)(Math.Pow(f/g, alfa)-(f/g)*Math.Sin(Math.PI*Freq*f*g));
        }
    }
}
