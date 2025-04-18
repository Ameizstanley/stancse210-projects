using System;

// A simple goal that can be completed once
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading from file
    public SimpleGoal(string name, string description, string points, bool isComplete) 
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsCompleted()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}