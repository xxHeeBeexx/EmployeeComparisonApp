// This console app demonstrates overloading the '==' operator to compare Employee objects by Id.
using System;

// Step 1: Create the Employee class with Id, FirstName, and LastName
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Step 2: Overload the '==' operator
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // If both are null, or both are same instance, return true
        if (ReferenceEquals(emp1, emp2))
            return true;

        // If one is null, but not both, return false
        if (emp1 is null || emp2 is null)
            return false;

        // Compare their Ids
        return emp1.Id == emp2.Id;
    }

    // Overload the '!=' operator (must be done in pairs)
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }

    // Recommended: Override Equals for consistency with '=='
    public override bool Equals(object obj)
    {
        if (obj is Employee emp)
        {
            return this.Id == emp.Id;
        }
        return false;
    }

    // Recommended: Override GetHashCode when Equals is overridden
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

// Step 3: Main Program to create and compare Employee objects
class Program
{
    static void Main(string[] args)
    {
        // Create two Employee instances
        Employee emp1 = new Employee { Id = 101, FirstName = "Alice", LastName = "Smith" };
        Employee emp2 = new Employee { Id = 101, FirstName = "Bob", LastName = "Jones" };

        // Compare the two using the overloaded '==' operator
        if (emp1 == emp2)
        {
            Console.WriteLine("The two employees are equal (same Id).");
        }
        else
        {
            Console.WriteLine("The two employees are NOT equal (different Ids).");
        }
    }
}
