public class Program 
{
    static void Main(string[] args)
    {
    TicketQueue ticketQueue = new TicketQueue();

    foreach (var ticket in ticketQueue.GetInitialTickets())
    {
      Console.WriteLine(ticket.ToString());
    }

    Console.WriteLine("====== Filter recent tickets ======");
    foreach (var ticket in ticketQueue.GetRecentTickets(2))
    {
      Console.WriteLine(ticket.ToString());
    }

    Console.WriteLine("====== Get high priority tickets ======");

    foreach (var ticket in ticketQueue.GetHighPriorityTicketsFirst())
    {
      Console.WriteLine(ticket.ToString());
    }

    Console.WriteLine("====== Get endless ticket ======");
    
    int count = 0;

    foreach (var ticket in ticketQueue.GetEndlessTicketProcessor())
    {
      if (count++ >= 16) break;
      Console.WriteLine(ticket.ToString());
    }
    }
}

public class SupportTicket
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public int Severity { get; set; }  // 1-5, 1 is most severe
    public DateTime CreatedTime { get; set; }

    public override string ToString()
    {
        return $"Ticket {Id}: {CustomerName} (Severity: {Severity})";
    }
}

public class TicketQueue 
{
    private List<SupportTicket> tickets;

    public TicketQueue()
    {
        tickets = GetInitialTickets();
    }

    public List<SupportTicket> GetInitialTickets()
    {
        return new List<SupportTicket>
        {
            new SupportTicket { Id = 1, CustomerName = "Urgent Corp", Severity = 1, CreatedTime = DateTime.Now.AddHours(-4) },
            new SupportTicket { Id = 2, CustomerName = "Standard Inc", Severity = 3, CreatedTime = DateTime.Now.AddHours(-2) },
            new SupportTicket { Id = 3, CustomerName = "Basic Co", Severity = 5, CreatedTime = DateTime.Now.AddHours(-1) },
            new SupportTicket { Id = 4, CustomerName = "Priority Ltd", Severity = 2, CreatedTime = DateTime.Now.AddHours(-3) },
            new SupportTicket { Id = 5, CustomerName = "Quick Help", Severity = 1, CreatedTime = DateTime.Now.AddMinutes(-30) }
        };
    }

    public IEnumerable<SupportTicket> GetRecentTickets(int threshold)
    {
      DateTime cutoff = DateTime.Now.AddHours(-threshold);

      foreach (var ticket in tickets)
      {
        if (ticket.CreatedTime >= cutoff)
        {
          yield return ticket;
        }
      }
    }

    public IEnumerable<SupportTicket> GetHighPriorityTicketsFirst()
    {
      for (int i = 1; i <= 5; i++)
      {
        foreach (var ticket in tickets)
        {
          if (ticket.Severity == i) yield return ticket; 
        }
      }
    }

    public IEnumerable<SupportTicket> GetEndlessTicketProcessor()
    {
      while(true)
      {
        foreach(var ticket in GetHighPriorityTicketsFirst())
        {
          yield return ticket;
        }

        yield return new SupportTicket { Id = -1, CustomerName = "=== Cycle Complete ===", Severity = 0, CreatedTime = DateTime.Now };
        break;
      }
    }
}