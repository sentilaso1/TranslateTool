using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string text, string targetLanguage);

        /// <summary>
        /// Translates text using previous context to improve quality.
        /// </summary>
        Task<string> TranslateWithContextAsync(string previousText, string text, string targetLanguage);
    }
}
