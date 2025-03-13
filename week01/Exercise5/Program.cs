using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);  // Added semicolon, fixed variable name
        
        DisplayResult(name, squaredNumber);  // Fixed variable name
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");  // Fixed capitalization
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");  // Changed to Write, fixed capitalization
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");  // Fixed spelling & capitalization
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int num)  // Added return type, fixed method name
    {
        return num * num;
    }

    static void DisplayResult(string name, int squared)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }
}