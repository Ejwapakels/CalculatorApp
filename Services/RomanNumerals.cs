using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public static class RomanNumerals
    {
        private static readonly Dictionary<char, int> RomanMap = new()
        {
            {'I', 1}, {'V', 5}, {'X', 10},{'L', 50},{'C', 100},{'D', 500},{'M', 1000}
        };

        private static readonly Dictionary<int, string> IntToRomanMap = new()
        {
            {1000, "M" },{900, "CM" }, {500,"D"},{400, "CD" },{100, "C"},{90,"XC" },{50, "L"},{40,"XL" },{10, "X"}, {9, "IX"}, {8, "VIII"}, {7, "VII"}, {6, "VI"},
            {5, "V"}, {4, "IV"}, {3, "III"}, {2, "II"}, {1, "I"}
        };

        public static int RomanToInt(string roman)
        {
            int total = 0;
            int prev = 0;

            foreach (char c in roman.ToUpper())
            {
                if (!RomanMap.ContainsKey(c)) throw new ArgumentException(" Invalid Roman numeral (only I to M supported");

                int current = RomanMap[c];
                total += current > prev ? current - 2 * prev : current;
                prev = current;
            }

            if (total < 1 || total > 1000)
                throw new ArgumentException("Only Roman numerals I to M are supported.");

            return total;
        }

        public static string IntToRoman(int number)
        {
            if (number < 1 || number > 1000)
                throw new ArgumentException("Only results from 1 to 1000 can be shown in Roman numerals.");

            var map = new Dictionary<int, string>
            {
                {1000,"M" },{900,"CM" }, {500,"D"},{400,"CD"},
                {100,"C"},{90,"XC" },{50,"L"},{40,"XL" },
                {10,"X"},{9,"IX"},{5,"V"}, {4,"IV"}, {1,"I"}
            };

            var result = "";
            foreach (var kvp in map)
            {
                while (number >= kvp.Key)
                {
                    result += kvp.Value;
                    number -= kvp.Key;
                }
                
            }
            return result;

        }
    }
}