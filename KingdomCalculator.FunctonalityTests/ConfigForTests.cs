using KingdomCalculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KingdomCalculator.FunctonalityTests
{
    /// <summary>
    /// Config calss to create an instance of the Calculator Logic Class for injection into test classes
    /// </summary>
    public class ConfigForTests
    {
        public ICalculatorLogic calculator { get; }
        public ConfigForTests()
        {
            calculator = new CalculatorLogic();
        }
    }
}
