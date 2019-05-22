

namespace BadCodeTestApp
{
    public interface ILogger
    {
        ILogger Logger {get;}
        void Log(string path, string fileName, string message);
    }
}