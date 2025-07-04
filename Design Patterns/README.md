## Questions and answers

**Q: What is a design pattern? Can you describe it in detail?**

**Answer: A design pattern is a reusable, proven solution to a common problem in software design. It’s not code itself but rather a general blueprint that can be adapted to fit specific situations in object-oriented or architectural designs.**

**Design patterns help make code more maintainable, testable, and scalable by promoting best practices and reducing code duplication.**

The concept was popularized by the **Gang of Four (GoF)** in their 1994 book, where they introduced 23 foundational patterns, grouped into three categories: **Creational, Structural, and Behavioral.** These cover patterns like **Singleton, Factory, Observer, and Strategy,** which are still heavily used today.

However, in modern software development — especially in enterprise and web-based applications — we also use many **non-GoF** design patterns like **Repository, Unit of Work, MVC, CQRS, and Dependency Injection.** These evolved to solve new architectural challenges like separation of concerns, testability, and domain-driven design.

So, while GoF patterns are essential building blocks, real-world systems often combine both GoF and non-GoF patterns to achieve clean and scalable architecture.

**💬 Optional Follow-Up: Can you give examples of patterns you've used in projects?**

Sure. I've used the **Repository and Unit of Work** patterns for data access in ASP.NET Core to maintain a clean separation between the domain and persistence layers. I also use **Strategy** to allow switching between different discount calculation methods and **Mediator (via MediatR)** to decouple service logic from controllers using the **CQRS pattern.**

### GoF Design Patterns (Gang of Four)

Published in the book “Design Patterns: Elements of Reusable Object-Oriented Software” (1994) by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides.

They classified 23 design patterns into three categories:

**🔹 Creational Design Patterns**

**✅ 1. Singleton Pattern**
Ensures a class has only one instance and provides a global point of access to it.

**📦 Structure:**

- Private constructor
- Private static variable of the same class
- Public static method/property to get the instance
- 
**Real-World Example:** Logger, Configuration Manager, or DB Connection Pool.

```
public sealed class Logger {
    private static readonly Logger instance = new Logger();
    private Logger() { }
    public static Logger Instance => instance;
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}

// Usage
Logger.Instance.Log("Application started.");
```

**✅ 2. Factory Method Pattern**

Provides an interface for creating objects but lets subclasses alter the type of created objects.

- You want to create objects without exposing the instantiation logic.
- The type of object is determined by a condition or input.

**📦 Structure:**

- Interface or abstract base class
- Multiple implementations
- Factory class with a method to create instances

**Real-World Example:** Creating different types of notifications (Email, SMS).

```
public interface INotification {
    void Send(string message);
}

public class EmailNotification : INotification {
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsNotification : INotification {
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public abstract class NotificationFactory {
    public abstract INotification CreateNotification();
}

public class EmailFactory : NotificationFactory {
    public override INotification CreateNotification() => new EmailNotification();
}

// Usage
NotificationFactory factory = new EmailFactory();
INotification notification = factory.CreateNotification();
notification.Send("Hello from Factory!");
```

**✅ 3. Builder Pattern**

Constructs complex objects step by step, separating the construction from its representation.

**📦 Structure:**

- Builder interface
- Concrete builder classes
- Director class (optional)

**Use Case:** Creating a user profile with optional fields.

```
public class UserProfile {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class UserProfileBuilder {
    private readonly UserProfile _profile = new();

    public UserProfileBuilder SetName(string name) { _profile.Name = name; return this; }
    public UserProfileBuilder SetEmail(string email) { _profile.Email = email; return this; }
    public UserProfileBuilder SetPhone(string phone) { _profile.Phone = phone; return this; }

    public UserProfile Build() => _profile;
}

// Usage
var user = new UserProfileBuilder()
    .SetName("Biplob")
    .SetEmail("biplob@email.com")
    .Build();
```

#### ✅ Structural Patterns

**✅ 4. Adapter Pattern**

Allows incompatible interfaces to work together.

**📦 Structure:**

- Target interface
- Existing class
- Adapter class to bridge them

**Use Case:** Integrating old payment system with a new one.

```
public class LegacyPayment {
    public void MakePayment(decimal amount) => Console.WriteLine($"Legacy payment of {amount}");
}

public interface IPayment {
    void Pay(decimal amount);
}

public class PaymentAdapter : IPayment {
    private readonly LegacyPayment _legacy = new();
    public void Pay(decimal amount) => _legacy.MakePayment(amount);
}

// Usage
IPayment payment = new PaymentAdapter();
payment.Pay(1500);
```

