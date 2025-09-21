using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformOperation("Add");
                        break;
                    case "2":
                        PerformOperation("Subtract");
                        break;
                    case "3":
                        PerformOperation("Multiply");
                        break;
                    case "4":
                        PerformOperation("Divide");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Press any key...");
                        Console.ReadKey();
                        break;

                }
            }
        }

        static void PerformOperation(string operation)
        {
            Console.WriteLine("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case "Add":
                    result = num1 + num2;
                    break;
                case "Subtract":
                    result = num1 - num2;
                    break;
                case "Multiply":
                    result = num1 * num2;
                    break;
                case "Divide":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Error: Divising by zero!");
                        Console.ReadKey();
                        return;
                    }
                    break;
                        
            }

            Console.WriteLine($"Result: {result}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}