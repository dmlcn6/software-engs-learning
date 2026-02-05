namespace Reup.Logger
{
    public class AuditLog : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        public void Log(string message, string filePath)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}