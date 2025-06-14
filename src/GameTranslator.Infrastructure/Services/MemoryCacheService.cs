using System.Collections.Concurrent;
using System.Threading.Tasks;
using GameTranslator.Core.Services;

namespace GameTranslator.Infrastructure.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly ConcurrentDictionary<string, string> _cache = new();

        public Task<string?> GetAsync(string key)
        {
            _cache.TryGetValue(key, out var value);
            return Task.FromResult<string?>(value);
        }

        public Task SetAsync(string key, string value)
        {
            _cache[key] = value;
            return Task.CompletedTask;
        }
    }
}
