using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("what is your grade percentage?");
        string answer = Console.ReadLine();
        int gradepercentage = int. Parse(answer); 

        string letter = "";

        if (gradepercentage >= 90)
        {
            letter = "A";
        }

        else if (gradepercentage >= 80)
        {
            letter = "B";
        }

        else if (gradepercentage >=70)
        {
            letter = "C";
        }

        else if (gradepercentage >=60)
        {
            letter = "D";
        }

        else 
        {
            letter = "F";
        }

        Console.WriteLine("Your letter grade is: " + letter);

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine("congratulations to you my beloved you made it,you passed and excel in your studies");
        }
        else{
            Console.WriteLine("so sorry you didnt make,try next time,repeat the course and keep up the hard work with your studiest.");
        }
    }
}