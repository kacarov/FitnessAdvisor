using System;

namespace App.Core
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Engine.Instance.Run();
            }
            catch (Exception ex)
            {
                FileLogger logger = new FileLogger();
                logger.Log(ex.Message);
                Console.WriteLine("");
            }
        }
    }
}
