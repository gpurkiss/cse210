using System;
using System.Collections.Generic;

public class ReflectionActivity : BaseActivity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine("\n" + _prompts[rnd.Next(_prompts.Count)]);
        Console.WriteLine("Consider the following questions:\n");

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rnd.Next(_questions.Count)];
            Console.WriteLine("> " + question);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}
