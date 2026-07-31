using System;
using System.Linq;

namespace PasswordChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            int minLength = 8;
            Console.WriteLine("Enter a password: ");
            string input = Console.ReadLine();
            int score = 0;

            if (input.Length >= minLength) score++;
            if (input.Any(char.IsUpper)) score++;
            if (input.Any(char.IsLower)) score++;
            if (input.Any(char.IsDigit)) score++;
            bool hasSpecialChar = input.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));
            if (hasSpecialChar) score++;
      

            switch(score) 
            {
                case 1:
                    Console.WriteLine("Weak");
                    break;
                case 2:
                    Console.WriteLine("Medium");
                    break;
                case 3:
                    Console.WriteLine("Strong");
                    break;
                case >= 4:
                    Console.WriteLine("Extremely strong!");
                    break;
                default:
                    Console.WriteLine("Doesn't meet any standards");
                    break;
            }
        }
    }
}