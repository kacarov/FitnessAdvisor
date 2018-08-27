using App.Core.Contracts;
using App.Core.Services;
using App.Data;
using App.Data.Contracts;
using App.Models.Calculators;
using App.Models.Contracts;
using Autofac;

namespace App.Core.FitnessAdvisorInjection
{
    public class FitnessAdvisorConfig
    {
        public IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterCoreComponents(containerBuilder);

            return containerBuilder.Build();
        }

        public void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<DbContext>().As<IDbContext>().SingleInstance();
            builder.RegisterType<BodyCalculator>().As<IBodyCalculator>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
