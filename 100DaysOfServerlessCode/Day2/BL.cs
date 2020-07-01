using System;
using System.Collections.Generic;
using System.Text;

namespace _100DaysOfServerlessCode.Day2
{
    class BL
    {
        public static string calculate(float num1,float num2,string operation) {

            if (operation.ToLower() == "addition")
            {
                return $"The sum of {num1} and {num2} is {num1 + num2}";
            }
            else if (operation.ToLower() == "substraction")
            {
                return $"The sum of {num1} and {num2} is {num1 + num2}";
            }
            else if (operation.ToLower() == "multiplication")
            {
                return $"The sum of {num1} and {num2} is {num1 + num2}";
            }
            else if (operation.ToLower() == "division")
            {
                return $"The sum of {num1} and {num2} is {num1 + num2}";
            }
            else
            {
                return $"Please select a valid opertaion to perform on {num1} and {num2}. {operation} is not a valid operation.";
            }

        }
    }
}
