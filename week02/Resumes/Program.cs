using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Developer";
        job1._companyName = "Tech Solutions Inc.";
        job1._startYear = 2024;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Data Analyst";
        job2._companyName = "Data Insights Ltd.";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Grace Purkiss";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();

    }
}