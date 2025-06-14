using System.Net.Http;
using GameTranslator.Core.Services;
using GameTranslator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameTranslator.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameTranslator(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<ITranslationService, GoogleTranslationService>();
            services.AddSingleton<ITextCaptureService, OcrTextCaptureService>();
            services.AddSingleton<IOverlayService, OverlayService>();
            services.AddSingleton<IContextService, TextContextService>();
            return services;
        }
    }
}
