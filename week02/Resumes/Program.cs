using System;

public class Job
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        public void DisplayJobDetails()
        {
            Console.WriteLine($"{_company} {_jobTitle} {_startYear} {_endYear}");
        }
    }

public class Resume
    {
        public string _name;
        public List<Job> _jobs;

        public void Display()
        {
            Console.WriteLine($"{_name} {_jobs}");
        }
    }



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._company = "microsoft";
        job1._jobTitle = "software engineer";
        job1._startYear = 1998;
        job1._endYear = 2024;

        job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._company = "apple";
        job2._jobTitle = "product designer";
        job2._startYear = 2023;
        job2._endYear = 2026;

        job2.DisplayJobDetails();

        Resume myresume = new Resume();
        myresume._name = "emeribe stanley";
        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);

        myresume.Display();

    }
}

    
        