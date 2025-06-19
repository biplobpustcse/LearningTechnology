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


