## Reflection
Reflection in C# is a powerful feature that allows you to **inspect and manipulate code at runtime**.

#### What is Reflection?
Reflection is the ability to inspect and interact with the metadata of types at runtime. It allows you to:

- Get information about assemblies, modules, and types.
- Discover and invoke methods and properties dynamically.
- Create instances of types at runtime.

#### Why Use Reflection?
- Dynamic Type Discovery: Useful in scenarios where types are not known at compile time.
- Late Binding: Allows methods and properties to be invoked dynamically.
- Metadata Inspection: Enables tools like debuggers, IDEs, and serialization libraries to inspect and manipulate code.

#### Getting Started with Reflection
Let’s start with a basic example to illustrate how to use reflection to inspect a type’s metadata.

Step-by-Step Example: Inspecting a Type’s Metadata
- 1 — Define a Sample Class
```
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }
}
```
- 2 — Using Reflection to Inspect the Person Class
```
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Get the type of the Person class
        Type personType = typeof(Person);

        // Display the full name of the type
        Console.WriteLine("Type: " + personType.FullName);

        // Display the properties of the type
        Console.WriteLine("Properties:");
        foreach (PropertyInfo property in personType.GetProperties())
        {
            Console.WriteLine("- " + property.Name + " (" + property.PropertyType.Name + ")");
        }

        // Display the methods of the type
        Console.WriteLine("Methods:");
        foreach (MethodInfo method in personType.GetMethods())
        {
            Console.WriteLine("- " + method.Name);
        }
    }
}
```
