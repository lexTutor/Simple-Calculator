using KingdomCalculator.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KingdomCalculator.UI
{
    /// <summary>
    /// Calculator User Interface
    /// An abstraction of the calculator Logic is injected
    /// </summary>
    public partial class CalculatorUI : Form
    {
        public readonly ICalculatorLogic _calculator;

        //Notes the current operation being executed in the system
        static OperationsEnum currentOperation = OperationsEnum.None;

        //Counts the number of decimals points pressed by the user. 
        //Cannot be more than one per operation.
        private int DecimalCount = 0;

        //Notes if the negator has been pressed  by the user
        //If false a Negative value is added to the front of the digit
        //If true the Negative value is removed from the front of the digit.
        private bool negate = false;
        public CalculatorUI(ICalculatorLogic calculator)
        {
            InitializeComponent();
            _calculator = calculator;
        }

        /// <summary>
        /// Deletes the last caharacter inputed into the calculator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataEntryLabel.Text[^1] ==  '+' || DataEntryLabel.Text[^1] == '-' || DataEntryLabel.Text[^1] == '*' || DataEntryLabel.Text[^1] == '/' || DataEntryLabel.Text[^1] == '^')
                {
                    currentOperation = OperationsEnum.None;
                }
                DeleteLastIndex();
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }
        }

        /// <summary>
        /// Clears all the labels in the UI and local instance of the calculator
        /// By setting their value to null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            try
            {
                currentOperation = OperationsEnum.None;
                displayLabel.Text = null;
                DataEntryLabel.Text = null;
                _calculator.Value1 = null;
                _calculator.Value2 =null;
                _calculator.Result = null;
                DecimalCount = 0;
            }
            catch (Exception)
            {
                displayLabel.Text = "Error";
                Clear_Click(sender, e);
            }
        }

        /// <summary>
        /// Adds the raised to power operand (^) to the input values.
        /// Sets the current operation to power
        /// If clicked while an operand was last entered, overrides the operation and resets the current operation to power
        /// If clicked when a full set of oprations are waiting to be executed
        /// it executes the operation and sets the operand infront of the result of the previous operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Power_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty && ((DataEntryLabel.Text[^1]) == '.' || int.TryParse((DataEntryLabel.Text[^1]).ToString(), out _));
                if (DataEntryLabel.Text == string.Empty && _calculator.Result != null)
                {
                    DataEntryLabel.Text += _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Power;
                }
                else if (currentOperation == OperationsEnum.None && DataEntryLabel.Text != null)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Power;
                }
                else if (currentOperation != OperationsEnum.None && !lastIndexCheck)
                {
                    DeleteLastIndex();
                    DataEntryLabel.Text += ((Button)sender).Text;
                    currentOperation = OperationsEnum.Power;
                    DecimalCount = 0;
                }
                else
                {
                    Total();
                    DataEntryLabel.Text = _calculator.Result + ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Power;
                    negate = false;
                }
            }
            catch (Exception)
            {
                displayLabel.Text = "Error";
                Clear_Click(sender, e);
            }
        }

        /// <summary>
        /// Adds the division operand (/) to the input values.
        /// Sets the current operation to divide
        /// If clicked while an operand was last entered, overrides the operation and resets the current operation to Division
        /// If clicked when a full set of oprations are waiting to be executed
        /// it executes the operation and sets the operand infront of the result of the previous operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Division_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty && ((DataEntryLabel.Text[^1]) == '.' || int.TryParse((DataEntryLabel.Text[^1]).ToString(), out _));
                if (DataEntryLabel.Text == string.Empty && _calculator.Result != null)
                {
                    DataEntryLabel.Text += _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Divide;

                }
                else if (currentOperation == OperationsEnum.None && lastIndexCheck == true)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Divide;
                }
                else if (currentOperation != OperationsEnum.None && !lastIndexCheck)
                {
                    DeleteLastIndex();
                    DataEntryLabel.Text +=((Button)sender).Text;
                    currentOperation = OperationsEnum.Divide;
                    DecimalCount = 0;
                }
                else if (currentOperation != OperationsEnum.None && lastIndexCheck == true)
                {
                    Total();
                    DataEntryLabel.Text = _calculator.Result + ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Divide;
                    negate = false;
                }
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }

        }

        /// <summary>
        /// Adds the multiplication operand (*) to the input values.
        /// Sets the current operation to multiply
        /// If clicked while an operand was last entered, overrides the operation and resets the current operation to Multiplication
        /// If clicked when a full set of oprations are waiting to be executed
        /// it executes the operation and sets the operand infront of the result of the previous operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Multiplication_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty && ((DataEntryLabel.Text[^1]) == '.' || int.TryParse((DataEntryLabel.Text[^1]).ToString(), out _));


                if (DataEntryLabel.Text == string.Empty && _calculator.Result != null)
                {
                    DataEntryLabel.Text += _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Multiply;
                }
                else if (currentOperation == OperationsEnum.None && lastIndexCheck == true)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Multiply;
                }
                else if (currentOperation != OperationsEnum.None && !lastIndexCheck)
                {
                    DeleteLastIndex();
                    DataEntryLabel.Text += ((Button)sender).Text;
                    currentOperation = OperationsEnum.Multiply;
                    DecimalCount = 0;
                }
                else if (currentOperation != OperationsEnum.None && lastIndexCheck == true)
                {
                    Total();
                    DataEntryLabel.Text = _calculator.Result + ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Multiply;
                    negate = false;
                }
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }
        }

        /// <summary>
        /// Adds the subtraction operand (-) to the input values.
        /// Sets the current operation to subtraction
        /// If clicked while an operand was last entered, overrides the operation and resets the current operation to Subtraction
        /// If clicked when a full set of oprations are waiting to be executed
        /// it executes the operation and sets the operand infront of the result of the previous operation.
        /// If the current operation is power it appends a negative sign to the input without changing the operand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Subtraction_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty &&((DataEntryLabel.Text[^1]) == '.'|| int.TryParse((DataEntryLabel.Text[^1]).ToString(), out _));

                if (DataEntryLabel.Text == string.Empty && _calculator.Result != null)
                {
                    DataEntryLabel.Text += _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Subtract;

                }
                else if (currentOperation == OperationsEnum.None && lastIndexCheck == true)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Subtract;
                }

                else if (currentOperation == OperationsEnum.Power && !lastIndexCheck)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                }
                else if (currentOperation != OperationsEnum.None && !lastIndexCheck)
                {
                    DeleteLastIndex();
                    DataEntryLabel.Text += ((Button)sender).Text;
                    currentOperation = OperationsEnum.Subtract;
                    DecimalCount = 0;
                }
                else if (currentOperation != OperationsEnum.None && lastIndexCheck == true)
                {
                    Total();
                    DataEntryLabel.Text = _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Subtract;
                    negate = false;
                }
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }
        }

        /// <summary>
        /// Adds the addition operand (+) to the input values.
        /// Sets the current operation to Add
        /// If clicked while an operand was last entered, overrides the operation and resets the current operation to Addition
        /// If clicked when a full set of oprations are waiting to be executed
        /// it executes the operation and sets the operand infront of the result of the previous operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Addition_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty && ((DataEntryLabel.Text[^1]) == '.' || int.TryParse((DataEntryLabel.Text[^1]).ToString(), out _));

                if (DataEntryLabel.Text == string.Empty && _calculator.Result != null)
                {
                    DataEntryLabel.Text += _calculator.Result + ((Button)sender).Text;
                    currentOperation = OperationsEnum.Add;

                }
                else if(currentOperation == OperationsEnum.None && lastIndexCheck == true)
                {
                    DataEntryLabel.Text += ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Add;
                }
                else if (currentOperation != OperationsEnum.None && !lastIndexCheck)
                {
                    DeleteLastIndex();
                    DataEntryLabel.Text += ((Button)sender).Text;
                    currentOperation = OperationsEnum.Add;
                    DecimalCount = 0;
                }
                else if (currentOperation != OperationsEnum.None && lastIndexCheck == true)
                {
                    Total();
                    DataEntryLabel.Text = _calculator.Result + ((Button)sender).Text;
                    DecimalCount = 0;
                    currentOperation = OperationsEnum.Add;
                    negate = false;
                }
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }
        }

        /// <summary>
        /// Equaltity function to calculate the total of the inputs
        /// Executes if the current operation is not none and the lastindex is a valid number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equality_Click(object sender, EventArgs e)
        {
            try
            {
                //checks that the last index of entry is a valid number before executing functions
                bool lastIndexCheck = DataEntryLabel.Text != string.Empty && int.TryParse(DataEntryLabel.Text[^1].ToString(), out _);
                
                if (DataEntryLabel.Text == string.Empty)
                {

                }
                else if (currentOperation != OperationsEnum.None && lastIndexCheck == true)
                {

                    Total();
                    displayLabel.Text = _calculator.Result;
                    DataEntryLabel.Text = _calculator.Result;
                    currentOperation = OperationsEnum.None;
                    DataEntryLabel.Text = null;
                    DecimalCount = 0;
                    negate = false;
                }
            }
            catch (Exception) { displayLabel.Text = "Error"; Clear_Click(sender, e); }

        }

        /// <summary>
        /// Sets the values of the calculator depending on the current opertaion
        /// Calls the equaltiy functionn
        /// </summary>
        private void Total()
        {
            try
            {
            string[] list = new string[2];
            if (DataEntryLabel.Text[0] == '-')
            {
                var str = DataEntryLabel.Text.Substring(1);
                list = str.Split('+', '-', '/', '*', '^');
            }
            else
            {
                list = DataEntryLabel.Text.Split('+', '-', '/', '*', '^');
            }
               
            if (currentOperation == OperationsEnum.None || list.Length < 2)
            {
               
            }
            else if (currentOperation == OperationsEnum.Power)
            {
                var list1 = DataEntryLabel.Text.Split('^');
                _calculator.Value1 = list1[0] == "."? 0.ToString(): list[0];
                _calculator.Value2 = list1[1];
                _calculator.Equality((int)currentOperation);
                currentOperation = OperationsEnum.None;
            }
            else
            {
                _calculator.Value1 = list[0] == "." ? 0.ToString() : list[0];
                _calculator.Value1 = negate == true ? "-" + list[0] : list[0];
                _calculator.Value2 = list[1];
                _calculator.Equality((int)currentOperation);
                currentOperation = OperationsEnum.None;

            }
            }
            catch (Exception)
            {
                _calculator.Result = "Error";
            }
        }

        /// <summary>
        /// Function that deletes the last character entered.
        /// </summary>
        private void DeleteLastIndex()
        {
            _ = DataEntryLabel.Text != string.Empty ? DataEntryLabel.Text = DataEntryLabel.Text.
                   Remove(DataEntryLabel.Text.Length - 1) : DataEntryLabel.Text = null;
        }

        #region Value Buttons

        /// <summary>
        /// Adds a decimal to the input if the decimal count is zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dot_Click(object sender, EventArgs e)
        {
            if (DecimalCount == 0)
            {
                DataEntryLabel.Text += '.';
                DecimalCount++;
            }
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '0';
        }

        /// <summary>
        /// Inserts a negator to the first index of the inputed characters if the negate property is false.
        /// Removes the negator if the negate property is true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleZero_Click(object sender, EventArgs e)
        {
            if (negate == false)
            {
                DataEntryLabel.Text = DataEntryLabel.Text.Insert(0, "-");
                negate = true;
            }
            else if(negate == true)
            {
                DataEntryLabel.Text = DataEntryLabel.Text[1..];
                negate = false;
            }
            if (DataEntryLabel.Text == "-" && _calculator.Result != string.Empty)
            {
                DataEntryLabel.Text += _calculator.Result;
            }

        }

        private void One_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '1';
        }

        private void Two_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '2';
        }

        private void Three_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '3';
        }

        private void Four_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '4';
        }

        private void Five_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '5';
        }

        private void Six_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '6';
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '7';
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '8';
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            DataEntryLabel.Text += '9';
        }
        #endregion
    }
}
