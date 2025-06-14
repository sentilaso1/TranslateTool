using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using GameTranslator.Core.Services;
using Tesseract;

namespace GameTranslator.Infrastructure.Services
{
    /// <summary>
    /// Uses the Tesseract OCR engine to extract text from a screenshot.
    /// </summary>
    public class TesseractTextCaptureService : ITextCaptureService
    {
        private readonly TesseractEngine _engine;

        public TesseractTextCaptureService()
        {
            var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");
            _engine = new TesseractEngine(dataPath, "eng", EngineMode.LstmOnly);
        }

        public Task<string?> CaptureTextAsync()
        {
            // In a real application you would capture the game window here.
            // For this skeleton we load a sample screenshot if available.
            const string sample = "sample.png";
            if (!File.Exists(sample))
            {
                return Task.FromResult<string?>(null);
            }

            using var img = Pix.LoadFromFile(sample);
            using var page = _engine.Process(img);
            var text = page.GetText();
            return Task.FromResult<string?>(text);
        }
    }
}
