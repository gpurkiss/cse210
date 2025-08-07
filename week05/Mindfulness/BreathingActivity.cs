using System;
using System.Threading;

public class BreathingActivity : BaseActivity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            elapsed += 4;

            if (elapsed >= _duration) break;

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
            elapsed += 4;
        }
    }
}
