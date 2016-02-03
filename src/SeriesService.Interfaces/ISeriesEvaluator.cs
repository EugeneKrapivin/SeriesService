using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesService.Interfaces
{
    public interface ISeriesEvaluator
    {
        string SeriesName { get; }
        int Evaluate(int index);
    }
}
