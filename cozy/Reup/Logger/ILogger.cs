namespace Reup.Logger;

public interface ILogger
{
    public void Log(string message);
    public void Log(string message, string filePath);
}
