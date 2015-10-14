using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public static class Lib
    {
        //public delegate float func(float x, float y);
        public delegate float func(float[] dims);
        
        //public delegate float func4D(float x, float y, float z);

        public static float Encapsulation3D(this func f, float x, float y)
        {
            float[] arr = new float[2];
            arr[0]=x;
            arr[1]=y;
            return f(arr);
        }

        public static decimal Factorial(int n) 
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
