using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;

    public GoalManager()
    {
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        string choice;
        do
        {
            Console.WriteLine($"\n*** Eternal Quest ***  Score: {_score}  Level: {_level}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
            }
        } while (choice != "6");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nTypes of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
            CheckLevelUp();
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"🎉 Level Up! You are now Level {_level}!");
        }
    }

    private void SaveGoals()
    {
        Console.Write("File name to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            output.WriteLine(_level);
            foreach (var goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("File name to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        using (StreamReader input = new StreamReader(filename))
        {
            _score = int.Parse(input.ReadLine());
            _level = int.Parse(input.ReadLine());

            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] parts = line.Split("|");
                string type = parts[0];
                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))
                    {
                        // manually setting completion status
                    });
                    if (bool.Parse(parts[4]))
                    {
                        ((SimpleGoal)_goals[_goals.Count - 1]).RecordEvent();
                    }
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                }
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
