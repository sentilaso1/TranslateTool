using System.Windows;
using GameTranslator.Core.Services;

namespace GameTranslator.Infrastructure.Services
{
    public class OverlayService : IOverlayService
    {
        private OverlayWindow? _window;

        public void Show(string text)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_window == null)
                {
                    _window = new OverlayWindow();
                }
                _window.SetText(text);
                if (!_window.IsVisible)
                {
                    _window.Show();
                }
            });
        }
    }
}
