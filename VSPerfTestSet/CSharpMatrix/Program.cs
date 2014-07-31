using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Complex;


namespace CSharpMatrix
{
    class Program
    {
        private const Int32 msize = 10000;

        static void Main(string[] args)
        {
            var amatrix = new MyMatrix(msize, msize, false);
            amatrix.FillWithRandom();
            amatrix.doMultiply();
            Console.WriteLine(amatrix.TimerMessages());
        }
    }
}
