using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task02
    {
        
        private static float min=-10;
        private static float max=10;
        private static float step=1;
        public static float Min { get { return min; } set { min = value; } }
        public static float Max { get { return max; } set { max = value; } }
        public static float Step { get { return step; } set { step = value; } }
        private static float PI = (float)Math.PI;
        private static float E = (float)Math.E;

        #region SHEKEL constants
        private float[] Shekel_c = {0.806f, 0.517f, 0.1f, .908f, 0.965f, 0.669f, 0.524f, 0.902f, 0.531f, 0.876f, 0.462f, 0.491f, 0.463f, 0.714f, 0.352f, 0.869f, 0.813f, 0.811f,
                                0.828f, 0.964f, 0.789f, 0.360f, 0.369f, 0.992f, 0.332f, 0.817f, 0.632f, 0.883f, 0.608f, 0.326f};
        private float[,] Shekel_a = 
            {{9.681f, 0.667f, 4.783f, 9.095f, 3.517f, 9.325f, 6.544f, 0.211f, 5.122f, 2.020f},
            {9.400f, 2.041f, 3.788f, 7.931f, 2.882f, 2.672f, 3.568f, 1.284f, 7.033f, 7.374f},
            {8.025f, 9.152f, 5.114f, 7.621f, 4.564f, 4.711f, 2.996f, 6.126f, 0.734f, 4.982f},
            {2.196f, 0.415f, 5.649f, 6.979f, 9.510f, 9.166f, 6.304f, 6.054f, 9.377f, 1.426f},
            {8.074f, 8.777f, 3.467f, 1.863f, 6.708f, 6.349f, 4.534f, 0.276f, 7.633f, 1.567f},
            {7.650f, 5.658f, 0.720f, 2.764f, 3.278f, 5.283f, 7.474f, 6.274f, 1.409f, 8.208f},
            {1.256f, 3.605f, 8.623f, 6.905f, 4.584f, 8.133f, 6.071f, 6.888f, 4.187f, 5.448f},
            {8.314f, 2.261f, 4.224f, 1.781f, 4.124f, 0.932f, 8.129f, 8.658f, 1.208f, 5.762f},
            {0.226f, 8.858f, 1.420f, 0.945f, 1.622f, 4.698f, 6.228f, 9.096f, 0.972f, 7.637f},
            {7.305f, 2.228f, 1.242f, 5.928f, 9.133f, 1.826f, 4.060f, 5.204f, 8.713f, 8.247f},
            {0.652f, 7.027f, 0.508f, 4.876f, 8.807f, 4.632f, 5.808f, 6.937f, 3.291f, 7.016f},
            {2.699f, 3.516f, 5.874f, 4.119f, 4.461f, 7.496f, 8.817f, 0.690f, 6.593f, 9.789f},
            {8.327f, 3.897f, 2.017f, 9.570f, 9.825f, 1.150f, 1.395f, 3.885f, 6.354f, 0.109f},
            {2.132f, 7.006f, 7.136f, 2.641f, 1.882f, 5.943f, 7.273f, 7.691f, 2.880f, 0.564f},
            {4.707f, 5.579f, 4.080f, 0.581f, 9.698f, 8.542f, 8.077f, 8.515f, 9.231f, 4.670f},
            {8.304f, 7.559f, 8.567f, 0.322f, 7.128f, 8.392f, 1.472f, 8.524f, 2.277f, 7.826f},
            {8.632f, 4.409f, 4.832f, 5.768f, 7.050f, 6.715f, 1.711f, 4.323f, 4.405f, 4.591f},
            {4.887f, 9.112f, 0.170f, 8.967f, 9.693f, 9.867f, 7.508f, 7.770f, 8.382f, 6.740f},
            {2.440f, 6.686f, 4.299f, 1.007f, 7.008f, 1.427f, 9.398f, 8.480f, 9.950f, 1.675f},
            {6.306f, 8.583f, 6.084f, 1.138f, 4.350f, 3.134f, 7.853f, 6.061f, 7.457f, 2.258f},
            {0.652f, 2.343f, 1.370f, 0.821f, 1.310f, 1.063f, 0.689f, 8.819f, 8.833f, 9.070f},
            {5.558f, 1.272f, 5.756f, 9.857f, 2.279f, 2.764f, 1.284f, 1.677f, 1.244f, 1.234f},
            {3.352f, 7.549f, 9.817f, 9.437f, 8.687f, 4.167f, 2.570f, 6.540f, 0.228f, 0.027f},
            {8.798f, 0.880f, 2.370f, 0.168f, 1.701f, 3.680f, 1.231f, 2.390f, 2.499f, 0.064f},
            {1.460f, 8.057f, 1.336f, 7.217f, 7.914f, 3.615f, 9.981f, 9.198f, 5.292f, 1.224f},
            {0.432f, 8.645f, 8.774f, 0.249f, 8.081f, 7.461f, 4.416f, 0.652f, 4.002f, 4.644f},
            {0.679f, 2.800f, 5.523f, 3.049f, 2.968f, 7.225f, 6.730f, 4.199f, 9.614f, 9.229f},
            {4.263f, 1.074f, 7.286f, 5.599f, 8.291f, 5.200f, 9.214f, 8.272f, 4.398f, 4.506f},
            {9.496f, 4.830f, 3.150f, 8.270f, 5.079f, 1.231f, 5.731f, 9.494f, 1.883f, 9.732f},
            {4.138f, 2.562f, 2.532f, 9.661f, 5.611f, 5.500f, 6.886f, 2.341f, 9.699f, 6.500f}};
        #endregion

        public static void SetMeasures(float min, float max, float step) 
        {
            Task02.Min = min;
            Task02.Max = max;
            Task02.Step = step;
        }

        /*
        private static float[, ,] Compute(func4D f)
        {
            float[, ,] result = new float[(int)((max - min) * (1/step) + 1),(int)( (max - min) * (1/step) + 1), (int)((max - min) * (1/step) + 1)];
            for (int i = min; i <= max; i ++)
                for (int j = min; j <= max; j++)
                    for (int k = min; k <= max; k ++)
                        result[i - min, j - min, k - min] = f(i, j, k);
            return result;
        }
        */
        public static Lib.func FirstDeJong()
        {
            return ((x, y) => ((float)(Math.Pow(x, 2) + Math.Pow(y, 2))));
        }

        public static Lib.func RosenbrockSaddle() 
        {
            // for 3D only!
            return ((x,y)=>(float)(100*Math.Pow(x*x-y,2)+Math.Pow(1-x, 2)));
        }

        public static Lib.func ThirdDeJong()
        {
            return ((x, y) => (Math.Abs(x) + Math.Abs(y)));
        }

        public static Lib.func FourthDeJong()
        {
            return ((x, y) => ((float)(Math.Pow(x, 4) + Math.Pow(y, 4))));
        }

        public static Lib.func Rastrigin()
        {
            //TODO BAD
            return ((x, y) => (float)(4 * (x*x - 10 * Math.Cos(2 * PI * x) + y*y - 10 * Math.Cos(2 * PI * y))));
        }

        public static Lib.func Schwefel()
        {
            //TODO BAD
            return ((x, y) => (float)(-x * Math.Sin(Math.Sqrt(Math.Abs(x))) + -y * Math.Sin(Math.Sqrt(Math.Abs(y)))));
        }

        public static Lib.func Griewangk()
        {
            return ((x, y) => (float)(1 + (x * x / 4000 + y * y / 4000) - (Math.Cos(x / 1) * Math.Cos(y / Math.Sqrt(2)))));
        }

        public static Lib.func SineEnvelopeSineWave()
        {
            //for 3D only!
            //TODO BAD
            return ((x, y) => (float)(-(0.5+(Math.Pow(Math.Sin(x*x+y*y-0.5),2))/(Math.Pow(1+0.001*(x*x+y*y),2)))));
        }

        public static Lib.func StretchedVSineWave() 
        {
            //for 3D only!
            //TODO BAD
            return ((x, y) => (float)(Math.Pow((x * x + y * y), 0.25) * Math.Sin(Math.Pow(50 * Math.Pow(x * x + y * y, 0.1),2) + 1)));
        }


        public static Lib.func AckleyI() 
        {
            //for 3D only!
            //TODO PROBABLY BAD
            return ((x,y)=>(float)(1/Math.Pow(E,5)*Math.Sqrt(x*x+y*y)+3*(Math.Cos(2*x)+Math.Sin(2*y))));
        }

        public static Lib.func AckleyII()
        {
            //for 3D only!
            return ((x,y)=>(float)(20+E-(20/Math.Pow(E,0.2*Math.Sqrt((x*x+y*y)/2)))-Math.Pow(E, 0.5*Math.Cos(2*PI*x)+Math.Cos(2*PI*y))));
        }

        public static Lib.func EggHolder() 
        {
            return ((x,y)=>(float)(-x*Math.Sin(Math.Sqrt(Math.Abs(x-y-47)))-(x+47)*Math.Sin(Math.Sqrt(Math.Abs(y+47+x/2)))));
        }

        public static Lib.func Rana() 
        {
            //for 3D only!
            return ((x,y)=>(float)(x*Math.Sin(Math.Sqrt(Math.Abs(y+1-x)))*Math.Cos(Math.Sqrt(Math.Abs(y+1+x)))+(y+1)*Math.Cos(Math.Sqrt(Math.Abs(y+1-x)))*Math.Sin(Math.Sqrt(Math.Abs(y+1+x)))));
        }

        public static Lib.func Pathological() 
        {
            //for 3D only!
            return ((x,y)=>(float)(0.5+(Math.Pow(Math.Sin(Math.Sqrt(100*x*x-y*y)),2)-0.5)/(1+0.001*Math.Pow(x*x-2*x*y+y*y,2))));
        }

        public static Lib.func Michalewicz() 
        {
            //for 3D only!
            //TODO CORRECT?
            return ((x,y)=>(float)(-(Math.Sin(x)*Math.Pow(Math.Sin(x*x/PI), 20)+Math.Sin(y)*Math.Pow(Math.Sin(2*x*x/PI), 20))));
        }

        public static Lib.func MastersCosineWave() 
        {
        //for 3D only!
            return ((x,y)=>(float)(Math.Pow(E, -(x*x+y*y+0.5*x*y)/8)*Math.Cos(4*Math.Sqrt(x*x+y*y+0.5*x*y))));
        }

        public static Lib.func4D TeaDivision()
        {
            //TODO BAD
            return ((x, y, z) => (float)(-(2 * x + 3 * y + 2 * z) * ((10 * x + 6 * y + 5 * z <= 2850) && (4 * y + 5 * z <= 1380) ? 1 : -100)));
        }

        
    }
}
