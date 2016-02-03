using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeriesService.Interfaces;

namespace SeriesSerivce.SeriesEvaluators.Fibonacci
{
    public class FibonacciSeriesEvaluator : ISeriesEvaluator
    {
        public string SeriesName => "Fibonacci";
        public int Evaluate(int index)
        {
            return index == 1 || index == 2 ? index : Evaluate(index - 1) + Evaluate(index - 2);
        }
    }
}
