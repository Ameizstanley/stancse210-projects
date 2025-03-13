using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        Console.WriteLine("enter a list of number, type 0 when finished.");

        while (userNumber !=0)
        {
            Console.Write("Enter number : ");
            userNumber = int.Parse(Console.ReadLine());
            
            if(userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("no numbers entered.");
            return;
        }


        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = (double)sum / numbers.Count;

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"the sum is: {sum}");
        Console.WriteLine($"the average is: {average}");
        Console.WriteLine($"the largest number is: {max}");
    }

}