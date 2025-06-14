using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string text, string targetLanguage);
    }
}
