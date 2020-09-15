using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NTNU.WebAppTemlate;
using Xunit;

namespace NTNU.WebAppTemplate.Tests
{
    public class IntegrationTestsWithMock : IDisposable
    {
        private readonly LightInjectWebApplicationFactory<Program> Factory;

        public IntegrationTestsWithMock()
        {
            Factory = new LightInjectWebApplicationFactory<Program>(hostBuilder =>
            {
                // Here we override the default registration which is "Foo";
                hostBuilder.ConfigureTestContainer(serviceRegistry => serviceRegistry.Override<IFoo, FooMock>());
            });
        }

        [Fact]
        public async Task ShouldGetWeatherForecast()
        {
            var client = Factory.CreateClient();

            var request = new HttpRequestBuilder()
                .WithMethod(HttpMethod.Get)
                .AddRequestUri("weatherforecast")
                .Build();

            var responseMessage = await client.SendAsync(request);
            responseMessage.EnsureSuccessStatusCode();

            var content = await responseMessage.ContentAs<WeatherForecast[]>();

            content.Length.Should().Be(5);
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}