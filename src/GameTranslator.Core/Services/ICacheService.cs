using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface ICacheService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}
