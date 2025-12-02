using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using CalculatorApp.Services;
using CalculatorApp.Interfaces;



namespace CalculatorApp
{

    class Program
    {

        static void Main()
        {
           
            var inputHandler = new InputHandler();
            var outputHandler = new OutputHandler();


            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Simple Calculator ===");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "5") break;

                double num1 = inputHandler.GetNumber("Enter the First Number (1-1000 or I-M): ");
                double num2 = inputHandler.GetNumber("Enter the Second Number (1-1000 or I-M): ");

                // Use IOperation for selected operation
                IOperation operation = choice switch 
                {
                 "1" => new AddOperation(),
                 "2" => new SubtractOperation(),
                 "3" => new MultiplyOperation(),
                 "4" => new DivideOperation(),
                 _ => null
                 };

                if (operation == null)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                try
                {
                    double result = operation.Execute(num1, num2);
                    outputHandler.ShowResult(result); // This handles Roman Numeral Display
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }    
}
               