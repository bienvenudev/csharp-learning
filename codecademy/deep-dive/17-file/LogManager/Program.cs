class Program
{
    static void Main()
    {
        LogManager logManager = new LogManager("logs");
        logManager.WriteLog(LogLevel.INFO, "Meeting at 6PM");
        logManager.WriteLog(LogLevel.WARN, "Maintenance on 2nd floor");
        logManager.WriteLog(LogLevel.ERROR, "Bug in registration system");

        Console.WriteLine("---------");
        List<LogEntry> logEntries = logManager.ReadLogEntries(logManager.currentLogPath);
     
        foreach (var entry in logEntries)
        {
            Console.WriteLine(entry);
        }

        logManager.SetMaxLogSize(100);
     
        for (int i = 0; i < 10; i++)
        {
            logManager.WriteLog(LogLevel.INFO, "Friday Pizza is being served");
            logManager.WriteLog(LogLevel.WARN, "Maintenance today");
            logManager.WriteLog(LogLevel.ERROR, "Bug in admin system");
        }

        //  List<FileInfo> files = logManager.ListLogFiles();
        // foreach (FileInfo file in files)
        // {
        //     Console.WriteLine($"{file.Name} - {file.Length} bytes");
        // }
        // Console.WriteLine($"Total log files: {files.Count}");

        // Get log file paths
        List<FileInfo> files = logManager.ListLogFiles();
        string[] logPaths = files.Select(f => f.FullName).ToArray();

        // Consolidate logs into a new file
        logManager.ConsolidateLogs(logPaths, "logs_combined.txt");
        Console.WriteLine("Consolidation complete!");

        // List files again to verify the new file exists
        files = logManager.ListLogFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine($"{file.Name} - {file.Length} bytes");
        }
        Console.WriteLine($"Total log files: {files.Count}");

    }
}