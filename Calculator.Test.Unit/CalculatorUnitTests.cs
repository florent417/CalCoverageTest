using System;
using Calculator;
using NUnit.Framework;


namespace Calculator.Test.Unit
{
    [TestFixture]
    [Author("Troels Jensen")]
    public class CalculatorUnitTests
    {
        private Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();
        }

        [Test]
        public void Ctor_NoOperations_AccumulatorIszero()
        {
            Assert.That(_uut.Accumulator, Is.EqualTo(0.0));
        }

        [TestCase(3, 2, 5)]
        [TestCase(-3, -2, -5)]
        [TestCase(-3, 2, -1)]
        [TestCase(3, -2, 1)]
        public void Add_AddPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Add(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 1)]
        [TestCase(-3, -2, -1)]
        [TestCase(-3, 2, -5)]
        [TestCase(3, -2, 5)]
        public void Subtract_SubtractPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 6)]
        [TestCase(-3, -2, 6)]
        [TestCase(-3, 2, -6)]
        [TestCase(3, -2, -6)]
        [TestCase(0, -2, 0)]
        [TestCase(-2, 0, 0)]
        [TestCase(0, 0, 0)]
        public void Multiply_MultiplyNunmbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(result));
        }


        [TestCase(2, 3, 8)]
        [TestCase(2, -3, 0.125)]
        [TestCase(-2, -3, -0.125)]
        [TestCase(1, 10, 1)]
        [TestCase(1, -10, 1)]
        [TestCase(10, 0, 1)]
        [TestCase(4, 0.5, 2.0)]
        [TestCase(9, 0.5, 3.0)]
        [TestCase(0.0289, 0.5, 0.17)]
        public void Power_RaiseNumbers_ResultIsCorrect(double x, double exp, double result)
        {
            Assert.That(_uut.Power(x, exp), Is.EqualTo(result).Within(0.001));
        }

        [TestCase(-2, 0.5)]
        [TestCase(-2, (1.0 / 3.0))]
       // [TestCase(0, -1)]
        public void Power_IncorrectParameters_ThrowsException(double b, double exp)
        {
            Assert.That(() => _uut.Power(b, exp), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Divide_DivideByZero_ThrowsException()
        {
            Assert.That(() => _uut.Divide(3, 0), Throws.TypeOf<DivideByZeroException>());
        }

        // Proposed EP representations: -3, -1, 0, +1, 7 -> 20 combinations (not 0 for divisor)
        [TestCase(-3, -3, 1)]
        [TestCase(-3, -1, 3)]
        [TestCase(-3, 1, -3)]
        [TestCase(-3, 7, -(3.0 / 7.0))]
        [TestCase(-1, -3, (1.0/3.0))]
        [TestCase(-1, -1, 1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, 7, -(1.0 / 7.0))]
        [TestCase(0, -3, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 7, 0)]
        [TestCase(1, -3, -(1.0 / 3.0))]
        [TestCase(1, -1, -1)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 7, (1.0 / 7.0))]
        [TestCase(7, -3, -(7.0 / 3.0))]
        [TestCase(7, -1, -7)]
        [TestCase(7, 1, 7)]
        [TestCase(7, 7, 1)]
        public void Divide_DivideNumbers_ResultIsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Divide(a, b), Is.EqualTo(result));
        }

        [Test]
        public void Add_2ParameterVersion_AccumulatorEqualsResult()
        {
            _uut.Add(3, 4);

            Assert.That(_uut.Accumulator, Is.EqualTo(7));
        }

        [Test]
        public void Subtract_2ParameterVersion_AccumulatorEqualsResult()
        {
            _uut.Subtract(3, 4);

            Assert.That(_uut.Accumulator, Is.EqualTo(-1));
        }

        [Test]
        public void Multiply_2ParameterVersion_AccumulatorEqualsResult()
        {
            _uut.Multiply(3, 4);

            Assert.That(_uut.Accumulator, Is.EqualTo(12));
        }

        [Test]
        public void Divide_2ParameterVersion_AccumulatorEqualsResult()
        {
            _uut.Divide(3, 4);

            Assert.That(_uut.Accumulator, Is.EqualTo(0.75));
        }

        [Test]
        public void Power_2ParameterVersion_AccumulatorEqualsResult()
        {
            _uut.Power(2, 0.5);

            Assert.That(_uut.Accumulator, Is.EqualTo(1.41).Within(0.005));
        }

        [Test]
        public void Add_1ParameterVersion_BuildsOnPreviousResult()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            Assert.That(_uut.Add(4), Is.EqualTo(9));
        }

        [Test]
        public void Subtract_1ParameterVersion_BuildsOnPreviousResult()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            Assert.That(_uut.Subtract(4), Is.EqualTo(1));
        }

        [Test]
        public void Multiply_1ParameterVersion_BuildsOnPreviousResult()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            Assert.That(_uut.Multiply(4), Is.EqualTo(20));
        }

        [Test]
        public void Divide_1ParameterVersion_BuildsOnPreviousResult()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            Assert.That(_uut.Divide(2), Is.EqualTo(2.5));
        }

        [Test]
        public void Power_1ParameterVersion_BuildsOnPreviousResult()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            Assert.That(_uut.Power(2), Is.EqualTo(25));
        }

        [Test]
        public void Add_1ParameterVersion_AccumulatorCorrect()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            _uut.Add(4);
            Assert.That(_uut.Accumulator, Is.EqualTo(9));
        }

        [Test]
        public void Subtract_1ParameterVersion_AccumulatorCorrect()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            _uut.Subtract(4);
            Assert.That(_uut.Accumulator, Is.EqualTo(1));
        }

        [Test]
        public void Multiply_1ParameterVersion_AccumulatorCorrect()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            _uut.Multiply(4);
            Assert.That(_uut.Accumulator, Is.EqualTo(20));
        }

        [Test]
        public void Divide_1ParameterVersion_AccumulatorCorrect()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            _uut.Divide(2);
            Assert.That(_uut.Accumulator, Is.EqualTo(2.5));
        }

        [Test]
        public void Power_1ParameterVersion_AccumulatorCorrect()
        {
            _uut.Add(2, 3);  // Accumulator is now 5, should be used in next calculation
            _uut.Power(2);
            Assert.That(_uut.Accumulator, Is.EqualTo(25));
        }

        [Test]
        public void Divide_1ParameterDivideByZero_ThrowsException()
        {
            _uut.Add(2, 3);
            Assert.That(() => _uut.Divide(0), Throws.TypeOf<DivideByZeroException>());
        }

        [TestCase(-2, 0.5)]
        [TestCase(-2, (1.0 / 3.0))]
        [TestCase(0, -1)]
        public void Power_1ParameterIncorrectParameters_ThrowsException(double b, double exp)
        {
            _uut.Add(b, 0);
            Assert.That(() => _uut.Power(exp), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(-2, 0.5)]
        [TestCase(-2, (1.0 / 3.0))]
        [TestCase(0, -1)]
        public void Power_1ParameterMINIncorrectParameters_ThrowsException(double b, double exp)
        {
            _uut.Add(b, -0);
            Assert.That(() => _uut.Power(exp), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        // added

    }
}
