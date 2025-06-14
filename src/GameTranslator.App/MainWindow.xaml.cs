using System.Windows;
using GameTranslator.Overlay;

namespace GameTranslator
{
    public partial class MainWindow : Window
    {
        private readonly OverlayService _overlay = new();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Example usage of the overlay: display a welcome message
            _overlay.ShowText("Translation overlay ready");
        }
    }
}