**✅ 5. Decorator Pattern**
Adds new behavior to objects dynamically without altering their structure.

**📦 Structure:**

- Base component interface
- Concrete component
- Decorator implementing the same interface

**Use Case:** Add logging to a user service.

```
public interface IUserService {
    void CreateUser(string name);
}

public class UserService : IUserService {
    public void CreateUser(string name) => Console.WriteLine($"User {name} created.");
}

public class LoggingUserService : IUserService {
    private readonly IUserService _inner;
    public LoggingUserService(IUserService inner) => _inner = inner;

    public void CreateUser(string name) {
        Console.WriteLine("Log: Creating user...");
        _inner.CreateUser(name);
    }
}

// Usage
IUserService service = new LoggingUserService(new UserService());
service.CreateUser("Biplob");
```
#### ✅ Behavioral Patterns

**✅ 6. Observer Pattern**

The Observer pattern defines a one-to-many dependency. When one object changes state, all its dependents are notified.

**📦 Structure:**

- Subject (Publisher)
- Observers (Subscribers)

**✅ Real-World Example:**

News app notifications, event handling in GUI, stock market updates.

**Use Case:** Automatically updating UI or logs when a product price changes.

```
public class Product {
    public event Action PriceChanged;
    private decimal _price;

    public decimal Price {
        get => _price;
        set {
            _price = value;
            PriceChanged?.Invoke();
        }
    }
}

// Usage
var product = new Product();
product.PriceChanged += () => Console.WriteLine("Price has been updated!");
product.Price = 250.50m;
```

**✅ 7. Mediator Pattern**

It reduces the chaos of direct communication between multiple objects by introducing a mediator object. The mediator handles the communication and encapsulates how these objects interact.

✅ Real-World Example:
Air Traffic Control (ATC):
Planes (components) don’t communicate with each other directly. Instead, ATC (mediator) coordinates all communication.

**📦 Simple Real-World C# Example – Chatroom System**
```
//Step 1: Define Mediator Interface
public interface IChatMediator
{
    void SendMessage(string message, User sender);
    void RegisterUser(User user);
}

//Step 2: Concrete Mediator
public class ChatRoom : IChatMediator
{
    private readonly List<User> _users = new();

    public void RegisterUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive(message);
            }
        }
    }
}

//Step 3: Colleague Class (User)
public class User
{
    public string Name { get; }
    private readonly IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
        _mediator.RegisterUser(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} received: {message}");
    }
}

//Step 4: Use It
public class Program
{
    public static void Main()
    {
        var chatRoom = new ChatRoom();

        var alice = new User("Alice", chatRoom);
        var bob = new User("Bob", chatRoom);
        var carol = new User("Carol", chatRoom);

        alice.Send("Hello everyone!");
        bob.Send("Hi Alice!");
    }
}
```
**🧰 ASP.NET Core Use Case — Using MediatR Library**

MediatR is a popular .NET library that implements the Mediator Pattern and is widely used in CQRS, Clean Architecture, and Microservices.



**✅ 8. Strategy Pattern**

Strategy pattern allows you to define a family of algorithms, put them in separate classes, and make them interchangeable.

**📦 Structure:**

- Strategy interface
- Concrete strategy implementations
- Context class that uses the strategy

**Use Case:** You're building an eCommerce checkout system. Users can pay using Credit Card, PayPal, or Bkash. You want to allow the app to easily switch payment strategies without modifying the OrderService.

```
public interface IPaymentStrategy
{
    void ProcessPayment(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Simulate processing credit card payment
        Console.WriteLine($"Paid {amount:C} using Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Simulate PayPal API call
        Console.WriteLine($"Paid {amount:C} using PayPal.");
    }
}

public class BkashPayment : IPaymentStrategy
{
    public void ProcessPayment(decimal amount)
    {
        // Simulate Bkash transaction
        Console.WriteLine($"Paid {amount:C} using Bkash.");
    }
}


public class OrderService
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout(decimal totalAmount)
    {
        if (_paymentStrategy == null)
        {
            throw new InvalidOperationException("Payment strategy not selected.");
        }

        // Simulate order finalization
        Console.WriteLine("Order placed successfully.");

        // Delegate payment to the chosen strategy
        _paymentStrategy.ProcessPayment(totalAmount);
    }
}

// Usage
public class Program
{
    public static void Main(string[] args)
    {
        var orderService = new OrderService();

        // Simulate payment selection from user
        string selectedPayment = "bkash"; // Or "creditcard", "paypal"
        decimal orderTotal = 2000;

        IPaymentStrategy strategy = selectedPayment.ToLower() switch
        {
            "creditcard" => new CreditCardPayment(),
            "paypal" => new PayPalPayment(),
            "bkash" => new BkashPayment(),
            _ => throw new Exception("Invalid payment method")
        };

        orderService.SetPaymentStrategy(strategy);
        orderService.Checkout(orderTotal);
    }
}
```
**✅ Benefits of Strategy Pattern Here**

