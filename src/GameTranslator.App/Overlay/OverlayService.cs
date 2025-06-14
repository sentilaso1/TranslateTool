using System.Windows;

namespace GameTranslator.Overlay
{
    /// <summary>
    /// Displays translated text in an always-on-top transparent window.
    /// </summary>
    public class OverlayService
    {
        private OverlayWindow? _window;

        public void ShowText(string text)
        {
            if (_window == null)
            {
                _window = new OverlayWindow();
                _window.Show();
            }

            _window.OverlayText.Text = text;
        }

        public void Close()
        {
            _window?.Close();
            _window = null;
        }
    }
}
