using System;

namespace Calculator
{
    public class Calculator
    {
        public double Accumulator { get; private set; }

        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return Accumulator;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;
            return Accumulator;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return Accumulator;
        }

        public double Power(double a, double b)
        {
            double result = Math.Pow(a, b);

            // Let Math.Pow check legal ranges, and check for any suspicious results, throwing an exception
            if (result.Equals(double.NaN))
            {
                throw new System.ArgumentOutOfRangeException("Result is not a number implying wrong usage");
            }
            else if (result.Equals(Double.NegativeInfinity))
            {
                throw new System.ArgumentOutOfRangeException("Result is minus infinity");
            }
            else if (result.Equals(Double.PositiveInfinity))
            {
                throw new System.ArgumentOutOfRangeException("Result is plus infinity");
            }

            Accumulator = result;
            return Accumulator;
        }

        public double Divide(double a, double b)
        {
            if (b == 0.0)
            {
                throw new System.DivideByZeroException("Parameter 2");
            }

            Accumulator = a/b;
            return Accumulator;
        }

        public double Add(double b)
        {
            return Add(Accumulator, b);
        }

        public double Subtract(double b)
        {
            return Subtract(Accumulator, b);
        }

        public double Multiply(double b)
        {
            return Multiply(Accumulator, b);
        }

        public double Power(double b)
        {
            return Power(Accumulator, b);
        }

        public double Divide(double b)
        {
            return Divide(Accumulator, b);
        }

    }
}
