using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("This program will help you track and achieve your goals.");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}