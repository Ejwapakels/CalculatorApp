using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public class OutputHandler
    {
        public void ShowResult(double result)
        {

            // Always show the decimal result first before Roman Numeral
            Console.WriteLine($"Result: {result}");

            // If result is an integer and within Roman Numeral range, show the Roman equivalent

            if (result >= 1 && result <= 1000 && result == (int)result)
            {
                string romanValue = RomanNumerals.IntToRoman((int)result);
                Console.WriteLine($"Roman Numeral : {romanValue}");
            }
            else
            {
                {   
                    // Tell user that Roman Numeral representation is not available for this value
                    Console.WriteLine("Roman Numeral representation is not available for this value.");
                }
            }
        }
    }
}
