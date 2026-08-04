namespace CorporatePolymorphism;

class Program
{
    static void Main(string[] args)
    { 
        //*********************************
        //******* Task3 Test Code *********
        //*********************************
        Employee hrRep = new HR();

        hrRep.ClockIn();
        hrRep.Work();
        hrRep.SubmitDailyReport();
        Console.WriteLine(); //Line break
        //*********************************
        //******* Task3 Test Code *********
        //*********************************

        Employee employee1 = new Engineer();
        employee1.SubmitDailyReport();
        Employee employee2 = new Manager();
        Employee employee3 = new Intern();
  

        // Placeholder for adding employees to the list
        List<Employee> employees = new List<Employee>();
        employees.Add(employee1);
        employees.Add(employee2);
        employees.Add(employee3);

        foreach (Employee e in employees)
        {
            if (e is Manager) Console.WriteLine("This is a Manager");
            if (e is Engineer) Console.WriteLine("This is an Engineer");
            if (e is Intern) Console.WriteLine("This is an Intern");
    
            // e.ClockIn();
            // e.Work();
            // e.SubmitDailyReport();
        }
    }
}