using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace algorithms_lesson3
{
    class Program
    {
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
        }
    }

    public class BechmarkClass
    {
        public float DistanceRefType(PointClassF p1, PointClassF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public float DistanceValueType(PointStructF p1, PointStructF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }  
        
        public double DistanceValueType(PointStructD p1, PointStructD p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public float DistanceValueTypeNoSqrt(PointStructF p1, PointStructF p2)
        {
            return (float)((p2.Y - p1.Y) / Math.Sin(Math.Atan((p2.Y - p1.Y) / (p2.X - p1.X))));
        }

        [Benchmark]
        public void TestDistanceFloatRef()
        {
            PointClassF p1 = new PointClassF();
            p1.X = 5.6F;
            p1.Y = 44.3F;
            PointClassF p2 = new PointClassF();
            p2.X = 55.6F;
            p2.Y = 444.3F;
            DistanceRefType(p1, p2);
        }

        [Benchmark]
        public void TestDistanceFloatValue()
        {
            PointStructF p1;
            p1.X = 5.6F;
            p1.Y = 44.3F;
            PointStructF p2;
            p2.X = 55.6F;
            p2.Y = 444.3F;
            DistanceValueType(p1, p2);
        }

        [Benchmark]
        public void TestDistanceDoubleValue()
        {
            PointStructD p1;
            p1.X = 5.6;
            p1.Y = 44.3;
            PointStructD p2;
            p2.X = 55.6;
            p2.Y = 444.3;
            DistanceValueType(p1, p2);
        }

        [Benchmark]
        public void TestDistanceFloatValueNoSqrt()
        {
            PointStructF p1;
            p1.X = 5.6F;
            p1.Y = 44.3F;
            PointStructF p2;
            p2.X = 55.6F;
            p2.Y = 444.3F;
            DistanceValueTypeNoSqrt(p1, p2);
        }        
    }


    public class PointClassF
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public struct PointStructF
    {
        public float X;
        public float Y;
    }

    public struct PointStructD
    {
        public double X;
        public double Y;
    }
}
