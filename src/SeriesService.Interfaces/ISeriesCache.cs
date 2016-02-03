using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesService.Interfaces
{
    public interface ISeriesCache
    {
        Task<int?> GetAsync(string series, int index);
        Task<bool> SetAsync(string series, int index, int value);
    }
}
