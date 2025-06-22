## Questions and answers
**1. What is the difference Between Equality Operator (==) and Equals() Method in C#?**

There is no diffrence between Equality Operator (==) and Equals() Method when we compare with **value types** (like int, bool,etc.) also with string(string is reference type but overridden in String to compare value).
<br/>But when compare with **reference type** "==" compares the object references are same while ".Equals()" compares the contents are same.

1. "==" compare object references.
2. ".Equal()" compares only object contents (We can not use .Equal() method with NULL variable,because it throws null exception).
3. String datatypes always does content comparison.
```
class Program
{
    static void Main(string[] args)
    {
        object obj1 = "Hello";
        object obj2 = new string("Hello");

        Console.WriteLine(obj1 == obj2); // False
        Console.WriteLine(obj1.Equals(obj2)); // True
    }
}
```
**2. What is the difference between ref and out parameters?**

In C#, both ref and out keywords are used to pass method arguments by reference, allowing the method to modify the original variable's value. However, ref requires the variable to be initialized before being passed, while out does not, but the method must assign a value to the out parameter before returning. ref is suitable for two-way communication (input and output), while out is primarily used for returning multiple values from a method. 

- **ref:** The variable must be initialized before it is passed to the method.
- **out**: The variable does not need to be initialized before it is passed, but must be assigned a value inside the method.

**ref Example:**
```
void AddRef(ref int x)
{
    x += 10;
}

int num = 5;// Must assign before method call
AddRef(ref num);
Console.WriteLine(num);  // Output: 15
```
**out Example:**
```
void GetSum(out int result, int a, int b)
{
    result = a + b; // Must assign before method ends
}

int sum; // No need to initialize
GetSum(out sum, 3, 4);
Console.WriteLine(sum);  // Output: 7
```

**3. What is the difference between Array and ArrayList?**

Array: Strongly typed, fixed size.

ArrayList: Stores objects, not type-safe, resizable.

**4. What is the difference between abstract class and interface?**

**Key Differences Between Abstract Class and Interface**

In C#, abstract classes and interfaces are both used to define contracts that other classes can implement or inherit, but they have key differences in usage, purpose, and behavior.

