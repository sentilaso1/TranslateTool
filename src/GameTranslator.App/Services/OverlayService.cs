using System.Threading.Tasks;
using GameTranslator.Core.Services;

namespace GameTranslator
{
    public class OverlayService : IOverlayService
    {
        public Task ShowAsync(string text)
        {
            var window = new OverlayWindow();
            window.ShowText(text);
            return Task.CompletedTask;
        }
    }
}

