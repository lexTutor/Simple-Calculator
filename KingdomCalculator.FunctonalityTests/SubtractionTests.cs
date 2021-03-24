using KingdomCalculator.Commons;
using KingdomCalculator.Core;
using System;
using Xunit;

namespace KingdomCalculator.FunctonalityTests
{
    /// <summary>
    /// ConfigForTests class is injected into the to Subtraction Test class by implementing the IclassFixture
    /// </summary>
    public class SubtractionTests : IClassFixture<ConfigForTests>
    {
        private readonly ConfigForTests _calculator;
        public SubtractionTests(ConfigForTests calculator)
        {
            _calculator = calculator;
        }


        /// <summary>
        /// Tests for the inline added data to determine if the subtraction method works successfully for valid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("10", "7",3)]
        [InlineData("2", "2", 0)]
        [InlineData("6.477", "3.912", 2.565)]
        public void SubtractionMethodTestsValidValues(string val1, string val2, double expected)
        {
            //Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;
            _calculator.calculator.Equality((int)OperationsEnum.Subtract);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);
            //Assert

            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Tests for the inline added data to determine if the subtraction method works successfully for edge cases
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-9", "7", -16)]
        [InlineData("-9", "-7", -2)]
        public void SubtractionMethodEdgeCases(string val1, string val2, double expected)
        {
            //Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;
            _calculator.calculator.Equality((int)OperationsEnum.Subtract);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            //Assert

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests for the inline added data to determine if the subtraction method works successfully for invalid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        [Theory]
        [InlineData("a", "b")]
        public void SubtractionMethodTestsInValidValues(string val1, string val2)
        {
            //Arrange & Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;

            //Assert

            Assert.Throws<FormatException>(() => _calculator.calculator.Equality((int)OperationsEnum.Subtract));
        }
    }
}
