using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<JournalEntry> entries = new List<JournalEntry>();
        private List<string> prompts = new List<string>
        {
            "What are you grateful for today?",
            "Describe a challenge you faced today.",
            "What made you smile today?",
            "What did you learn today?",
            "How did you take care of yourself today?"
        };

        private Random random = new Random();

        public void ShowMenu()
        {
            string input = "";
            while (input != "5")
            {
                Console.WriteLine("\n--- Journal Menu ---");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": WriteNewEntry(); break;
                    case "2": DisplayJournal(); break;
                    case "3": SaveToFile(); break;
                    case "4": LoadFromFile(); break;
                    case "5": Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void WriteNewEntry()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your Response: ");
            string response = Console.ReadLine();

            JournalEntry entry = new JournalEntry(prompt, response);
            entries.Add(entry);

            Console.WriteLine("Entry saved!\n");
        }

        private void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("\nNo journal entries to display.\n");
                return;
            }

            Console.WriteLine("\n--- Journal Entries ---");
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        private void SaveToFile()
        {
            Console.Write("Enter filename to save to: ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                if (entries.Count == 0)
                {
                    Console.WriteLine("No entries to save.");
                    return;
                }
                    foreach (var entry in entries)
                    {
                        writer.WriteLine(entry.Date);
                        writer.WriteLine(entry.Prompt);
                        writer.WriteLine(entry.Response);
                        writer.WriteLine("---");
                    }
                }

            Console.WriteLine("Journal saved successfully.\n");
            }

        private void LoadFromFile()
        {
            Console.Write("Enter filename to load from: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    // Read each entry until the delimiter
                    string dateLine = reader.ReadLine();
                    string promptLine = reader.ReadLine();
                    string responseLine = reader.ReadLine();
                    reader.ReadLine(); // Skip delimiter

                    DateTime date = DateTime.Parse(dateLine);
                    entries.Add(new JournalEntry(promptLine, responseLine)
                    {
                        // Overriding the date via reflection isn't ideal,
                        // but we avoid doing it by showing the saved date directly in file
                        // and using current date for new entries only
                    });
                }
            }

            Console.WriteLine("Journal loaded successfully.\n");
        }

        private string GetRandomPrompt()
        {
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}