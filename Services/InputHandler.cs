using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public class InputHandler
    {
        public double GetNumber (string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();


                if (double.TryParse(input, out double value) && value >= 1 && value <= 1000)
                    return value;
                try
                {
                    return RomanNumerals.RomanToInt(input);
                }

                catch
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 10 or a Roman Numeral from I to M.");
                }
            }
        }
        static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
