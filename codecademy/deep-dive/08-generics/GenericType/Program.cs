using System;

public interface IValidatable
{
    bool IsValid();
}

public class ValidatableAmount : IValidatable
{
    private decimal _value;
    private decimal _min;
    private decimal _max;

    public ValidatableAmount(decimal value, decimal min, decimal max)
    {
        _value = value;
        _min = min;
        _max = max;
    }

    public bool IsValid()
    {
        if(_value >= _min && _value <= _max) return true;
        return false;
    }

    public decimal Amount
    {
        get { return _value; }
    }
}

public class SafeValue<T> where T : IValidatable
{
    private T? _value;
    public SafeValue(T initialValue)
    {
        if (!initialValue.IsValid()) throw new ArgumentException("The value is not valid");
        _value = initialValue;
    }

    public T? GetValue()
    {
        return _value;
    }

    public T? Value
    {
        get { return _value; }
    }

    public void SetValue(T input)
    {
        if (!input.IsValid()) throw new ArgumentException("The value is not valid");
        _value = input;
    }

    public bool HasValue()
    {
        if (_value != null) return true;
        return false;
    }
}

class Program 
{
    static void Main()
    {
        // SafeValue<int> testValue = new SafeValue<int>(42);
        // Console.WriteLine(testValue.GetValue());
        // testValue.SetValue(100);
        // Console.WriteLine(testValue.GetValue());

        ValidatableAmount amount = new ValidatableAmount(50, 0, 100);

        SafeValue<ValidatableAmount> safeVal = null;

        try {
            safeVal = new SafeValue<ValidatableAmount>(new ValidatableAmount(150, 0, 100));
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

// Only access safeVal if it is not null
        if (safeVal != null && safeVal.GetValue() != null)
        {
            Console.WriteLine(safeVal.GetValue().Amount);
        }
    }
}