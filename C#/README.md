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





