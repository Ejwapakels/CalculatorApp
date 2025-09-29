using System;


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
                    double num1 = GetNumber("Enter the First Number: ");
                    double num2 = GetNumber("Enter the Second Number: ");

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

                        Console.WriteLine($"Result: {result}");
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
            double value;
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Invalid number, try again.");
            }
        }

        static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
               