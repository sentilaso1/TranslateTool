using System;
using System.Drawing;
using System.Drawing.Imaging;
using SystemDrawingImageFormat = System.Drawing.Imaging.ImageFormat;
using System.IO;
using System.Threading.Tasks;
using GameTranslator.Core.Services;
using Tesseract;

namespace GameTranslator.Infrastructure.Services
{
    public class OcrTextCaptureService : ITextCaptureService
    {
        private readonly TesseractEngine _engine;

        public OcrTextCaptureService()
        {
            var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");
            _engine = new TesseractEngine(dataPath, "eng", EngineMode.LstmOnly);
        }

        public Task<string?> CaptureTextAsync()
        {
            // Capture a fixed 800x600 region from the top-left corner of the screen
            Rectangle bounds = new Rectangle(0, 0, 800, 600);
            using var bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            using var ms = new MemoryStream();
            bitmap.Save(ms, SystemDrawingImageFormat.Png);
            var bytes = ms.ToArray();
            using var pix = Pix.LoadFromMemory(bytes);
            using var page = _engine.Process(pix);
            var text = page.GetText();
            return Task.FromResult<string?>(string.IsNullOrWhiteSpace(text) ? null : text.Trim());
        }
    }
}
