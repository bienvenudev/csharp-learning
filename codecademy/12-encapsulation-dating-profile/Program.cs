using System;

namespace DatingProfile
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] samHobbies = {"listening to audiobooks and podcasts","playing rec sports like bowling and kickball", "writing a speculative fiction novel", "reading advice columns"};

      Profile sam = new Profile("Sam Drakkila", 30, "New York", "USA", "he/him");
      sam.SetHobbies(samHobbies);
      
      Console.WriteLine(sam.ViewProfile());

      string[] sarahHobbies = {"listening to audiobooks and podcasts","playing rec sports like bowling and kickball", "writing a speculative fiction novel", "reading advice columns"};

      Profile sarah = new Profile("Sarah Joe", 30);
      Console.WriteLine(sarah.ViewProfile());
    }
  }
}
