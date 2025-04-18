using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        Running run = new Running(new DateTime(2022, 11, 3), 30, 4.8);
        Cycling cycle = new Cycling(new DateTime(2022, 11, 4), 45, 20);
        Swimming swim = new Swimming(new DateTime(2022, 11, 5), 40, 32);

        // Store activities in a list to demonstrate polymorphism
        List<Activity> activities = new List<Activity>
        {
            run,
            cycle,
            swim
        };

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("----------------------------------------------------------------------");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}