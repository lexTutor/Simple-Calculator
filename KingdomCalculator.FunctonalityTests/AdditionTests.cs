using KingdomCalculator.Commons;
using KingdomCalculator.Core;
using System;
using Xunit;

namespace KingdomCalculator.FunctonalityTests
{
    /// <summary>
    /// ConfigForTests class is injected into the to Addition Test class by implementing the IclassFixture
    /// </summary>
    public class AdditionTests: IClassFixture<ConfigForTests>
    {
        private readonly ConfigForTests _calculator;
        public AdditionTests(ConfigForTests calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Tests for the inline added data to determine if the addition method works successfully for valid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData ("7", "10", 17)]
        [InlineData("1.35", "2.3", 3.65)]
        public void AdditionMethodTestsValidValues(string val1, string val2, double expected)
        {
            //Act

            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;
            _calculator.calculator.Equality((int)OperationsEnum.Add);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            //Assert

            Assert.Equal(expected, actual, 2);
        }

        /// <summary>
        /// Tests for the inline added data to determine if the addition method works successfully for Edge Csaes
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-9", "7", -2)]
        [InlineData("-2", "-2", -4)]
        public void AdditionMethodTestsEdgeCases(string val1, string val2, double expected)
        {

            //Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;
            _calculator.calculator.Equality((int)OperationsEnum.Add);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);


            //Assert
            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// Tests for the inline added data to determine if the addition method works successfully for Invalid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        [Theory]
        [InlineData("a", "b")]
        public void AdditionMethodTestsInValidValues(string val1, string val2)
        {
            //Arrange & Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;

            //Assert

            Assert.Throws<FormatException>(() => _calculator.calculator.Equality((int)OperationsEnum.Add));
        }
    }
}
