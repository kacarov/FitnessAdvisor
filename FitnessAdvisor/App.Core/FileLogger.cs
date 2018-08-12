using System;
using System.IO;

namespace App.Core
{
    public class FileLogger
    {
        public void Log(string messege)
        {
            DateTime time = DateTime.Now;
            messege = time  + " ---> Error: " + messege +"\n";
            File.AppendAllText(@"../../../errorLogs.txt",messege);
        }
    }
}
