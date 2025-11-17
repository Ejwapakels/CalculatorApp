using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


namespace CalculatorApp
{
    enum Operation { Add, Subtract, Multiply, Divide, Exit, Invalid }

    class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, int b) => a * b;
        public double Divide(double a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");

            return a / b;
        }
    }

    static class RomanNumerals
    {
        private static readonly Dictionary<char, int> RomanMap = new()
        {
            {'I', 1}, {'V', 5}, {'X', 10}
        };

        private static readonly Dictionary<int, string> IntToRomanMap = new()
        {
            {10, "X"}, {9, "IX"}, {8, "VIII"}, {7, "VII"}, {6, "VI"},
            {5, "V"}, {4, "IV"}, {3, "III"}, {2, "II"}, {1, "I"}
        };

        public static int RomanToInt(string roman)
        {
            int total = 0;
            int prev = 0;

            foreach (char c in roman.ToUpper())
            {
                if (!RomanMap.ContainsKey(c)) throw new ArgumentException(" Invalid Roman numeral (only I to X supported");

                int current = RomanMap[c];
                total += current > prev ? current - 2 * prev : current;
                prev = current;
            }

            if (total < 1 || total > 10)
                throw new ArgumentException("Only Roman numerals I to X are supported.");

            return total;
        }

        public static string IntToRoman(int number)
        {
            if (number < 1 || number > 10) throw new ArgumentException("Only results from 1 to 10 can be shown in Roman numerals.");

            return IntToRomanMap[number];
        }

    

        class Program
        {

            static void Main(string[] args)
            {
                var calculator = new Calculator();
                bool running = true;

                while (running)
                {
                    Console.Clear();
                    ShowMenu();

                    Operation op = GetChoice();

                    if (op == Operation.Exit) running = false;
                    else if (op == Operation.Invalid) Pause("Invalid Choice!");
                    else
                    {
                        double num1 = GetNumber("Enter the First Number (1-10 or I-X): ");
                        double num2 = GetNumber("Enter the Second Number (1-10 or I-X): ");

                        try
                        {
                            double result = op switch
                            {
                                Operation.Add => calculator.Add(num1, num2),
                                Operation.Subtract => calculator.Subtract(num1, num2),
                                Operation.Multiply => calculator.Multiply(num1, (int)num2),
                                Operation.Divide => calculator.Divide(num1, (int)num2),
                                _ => 0
                            };

                            Console.WriteLine("Show result in Roman Numerals? (Y/N): ");
                            if (Console.ReadLine().Trim().ToLower() == "Y")
                            {
                                try
                                {
                                    Console.WriteLine($"Result: {RomanNumerals.IntToRoman((int)result)}");
                                }
                                catch
                                {
                                    Console.WriteLine("Result cannot be reprensented in Roman numerals (only 1-10 supported).");
                                }
                            }
                            else
                            {
                                if (result >= 1 && result <= 10 && result == (int)result)
                                {
                                    string roman = RomanNumerals.IntToRoman((int)result);
                                    Console.WriteLine($"Result: {result} ({roman})");
                                }
                            }
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Pause("Press any key to continue...");
                    }
                }
            }

            static void ShowMenu()
            {
                Console.WriteLine("=== Simple Calculator ===");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
            }

            static Operation GetChoice()
            {
                Console.Write("Choose an option: ");
                return Console.ReadLine() switch
                {
                    "1" => Operation.Add,
                    "2" => Operation.Subtract,
                    "3" => Operation.Multiply,
                    "4" => Operation.Divide,
                    "5" => Operation.Exit,
                    _ => Operation.Invalid
                };
            }

            static double GetNumber(string message)
            {
                while (true)
                {
                    Console.Write(message);
                    string input = Console.ReadLine();


                    if (double.TryParse(input, out double value) && value >= 1 && value <= 10)
                        return value;
                    try
                    {
                        return RomanNumerals.RomanToInt(input);
                    }
                
                catch
                {
                        Console.WriteLine("Invalid input. Enter a number between 1 and 10 or a Roman Numeral from I to X.");
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
}
               