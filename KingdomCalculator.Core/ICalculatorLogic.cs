namespace KingdomCalculator.Core
{
    /// <summary>
    /// Abstraction of calculator Logic class
    /// </summary>
    public interface ICalculatorLogic
    {
        string Result { get; set; }
        string Value1 { get; set; }
        string Value2 { get; set; }

        void Equality(int enumValue);
    }
}