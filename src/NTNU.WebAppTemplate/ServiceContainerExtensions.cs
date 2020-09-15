using System;
using LightInject;

namespace NTNU.WebAppTemplate
{

    // These extension methods might be moved to LightInject 👍❤️
    public static class ServiceContainerExtensions
    {
        public static IServiceRegistry RegisterFrom<TCompositionRoot>(this IServiceRegistry serviceRegistry, params object[] args) where TCompositionRoot : ICompositionRoot
        {
            var compositionRoot = (ICompositionRoot)Activator.CreateInstance(typeof(TCompositionRoot), args);
            compositionRoot.Compose(serviceRegistry);
            return serviceRegistry;
        }

        public static IServiceRegistry Override<TService, TImplementation>(this IServiceRegistry serviceRegistry) where TImplementation : TService
        {
            return serviceRegistry.Override(sr => sr.ServiceType == typeof(TService), (serviceFactory, registration) =>
            {
                registration.ImplementingType = typeof(TImplementation);
                return registration;
            });
        }

        public static IServiceRegistry Override<TService, TImplementation>(this IServiceRegistry serviceRegistry, ILifetime lifetime) where TImplementation : TService
        {
            return serviceRegistry.Override(sr => sr.ServiceType == typeof(TService), (serviceFactory, registration) =>
            {
                registration.ImplementingType = typeof(TImplementation);
                registration.Lifetime = lifetime;
                return registration;
            });
        }
    }
}