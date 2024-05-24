using System;

class Employee
{
    public string Name { get; set; }
    public double HourlyRate { get; set; }

    public double CalculatePay(double hours)
    {
        if (hours <= 40)
        {
            return hours * HourlyRate;
        }
        else
        {
            return 40 * HourlyRate + (hours - 40) * HourlyRate * 1.5;
        }
    }

    public void DisplayGrossPay(double hours)
    {
        double pay = CalculatePay(hours);
        Console.WriteLine($"{Name}: ${pay:F2}");
    }
}

class Program
{
    static void Main()
    {
        Employee manager = new Employee { Name = "Manager", HourlyRate = 30.0 };
        Employee technician = new Employee { Name = "Technician", HourlyRate = 25.0 };

        manager.DisplayGrossPay(45);
        technician.DisplayGrossPay(50);
    }
}

