using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello. What is your grade percentage?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string grade = "";
        // Determine the letter grade based on the percentage
        // A: 90-100, B: 80-89, C: 70-79, D: 60-69, F: 0-59
        if (percent >= 90)
        {
            grade = "A";
        }
        else if (percent >= 80)
        {
            grade = "B";
        }
        else if (percent >= 70)
        {
            grade = "C";
        }
        else if (percent >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your letter grade is: {grade}");
        
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course. Please try again next time");
        }

        

    }
}