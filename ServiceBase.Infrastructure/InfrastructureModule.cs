using Autofac;
using ServiceBase.Core.Interfaces;
using ServiceBase.Infrastructure.Repository;

namespace ServiceBase.Infrastructure
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExampleRepository>().As<IExampleRepository>();
        }
    }
}