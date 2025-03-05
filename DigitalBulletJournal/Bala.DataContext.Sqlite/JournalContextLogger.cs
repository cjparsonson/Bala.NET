using static System.Environment;

namespace Bala.Shared;

public class JournalContextLogger
{
    public static void WriteLine(string message)
    {
        string dateTimeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");

        string path = Path.Combine(GetFolderPath(
            SpecialFolder.DesktopDirectory),
            $"BalaLog-{dateTimeStamp}.txt");

        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine(message);
        textFile.Close();
    }
}