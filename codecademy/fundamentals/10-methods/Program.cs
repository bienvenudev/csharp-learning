using System;

namespace ArchitectArithmetic
{
  class Program
  {
    public static void Main(string[] args)
    {
      // Console.WriteLine(Rect(4, 5));
      // Console.WriteLine(Circle(4));
      // Console.WriteLine(Triangle(10, 9));

      Console.WriteLine(Rect(2500, 1500));
      Console.WriteLine(Triangle(750, 500));
      Console.WriteLine(Circle(375/2));
      double totalArea = (Rect(2500, 1500)) + (Triangle(750, 500)) + (Circle(375/2));
      Console.WriteLine($"Total Area: {totalArea}");
      double costPerTotalArea = Math.Round(totalArea * 180, 2);
      Console.WriteLine($"Cost Per Total Area : {costPerTotalArea}");
    }

    static double Rect(double length, double width)
    {
      return length * width;
    }

    static double Circle(double radius)
    {
      return Math.PI * Math.Pow(radius, 2);
    }

    static double Triangle(double bottom, double height)
    {
      return 0.5 * bottom * height;
    }
  }

}
