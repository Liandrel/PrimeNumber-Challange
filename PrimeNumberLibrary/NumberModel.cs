using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberLibrary
{
    public class NumberModel :IComparable
    {
        public int Value { get; set; }
        public bool IsPrime { get; set; }
        public List<NumberModel> Factors { get; set; } = new();
        public List<NumberModel> PrimeFactors { get; set; } = new();
        
        public NumberModel(int value)
        {
            Value = value;
            IsPrime = IsNumberPrime(Value);
            Factors = AllFactorsOfNumber(Value);
            PrimeFactors = PrimeFactorsOfNumber(Factors);
        }



        private static bool IsNumberPrime(int number)
        {
            if ((number == 2) || (number == 3))
            {
                return true;
            }
            if ((number <= 1) || (number % 2 == 0) || (number % 3 == 0))
            {
                return false;
            }
            for (long i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static List<NumberModel> AllFactorsOfNumber(int number)
        {
            List<NumberModel> output = new();

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    output.Add(new NumberModel(i));
                }
            }

            return output;
        }

        private static List<NumberModel> PrimeFactorsOfNumber(List<NumberModel> factors)
        {
            List<NumberModel> output = new();

            foreach (NumberModel factor in factors)
            {
                if(factor.IsPrime == true)
                {
                    output.Add(factor);
                }
            }
            return output;
        }

        public int CompareTo(object? obj)
        {
            NumberModel? nextNumber = obj as NumberModel;

            return this.Value.CompareTo(nextNumber?.Value);
        }
    }
}
