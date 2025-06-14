using System.Windows;

namespace GameTranslator
{
    public partial class OverlayWindow : Window
    {
        public OverlayWindow()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            TextBlock.Text = text;
        }
    }
}
