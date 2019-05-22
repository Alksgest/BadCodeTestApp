using System;
using System.IO;


namespace BadCodeTestApp
{
    public class ConsoleLogger : ILogger {
        private ConsoleLogger() {}
        public ILogger Logger 
        {
            get 
            {
                return Logger == null ? new ConsoleLogger() : this.Logger;
            }
        }

        public void Log(string path, string fileName, string message = "") => System.Console.WriteLine(message);
    }
}