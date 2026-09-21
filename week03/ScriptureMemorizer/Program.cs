using System;

/*
    stretch challenge

    1 Library of scriptures loaded from a file
    2 Hides only words that are still visible
       
*/

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = ChooseScripture(library);
        const int wordsPerRound = 3;

        ClearScreen();
        DisplayScripture(scripture);

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.Write("Press enter to hide more words, or type 'quit' to end: ");
            string answer = Console.ReadLine();
            if (answer == null)
            {
                running = false;
                break;
            }
            answer = answer.Trim().ToLower();

            if (answer == "quit")
            {
                running = false;
            }
            else
            {
                scripture.HideRandomWords(wordsPerRound);
                ClearScreen();
                DisplayScripture(scripture);

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine();
                    Console.WriteLine("All words are hidden. Press enter to finish.");
                    Console.ReadLine();
                    running = false;
                }
            }
        }
    }

    static void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
        }
    }

    static Scripture ChooseScripture(ScriptureLibrary library)
    {
        ClearScreen();
        Console.WriteLine("WELCOME TO THE SCRIPTURE MEMORIZER");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine();

        int index = 1;
        foreach (Scripture scripture in library.GetScriptures())
        {
            Console.WriteLine($"  {index}. {scripture.GetDisplayText()}");
            index++;
        }

        Console.WriteLine();
        Console.Write("Enter a number to choose a scripture (press Enter for a random one): ");
        string input = Console.ReadLine();
        if (input == null)
        {
            return library.GetRandomScripture();
        }

        int choice;
        if (int.TryParse(input.Trim(), out choice) && choice >= 1 && choice <= library.GetScriptures().Count)
        {
            return library.GetScriptures()[choice - 1];
        }

        return library.GetRandomScripture();
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
    }
}