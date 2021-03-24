using System;

namespace KingdomCalculator.Commons
{
    public static class Utilities
    {
        /// <summary>
        /// Converts a string to its double equivalent.
        /// Throws an error if the string is of a wrong input format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(string value)
        {
            return Convert.ToDouble(value);
        }

    }
}
