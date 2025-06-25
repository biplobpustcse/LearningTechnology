## Questions and answers
**1. What is SOLID?**

The SOLID principles are a set of five design principles in C# intended to make software designs more understandable, maintainable, flexible, and scalable. SOLID is an acronym that stands for:

- S – Single Responsibility Principle
- O – Open/Closed Principle
- L – Liskov Substitution Principle
- I – Interface Segregation Principle
- D – Dependency Inversion Principle

**🔹 1. Single Responsibility Principle (SRP)** What is the Single Responsibility Principle? How can you implement it in C#?

A class should have only one reason to change, meaning it should have only one responsibility or job.
**💡 Real-Life Analogy:**
Think of a printer. It should only print documents, not scan or fax.
**🧑‍💻 Code Example:**
```
// Bad Example
public class InvoiceService
{
    public void CreateInvoice() { /* Logic */ }
    public void PrintInvoice() { /* Logic */ } // Printing logic should not be here
    public void SaveToDatabase() { /* Logic */ } // DB logic should be separated
}

// Good Example
public class InvoiceGenerator
{
    public void CreateInvoice() { /* Generate invoice */ }
}

public class InvoicePrinter
{
    public void Print(Invoice invoice) { /* Print logic */ }
}

public class InvoiceRepository
{
    public void Save(Invoice invoice) { /* Save to DB */ }
}
```
**🔹 2. Open/Closed Principle (OCP)** Explain the Open/Closed Principle with an example in C#.

Classes should be open for **extension but closed for modification**. You should be able to add new functionality **without changing existing code.**

**💡 Real-Life Analogy:**

A plug socket with multiple adapters. You can add new devices without rewiring the house.

**🧑‍💻 Code Example:**
```
// Bad: Violation of OCP
public class DiscountCalculator
{
    public double GetDiscount(string customerType)
    {
        if (customerType == "Regular") return 10;
        else if (customerType == "Premium") return 20;
        return 0;
    }
}

// Good: Follows OCP
public interface IDiscountStrategy
{
    double GetDiscount();
}

public class RegularCustomerDiscount : IDiscountStrategy
{
    public double GetDiscount() => 10;
}

public class PremiumCustomerDiscount : IDiscountStrategy
{
    public double GetDiscount() => 20;
}

public class GoldCustomerDiscount : IDiscountStrategy
{
    public double GetDiscount() => 30;
}

public class DiscountCalculator
{
    public double CalculateDiscount(IDiscountStrategy strategy)
    {
        return strategy.GetDiscount();
    }
}

class Program
{
    static void Main()
    {
        DiscountCalculator disCal = new DiscountCalculator();
        var result = disCal.CalculateDiscount(new PremiumCustomerDiscount());

        Console.WriteLine($"Discount calculated successfully using OCP:{result}");
    }
}
```
**🔹 3. Liskov Substitution Principle (LSP)** What is Liskov Substitution Principle? How do you violate it?

You should be able to replace a base class with any of its derived classes without breaking the functionality.

**💡 Real-Life Analogy:**

Suppose you have a Product class, and you also sell digital goods (like eBooks). Your inventory logic includes ReduceStock() for shipped products. But digital products don’t require stock. Let's see what happens.

**❌ Violation of LSP (Bad Design)**
```
public class Product
{
    public string Name { get; set; }
    public int QuantityInStock { get; set; }

    public virtual void ReduceStock(int quantity)
    {
        if (quantity > QuantityInStock)
            throw new InvalidOperationException("Not enough stock.");

        QuantityInStock -= quantity;
    }
}

public class DigitalProduct : Product
{
    public override void ReduceStock(int quantity)
    {
        throw new NotSupportedException("Digital products do not have stock.");
    }
}
```
**❌ Problem:**
- Client code using Product assumes ReduceStock will work, but if passed a DigitalProduct, it breaks.
```
void ShipProduct(Product product)
{
    product.ReduceStock(1); // Will crash for DigitalProduct
}
```
**✅ Correct Design Following LSP**

We can refactor the class hierarchy to respect LSP by using interfaces or a base abstraction that separates stock-tracked products from non-stock ones.
```
public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public abstract void ProcessOrder(int quantity);
}

public class PhysicalProduct : Product
{
    public int QuantityInStock { get; set; }

    public override void ProcessOrder(int quantity)
    {
        if (quantity > QuantityInStock)
            throw new InvalidOperationException("Insufficient stock.");

        QuantityInStock -= quantity;
        Console.WriteLine($"Shipped {quantity} units of {Name}.");
    }
}

public class DigitalProduct : Product
{
    public override void ProcessOrder(int quantity)
    {
        Console.WriteLine($"Delivered digital copy of {Name} to email.");
    }
}
```
**✅ Now the client code works perfectly:**
```
void ProcessPurchase(Product product, int qty)
{
    product.ProcessOrder(qty); // Safe for both physical and digital
}
```



  
