using System;

public class Cycling : Activity
{
    // Private member variables
    private double _speed;

    // Constructor
    public Cycling(DateTime date, int minutes, double speed) 
        : base(date, minutes)
    {
        _speed = speed;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        return (_speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}