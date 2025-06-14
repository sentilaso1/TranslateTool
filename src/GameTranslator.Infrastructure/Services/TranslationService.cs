using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GameTranslator.Core.Services;
using GameTranslator.Core.Models;

namespace GameTranslator.Infrastructure.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly HttpClient _httpClient;
        private readonly ICacheService _cache;

        public TranslationService(HttpClient httpClient, ICacheService cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<string> TranslateAsync(TextContext context, string targetLanguage)
        {
            var cacheKey = $"{context.SourceText}_{context.Context}_{targetLanguage}";
            var cached = await _cache.GetAsync(cacheKey);
            if (cached != null)
            {
                return cached;
            }

            var query = $"https://api.example.com/translate?text={Uri.EscapeDataString(context.SourceText)}&lang={targetLanguage}&context={Uri.EscapeDataString(context.Context)}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(result);
            var translated = doc.RootElement.GetProperty("translatedText").GetString() ?? string.Empty;
            await _cache.SetAsync(cacheKey, translated);
            return translated;
        }
    }
}
