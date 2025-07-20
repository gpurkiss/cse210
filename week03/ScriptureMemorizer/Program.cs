using System;

// Exceeds Requirements: This version prevents already hidden words from being re-hidden,
// and uses clean object-oriented design with multiple constructors and full encapsulation.

class Program
{
    static void Main(string[] args)
    {
        // Example scripture: "Proverbs 3:5-6"
        var reference = new ScriptureReference("Proverbs", 3, 5, 6);
        string text = "Trust in the LORD with all your heart and lean not on your own understanding; " +
                      "in all your ways submit to him, and he will make your paths straight.";

        var scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress [Enter] to hide words or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        Console.Clear();
        Console.WriteLine("Final verse (all words hidden):\n");
        scripture.Display();

        Console.WriteLine("\nGreat job! Press any key to exit.");
        Console.ReadKey();
    }
}
