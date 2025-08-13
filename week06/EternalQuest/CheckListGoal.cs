using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            return Points + _bonus;
        }
        return Points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
