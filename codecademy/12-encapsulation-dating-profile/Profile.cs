using System;

namespace DatingProfile
{ 
  class Profile
  {
    private int age;
    private string[] hobbies = [];

    private string Name { get; set; }
    private string City { get; set; }
    private string Country { get; set; }
    private string Pronouns { get; set; }

    private int Age
    {
      get { return age; }
      set
      {
        if (value < 18)
        {
          throw new ArgumentException("Users must be at least 18 years of age.");
        }
        age = value;
      }
    }

    public Profile(string name, int age, string city, string country, string pronouns = "they/them")
    {
      this.Name = name;
      this.Age = age;
      this.City = city;
      this.Country = country;
      this.Pronouns = pronouns;
      this.hobbies = [];
    }

    public Profile(string name, int age) : this(name, age, "n/a", "n/a")
    { }

    public void SetHobbies(string[] hobbies)
    {
      this.hobbies = hobbies;
    }

    public string ViewProfile()
    {
      string hobbiesList = string.Join(", ", hobbies);

      if (hobbiesList.Length <= 0) return $"Name is {Name}, age is {age}, and city is {City}. The country they live in is {Country}, and the pronouns are {Pronouns}.";

      return $"Name is {Name}, age is {age}, and city is {City}. The country they live in is {Country}, and the pronouns are {Pronouns} and the hobbies are: {hobbiesList}.";
    } 
  }
}
