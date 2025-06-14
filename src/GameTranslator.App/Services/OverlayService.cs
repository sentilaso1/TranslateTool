using System.Threading.Tasks;
using GameTranslator.Core.Services;

namespace GameTranslator.Services
{
    public class OverlayService : IOverlayService
    {
        private OverlayWindow? _window;

        public Task ShowAsync(string text)
        {
            if (_window == null)
            {
                _window = new OverlayWindow();
            }
            _window.SetText(text);
            _window.Show();
            return Task.CompletedTask;
        }

        public Task HideAsync()
        {
            _window?.Hide();
            return Task.CompletedTask;
        }
    }
}
