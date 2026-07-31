using System;

namespace TrueOrFalse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Do not edit these lines
            Console.WriteLine("Welcome to 'True or False?'\nPress Enter to begin:");
            string entry = Console.ReadLine();
            Tools.SetUpInputStream(entry);

            // Type your code below
            string[] questions = ["is the sky blue?", "is java the same with javascript?", "is vscode better than rider?", "is college a scam?", "is smoking bad to your health?"];

            bool[] answers = [true, false, true, false, true];
            bool[] responses = new bool[answers.Length];

            if (questions.Length != answers.Length) Console.WriteLine("Warning!!!");

            int askingIndex = 0;

            foreach (string question in questions) {
                Console.WriteLine(question);
                Console.WriteLine("True or false?");
                string input = Console.ReadLine().ToLower();
                bool isBool;
                bool inputBool;

                isBool = (input == "true" || input == "false");
        
                while (!isBool) {
                    Console.WriteLine("Please respond with 'true' or 'false'.");
                    input = Console.ReadLine().ToLower();
                    isBool = (input == "true" || input == "false");
                }

                inputBool = input == "true";
                responses[askingIndex] = inputBool;
                askingIndex++;
            }

            int scoringIndex = 0;
            int score = 0;

            foreach (bool answer in answers) {
                bool current = responses[scoringIndex];
                Console.WriteLine($"Input: {current} | Answer:{answer}");
                if (current == answer) score++;
                scoringIndex++;
            }

            Console.WriteLine($"You got {score} out of {questions.Length} correct!");
        }
    }
}