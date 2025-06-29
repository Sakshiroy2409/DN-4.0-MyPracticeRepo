using System;

public class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public Employee(int employeeId, string name, string position, double salary)
    {
        EmployeeId = employeeId;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary}");
    }
}

public class EmployeeManagementSystem
{
    private Employee[] employees;
    private int count;

    public EmployeeManagementSystem(int size)
    {
        employees = new Employee[size];
        count = 0;
    }

    
    public void AddEmployee(Employee emp)
    {
        if (count < employees.Length)
        {
            employees[count++] = emp;
            Console.WriteLine("Employee added successfully.");
        }
        else
        {
            Console.WriteLine("Array is full. Cannot add more employees.");
        }
    }

    
    public Employee SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
                return employees[i];
        }
        return null;
    }

    public void DisplayAllEmployees()
    {
        if (count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            employees[i].Display();
        }
    }

    
    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                employees[--count] = null;
                Console.WriteLine("Employee deleted successfully.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }
}

class Program
{
    static void Main()
    {
        EmployeeManagementSystem system = new EmployeeManagementSystem(5);

        system.AddEmployee(new Employee(101, "Alice", "Manager", 75000));
        system.AddEmployee(new Employee(102, "Bob", "Developer", 60000));
        system.AddEmployee(new Employee(103, "Charlie", "Tester", 50000));

        Console.WriteLine("\nAll Employees:");
        system.DisplayAllEmployees();

        Console.WriteLine("\nSearch for Employee with ID 102:");
        var emp = system.SearchEmployee(102);
        if (emp != null)
            emp.Display();
        else
            Console.WriteLine("Employee not found.");

        Console.WriteLine("\nDelete Employee with ID 102:");
        system.DeleteEmployee(102);

        Console.WriteLine("\nAll Employees After Deletion:");
        system.DisplayAllEmployees();
    }
}