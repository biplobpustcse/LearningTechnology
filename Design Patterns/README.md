## Questions and answers

**What is a design pattern?**

A design pattern is a general, reusable solution to a commonly occurring problem within a given context in software design. Patterns are templates—not code—that can be adapted to solve specific design issues in object-oriented systems.

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

**✅ 7. Strategy Pattern**

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

**✅ 8. Command Pattern**

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

**9. Repository Pattern**

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


  
