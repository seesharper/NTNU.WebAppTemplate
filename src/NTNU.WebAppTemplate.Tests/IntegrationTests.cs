using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using LightInject;
using Microsoft.Extensions.Hosting;
using NTNU.WebAppTemlate;
using Xunit;

namespace NTNU.WebAppTemplate.Tests
{
    public class IntegrationTests : IDisposable
    {
        private readonly LightInjectWebApplicationFactory<Program> Factory = new LightInjectWebApplicationFactory<Program>();

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
