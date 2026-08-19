using System;

namespace ExpenseTrackerApp
{
    // Tasks 1, 2 and 8 code here.
    [Flags]
    public enum ExpenseType
    {
      None = 0,
      Travel = 1,
      Meals = 2,
      OfficeSupplies = 4,
      Software = 8,
      Entertainment = 16
    }

    public enum ApprovalStage
    {
      Draft = 0,
      Submitted = 1,
      UnderReview = 2,
      Approved = 3,
      Rejected = 4
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Expense Tracker App Running...");
            // Task 3-7, 9-16 code here.
            foreach (string expense in Enum.GetNames(typeof(ExpenseType)))
            {
              Console.WriteLine(expense); 
            }

            ExpenseType expenses = ExpenseType.Travel | ExpenseType.Meals;

             if ((expenses & ExpenseType.Meals) == ExpenseType.Meals)
             {
              Console.WriteLine("Expense includes: Meals");
             }
             else
             {
              Console.WriteLine("Expense does not include: Meals");
             }

             expenses &= ~ExpenseType.Meals;             
             
             Console.WriteLine(expenses);

             if(Enum.TryParse("Meals | Software", out ExpenseType parsedExpense))
             {
              Console.WriteLine(parsedExpense);
             }
             else
             {
              Console.WriteLine("Failed to parse");
             }

             foreach (ApprovalStage stage in Enum.GetValues(typeof(ApprovalStage)))
             {
              Console.WriteLine($"{stage} - {(int)stage}");
             }

            if(Enum.TryParse("Submitted", out ApprovalStage parsedStage))
            {
              Console.WriteLine(parsedStage);
            }
            else
            {
              Console.WriteLine("Failed to parse Approval");
            }

            int approvalValue = 4;

            if(Enum.IsDefined(typeof(ApprovalStage), approvalValue))
            {
              Console.WriteLine((ApprovalStage)approvalValue);
            }
            else
            {
              Console.WriteLine("A value is not defined");
            }

            ApprovalStage currentStage = ApprovalStage.Rejected;

            switch (currentStage)
            {
              case ApprovalStage.Draft:
              Console.WriteLine("Project is still a draft");
              break;
              case ApprovalStage.Submitted:
              Console.WriteLine("Project is submitted");
              break;
              case ApprovalStage.UnderReview:
              Console.WriteLine("Project is under review");
              break;
              case ApprovalStage.Approved:
              Console.WriteLine("Project is approved");
              break;
              case ApprovalStage.Rejected:
              Console.WriteLine("Project is rejected");
              break;
              default:
              Console.WriteLine("Not a valid approval stage!");
              break;
            }

            ExpenseType validExpense = ExpenseType.OfficeSupplies | ExpenseType.Software;

            if (Enum.IsDefined(typeof(ExpenseType), "Meals"))
            {
              Console.WriteLine("Meals is included");
            }
            else
            {
              Console.WriteLine("Meals not included");
            }

            currentStage = ApprovalStage.Approved;
            Console.WriteLine(currentStage);
            Console.WriteLine(validExpense);
        }
    }
}
