using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Services;

namespace CalculatorApp.Interfaces
{
    public interface IOperation
    {
        double Execute(double a, double b);
    }
}
