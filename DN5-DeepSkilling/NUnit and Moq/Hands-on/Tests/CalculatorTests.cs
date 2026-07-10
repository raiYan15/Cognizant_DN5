using NUnit.Framework;
using CalcLibrary;

namespace HandsOn.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator.AllClear();
        }

        [TestCase(3, 2, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(2.5, 1.5, 4.0)]
        public void Addition_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Addition(a, b);
            Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
        }

        [TestCase(5, 2, 3)]
        [TestCase(0, 5, -5)]
        public void Subtraction_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Subtraction(a, b);
            Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
        }

        [TestCase(3, 4, 12)]
        [TestCase(-2, 5, -10)]
        public void Multiplication_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Multiplication(a, b);
            Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
        }

        [TestCase(10, 2, 5)]
        [TestCase(7.5, 2.5, 3)]
        public void Division_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Division(a, b);
            Assert.That(actual, Is.EqualTo(expected).Within(1e-6));
        }

        [Test]
        public void Division_ByZero_ShouldThrowArgumentException()
        {
            Assert.That(() => _calculator.Division(10, 0), Throws.ArgumentException.With.Message.Contain("Second Parameter Can't be Zero"));
        }
    }
}
