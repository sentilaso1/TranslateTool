using System.Threading.Tasks;

namespace GameTranslator.Core.Services
{
    public interface ITextCaptureService
    {
        Task<string?> CaptureTextAsync();
    }
}
