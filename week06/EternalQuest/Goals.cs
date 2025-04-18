using System;

// Base abstract class for all types of goals
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract methods that all derived classes must implement
    public abstract void RecordEvent();
    public abstract bool IsCompleted();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    // Properties for accessing goal information
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => int.Parse(_points);
}