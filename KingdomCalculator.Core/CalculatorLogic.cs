using KingdomCalculator.Commons;
using System;

namespace KingdomCalculator.Core
{
    /// <summary>
    /// Clalculator Logic and operations class
    /// </summary>
    public class CalculatorLogic : ICalculatorLogic
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Result { get; set; }

         /// <summary>
         /// Adds the two values and sets the result 
         /// </summary>
        private void Add()
        {
            double val1 = Converter().Item1;
            double val2 = Converter().Item2;
            double sum = (val1 + val2);
            Result = (Math.Round(sum, 3)).ToString();

        }

        /// <summary>
        /// Subtracts value one from value two and sets the result 
        /// </summary>
        private void Subtract()
        {
            double val1 = Converter().Item1;
            double val2 = Converter().Item2;
            var sub = val1 - val2;
            Result = (Math.Round(sub, 3)).ToString();
        }

        /// <summary>
        /// Multiplies value one and value two and sets the result
        /// </summary>
        private void Multiply()
        {
            double val1 = Converter().Item1;
            double val2 = Converter().Item2;
            Result = (val1 * val2).ToString();
        }

        /// <summary>
        /// Divides value one by value two and sets the result
        /// </summary>
        private void Divide()
        {
            
            double val1 = Converter().Item1;
            double val2 = Converter().Item2;
            if (val2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not a valid mathematical operation");
            }
            else
            {
                Result = (val1 / val2).ToString();
            }
        
        }

        /// <summary>
        /// Raises value one to the  power of value two and sets the result
        /// </summary>
        private void Power()
        {
            double val1 = Converter().Item1;
            double val2 = Converter().Item2;
            Result = (Math.Pow(val1, val2)).ToString();
        }

        /// <summary>
        /// Calls the Logic methods based on the inputed enum values
        /// </summary>
        /// <param name="enumValue"></param>
        public void Equality(int enumValue)
        {
            switch (enumValue)
            {
                case 0:
                    Add();
                    break;
                case 1:
                    Subtract();
                    break;
                case 2:
                    Multiply();
                    break;
                case 3:
                    Divide();
                    break;
                case 4:
                    Power();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// converts the values to doubles returns them as a tuple.
        /// </summary>
        /// <returns></returns>
        private (double, double) Converter()
        {
            return (Utilities.ToDouble(Value1), Utilities.ToDouble(Value2));
        }

    }
}
