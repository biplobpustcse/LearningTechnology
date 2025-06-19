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

**5. What is the difference between Array and ArrayList?**

Array: Strongly typed, fixed size.

ArrayList: Stores objects, not type-safe, resizable.

**6. What is the difference between abstract class and interface?**

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

**7. What is boxing and unboxing in C#?**

- Boxing: Converting a value type to object.
- Unboxing: Extracting the value type from object.
```
int num = 123;
object obj = num;          // Boxing
int newNum = (int)obj;     // Unboxing
```
**7. Difference between var vs dynamic and object in c#**

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
