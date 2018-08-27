using App.Core.Contracts;
using App.Core.FitnessAdvisorInjection;
using Autofac;

namespace App.Core
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var containerConfig = new FitnessAdvisorConfig();
            var container = containerConfig.Build();


            var engine = container.Resolve<IEngine>();
            engine.Run();

            //try
            //{
            //    Engine.Instance.Run();
            //}
            //catch (Exception ex)
            //{
            //    FileLogger logger = new FileLogger();
            //    logger.Log(ex.Message);
            //    Console.WriteLine("");
            //}
        }
    }
}
