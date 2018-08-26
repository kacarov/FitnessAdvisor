using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.FitnessAdvisorInjection
{
    public class FitnessAdvisorConfig
    {
        IContainer Build()
        {
            var builder = new ContainerBuilder();

            RegisterCoreComponents(builder);

            var container = builder.Build();

            return container;
        }

        public void RegisterCoreComponents(ContainerBuilder builder)
        {
            //Register core components Bai Ivane
        }
    }
}
