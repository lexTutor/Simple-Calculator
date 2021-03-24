using KingdomCalculator.Commons;
using KingdomCalculator.Core;
using System;
using Xunit;

namespace KingdomCalculator.FunctonalityTests
{
    /// <summary>
    /// ConfigForTests class is injected into the to Division Tests class by implementing the IclassFixture
    /// </summary>
    public class DivisionTests: IClassFixture<ConfigForTests>
    {
        private readonly ConfigForTests _calculator;
        public DivisionTests(ConfigForTests calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        ///Tests for the inline added data to determine if the division method works successfully for valid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("70", "10", 7)]
        [InlineData("9", "2.4", 3.75)]
        [InlineData("6.3", "2.4", 2.625)]
        [InlineData("0", "9", 0)]
        public void DivisionMethodTestsValidValues(string val1, string val2, double expected)
        {

            //Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;
            _calculator.calculator.Equality((int)OperationsEnum.Divide);
            double actual = Utilities.ToDouble(_calculator.calculator.Result);

            //Assert

            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///  Tests for the inline added data to determine if the division method works successfully for Edge Csaes
        /// </summary>
        [Fact]
        public void DivisionMethodTestsEdgeCases()
        {
            
            //Arrange & Act
            _calculator.calculator.Value1 = "9";
            _calculator.calculator.Value2 = "0";
            
            //Assert

            Assert.Throws<DivideByZeroException>(() => _calculator.calculator.Equality((int)OperationsEnum.Divide));
           
        }

        /// <summary>
        ///Tests for the inline added data to determine if the addition method works successfully for invalid values
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        [Theory]
        [InlineData("a", "b")]
        public void DivisionMethodTestsInValidValues(string val1, string val2)
        {
            //Arrange & Act
            _calculator.calculator.Value1 = val1;
            _calculator.calculator.Value2 = val2;

            //Assert

            Assert.Throws<FormatException>(() => _calculator.calculator.Equality((int)OperationsEnum.Divide));
        }
    }
}
