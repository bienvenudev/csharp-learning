using System;

namespace SmartHome 
{
  // Pre-implemented sensor simulation
  public class Sensors 
  {
    private static Random _random = new Random();
        
    public static double GetTemperature(string sensorId)
    {
      // Simulates temperature between 65-80 degrees
      return 65 + _random.NextDouble() * 15;
    }
        
    public static double GetHumidity(string sensorId) 
    {
      // Simulates humidity between 30-60%
      return 30 + _random.NextDouble() * 30;
    }
        
    public static double GetMotion(string sensorId)
    {
      // Simulates motion detection (0-1 scale)
      return _random.NextDouble();
    }
  }

  public class HomeAutomation 
  {
    // Basic Sensor System: Delegates will be declared here
    public delegate double SensorProcessor(string sensorId);
    public delegate void AutomationHandler(string device, string action);

    public void ProcessSensorData(string[] sensors, Func<string, double> sens)
    {
      // Task: Implement sensor processing using delegates
      foreach (string sensor in sensors)
      {
        Console.WriteLine($"{sens(sensor)}");
      }
    }

    // Built-in Delegates: Built-in delegates will be defined here

    // Instance Methods and Predicates: Temperature control for method group conversion
    public class TemperatureControl 
    {
      public Predicate<double> IsComfortable = temp => temp >= 68.0 && temp <= 76.0;
    }

    // Multicast Delegates: Fields for multicast example
    private double _currentTemp = 72.0;
    private bool _lightsOn = false;

    public void AdjustHVAC(string device, string action)
    {
      _currentTemp += action == "up" ? 1 : -1;
      Console.WriteLine($"Temperature now: {_currentTemp}");
    }

    public void ControlLights(string device, string action)
    {
      _lightsOn = action == "on";
      Console.WriteLine($"Lights are now {(_lightsOn ? "on" : "off")}");
    }

    // Complex Automation Rules: Base class for automation rules
    public class AutomationRule 
    {
      // Task: Implement rule properties
      public Predicate<double> Condition { get; set; } 
      public AutomationHandler Actions { get; set; }
      public string Device { get; set; } 
      public string Action { get; set; }
    }

    public void ProcessRule(AutomationRule rule, double sensorReading)
    {
      // Task: Implement rule processing
      if(rule.Condition(sensorReading))
      {
        rule.Actions(rule.Device, rule.Action);
      }
    }

    public static void Main()
    {
      var home = new HomeAutomation();
      Console.WriteLine("Smart Home Automation Starting...");
            
      // Test code will be added for each task group
      string[] tempSensors = { "TEMP1", "TEMP2" };
      Func<string, double> processor = Sensors.GetTemperature;
      home.ProcessSensorData(tempSensors, processor);

      Func<double, bool> isValidReading = number => number >= 0.0 && number <= 100.0;
      double temp = Sensors.GetTemperature(tempSensors[0]);
      Console.WriteLine(temp + " - " + isValidReading(temp));

      Action<string, double> logReading = (str, num) => Console.WriteLine($"{str}: {num}");

      logReading("temp1", temp);
      
      Predicate<double> isCritical = num => num > 90;
      Console.WriteLine(isCritical(80));

      TemperatureControl temperature = new TemperatureControl();
      Predicate<double> comfort = temperature.IsComfortable;
      Console.WriteLine(comfort(79.0));

      double[] tempArr = { 65.0, 70.0, 75.0, 80.0 };
      Console.WriteLine(string.Join(", ", Array.FindAll(tempArr, comfort)));

      AutomationHandler autom = home.ControlLights;
      autom += home.AdjustHVAC;
      autom("MAIN", "on");

      AutomationRule ruleset = new AutomationRule
      {
        Condition = t => t < 68,
        Actions = autom,
        Device = "MAIN",
        Action = "on"
      };

      Console.WriteLine("Processing rule now...");
      home.ProcessRule(ruleset, 66.0);
    }
  }
}