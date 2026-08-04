using System;

namespace BibliographicalInheritance
{
class Animal {
    public void Walk() {
        Console.WriteLine("Animal walks.");
    } 
  
    public virtual void MakeSound() {
        Console.WriteLine("Animal makes noise.");
    } 
}

class Dog : Animal {
    public void Sleep() {
        Console.WriteLine("Dog sleeps.");
    } 
  
    public override void MakeSound() {
        Console.WriteLine("Dog barks.");
    } 
}

class Program {
    static void Main(string[] args) {
        // Create an upcast Animal object
        Animal myAnimal = new Dog();

        // Downcast the myAnimal object
        Dog myDog = (Dog)myAnimal;

        myDog.MakeSound(); // Output: Dog barks.
        myDog.Walk(); // Output: Animal walks.
        myDog.Sleep(); // Output: Dog sleeps.
    }
}
}

// {
    // class Program
    // {
        // static void Main(string[] args)
        // {
            // Resource r1 = new Resource("Atomic Habits", "Self-help");
            // r1.GetInfo();
            // r1.UpdateStatus();
            // r1.GetInfo();

            // Book b1 = new Book("Code: The Hidden Language of Computer Hardware and Software", "Non-Fiction", "Charles Petzold", 396);
            // b1.GetInfo();

            // Periodical p1 = new Periodical("Wired", "Technology", "Monthly");
            // p1.GetInfo();
            // p1.UpdateStatus();
            // p1.GetInfo();

//             Video v1 = new Video("Ex Machina", "Sci-Fi", "Alex Garland", 108, "On-Demand");
//             v1.GetInfo();
//         }
//     }
// }