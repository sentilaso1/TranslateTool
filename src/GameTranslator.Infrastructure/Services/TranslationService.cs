using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GameTranslator.Core.Services;

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

        public async Task<string> TranslateAsync(string text, string targetLanguage)
        {
            var cacheKey = $"{text}_{targetLanguage}";
            var cached = await _cache.GetAsync(cacheKey);
            if (cached != null)
            {
                return cached;
            }

            var response = await _httpClient.GetAsync($"https://api.example.com/translate?text={Uri.EscapeDataString(text)}&lang={targetLanguage}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(result);
            var translated = doc.RootElement.GetProperty("translatedText").GetString() ?? string.Empty;
            await _cache.SetAsync(cacheKey, translated);
            return translated;
        }

        /// <summary>
        /// Translates a phrase using additional context to improve result quality.
        /// </summary>
        /// <param name="previousText">Previously translated text that provides context.</param>
        /// <param name="text">Current text to translate.</param>
        /// <param name="targetLanguage">Target language code.</param>
        public async Task<string> TranslateWithContextAsync(string previousText, string text, string targetLanguage)
        {
            var combined = string.IsNullOrWhiteSpace(previousText) ? text : previousText + "\n" + text;
            return await TranslateAsync(combined, targetLanguage);
        }
    }
}
