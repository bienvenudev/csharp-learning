using System;

// Base Image class to store image properties
public class Image
{
  // Basic properties with default neutral values
  public double Brightness { get; set; } = 0.5;
  public double Contrast { get; set; } = 0.5; 
  public double Saturation { get; set; } = 0.5;

  // Helper methods for creating test images
  public static Image CreateDarkImage() => 
    new Image { Brightness = 0.1 };

  public static Image CreateBrightImage() => 
    new Image { Brightness = 0.9 };

  // Override ToString for testing output
  public override string ToString() => 
    $"Image[B:{Brightness:F2}, C:{Contrast:F2}, S:{Saturation:F2}]";

  // Task 1: Basic expression-bodied method
  public Image CreateBrighterVersion() => 
  new Image {
    Brightness = this.Brightness + (this.Brightness * 0.2)
  };
  
  
  // Task 2: Method chaining with multiple adjustments
  public Image AddBrightness(double brightAmount) =>
    new Image {
      Brightness = this.Brightness + brightAmount,
      Contrast = this.Contrast,
      Saturation = this.Saturation
    };  

  public Image AddSaturation(double satAmount) =>
    new Image {
      Brightness = this.Brightness,
      Contrast = this.Contrast,
      Saturation = this.Saturation + satAmount
    };  

  public Image BrightenThenSaturate(double brightAmount, double satAmount)  => AddBrightness(brightAmount).AddSaturation(satAmount);

  public Image TransformBrightness(Func<double, double> transformer) =>
    new Image
    {
      Brightness = transformer(this.Brightness),
      Contrast = this.Contrast,
      Saturation = this.Saturation
    };
}

// Program class with test code
class Program 
{
  static void Main() 
  {
    // Test 1: Basic brightness adjustment
    Console.WriteLine("\n=== Testing CreateBrighterVersion ===");
    Image original = Image.CreateDarkImage();
    Image brightened = original.CreateBrighterVersion();
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Brightened: {brightened}");
    
    // Test 2: Chain multiple adjustments
    Console.WriteLine("\n=== Testing BrightenThenSaturate ===");
    Image chained = original.BrightenThenSaturate(0.2, 0.1);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Chained: {chained}");

    // Test 3: Lambda transformations
    Console.WriteLine("\n=== Testing TransformBrightness ===");
    Image doubled = original.TransformBrightness(x => x * 2);
    Image halved = original.TransformBrightness(x => x / 2);
    Console.WriteLine($"Original: {original}");
    Console.WriteLine($"Doubled brightness: {doubled}");
    Console.WriteLine($"Halved brightness: {halved}");
  }
}