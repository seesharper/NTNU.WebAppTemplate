using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NTNU.WebAppTemlate;
using Xunit;

namespace NTNU.WebAppTemplate.Tests
{
    public class UnitTest1
    {
        private readonly WebApplicationFactory<Program> Factory = new WebApplicationFactory<Program>();


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
    }
}
