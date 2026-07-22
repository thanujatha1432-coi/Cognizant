using CalcLibrary;
using NUnit.Framework;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [Test]
        [TestCase(10, 20, 30)]
        [TestCase(5, 6, 11)]
        [TestCase(100, 200, 300)]
        public void TestAddition(int num1, int num2, int expected)
        {
            int actual = calculator.Add(num1, num2);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}