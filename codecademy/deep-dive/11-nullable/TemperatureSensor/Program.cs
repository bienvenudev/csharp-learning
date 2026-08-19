#nullable enable
using System;

class SensorReading
{
  public decimal? Value { get; set; }
  public DateTime? LastUpdated { get; set; }
  public ReadingStatus? Status { get; private set; }


  public void Update(decimal? value)
  {
    if (value.HasValue)
    {
      Status = new ReadingStatus { Message = "OK", IsValid = true};
    }
    else
    {
      Status = new ReadingStatus { Message = "No Reading", IsValid = false };
    }

    Value = value;
    LastUpdated = value != null ? DateTime.Now : null;
  }

  public string GetStatusSummary()
  {
    return $"Status : [{Status?.Message ?? "Unknown"}], Valid: [{Status?.IsValid ?? false}]";
  }
}

class TemperatureSensor
{
  private const decimal MinTemp = 0.5m;
  private const decimal MaxTemp = 10.5m;

  public SensorReading Temperature { get; set; }

  public string ValidateReading()
  {
    if (Temperature.Value != null)
    {
      if (Temperature.Value > MinTemp && Temperature.Value < MaxTemp)return "Temperature reading is valid";
      else return "Temperature reading is out of range";
    }

    return "Temperature reading has no value";
  }
}

class Schedule
{
  public decimal? DayTarget { get; set; }
  public decimal? NightTarget { get; set; }
  public const decimal DefaultTarget = 0.0m;

  public decimal GetCurrentTarget(bool isDayTime)
  {
    decimal? result = isDayTime ? DayTarget : NightTarget;
    return result ?? DefaultTarget;
  }
}

class ReadingStatus
{
  public string Message { get; set; }
  public bool IsValid { get; set; }

}

class Program {
  static void Main(string[] args) {
    // Your code will go here!
    Console.WriteLine("Smart Temperature Sensor Starting Up...");
    
    // You'll create and test your classes here through the exercises
    // Task Group 1 Testing Area:
    SensorReading sens1 = new SensorReading();
    sens1.Update(6.5m);
    Console.WriteLine($"Reading: {sens1.Value}, Timestamp: {sens1.LastUpdated}.");
    // sens1.Update(null);
    // Console.WriteLine($"Reading: {sens1.Value}, Timestamp: {sens1.LastUpdated}.");

    // Task Group 2 Testing Area:
    TemperatureSensor temp1 = new TemperatureSensor();
    temp1.Temperature = sens1;
    Console.WriteLine(temp1.ValidateReading());

    // Task Group 3 Testing Area:
    Schedule sch1 = new Schedule();
    sch1.DayTarget = 5.4m;
    sch1.NightTarget = 15.4m;

    Console.WriteLine(sch1.GetCurrentTarget(false));

    // Task Group 4 Testing Area:
    SensorReading sens2 = new SensorReading();
    Console.WriteLine(sens2.GetStatusSummary());
    sens2.Update(13.4m);
    Console.WriteLine(sens2.GetStatusSummary());
  }
}