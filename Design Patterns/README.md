## Questions and answers

**✅ 1. Singleton Pattern**
Ensures a class has only one instance and provides a global point of access to it.

**Use Case:** Centralized logging system.

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

**Use Case:** Creating different types of notifications (Email, SMS).

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

Separates construction of a complex object from its representation.

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

Allows objects to be notified when another object's state changes.

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

Encapsulates algorithms and makes them interchangeable.

**Use Case:** Switch sorting strategy dynamically.

```
public interface ISortStrategy {
    void Sort(List<int> list);
}

public class BubbleSort : ISortStrategy {
    public void Sort(List<int> list) => Console.WriteLine("Sorting with BubbleSort");
}

public class QuickSort : ISortStrategy {
    public void Sort(List<int> list) => Console.WriteLine("Sorting with QuickSort");
}

public class Sorter {
    private readonly ISortStrategy _strategy;
    public Sorter(ISortStrategy strategy) => _strategy = strategy;
    public void Sort(List<int> data) => _strategy.Sort(data);
}

// Usage
var sorter = new Sorter(new QuickSort());
sorter.Sort(new List<int> { 1, 3, 2 });
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




  
