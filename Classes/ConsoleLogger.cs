using System;
using System.IO;


namespace BadCodeTestApp
{
    public class ConsoleLogger : ILogger {
        private ConsoleLogger() {}
        public static ILogger Logger 
        {
            get 
            {
                return Logger == null ? new ConsoleLogger() : Logger;
            }
        }

        public void Log(string message = "", string path = null, string fileName = null) => System.Console.WriteLine(message);
    }
}