using App.Core.Contracts;


namespace App.Core
{
    public class Engine : IEngine
    {
        private static Engine engineInstance;
        private Engine()
        {

        }
        public static Engine EngineInstance
        {
            get
            {
                if (engineInstance == null)
                {
                    engineInstance = new Engine();
                }
                return engineInstance;
            }
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
