namespace DistributedComputing.Logging;

public static class LoggingExtensions
{
    static ReaderWriterLock locker = new ReaderWriterLock();
    public static void WriteDebug(this string text)
    {
        try
        {
            locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
            System.IO.File.AppendAllLines("//home//ryan//workspace//PracticeCode//DistributedComputing//OutputFile.txt", new[] { text });
        }
        finally
        {
            locker.ReleaseWriterLock();
        }
    }
}