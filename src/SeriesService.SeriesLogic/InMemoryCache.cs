using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SeriesService.Interfaces;

namespace SeriesService.SeriesLogic
{
    public class InMemoryCache : ISeriesCache
    {
        private readonly Dictionary<string, Dictionary<int,int>> _cache = new Dictionary<string, Dictionary<int, int>>(); 
        public Task<int?> GetAsync(string series, int index)
        {
            if (_cache.ContainsKey(series) && _cache[series].ContainsKey(index))
            {
                return Task.FromResult(_cache[series][index] as int?);
            }

            return Task.FromResult((int?)null);
        }

        public Task<bool> SetAsync(string series, int index, int value)
        {
            if (_cache.ContainsKey(series))
            {
                _cache[series][index] = value;
            }
            else
            {
                lock (_cache)
                {
                    _cache[series] = new Dictionary<int, int>
                    {
                        [index] = value
                    };
                }
            }

            return Task.FromResult(true);
        }
    }
}
