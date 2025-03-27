using static System.Environment;

namespace Bala.Shared;

public class JournalContextLogger
{
    public static void WriteLine(string message)
    {
        string dateTimeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        string path = Path.Combine("..", $"BalaLog-{dateTimeStamp}.txt");
        path = Path.GetFullPath(path);
        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine(message);
        textFile.Close();
    }
}