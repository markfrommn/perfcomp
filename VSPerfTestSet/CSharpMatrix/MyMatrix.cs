using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.Algorithms.LinearAlgebra.Mkl;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;
using MathNet.Numerics.Random;


namespace CSharpMatrix
{
    class MyMatrix
    {
        public MyMatrix(Int32 x, Int32 y, bool doNative)
        {
            if (doNative)
            {
                Control.LinearAlgebraProvider = new MklLinearAlgebraProvider();
            }
            initTimer = new Stopwatch();
            fillTimer = new Stopwatch();
            multTimer = new Stopwatch();

            initTimer.Start();
            aMatrix = new DenseMatrix(x, y);
            bMatrix = new DenseMatrix(x, y);
            initTimer.Stop();
            xDim = x;
            yDim = y;
            myRandom = new Random();
        }

        private System.Random myRandom;
        public Int32 xDim { get; private set; }
        public Int32 yDim { get; private set; }
        public Matrix<double> aMatrix { get; set; }
        public Matrix<double> bMatrix { get; set; }
        public Matrix<double> resMatrix { get; private set; }
        public Stopwatch multTimer { get; private set; }
        public Stopwatch fillTimer { get; private set; }
        public Stopwatch initTimer { get; private set; }   

        public bool doMultiply()
        {
            multTimer.Start();
            resMatrix = aMatrix.Multiply(bMatrix);
            multTimer.Stop();
            return (true);
        }

        public Int64 FillWithRandom()
        {
            Int64 elSet = 0;
            fillTimer.Start();
            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    aMatrix[x,y] = myRandom.NextDouble()*myRandom.NextInt64();
                    bMatrix[x,y] = myRandom.NextDouble()*myRandom.NextInt64();
                    ++elSet;
                }
            }
            fillTimer.Stop();
            return (elSet);
        }

        public string TimerMessages()
        {
            string output = String.Format("Init Time: {0}\n, Fill Time: {1}\n, Multiply Time: {2}",
                initTimer.Elapsed.ToString("c"), fillTimer.Elapsed.ToString("c"), multTimer.Elapsed.ToString("c"));
            return output;
        }
    }
}
