using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Interfaces;


namespace CalculatorApp.Services
{
    public class MultiplyOperation : IOperation
    {
        public double Execute(double a, double b) => a * b;
    }
}
