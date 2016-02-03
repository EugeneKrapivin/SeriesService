using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesService.Interfaces
{
    public interface ISeriesLogic
    {
        Task<int> Evalute(string series, int index);
        Task<IEnumerable<string>> GetSeriesEvaluators();
    }
}
