using System;

// An eternal goal that can never be fully completed
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Nothing specific happens here as eternal goals are never completed
    }

    public override bool IsCompleted()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) - {_points} points each time";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}