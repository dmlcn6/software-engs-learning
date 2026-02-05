namespace TestHH.Logger
{
    public class AuditLog : ILogger
    {

        public void Log(string message)
        {
            // Logging implementation
            Console.WriteLine(message);
        }

        public void Log(string message, string filePath)
        {
            // Logging implementation
            File.AppendAllText(filePath, message + Environment.NewLine);
        }

        public void RecordWin()
        {
            Log($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - CONGRATULATIONS!", "./grampsGameplayLog.txt");
        }

        public void RecordLoss()
        {
            Log($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - GAMEOVER!", "./grampsGameplayLog.txt");
        }
    }

}