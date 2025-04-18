using System;

public class Swimming : Activity
{
    // Private member variables
    private int _laps;

    // Constructor
    public Swimming(DateTime date, int minutes, int laps) 
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        // Distance in kilometers: laps * 50 meters per lap / 1000 meters per km
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        // Speed in kph: (distance / minutes) * 60 minutes per hour
        double distance = GetDistance();
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        // Pace in minutes per kilometer: minutes / distance
        double distance = GetDistance();
        return Minutes / distance;
    }
}