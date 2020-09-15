using System;
using LightInject;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace NTNU.WebAppTemplate.Tests
{
    public class LightInjectWebApplicationFactory<TEntrypoint> : WebApplicationFactory<TEntrypoint> where TEntrypoint : class
    {
        private readonly Action<IHostBuilder> configureHost;

        public LightInjectWebApplicationFactory(Action<IHostBuilder> configureHost = null)
        {
            this.configureHost = configureHost;
        }

        protected override IHost CreateHost(IHostBuilder hostBuilder)
        {
            configureHost?.Invoke(hostBuilder);
            return base.CreateHost(hostBuilder);
        }
    }

    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureTestContainer(this IHostBuilder builder, Action<IServiceRegistry> config)
        {
            return builder.ConfigureContainer<IServiceContainer>(container => config(container));
        }
    }
}
