using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GameTranslator.Core.Services;

namespace GameTranslator.Infrastructure.Services
{
    public class GoogleTranslationService : ITranslationService
    {
        private readonly HttpClient _httpClient;
        private readonly ICacheService _cache;

        public GoogleTranslationService(HttpClient httpClient, ICacheService cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<string> TranslateAsync(string text, string targetLanguage)
        {
            var cacheKey = $"{text}_{targetLanguage}";
            var cached = await _cache.GetAsync(cacheKey);
            if (cached != null)
                return cached;

            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={targetLanguage}&dt=t&q={Uri.EscapeDataString(text)}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(result);
            var translated = doc.RootElement[0][0][0].GetString() ?? string.Empty;
            await _cache.SetAsync(cacheKey, translated);
            return translated;
        }
    }
}
