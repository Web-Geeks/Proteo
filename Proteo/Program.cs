using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Proteo
{
    class Program
    {
        static void Main(string[] args)
        {
            string prompt = "Please enter multiple integers (1, 2, 3): ";
            Console.Write(prompt);

            while (true)
            {
                //check to make sure valid values are entered
                int[] inputValues;
                while (!TryParseIntegerList(Console.ReadLine(), out inputValues))
                {
                    Console.WriteLine("Invalid Input. Try Again...");
                    Console.Write(prompt);
                }

                Console.WriteLine(divisible_by_five(inputValues));
                Console.Write(prompt);
            }
        }

        public static bool TryParseIntegerList(string input, out int[] inputValues)
        {
            inputValues = default;

            var splits = input.Split(",");
            var result = new int[splits.Length];
            if (splits.Where((t, i) => !int.TryParse(t.Trim(), out result[i])).Any())
            {
                return false;
            }
            inputValues = result;

            return true;
        }

        public static int divisible_by_five(int[] my_list)
        {
            //sum the list to check if the total is less than 100

            var sumOfList = my_list.Sum();

            switch (sumOfList)
            {
                case < 100:
                {
                    int nInRange = 0;
                    foreach (int a in my_list)
                    {
                        switch (a % 5)
                        {
                            case 0:
                                nInRange++;
                                break;
                        }
                    }
                    return nInRange;
                }
                default:
                    return 0;
            }
        }

       

    }
}
