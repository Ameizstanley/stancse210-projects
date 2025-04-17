using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        
        while (!quit)
        {
            // Display menu
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                
                case "4":
                    quit = true;
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}

/* 
Exceeding Requirements:
1. Added more meaningful animations for the breathing activity by using different timing
   for breathing in (4 seconds) and breathing out (6 seconds), which is physiologically 
   more beneficial for relaxation
2. Improved the spinner animation with multiple characters for a more engaging visual experience
3. Added input validation and error handling (could be expanded further)
4. Used clear console commands for better user experience with cleaner transitions between activities
*/
