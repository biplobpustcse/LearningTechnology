## Questions and answers
**1. What is .NET Core?**<br/>
.NET Core is a free, open-source, cross-platform (Windows, macOS, Linux) framework created by Microsoft for building modern high-performance applications, including web, cloud, mobile backends and microservices architectures. 

**2. What is the difference between .net core and .net framework?**<br/>
NET Framework and .NET Core are both development platforms from Microsoft, but they have key differences. .NET Framework is older, Windows-specific, and primarily used for traditional desktop and web applications. .NET Core is a newer, cross-platform (Windows, macOS, Linux) framework, designed for modern, cloud-based, and microservices architectures. .NET Core is also open-source and more lightweight than .NET Framework. 

**3. What is Middleware in .NET Core?**
<br/>
Middleware are reusable software components in the HTTP pipeline that handle incoming HTTP requests and outgoing HTTP responses. They can modify or even terminate a request before it reaches the application's core logic or the response before it is sent back to the client.

**Use Middleware** for things like CORS, exception handling, authentication.

**Execution Time**	Runs before routing (and after, depending on order)

✅ **Common Built-in Middleware in ASP.NET Core**

| Middleware                  | Purpose                                                            |
| --------------------------- | ------------------------------------------------------------------ |
| `UseRouting`                | Matches the request to route endpoints                             |
| `UseEndpoints`              | Executes the endpoint (like controller actions, Razor pages, etc.) |
| `UseAuthentication`         | Authenticates users                                                |
| `UseAuthorization`          | Authorizes users based on policies and roles                       |
| `UseStaticFiles`            | Serves static files (e.g., CSS, JS, images) from `wwwroot`         |
| `UseCors`                   | Enables Cross-Origin Resource Sharing                              |
| `UseExceptionHandler`       | Global exception handling and error pages                          |
| `UseDeveloperExceptionPage` | Shows detailed exception info in development environment           |
| `UseHttpsRedirection`       | Redirects HTTP requests to HTTPS                                   |
| `UseStatusCodePages`        | Returns user-friendly status code pages (like 404, 500, etc.)      |
| `UseResponseCompression`    | Compresses response bodies                                         |
| `UseResponseCaching`        | Enables caching of responses                                       |
| `UseSession`                | Enables session state management                                   |
| `UseWebSockets`             | Supports WebSocket communication                                   |
| `UseHealthChecks`           | Adds health check endpoints for monitoring                         |


**Register Middleware in Program.cs**
```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Register custom middleware
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseRouting();

app.UseAuthentication(); // Login required?
app.UseAuthorization();  // Check user roles/permissions

app.MapGet("/", () => "Hello, World!");

app.Run();

```

**4. What is filters in .net core?**
<br/>
In ASP.NET Core, filters are components that allow you to execute custom logic at specific points during the request processing pipeline, before or after actions are executed.
<br/>
**Types of Filters in ASP.NET Core:**

- **Authorization filters:** Control access to resources. **IAuthorizationFilter, IAsyncAuthorizationFilter**
- **Resource filters:** Control resource binding and model validation. **IResourceFilter, IAsyncResourceFilter**
- **Action filters:** Execute logic before and after action methods. **IActionFilter, IAsyncActionFilter**
- **Result filters:** Control the result of an action method before it's returned to the client. **IResultFilter, IAsyncResultFilter**
- **Exception filters:** Handle exceptions that occur during request processing. **IExceptionFilter, IAsyncExceptionFilter**

**Use Filters** when dealing with controller-level logic like validation, logging, result formatting, or authorization.

**Execution Time**	Runs after routing, once controller/action is known

**Middleware vs Filters**

| Middleware                         | Filters                              |
| ---------------------------------- | ------------------------------------ |
| Works on **all** HTTP requests     | Works on **controller/action** level |
| Good for **global concerns**       | Good for **MVC/Web API logic**       |
| Executes early (before routing)    | Executes after routing               |
| Applied in `Program.cs/Startup.cs` | Applied via attributes or globally   |

**5. What is dependency injection in .net core?**
<br/>
Dependency injection (DI) in .NET Core is a design pattern that promotes loose coupling and testability by providing dependencies to a class from an external source rather than having the class create them itself.<br/>
It involves separating a class's dependencies from its implementation, allowing for greater flexibility and easier modification.

**Injection Types:**

There are three main ways to inject dependencies:
- **Constructor Injection:** The most common approach, where dependencies are passed through the constructor of a class. 
- **Property Injection:** Dependencies are injected through properties of a class. 
- **Method Injection:** Dependencies are injected through a method parameter. 

**Service Container:**
.NET Core provides a built-in service container (or IoC container) that manages the registration and resolution of dependencies. 

**🧰 Lifetime Options in .NET Core DI:**

| Lifetime  | Description                            |
| --------- | -------------------------------------- |
| Singleton | Same instance for the entire app       |
| Scoped    | One instance per HTTP request          |
| Transient | New instance every time it's requested |

**Program.cs**
```
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ProductService>();
```



