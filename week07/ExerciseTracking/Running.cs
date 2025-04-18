using System;

public class Running : Activity
{
    // Private member variables
    private double _distance;

    // Constructor
    public Running(DateTime date, int minutes, double distance) 
        : base(date, minutes)
    {
        _distance = distance;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / _distance;
    }
}