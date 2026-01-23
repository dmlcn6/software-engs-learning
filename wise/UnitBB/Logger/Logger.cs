//using

namespace UnitBB.Logger
{
    public class Logs : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message}");
        }
        public void Log(string message, string route)
        {
            File.AppendAllText(route, message + Environment.NewLine);
        }
    }

}