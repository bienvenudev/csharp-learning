using System;
using System.Collections.Generic;

public class InvalidLogFormatException : Exception
{
  public InvalidLogFormatException(string message) : base(message)
  { }
}

public class LogProcessor
{
  private readonly List<string> logEntries;

  public LogProcessor(List<string> logEntries)
  {
    this.logEntries = logEntries ?? throw new ArgumentNullException(nameof(logEntries));
  }

  public void ProcessLogs()
  {
    int processedCount = 0;
    int totalCount = 0;
    foreach (string entry in logEntries)
    {
      totalCount++;
      
      try
      {
        ProcessLogEntry(entry);
        processedCount++;
      } 
      catch(Exception e)
      {
        Console.WriteLine($"Error processing entry: {e.Message}");
      }
      finally
      {
        Console.WriteLine($"Processed {processedCount} out of {totalCount} entries");
      }
    }
  }

  private void ProcessLogEntry(string entry)
  {
    if (string.IsNullOrEmpty(entry)) {
      throw new InvalidLogFormatException("Empty or null log entry");
    }

    string[] parts = entry.Split('|');
    string level = parts[1].Trim().ToUpper();

    if (level != "ERROR" && level != "WARN" && level != "INFO")
    {
      throw new Exception($"Invalid log level: {level}. Expected: ERROR, WARN, or INFO");
    }
      // Process valid entry
      Console.WriteLine($"Log Entry - Time: {parts[0].Trim()}, Level: {level}, Message: {parts[2].Trim()}");
  }
}

class Program
{
  static void Main()
  {
    // Test null list handling
    Console.WriteLine("Testing null list handling");
    try
    {
      LogProcessor nullProcessor = new LogProcessor(null);
    }
    catch(ArgumentNullException e)
    {
      Console.WriteLine($"Null list error: {e.Message}");
    }
    Console.WriteLine();

    // Test malformed entry handling
    Console.WriteLine("Testing malformed entry");
    List<string> malformedLogs = new List<string> 
    {
      "", 
      "2024-01-15 10:30:00|INFO|Application started",
      "bad format", 
      "2024-01-15 10:31:00|WARN|Low memory warning"
    };
    LogProcessor processor = new LogProcessor(malformedLogs);
    try
    {
      processor.ProcessLogs();
    }
    catch (InvalidLogFormatException e)
    {
      Console.WriteLine("Invalid Log Format Exception");
    }
    Console.WriteLine();

    // Test log level validation
    Console.WriteLine("Testing invalid log levels");
    List<string> invalidLevelLogs = new List<string>
    {
      "2024-01-15 10:30:00|DEBUG|This should not work",
      "2024-01-15 10:30:00|INFO|Application started",
      "2024-01-15 10:30:00|CRITICAL|This also should not work"
    };
    processor = new LogProcessor(invalidLevelLogs);
    processor.ProcessLogs();
    Console.WriteLine();

    // Test valid log processing
    Console.WriteLine("Testing valid logs");
    List<string> validLogs = new List<string>
    {
      "2024-01-15 10:30:00|INFO|Application started",
      "2024-01-15 10:31:00|WARN|Low memory warning",
      "2024-01-15 10:32:00|ERROR|Process crashed"
    };
    processor = new LogProcessor(validLogs);
    processor.ProcessLogs();
  }
}