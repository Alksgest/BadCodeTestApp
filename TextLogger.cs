using System;
using System.IO;


namespace BadCodeTestApp
{
    public class TextLogger : ILogger {
        private TextLogger() {}
        public ILogger Logger 
        {
            get 
            {
                return Logger == null ? new TextLogger() : this.Logger;
            }
        }

        public void Log(string path, string fileName, string message = "")
        {
            if(Directory.Exists(path))
            {
                string fullPath = path + "//" + fileName;
                using(StreamWriter sw = new StreamWriter(fullPath, true, System.Text.Encoding.Default)) 
                {
                    sw.WriteLine(message);
                }
            }
            else 
            {
                throw new DirectoryNotFoundException("Directory doesn`t exist.");
            }
        }
    }
}