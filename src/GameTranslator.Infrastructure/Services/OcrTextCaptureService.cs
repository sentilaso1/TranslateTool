using System.Threading.Tasks;
using GameTranslator.Core.Services;

namespace GameTranslator.Infrastructure.Services
{
    public class OcrTextCaptureService : ITextCaptureService
    {
        public Task<string?> CaptureTextAsync()
        {
            // TODO: Implement OCR text capture from game window
            return Task.FromResult<string?>(null);
        }
    }
}
