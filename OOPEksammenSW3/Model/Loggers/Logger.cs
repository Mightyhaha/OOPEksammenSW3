using System.IO;

namespace OOPEksammenSW3.Model.Loggers
{
    public class Logger : ILogger
    {
        public void Log(string logthis)
        {
            using StreamWriter sw = File.AppendText(@"TransactionLog.txt");
            sw.WriteLine(logthis);
        }
    }

}