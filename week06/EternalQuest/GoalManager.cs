using System;
using System.Collections.Generic;
using System.IO;

// Class to manage all goals
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        
        while (!quit)
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string completionStatus = goal.IsCompleted() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {completionStatus} {goal.GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nGoal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string goalType = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();
        
        Goal newGoal = null;
        
        switch (goalType)
        {
            case "1": // Simple Goal
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2": // Eternal Goal
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3": // Checklist Goal
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
        
        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
        
        Console.Write("Which goal did you accomplish? ");
        int goalIndex;
        if (int.TryParse(Console.ReadLine(), out goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal goal = _goals[goalIndex - 1];
            
            // Don't allow recording completion for already completed simple goals
            if (goal is SimpleGoal && goal.IsCompleted())
            {
                Console.WriteLine("This goal has already been completed!");
                return;
            }
            
            // Check if this is a checklist goal that's about to be completed
            bool wasCompletedBefore = goal.IsCompleted();
            
            goal.RecordEvent();
            int pointsEarned = goal.Points;
            
            // Award bonus if a checklist goal was just completed
            if (!wasCompletedBefore && goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                Console.WriteLine("Congratulations! You've completed all steps in this checklist goal!");
                pointsEarned += checklistGoal.Bonus;
            }
            
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // First line is the score
                writer.WriteLine(_score);
                
                // Write each goal on a separate line
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        try
        {
            string[] lines = File.ReadAllLines(filename);
            
            // First line is the score
            _score = int.Parse(lines[0]);
            
            // Clear existing goals
            _goals.Clear();
            
            // Read each goal
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');
                
                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(
                            goalData[0],
                            goalData[1],
                            goalData[2],
                            bool.Parse(goalData[3])
                        ));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(
                            goalData[0],
                            goalData[1],
                            goalData[2]
                        ));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(
                            goalData[0],
                            goalData[1],
                            goalData[2],
                            int.Parse(goalData[3]),
                            int.Parse(goalData[4]),
                            int.Parse(goalData[5])
                        ));
                        break;
                }
            }
            
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}