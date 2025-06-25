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

**ii. Inheritance**
Inheritance allows a class (child/derived class) to reuse properties and methods from another class (parent/base class). It promotes code reuse.
```
class Animal // Base class
{
    public void Eat()
    {
        Console.WriteLine("This animal eats food.");
    }
}

class Dog : Animal // Derived class
{
    public void Bark()
    {
        Console.WriteLine("The dog barks.");
    }
}

class Program
{
    static void Main()
    {
        Dog myDog = new Dog();
        myDog.Eat();  // Inherited from Animal
        myDog.Bark(); // Dog-specific method
    }
}
```
- The Dog class inherits the Eat() method from Animal.
- Additional features (Bark()) can be added in the derived class.

**iii. Polymorphism**

Polymorphism allows methods to take multiple forms, enabling method overloading and method overriding.

**Two types:**

**(a) Compile-time (Overloading):**

Same method name, different parameter lists.
```
class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();
        Console.WriteLine(math.Add(5, 10));       // Output: 15
        Console.WriteLine(math.Add(3.5, 2.1));    // Output: 5.6
    }
}
```
**(b) Run-time (Overriding)**

Same method name but implementation different.

A derived class modifies a base class method.
```
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks.");
    }
}

class Program
{
    static void Main()
    {
        Animal myAnimal = new Dog(); // Runtime polymorphism
        myAnimal.MakeSound(); // Output: Dog barks.
    }
}
```
- Virtual method in base class allows overriding.
- Derived class provides its own implementation.

**iv. Abstraction**

Abstraction hides complexity by showing only essential details.

**Example: Abstraction using Abstract Class**

Abstract classes can provide both common implementation and abstract methods
```
abstract class Vehicle
{
    public abstract void Start(); // Abstract method (no implementation)
}

class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car engine starts with a key.");
    }
}

class Program
{
    static void Main()
    {
        Vehicle myCar = new Car();
        myCar.Start(); // Output: Car engine starts with a key.
    }
}
```
- Derived class must provide an implementation of Start().

**Example: Abstraction using Interfaces**

- Interfaces enforce 100% abstraction (only method signatures, no implementation).
```
interface IShape
{
    void Draw(); // Interface method
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

class Program
{
    static void Main()
    {
        IShape shape = new Circle();
        shape.Draw(); // Output: Drawing a Circle.
    }
}
```

**3. Interfaces vs Abstract Class**

| Feature                   | Abstract Class            | Interface                                   |
| ----------------          | ------------------------- | ----------------------------------------    |
| Implementation            | Can have implementation   | Cannot have implementation (before C# 8)    |
| Access Modifiers          | Can have access modifiers | Members are public by default (before C# 8) |
| Constructor               | Can have constructors     | Cannot have constructors                    |
| Inheritance               | Single inheritance        | Multiple interface support                  |
| State (Fields/Properties) | can have fields and properties to maintain state | can only have properties with get/set accessors |

**When to Use What?**

| Situation                                                              | Use                |
| ---------------------------------------------------------------------- | ------------------ |
| You need to define a common **contract** across unrelated classes      | **Interface**      |
| You want to share **base code** (implementation) among related classes | **Abstract Class** |
| You need **multiple inheritance** (of behavior)                        | **Interfaces**     |
| You have a **base class with common behavior/state**                   | **Abstract Class** |

- **Abstract classes** are about **code reuse and inheritance**, while **interfaces** are about defining **contracts and achieving polymorphism**. 

**4. Partial Classes**

Splitting a class into multiple files.
```
partial class MyClass
{
    public void Method1() => Console.WriteLine("Method1");
}

partial class MyClass
{
    public void Method2() => Console.WriteLine("Method2");
}
```


  
