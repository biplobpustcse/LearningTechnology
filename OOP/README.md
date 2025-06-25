## Questions and answers
**1. Object-Oriented Programming (OOP)**

Object-Oriented Programming (OOP) is a programming paradigm that uses objects to model real-world entities. It promotes code reusability, scalability, and maintainability.

**2. What are the four pillars/Core Principles of OOP?**

**OOP in C# is built on four key principles:**

**i. Encapsulation**

Encapsulation is the process of hiding the internal details of a class and exposing only the necessary parts. It helps in data security and modularity.
```
class Person
{
    private string name; // Private field (hidden from outside)
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person();
        p.Name = "John";
        Console.WriteLine(p.Name); // Output: John
    }
}
```
- Private fields (name) prevent direct modification.
- Public fields (Name) has methods (Getter, Setter) to the control access.
