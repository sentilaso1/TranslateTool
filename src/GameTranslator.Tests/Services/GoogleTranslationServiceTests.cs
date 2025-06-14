using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GameTranslator.Core.Services;
using GameTranslator.Infrastructure.Services;
using Moq;
using Xunit;

namespace GameTranslator.Tests.Services
{
    public class GoogleTranslationServiceTests
    {
        [Fact]
        public async Task TranslateAsync_ParsesResponse()
        {
            var cache = new Mock<ICacheService>();
            var handler = new StubHandler("[[[\"hola\"]]]");
            var httpClient = new HttpClient(handler);
            var service = new GoogleTranslationService(httpClient, cache.Object);

            var result = await service.TranslateAsync("hello", "es");

            Assert.Equal("hola", result);
        }

        private class StubHandler : HttpMessageHandler
        {
            private readonly string _content;
            public StubHandler(string content) => _content = content;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(_content)
                };
                return Task.FromResult(response);
            }
        }
    }
}
