using NUnit.Framework;
using CalculatorLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 5, 10)]
        [TestCase(100, 200, 300)]
        [TestCase(-10, 20, 10)]
        public void Add_Test(
            int firstNumber,
            int secondNumber,
            int expectedResult)
        {
            int actualResult =
                calculator.Add(firstNumber, secondNumber);

            Assert.That(
                actualResult,
                Is.EqualTo(expectedResult));
        }
    }
}