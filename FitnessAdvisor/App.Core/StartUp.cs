using App.Core.Contracts;
using App.Core.FitnessAdvisorInjection;
using Autofac;
using System;

namespace App.Core
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var containerConfig = new FitnessAdvisorConfig();
                var container = containerConfig.Build();

                var engine = container.Resolve<IEngine>();
                engine.Run();
            }
            catch (Exception ex)
            {
                FileLogger logger = new FileLogger();
                logger.Log(ex.Message);
                Console.WriteLine("You just broke it. Please restart the app:)");
            }
        }
    }
}
