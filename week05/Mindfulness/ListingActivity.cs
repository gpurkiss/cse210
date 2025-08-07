using System;
using System.Collections.Generic;

public class ListingActivity : BaseActivity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine("\n" + _prompts[rnd.Next(_prompts.Count)]);
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine("\nStart listing. Press Enter after each item:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}
