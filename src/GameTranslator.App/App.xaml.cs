using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using GameTranslator.Infrastructure;

namespace GameTranslator
{
    public partial class App : Application
    {
        private ServiceProvider? _provider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            services.AddGameTranslator();
            services.AddSingleton<MainWindow>();
            _provider = services.BuildServiceProvider();

            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
