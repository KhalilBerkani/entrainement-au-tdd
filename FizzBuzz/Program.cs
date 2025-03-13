using System;
using System.Collections.Generic;

//// This class violates multiple SOLID principles
//public class HugeClass
//{
//    private string Name;
//    private double Salary;
//    private List<string> Tasks;
//    private string ReportFormat;
//    private string Department;
//    private string Address;
//    private string PhoneNumber;

//    public HugeClass(string name, double salary, List<string> tasks, string reportFormat, string department, string address, string phoneNumber)
//    {
//        Name = name;
//        Salary = salary;
//        Tasks = tasks;
//        ReportFormat = reportFormat;
//        Department = department;
//        Address = address;
//        PhoneNumber = phoneNumber;
//    }

//    //APRES la modif




//    // SRP Violation: This class handles multiple responsibilities
//    public void GenerateReport()
//    {
//        if (ReportFormat == "PDF")
//        {
//            Console.WriteLine("Generating PDF Report...");
//        }
//        else if (ReportFormat == "HTML")
//        {
//            Console.WriteLine("Generating HTML Report...");
//        }
//    }

//    public void SendReport(string email)
//    {
//        Console.WriteLine("Sending report to: " + email);
//    }

//    // OCP Violation: If a new employee type is added, we have to modify this method
//    public double CalculateBonus(string role)
//    {
//        if (role == "Manager") return Salary * 0.2;
//        if (role == "Developer") return Salary * 0.1;
//        if (role == "Intern") return Salary * 0.05;
//        return Salary * 0.03;
//    }

//    // LSP Violation: Not using abstraction properly
//    public void PerformTask()
//    {
//        if (Tasks.Count == 0)
//        {
//            Console.WriteLine("No tasks assigned");
//        }
//        else
//        {
//            foreach (var task in Tasks)
//            {
//                Console.WriteLine("Performing task: " + task);
//            }
//        }
//    }

//    // ISP Violation: This class is doing too many things
//    public void ProcessSalary()
//    {
//        Console.WriteLine("Processing salary for: " + Name);
//    }

//    public void SaveToDatabase()
//    {
//        Console.WriteLine("Saving employee data to the database");
//    }

//    public void UpdateAddress(string newAddress)
//    {
//        Address = newAddress;
//        Console.WriteLine("Updated address to: " + newAddress);
//    }

//    public void UpdatePhoneNumber(string newPhoneNumber)
//    {
//        PhoneNumber = newPhoneNumber;
//        Console.WriteLine("Updated phone number to: " + newPhoneNumber);
//    }

//    public void PrintTasks()
//    {
//        foreach (var task in Tasks)
//        {
//            Console.WriteLine("Task: " + task);
//        }
//    }

//    // DIP Violation: Directly depends on concrete classes instead of abstractions
//    public void ConnectToDatabase()
//    {
//        DatabaseConnection connection = new DatabaseConnection();
//        connection.Connect();
//    }

//    // More functionality added, increasing the class complexity
//    public void RequestLeave(int days)
//    {
//        Console.WriteLine(Name + " requested " + days + " days of leave.");
//    }

//    public void ApproveLeave(string employeeName)
//    {
//        Console.WriteLine("Leave approved for " + employeeName);
//    }

//    public void RejectLeave(string employeeName)
//    {
//        Console.WriteLine("Leave rejected for " + employeeName);
//    }

//    public void ConductMeeting(string topic)
//    {
//        Console.WriteLine("Conducting meeting on: " + topic);
//    }

//    public void EvaluatePerformance(string employeeName, string performance)
//    {
//        Console.WriteLine("Performance of " + employeeName + " is: " + performance);
//    }

//    public void ScheduleInterview(string candidateName)
//    {
//        Console.WriteLine("Scheduled interview with " + candidateName);
//    }

//    public void PrintEmployeeDetails()
//    {
//        Console.WriteLine("Employee Name: " + Name);
//        Console.WriteLine("Department: " + Department);
//        Console.WriteLine("Salary: " + Salary);
//        Console.WriteLine("Address: " + Address);
//        Console.WriteLine("Phone: " + PhoneNumber);
//    }
//}

//// This class should be abstracted, but is used directly, violating DIP
//class DatabaseConnection
//{
//    public void Connect()
//    {
//        Console.WriteLine("Connecting to database...");
//    }
//}



//APRES la modif
// Interface pour le Reporting (SRP & ISP)
interface IReportGenerator
{
    void GenerateReport();
}

// Interface pour l'envoi des rapports (SRP & ISP)
interface IReportSender
{
    void SendReport(string email);
}

// Interface pour le calcul des bonus (OCP & LSP)
interface IBonusCalculator
{
    double CalculateBonus(double salary);
}

// Interface pour la gestion des tâches (SRP & ISP)
interface ITaskManager
{
    void PerformTask();
}

// Interface pour la base de données (DIP)
interface IDatabaseConnection
{
    void Connect();
}

public class Employee
{
    private string Name;
    private double Salary;
    private string Department;
    private string Address;
    private string PhoneNumber;


    public Employee(string name, double salary, string department, string address, string phoneNumber)
    {
        Name = name;
        Salary = salary;
        Department = department;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public void UpdateAddress(string newAddress)
    {
        Address = newAddress;
        Console.WriteLine($"New address : {newAddress}");
    }

    public void UpdatePhoneNumber(string newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
        Console.WriteLine($"New Phone : {newPhoneNumber}");
    }
    public void PrintDetail()
    {
        Console.WriteLine($"Employee Name : {Name}");
        Console.WriteLine($"Department : {Department}");
        Console.WriteLine($"Salary : {Salary}");
        Console.WriteLine($"Address : {Address}");
        Console.WriteLine($"Phone : {PhoneNumber}");
    }

    class ManagerBonusCalculator : IBonusCalculator
    {
        public double CalculateBonus(double salary) => salary * 0.2;
    }

    class DeveloperBonusCalculator : IBonusCalculator
    {
        public double CalculateBonus(double salary) => salary * 0.1;
    }

    class InternBonusCalculator : IBonusCalculator
    {
        public double CalculateBonus(double salary) => salary * 0.05;
    }

    class TaskManager : ITaskManager
    {
        private List<string> Tasks;

        public TaskManager(List<string> tasks)
        {
            Tasks = tasks;
        }

        public void PerformTask()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks");
            }
            else
            {
                foreach (var task in Tasks)
                {
                    Console.WriteLine($"task: {task}");
                }
            }
        }
    }

    class PDFReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating PDF Report...");
        }
    }

    class HTMLReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating HTML Report...");
        }
    }

    class EmailReportSender : IReportSender
    {
        public void SendReport(string email)
        {
            Console.WriteLine($"Sending report to: {email}");
        }
    }

    class DatabaseConnection : IDatabaseConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to database...");
        }
    }


}