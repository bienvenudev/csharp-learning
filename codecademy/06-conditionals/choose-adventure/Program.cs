using System;

namespace ChooseYourOwnAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            /* THE MYSTERIOUS NOISE */
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! Welcome to our story.");
            Console.WriteLine("It begins on a cold rainy night. You're sitting in your room and hear a noise coming from down the hall. Do you go investigate?");

            Console.Write("Type YES or NO: ");
            string noiseChoice = Console.ReadLine().ToUpper();

            Console.WriteLine(noiseChoice); 
        }
    }
}