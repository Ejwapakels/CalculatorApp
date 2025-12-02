using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public class DivideOperation : IOperation
    {
        public double Execute(double a, double b)
        {
            if (b== 0) throw new DivideByZeroException("Cannot divide by zero");
            return a / b;
        }
    }
}
