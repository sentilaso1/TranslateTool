using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GameTranslator.Core.Services;
using GameTranslator.Infrastructure.Services;
using Moq;
using Xunit;

namespace GameTranslator.Tests.Services
{
    public class TranslationServiceTests
    {
        [Fact]
        public async Task TranslateAsync_UsesCache_WhenAvailable()
        {
            var cacheMock = new Mock<ICacheService>();
            cacheMock.Setup(c => c.GetAsync("hello_en")).ReturnsAsync("hi");
            var httpClient = new HttpClient(new HttpMessageHandlerStub());
            var service = new TranslationService(httpClient, cacheMock.Object);

            var result = await service.TranslateAsync("hello", "en");

            Assert.Equal("hi", result);
            cacheMock.Verify(c => c.GetAsync("hello_en"), Times.Once);
        }
    }

    internal class HttpMessageHandlerStub : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("{\"translatedText\":\"hi\"}")
            };
            return Task.FromResult(response);
        }
    }
}
