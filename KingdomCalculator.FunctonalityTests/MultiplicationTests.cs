using KingdomCalculator.Commons;
using KingdomCalculator.Core;
using System;
using Xunit;

namespace KingdomCalculator.FunctonalityTests
{
    public class MultiplicationTests: IClassFixture<ConfigForTests>
    {
        /// <summary>
        /// ConfigForTests class is injected into the to Multiplication Testsclass by implementing the IclassFixture
        /// </summary>
        private readonly ConfigForTests _calculator;
        public MultiplicationTests(ConfigForTests calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Tests for the inline added data to determine if the multiplication method works successfully for valid values
        /// </summary>
        [Fact]
        public void MultiplicationMethodTestsValidValues()
        {
            //Arrange

            double expected = 70;
            double expected2 = 0;
            double expected3 = 18.174;

            //Act
            _calculator.calculator.Value1 = "10";
            _calculator.calculator.Value2 = "7";
            _calculator.calculator.Equality((int)OperationsEnum.Multiply);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            _calculator.calculator.Value1 = "100";
            _calculator.calculator.Value2 = "0";
            _calculator.calculator.Equality((int)OperationsEnum.Multiply);
            double actual2 = Utilities.ToDouble(_calculator.calculator.Result);

            _calculator.calculator.Value1 = "3.9";
            _calculator.calculator.Value2 = "4.66";
            _calculator.calculator.Equality((int)OperationsEnum.Multiply);
            double actual3 = Utilities.ToDouble(_calculator.calculator.Result);
            //Assert

            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
        }

        /// <summary>
        /// Tests for the inline added data to determine if the Multiplication method works successfully for Edge cases
        /// </summary>
        [Fact]
        public void MultiplicationMethodEdgeCases()
        {
            //Arrange

            double expected = -16;
            double expected2 = 16;

            //Act
            _calculator.calculator.Value1 = "-4";
            _calculator.calculator.Value2 = "4";
            _calculator.calculator.Equality((int)OperationsEnum.Multiply);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            _calculator.calculator.Value1 = "-4";
            _calculator.calculator.Value2 = "-4";
            _calculator.calculator.Equality((int)OperationsEnum.Multiply);
            double actual2 = Utilities.ToDouble(_calculator.calculator.Result);
            //Assert

            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);

        }

        /// <summary>
        /// Tests for the inline added data to determine if the multiplication method works successfully for invalid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        [Theory]
        [InlineData("a", "b")]
        public void MultiplicationMethodTestsInValidValues(string val1, string val2)
        {
            //Arrange & Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;

            //Assert

            Assert.Throws<FormatException>(() => _calculator.calculator.Equality((int)OperationsEnum.Multiply));
        }
    }
}
