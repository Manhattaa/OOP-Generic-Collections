using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        Stack<Employee> employeeStack = new Stack<Employee>();

        // Skapa fem objekt av Employee-klassen och lägg till dem i stacken
        for (int i = 1; i <= 5; i++)
        {
            Employee employee = new Employee
            {
                Id = i,
                Name = "Employee" + i,
                Gender = i % 2 == 0 ? "Male" : "Female",
                Salary = 50000 + i * 1000
            };
            employeeStack.Push(employee);
        }

        Console.WriteLine("Objekt i Stack:");

        // Skriv ut alla objekt i stacken
        foreach (var employee in employeeStack)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
        }

        Console.WriteLine($"Antal objekt kvar i Stack: {employeeStack.Count}");

        Console.WriteLine("\nHämta alla objekt med Pop-metoden:");

        // Hämta och skriv ut alla objekt med Pop-metoden
        while (employeeStack.Count > 0)
        {
            var employee = employeeStack.Pop();
            Console.WriteLine($"Popped: Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
            Console.WriteLine($"Antal objekt kvar i Stack: {employeeStack.Count}");
        }

        // Lägg till alla objekt igen i Stack
        for (int i = 1; i <= 5; i++)
        {
            Employee employee = new Employee
            {
                Id = i,
                Name = "Employee" + i,
                Gender = i % 2 == 0 ? "Male" : "Female",
                Salary = 50000 + i * 1000
            };
            employeeStack.Push(employee);
        }

        Console.WriteLine("\nHämta objekt med Peek-metoden:");

        // Hämta och skriv ut två objekt med Peek-metoden
        for (int i = 0; i < 2; i++)
        {
            if (employeeStack.Count > 0)
            {
                var employee = employeeStack.Peek();
                Console.WriteLine($"Peeked: Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
                employeeStack.Pop(); // Ta bort objektet från Stack
                Console.WriteLine($"Antal objekt kvar i Stack: {employeeStack.Count}");
            }
        }

        Console.WriteLine("\nKolla om objekt nummer 3 finns i Stack eller inte:");

        int employeeIdToFind = 3;
        bool employeeExists = employeeStack.Contains(employeeStack.FirstOrDefault(e => e.Id == employeeIdToFind));
        if (employeeExists)
        {
            Console.WriteLine($"Objekt med Id {employeeIdToFind} finns i Stack.");
        }
        else
        {
            Console.WriteLine($"Objekt med Id {employeeIdToFind} finns inte i Stack.");
        }

        // Del 2 - List

        List<Employee> employeeList = new List<Employee>();

        // Lägg till fem objekt av Employee-klassen i listan
        for (int i = 1; i <= 5; i++)
        {
            Employee employee = new Employee
            {
                Id = i,
                Name = "Employee" + i,
                Gender = i % 2 == 0 ? "Male" : "Female",
                Salary = 50000 + i * 1000
            };
            employeeList.Add(employee);
        }

        // Använd Contains-metoden för att söka efter Employee2 i listan
        if (employeeList.Contains(employeeList.FirstOrDefault(e => e.Name == "Employee2")))
        {
            Console.WriteLine("\nEmployee2-objektet finns i listan.");
        }
        else
        {
            Console.WriteLine("\nEmployee2-objektet finns inte i listan.");
        }

        // Använd Find-metoden för att hitta det första manliga (Male) objektet i listan
        var firstMaleEmployee = employeeList.Find(e => e.Gender == "Male");
        if (firstMaleEmployee != null)
        {
            Console.WriteLine($"Det första manliga objektet i listan är: Id: {firstMaleEmployee.Id}, Name: {firstMaleEmployee.Name}");
        }

        // Använd FindAll-metoden för att hitta och skriva ut alla manliga (Male) objekt i listan
        var maleEmployees = employeeList.FindAll(e => e.Gender == "Male");
        Console.WriteLine("\nManliga objekt i listan:");
        foreach (var maleEmployee in maleEmployees)
        {
            Console.WriteLine($"Id: {maleEmployee.Id}, Name: {maleEmployee.Name}");
        }
    }
}