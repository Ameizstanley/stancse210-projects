using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int mymagicnumber = random.Next(101);

        int guess;
        int guessCount = 0;

        Console.WriteLine("welcome to my guess number game!");


        do
        {
            Console.Write("what is your guess ? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess < mymagicnumber)
            {
                Console.WriteLine("higher");
            }
            else if (guess > mymagicnumber)
            {
                Console.WriteLine("lower");
            }
        }while (guess != mymagicnumber);

    Console.WriteLine($"you guessed it in {guessCount} tries!");

    }
}