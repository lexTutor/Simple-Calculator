using System;
using Xunit;
using KingdomCalculator.UI;
using KingdomCalculator.Core;
using KingdomCalculator.Commons;

namespace KingdomCalculator.FunctonalityTests
{
    /// <summary>
    /// ConfigForTests class is injected into the to Power Tests class by implementing the IclassFixture
    /// </summary>
    public class PowerTests : IClassFixture<ConfigForTests>
    {
        private readonly ConfigForTests _calculator;
        public PowerTests(ConfigForTests calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        ///Tests for the inline added data to determine if the power method works successfully for valid values
        /// </summary>
        [Fact]
        public void PowerMethodTestsValidValues()
        { 
            //Arrange
            double expected = 32;
            double expected2 = 533.61;

            //Act
            _calculator.calculator.Value1 = "2";
            _calculator.calculator.Value2 = "5";
            _calculator.calculator.Equality((int)OperationsEnum.Power);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);


            _calculator.calculator.Value1 = "23.1";
            _calculator.calculator.Value2 = "2";
            _calculator.calculator.Equality((int)OperationsEnum.Power);
            double actual2 = Utilities.ToDouble(_calculator.calculator.Result);


            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);

        }

        /// <summary>
        /// Tests for the inline added data to determine if the power method works successfully for edge cases
        /// </summary>
        [Fact]
        public void PowerMethodTestsEdgeCases()
        {
            //Arrange
            double expected = 0.5;

            //Act

            _calculator.calculator.Value1 = "2";
            _calculator.calculator.Value2 = "-1";
            _calculator.calculator.Equality((int)OperationsEnum.Power);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            //Assert

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests for the inline added data to determine if the power method works successfully for invalid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        [Theory]
        [InlineData("a", "b")]
        public void PowerMethodTestsInValidValues(string val1, string val2)
        {
            //Arrange & Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;

            //Assert

            Assert.Throws<FormatException>(() => _calculator.calculator.Equality((int)OperationsEnum.Power));
        }
    }
}