**Key Differences Between Abstract Class and Interface**
| Feature          | Abstract Class                       | Interface                                                |
| ---------------- | ------------------------------------ | -------------------------------------------------------- |
| Implementation   | Can have implementation              | No implementation (C# 8.0 allows default implementation) |
| Inheritance      | Single inheritance                   | Multiple implementation                                  |
| Access Modifiers | Yes                                  | No (C# 8.0 allows)                                       |
| Constructors     | Yes                                  | No                                                       |
| Abstraction      | doesn't provide full abstraction     | provide full abstraction                                 |

**5. What is boxing and unboxing in C#?**

- Boxing: Converting a value type to an object.
- Unboxing: Extracting the value type from the object.
```
int num = 123;
object obj = num;          // Boxing
int newNum = (int)obj;     // Unboxing
```
**6. Difference between var vs dynamic and object in c#**

In C#, var, dynamic, and object all offer ways to work with variables of unknown or varying types, but they differ significantly in how they handle type information and when that information is used. var uses type inference at compile time, dynamic uses late binding at runtime, and object represents a base type that can hold any object but requires explicit casting (boxing/unboxing) for specific operations.

**VAR keyword and I listed some key points of type below:**

- You need to assign a value for the var keyword while declaring variables;
- Because its type is known at compile time and it is statically typed variable;
- You can’t change the data type of variable when it has been declared using the keyword var.

**DYNAMIC keyword:**

- It can store any type of value, and its type is unknown until runtime, so it will not support IntelliSense;
- It is not mandatory to assign a value at declaration time.

**OBJECT keyword.**

- It can assign or store any type of value because it is the base class for all types in C#;
- We need to change the type an object value to a specific type before doing any manipulation on it;
- We need to be very careful while using objects because it can cause serious problems at runtime if it can’t convert to a specific type.

**Then, let’s check the difference among these three types:**

1. Declaration and Initialization.Object: Assigning is not required; Var: Assigning is mandatory at the time of declaration;Dynamic: Assigning is not required.
2. Value acceptance / storage.Object: Possible to store any kind of data type;Var: You can store any type of value, but initialization is mandatory;Dynamic: Possible to store any kind of data type.
3. Passing as a method argument.Object: Yes, we can pass it as a method argument;Var: No;Dynamic: Like an object, we can pass it as a method argument.
```
class Program
{
    static void Main(string[] args)
    {
        var vName = "Hello"; //It is mandatory to assign a value at declaration time
        Console.WriteLine(vName);

        dynamic name; //It is not mandatory to assign a value at declaration time
        name = "Biplob";
        Console.WriteLine(name);
        name = 1234;
        Console.WriteLine(name);

        dynamic a = 3;
        dynamic b = 5;
        dynamic c = a + b; //no need to convertion
        Console.WriteLine(c);

        object m;
        m = "Biplob";
        m = 5;
        object n = 7;
        object result = Convert.ToDecimal(m) + Convert.ToDecimal(n); //need to change object type to a specific type before doing any manipulation on it;
        Console.WriteLine(result);
    }
}
```
**7. What is a delegate in C#?**

In C#, a delegate is a type that represents a reference to a method. Think of it as a variable that can hold a reference to a method, allowing you to pass methods as arguments to other methods, store them for later use, or invoke them dynamically. Essentially, delegates enable you to treat methods like any other data type in your code. 

**Key Points**

- A delegate allows you to encapsulate a method call.
- You can pass methods as parameters to other methods.
- You can change the method being called at runtime.
- Delegates are the basis for events in C#.
```
// Declare a delegate
public delegate void GreetDelegate(string name);

// Define a method matching the delegate signature
public class Greeter
{
    // First method
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    // Second method
    public void SayWelcome(string name)
    {
        Console.WriteLine($"Welcome, {name}, to the system.");
    }
}

class Program
{
    static void Main()
    {
        Greeter greeter = new Greeter();

        // Create delegate instance
        GreetDelegate greet = greeter.SayHello;

        // Add another method to the delegate invocation list
        greet += greeter.SayWelcome;

        // Invoke the delegate
        greet("Biplob");
    }
}
```
**8. What is the difference between readonly and const?**

| Feature      | const             | readonly            |
| ------------ | ----------------- | ------------------- |
| Evaluated at | Compile-time      | Runtime             |
| Modifiable   | No                | In constructor only |
| Type         | Static by default | Instance or static  |

**Example of const**
```
public class MathConstants
{
    public const double Pi = 3.14159; // must be assigned at declaration
}
```
** Example of readonly**
```
public class Config
{
    public readonly string ConnectionString;

    public Config(string connectionString)
    {
        ConnectionString = connectionString; // allowed in constructor
    }
}
```
**9. What are async and await in C#?**

Used for asynchronous programming. They allow non-blocking code execution.
```
public async Task<string> GetDataAsync()
{
    HttpClient client = new HttpClient();
    string result = await client.GetStringAsync("https://api.example.com");
    return result;
}
```
**10. What is the difference between Task and Thread?**

- **Task:** High-level abstraction of asynchronous operations, managed by ThreadPool.
<br/>Uses the ThreadPool, which reuses threads for better performance and lower overhead.

- **Thread:** Low-level control, each thread has its own context.
<br/>Creates a dedicated thread, consumes more memory (1MB stack by default).

| Feature           | `Thread`                        | `Task`                               |
| ----------------- | ------------------------------- | ------------------------------------ |
| Abstraction       | Low                             | High                                 |
| Thread source     | OS-managed                      | ThreadPool                           |
| Performance       | Slower (more overhead)          | Faster (less overhead)               |
| Async support     | ❌                               | ✅                                    |
| Exception capture | Manual                          | Built-in                             |
| Use case          | Long-running or thread-specific | Short, parallel, or async operations |

**11. What is the using statement in C#?**

A **using** statement is used to ensure the disposal of resources (like files, DB connection).
```
using (var reader = new StreamReader("file.txt"))
{
    string content = reader.ReadToEnd();
}
```
**11. What is garbage collection in C#?**

The Garbage Collector (GC) automatically reclaims memory occupied by objects that are no longer in use.

**Why is it needed?**
Without GC, developers would have to manually allocate and deallocate memory, which often leads to:

- Memory leaks (unused objects not being cleaned up)
- Dangling pointers (referencing freed memory)
- Crashes and instability

**12. What are value types and reference types in C#?**

- **Value types:** Value types hold the actual data. When a value type is assigned to another variable, a copy of the data is made. They are stored in the stack memory
  
**Common Value Types:**
- int
- float
- double
- char
- bool
- struct
- enum
- decimal
- DateTime
  **Example:**
```
int x = 10;
int y = x;
y = 20;

Console.WriteLine(x); // Output: 10 (not affected by y)
```
- **Reference types:** Reference types store a reference (pointer) to the actual data, not the data itself. They are stored in the heap, and the reference is stored in the stack.

🔑 **Common Reference Types:**
- class
- interface
- delegate
- array
- string
- object (base type for all types)
**Example:**
```
  class Person {
    public string Name;
}

Person p1 = new Person();
p1.Name = "Biplob";

Person p2 = p1;
p2.Name = "Hosen";

Console.WriteLine(p1.Name); // Output: Hosen
```
**13. What is a Memory Leak in C#?**

A memory leak in C# happens when your application holds references to objects that are no longer needed, preventing the garbage collector (GC) from freeing that memory. Over time, this can lead to increased memory usage, performance degradation, or even OutOfMemoryException.

**Common Causes of Memory Leaks in C#**
| Cause                                       | Example                                                                                  |
| ------------------------------------------- | ---------------------------------------------------------------------------------------- |
| ❌ **Event Handlers Not Unsubscribed**       | Subscribing to events and never unsubscribing.                                           |
| ❌ **Static Collections**                    | Storing objects in static lists or dictionaries.                                         |
| ❌ **Long-lived Objects Holding References** | Singleton or long-running services holding references to short-lived objects.            |
| ❌ **Unmanaged Resources Not Disposed**      | Failing to call `Dispose()` on `IDisposable` objects like `SqlConnection`, `FileStream`. |

**Example of a Memory Leak (Event Handler):**
```
public class Publisher
{
    public event EventHandler MyEvent;
}

public class Subscriber
{
    public Subscriber(Publisher publisher)
    {
        publisher.MyEvent += HandleEvent;
    }

    private void HandleEvent(object sender, EventArgs e)
    {
        // do something
    }
}
```
**How to Prevent Memory Leaks**

✅ Use using statements or explicitly call Dispose() for IDisposable objects.

✅ Unsubscribe from events (event -= handler) when done.

✅ Avoid unnecessary use of static references.

✅ Use WeakReference if necessary.

✅ Monitor memory usage using tools like:
- Visual Studio Diagnostic Tools

**14. What is a static constructor in C#?**

It’s used to initialize static data or perform actions that need to run only once.
```
class Logger
{
    static Logger() { /* Initialize once */ }
}
```
**15. What is the yield keyword in C#?**

Used in an iterator method to return values one at a time, enabling lazy evaluation.
```
public IEnumerable<int> GetEven()
{
    for (int i = 0; i < 10; i += 2)
        yield return i;
}
```
**16. Difference between Task, Task<T>, and ValueTask<T>?**

**Task:** For async operations with no result.

**Task<T>:** Async with a result.

**ValueTask<T>:** Performance optimization; avoids heap allocation if result is available synchronously.

**17. What is the difference between Dictionary and Hashtable?**

In C#, both Dictionary<TKey, TValue> and Hashtable are used to store key-value pairs, but there are key differences between them in terms of type safety, performance, and usage in modern .NET. Here's a detailed comparison:

Dictionary<TKey, TValue> is type-safe and generic.

Hashtable<TKey, TValue> is non-generic and stores objects.

Dictionary is faster due to type safety and avoids boxing/unboxing.

**Code Examples**

Dictionary Example:
```
var dict = new Dictionary<string, int>();
dict["apple"] = 5;
int count = dict["apple"]; // No casting needed
```
Hashtable Example:
```
Hashtable table = new Hashtable();
table["apple"] = 5;
int count = (int)table["apple"]; // Explicit casting required
```
| Feature          | Dictionary | Hashtable     |
| ---------------- | ---------- | ------------- |
| Generics         | ✅ Yes      | ❌ No          |
| Type Safety      | ✅ Yes      | ❌ No          |
| Performance      | ✅ Faster   | ❌ Slower      |
| Null Key Support | ❌ No       | ✅ Yes         |
| Recommended      | ✅ Yes      | ❌ No (legacy) |

