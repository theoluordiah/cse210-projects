using System;

// Exceeding requirements
// the program keeps a count of how many times each
// activity was completed during this session and shows a summary on quit.
// duration input is also validated so the program doesn't crash on bad input.

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    breathingCount++;
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    reflectingCount++;
                    break;
                case "3":
                    new ListingActivity().Run();
                    listingCount++;
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    Thread.Sleep(1500);
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Session summary:");
        Console.WriteLine($"  Breathing activities completed: {breathingCount}");
        Console.WriteLine($"  Reflecting activities completed: {reflectingCount}");
        Console.WriteLine($"  Listing activities completed: {listingCount}");
        Console.WriteLine("Goodbye!");
    }
}
