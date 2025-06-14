using System.Windows;
using GameTranslator.Core.Services;

namespace GameTranslator
{
    public partial class MainWindow : Window
    {
        private readonly ITextCaptureService _captureService;
        private readonly ITranslationService _translationService;
        private readonly IOverlayService _overlayService;
        private readonly IContextService _context;

        public MainWindow(ITextCaptureService captureService,
                          ITranslationService translationService,
                          IOverlayService overlayService,
                          IContextService context)
        {
            _captureService = captureService;
            _translationService = translationService;
            _overlayService = overlayService;
            _context = context;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var text = await _captureService.CaptureTextAsync();
            if (text == null) return;
            _context.Add(text);
            var translation = await _translationService.TranslateAsync(text, "en");
            _overlayService.Show(translation);
        }
    }
}
