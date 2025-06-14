using System.Windows;
using GameTranslator.Core.Models;
using GameTranslator.Core.Services;
using GameTranslator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GameTranslator
{
    public partial class MainWindow : Window
    {
        private readonly ITranslationService _translator;
        private readonly IOverlayService _overlay;

        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection()
                .AddGameTranslator()
                .AddSingleton<IOverlayService, OverlayService>()
                .BuildServiceProvider();

            _translator = services.GetRequiredService<ITranslationService>();
            _overlay = services.GetRequiredService<IOverlayService>();
        }

        private async void Translate_Click(object sender, RoutedEventArgs e)
        {
            var text = InputBox.Text;
            if (string.IsNullOrWhiteSpace(text))
                return;

            var context = new TextContext(text, string.Empty);
            var result = await _translator.TranslateAsync(context, "en");
            await _overlay.ShowAsync(result);
        }
    }
}