- Easy to add new payment methods.
- Promotes Open/Closed Principle – no changes in OrderService.
- Decouples business logic from payment details.

**✅ 9. Command Pattern**

Encapsulates a request as an object, allowing undo/redo functionality.

**Use Case:** Undo action in a text editor.

```
public interface ICommand {
    void Execute();
    void Undo();
}

public class TextEditor {
    public string Text { get; set; } = "";
}

public class AddTextCommand : ICommand {
    private readonly TextEditor _editor;
    private readonly string _text;

    public AddTextCommand(TextEditor editor, string text) {
        _editor = editor;
        _text = text;
    }

    public void Execute() => _editor.Text += _text;
    public void Undo() => _editor.Text = _editor.Text.Replace(_text, "");
}

// Usage
var editor = new TextEditor();
var command = new AddTextCommand(editor, "Hello ");
command.Execute();
Console.WriteLine(editor.Text); // Hello 
command.Undo();
Console.WriteLine(editor.Text); // (empty)
```
### 🌐 2. Non-GoF Design Patterns

These patterns are not part of the original GoF catalog but have emerged over time, especially with modern frameworks, enterprise systems, and architectural patterns like DDD and microservices.

**🔍 Real-World Examples of Non-GoF Patterns That Are Widely Accepted**

| Pattern                  | Where It's Used                            |
| ------------------------ | ------------------------------------------ |
| **Repository**           | ASP.NET Core, DDD, Clean Architecture      |
| **Unit of Work**         | Entity Framework, NHibernate               |
| **CQRS**                 | Microservices, Event-driven architectures  |
| **MVC/MVVM**             | ASP.NET Core MVC, WPF, Angular             |
| **Dependency Injection** | .NET Core, Spring, NestJS, Unity Container |

**10. Repository Pattern**

**✅ Purpose:**

Abstracts data access logic and centralizes it into a repository class.

**✅ Real-World Use:**

Used heavily in ASP.NET Core with Entity Framework.
```
public interface IProductRepository
{
    Product Get(int id);
    void Add(Product product);
}

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) => _context = context;

    public Product Get(int id) => _context.Products.Find(id);
    public void Add(Product product) => _context.Products.Add(product);
}
```
**12. CQRS Pattern**

**🔹What is CQRS?**

**CQRS (Command Query Responsibility Segregation)** is a design pattern that separates read (query) and write (command) operations into different models, allowing each to evolve independently for scalability, performance, and maintainability.

- **Command**: Focuses on business rules and validation (rich domain model or DDD)
- **Query**: Optimized for query performance (flat, denormalized, DTO-based)

**🔹Why use CQRS?**

- To decouple read and write logic
- To optimize queries separately from commands
- To scale read-heavy and write-heavy parts independently
- To support event sourcing, audit logging, or event-driven architectures

**🔹Have you implemented CQRS in your projects?**

Yes. In a modular .NET Core accounting system, I used MediatR for CQRS where:

- Commands like CreateJournalEntryCommand handled validations, business logic, and persistence.
- Queries like GetTrialBalanceQuery returned view-optimized DTOs using raw SQL or Dapper for better performance.

**🔹When should you NOT use CQRS?**

- In simple CRUD systems or small apps — it adds complexity
- When your app has minimal domain logic
- When you're not facing scaling or performance issues

**🔹What tools or libraries help implement CQRS in .NET?**


- **MediatR** – To dispatch commands and queries via a mediator
- **FluentValidation** – For validating commands
- **AutoMapper** – For mapping between domain and DTOs
- **Entity Framework Core / Dapper** – For data access
- **ASP.NET Core Minimal APIs or Controllers** – As endpoints


