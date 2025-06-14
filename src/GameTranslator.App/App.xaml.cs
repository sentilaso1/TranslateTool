using System;
using System.Windows;
using GameTranslator.Core.Services;
using GameTranslator.Services;
using GameTranslator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GameTranslator
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            var sc = new ServiceCollection();
            sc.AddGameTranslator();
            sc.AddSingleton<IOverlayService, OverlayService>();
            Services = sc.BuildServiceProvider();
            base.OnStartup(e);
        }
    }
}
