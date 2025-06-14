using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using GameTranslator.Core.Services;

namespace GameTranslator
{
    public partial class MainWindow : Window
    {
        private readonly IOverlayService _overlay;

        public MainWindow()
        {
            InitializeComponent();
            _overlay = (IOverlayService)App.Services.GetRequiredService(typeof(IOverlayService));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _overlay.ShowAsync("Translation overlay ready");
        }
    }
}
