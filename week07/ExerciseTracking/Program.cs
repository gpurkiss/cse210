using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes; // duration of activity

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    public abstract double GetDistance(); // miles or km depending on units chosen
    public abstract double GetSpeed();    // miles/hour or km/hour
    public abstract double GetPace();     // minutes per mile or minute per km

    public string GetSummary()
    {
        // Format date as "dd MMM yyyy"
        string dateStr = _date.ToString("dd MMM yyyy");
        // Get activity type name
        string activityType = this.GetType().Name;

        // Format summary string
        return $"{dateStr} {activityType} ({_lengthInMinutes} min) - " +
               $"Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Running activity
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // speed = distance / time * 60 (minutes to hours)
        return (_distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        // pace = minutes / miles
        if (_distance == 0) return 0;
        return (double)LengthInMinutes / _distance;
    }
}

// Cycling activity
public class Cycling : Activity
{
    private double _speed; // in miles per hour

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // distance = speed * time(hours)
        return _speed * (LengthInMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // pace = 60 / speed (minutes per mile)
        if (_speed == 0) return 0;
        return 60.0 / _speed;
    }
}

// Swimming activity
public class Swimming : Activity
{
    private int _laps; // number of laps
    private const double LapLengthMeters = 50.0;
    private const double MeterToMile = 0.000621371;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // distance in miles = laps * 50m * meters to miles
        return _laps * LapLengthMeters * MeterToMile;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (LengthInMinutes == 0) return 0;
        return (distance / LengthInMinutes) * 60; // mph
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0;
        return LengthInMinutes / distance;
    }
}

// Program to test
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));           // 3 miles run in 30 min
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 30, 12.0));          // 12 mph cycling for 30 min
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 20));           // 20 laps swimming in 30 min

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
