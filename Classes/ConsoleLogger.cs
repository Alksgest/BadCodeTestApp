using System;
using System.IO;


namespace BadCodeTestApp
{
    public class ConsoleLogger : ILogger
    {
        private ConsoleLogger() { }
        static private ILogger Logger;

        public static ILogger GetLogger()
        {
            if (Logger == null)
            {
                Logger = new ConsoleLogger();
                return Logger;
            }
            else
                return Logger;
        }

        public void Log(string message = "", string path = null) => System.Console.WriteLine(message);
    }
}