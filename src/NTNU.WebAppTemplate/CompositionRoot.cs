using CQRS.LightInject;
using CQRS.Query.Abstractions;
using LightInject;
using Microsoft.Extensions.Configuration;
using NTNU.WebAppTemplate.Queries;

namespace NTNU.WebAppTemplate
{
    public class CompositionRoot : ICompositionRoot
    {
        public CompositionRoot(IConfiguration configuration)
        {

        }

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterCommandHandlers();
            serviceRegistry.RegisterQueryHandlers();
            serviceRegistry.Decorate(typeof(IQueryHandler<,>), typeof(LoggedQueryHandler<,>));
            serviceRegistry.Register<IFoo, Foo>();
        }
    }
}