using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv09
{
    class Calculator
    {

        public string Display { get; private set; }
        public string Memory { get; private set; }

        private double operand1;
        private double operand2;

        private enum Operand { add, subtract, times, divide, equals };

        private Operand _operand;
        private CultureInfo myCulture;

        public Calculator()
        {
            myCulture = new CultureInfo("cs-cz");
            _operand = Operand.equals;
            operand1 = 0;
            Display = "0";
            Memory = "0";
        }


        public void Button(string pressedButton)
        {

        }

        public void NumberButton(string pressedButton)
        {
            if (pressedButton == "," && Display == "") Display = "0";
            if (Display != "" && !Char.IsDigit(Display[0])) Display = "";
            if ( Display == "0"&& pressedButton != ",") Display = pressedButton;
            else if((!Display.Contains(",")&& pressedButton == ",")|| pressedButton != ",") Display += pressedButton;
             
        }

        public void ClearButton(string pressedButton)
        {
            switch (pressedButton)
            {
                case ("C"):
                    Display = "";
                    break;
                case ("CE"):
                    Display = "";
                    _operand = Operand.equals;
                    break;
                case ("<="):
                    if (Display.Length > 0) Display = Display.Remove(Display.Length - 1);
                    break;
            }
        }

        public void Evaluate()
        {
            operand2 = double.Parse(Display, myCulture);
            switch (_operand)
            {
                case Operand.equals:
                    break;
                case Operand.add:
                    Display = "" + (operand1 + operand2);
                    break;
                case Operand.subtract:
                    Display = "" + (operand1 - operand2);
                    break;
                case Operand.times:
                    Display = "" + (operand1 * operand2);
                    break;
                case Operand.divide:
                    if (operand2 == 0) Display = "Cannot divide by 0";
                    else Display = "" + (operand1 / operand2);
                    break;
            }
            _operand = Operand.equals;
        }
        public void OperationSet(string pressedButton)
        {
            operand1 = double.Parse(Display, myCulture);

            switch (pressedButton)
            {
                case "+":
                    _operand = Operand.add;
                    Display = "+";
                    break;
                case "-":
                    _operand = Operand.subtract;
                    Display = "-";
                    break;
                case "*":
                    _operand = Operand.times;
                    Display = "*";
                    break;
                case "/":
                    _operand = Operand.divide;
                    Display = "/";
                    break;
                case "X*X":
                    Display = "" + (operand1 * operand1);
                    break;
            }
        }
        public void MemoryOperation(string pressedButton)
        {
            switch (pressedButton)
            {
                case "MC":
                    Memory = "0";
                    break;
                case "MS":
                    if (Display != "" && Char.IsDigit(Display[0])) Memory = Display;
                    break;
                case "MR":
                    Display = Memory;
                    break;
                case "M+":
                    if (Display != "" && Char.IsDigit(Display[0]))
                    {
                        Memory = "" + (double.Parse(Memory, myCulture) + double.Parse(Display, myCulture));
                    }
                    break;
                case "M-":
                    if (Display != "" && Char.IsDigit(Display[0]))
                    {
                        Memory = "" + (double.Parse(Memory, myCulture) - double.Parse(Display, myCulture));
                    }
                    break;


            }
        }
    }
}
