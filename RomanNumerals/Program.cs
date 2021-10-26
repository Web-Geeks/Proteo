using System;
using System.Linq;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            string prompt = "Please enter number (example 5): ";
            Console.Write(prompt);

            while (true)
            {
                //check to make sure valid values are entered
                int inputValue;
                while (!TryParseInteger(Console.ReadLine(), out inputValue))
                {
                    Console.WriteLine("Invalid Input. Try Again...");
                    Console.Write(prompt);
                }

                Console.WriteLine(ConvertToRoman(inputValue));
                Console.Write(prompt);
            }
        }


        public static string ConvertToRoman(int n)
        {
            if (n < 0)
                return "Please enter a positive integer";
            else if (n > 3999)
            {
                return "Maximum Number is 3999.  Please try a number between 0 and 3999";
            }
            else if (n == 0)
            {
                return "Nullus";
            }

            else
            {
                string[] m = { "", "M", "MM", "MMM" };
                string[] c = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC","DCCC", "CM" };
                string[] x = { "", "X", "XX", "XXX","XL","L", "LX", "LXX", "LXXX","XC" };
                string[] i = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

                var thousands = m[n/ 1000];
                var hundreds = c[(n / 100) % 10];
                var tens = x[(n / 10) % 10];
                var ones = i[n % 10];

                var ans = thousands + hundreds + tens + ones;

                return ans;
            }
        }

        public static bool TryParseInteger(string input, out int inputValue)
        {
            inputValue = default;

            if (int.TryParse(input.Trim(), out inputValue))
            {
                return true;
            }

            return false;
        }
    }
}
