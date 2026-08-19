public interface INotificationPublisher
{
  event EventHandler<NotificationEventArgs> DetailedNotification;
}

public class UrgentNotificationSystem : INotificationPublisher
{
  public event EventHandler<NotificationEventArgs> DetailedNotification;

  protected virtual void OnUrgentNotification(string dept, string msg)
  {
    DetailedNotification?.Invoke(this, new NotificationEventArgs(dept, msg, Priority.Urgent));
  }

  public void SendUrgentNotification(string dept, string msg)
  {
    Console.WriteLine("Urgent Notification sent...");
    this.OnUrgentNotification(dept, msg);
  }
}

public enum Priority 
{ 
  Low,     // For routine notifications
  Medium,  // For important notifications
  High,    // For time-sensitive notifications
  Urgent   // For emergency notifications
}

public class NotificationEventArgs : EventArgs
{
  public string Department { get; set; }
  public string Message { get; set; }
  public Priority Priority { get; set; }

  public NotificationEventArgs(string department, string message, Priority priority)
  {
    Department = department;
    Message = message;
    Priority = priority;
  }
}

public class NotificationSystem
{
  public event EventHandler Notification;
  public event EventHandler<NotificationEventArgs> DetailedNotification;

  protected virtual void OnDetailedNotification(string dept, string msg, Priority priority)
  {
    DetailedNotification?.Invoke(this, new NotificationEventArgs(dept, msg, priority));
  }

  protected virtual void OnNotification()
  {
    Notification?.Invoke(this, EventArgs.Empty);
  }

  public void SendDetailedNotification(string dept, string msg, Priority priority)
  {
    Console.WriteLine("Attempt message");
    this.OnDetailedNotification(dept, msg, priority);
  }

  public void SendNotification(string message)
  {
    Console.WriteLine($"Attempting to send: {message}");
    this.OnNotification();
  }
}

public class EmailSubscriber
{
  public void HandleBasicNotification(object sender, EventArgs param)
  {
    Console.WriteLine("Email: Notification received");
  }

  public void HandleDetailedNotification(object sender, NotificationEventArgs e)
  {
    Console.WriteLine($"{e.Department}: {e.Message} - {e.Priority}");
  }
}

class Program
{
  static void Main()
  {
    Console.WriteLine("Corporate Notification System");

    NotificationSystem notifier = new NotificationSystem();
    // notifier.SendNotification("System startup complete");

    EmailSubscriber subscriber = new EmailSubscriber();

    notifier.Notification += subscriber.HandleBasicNotification;
    // notifier.SendNotification("The code is 007");

    notifier.DetailedNotification += subscriber.HandleDetailedNotification;
    // notifier.SendDetailedNotification("IT", "System update at 6h00", Priority.Low);

    UrgentNotificationSystem urgent = new UrgentNotificationSystem();

    urgent.DetailedNotification += subscriber.HandleDetailedNotification;
    urgent.SendUrgentNotification("Fire Department", "Securiy Alert");
  }
}