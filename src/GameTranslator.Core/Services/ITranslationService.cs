using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface ITranslationService
    {
        /// <summary>
        /// Translate the provided text using additional context information.
        /// </summary>
        /// <param name="context">Source text and optional surrounding context.</param>
        /// <param name="targetLanguage">Target language code.</param>
        /// <returns>Translated text.</returns>
        Task<string> TranslateAsync(TextContext context, string targetLanguage);
    }
}
