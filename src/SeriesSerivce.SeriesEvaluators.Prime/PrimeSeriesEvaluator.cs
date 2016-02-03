using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeriesService.Interfaces;

namespace SeriesSerivce.SeriesEvaluators.Prime
{
    public class PrimeSeriesEvaluator : ISeriesEvaluator
    {
        public string SeriesName => "Prime";
        public int Evaluate(int index)
        {
            var count = 0;

            for (var i = 1; count <= index; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
                
                if (count == index)
                {
                    return i;
                }
            }

            throw new Exception("oopsy");
        }

        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}
