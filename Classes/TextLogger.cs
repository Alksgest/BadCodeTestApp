using System;
using System.IO;


namespace BadCodeTestApp
{
    public class TextLogger : ILogger
    {
        private const string LoggerDir = "log";
        private TextLogger() { }

        static private ILogger Logger;

        public static ILogger GetLogger() => Logger ?? (Logger = new TextLogger());

        public void Log(string message = "", string path = null)
        {
            string fileName = $"Log_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.txt";
            if (Directory.Exists(path))
            {
                if (!Directory.Exists($"{path}//{LoggerDir}"))
                    Directory.CreateDirectory($"{path}//{LoggerDir}");

                string fullPath = $"{path}//{LoggerDir}//{fileName}";
                using (StreamWriter sw = new StreamWriter(fullPath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{message}  {DateTime.Now.TimeOfDay.ToString()}");
                }
            }
            else
            {
                throw new DirectoryNotFoundException("Directory doesn`t exist.");
            }
        }
    }
}