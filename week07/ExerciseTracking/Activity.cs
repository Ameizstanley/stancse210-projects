using System;

public abstract class Activity
{
    // Private member variables
    private DateTime _date;
    private int _minutes;

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Protected properties to allow derived classes to access
    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    // Abstract methods that derived classes must implement
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Common method for all activities
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min)- " +
               $"Distance {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }
}