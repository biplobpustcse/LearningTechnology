## Questions and answers
**1. What is Software Architecture?**

**Software architecture** refers to the **high-level structure of a software system.** It defines how different components or modules of the system interact, communicate, and function together. It's crucial because it affects **performance, scalability, reliability, maintainability**, and the **team's ability** to develop and extend the system efficiently.

🧠 Think of it like the architectural design of a building: it includes major systems (plumbing, electrical, HVAC) and how they fit together, not the details of every pipe or wire.
  
**🧩 Key Elements of Software Architecture**

- **Components** – independent pieces like services, modules, or layers
- **Connectors** – communication between components (HTTP, message queues, etc.)
- **Patterns** – like MVC, Microservices, Event-Driven, Layered
- **Quality** attributes – performance, scalability, security, maintainability
- **Decisions** – trade-offs and guidelines for technology, design, and development

**2. What are common software architecture patterns?**

Some common architecture patterns include:

- **Layered (N-tier) Architecture**
- **Microservices Architecture**
- **Monolithic Architecture**
- **Event-Driven Architecture**
- **Serverless Architecture**
- **Clean Architecture / Hexagonal Architecture**
- **Client-Server Architecture**
- **CQRS (Command Query Responsibility Segregation)**

**3. What is the difference between Monolithic and Microservices Architecture?**

| Feature          | Monolithic              | Microservices                        |
| ---------------- | ----------------------- | ------------------------------------ |
| Deployment       | Single unit             | Independent services                 |
| Scalability      | Harder to scale parts   | Easy to scale individual services    |
| Technology Stack | One stack               | Different stacks per service allowed |
| Complexity       | Easier for small apps   | Better for large/complex systems     |
| Maintainability  | Hard to change one part | Changes isolated to services         |

**4. ❓ What is the difference between Architecture and Design?**

- **Architecture** is about the **overall structure** and **high-level decisions** (what modules exist, how they interact).
- **Design** is more about **low-level decisions** (data structures, algorithms, internal logic of a module).

**5. ❓ How do you ensure scalability in your architecture?**

- Use **load balancers** to distribute traffic
- Implement **horizontal scaling** with microservices
- Use **caching layers** (Redis, CDN)
- Adopt **asynchronous processing** (message queues)
- Use **stateless services**
- Choose **scalable databases** (sharding, replication)

**6. ❓ What is Domain-Driven Design (DDD)?**

DDD is an approach that focuses on modeling software based on the core business domain. It uses concepts like:

- **Entities**
- **Value Objects**
- **Aggregates**
- **Repositories**
- **Bounded Contexts**

**7. ❓ What is the role of an API Gateway in Microservices Architecture?**

An API Gateway acts as a single entry point for all client requests in a microservices system. It:

- Routes requests to the appropriate services
- Handles **authentication, rate limiting**, logging, etc.
- Aggregates multiple service responses

![𝐀𝐏𝐈 𝐆𝐚𝐭𝐞𝐰𝐚𝐲 𝐫𝐨𝐥𝐞𝐬 𝐢𝐧 𝐌𝐢𝐜𝐫𝐨𝐬𝐞𝐫𝐯𝐢𝐜𝐞 𝐞𝐱𝐩𝐥𝐚𝐢𝐧𝐞𝐝 𝐬𝐢𝐦𝐩𝐥𝐲](https://github.com/user-attachments/assets/36e061ae-c156-43af-ae3b-b7fbd64515a6)

**8. ❓ How do you handle inter-service communication in Microservices?**

- **Synchronous**: REST, gRPC
- **Asynchronous**: Message Brokers (RabbitMQ, Kafka, Azure Service Bus)
- Use **event-driven architecture** to decouple services

**9. ❓ What tools and technologies do you use for software architecture?**

- **Documentation**: C4 Model, PlantUML, ArchiMate
- **Monitoring**: Prometheus, Grafana, ELK Stack
- **CI/CD**: GitHub Actions, Azure DevOps, Jenkins
- **Cloud**: Azure, AWS, GCP
- **Design**: Draw.io, Lucidchart

**10. 🧱 N-Layered Architecture (Logical Separation)**

- Refers to the **logical separation** of concerns within code.
- Code is organized into **layers**, each with a specific responsibility:

  - Presentation Layer (UI)
  - Business Logic Layer (BLL)
  - Data Access Layer (DAL)
  - Database (SQL/NoSQL)
    
🎯 Focus: Code structure
**All layers can exist within the same application or process.**

**11. 🏢 N-Tier Architecture (Physical Separation)**

- Refers to the **physical deployment** of application components to different machines or environments (tiers).
- Each tier is deployed independently, possibly on different servers or containers:

  - Web Tier (Web Server)
  - Application Tier (App Server)
  - Data Tier (Database Server)

🎯 Focus: Deployment & infrastructure

**N-Layered vs N-Tier Architecture**

| Feature                   | **N-Layered Architecture**   | **N-Tier Architecture**          |
| ------------------------- | -------------------------- | -------------------------------- |
| Separation Type           | Logical (in code)          | Physical (in deployment)         |
| Primary Concern           | Code organization          | Scalability, security, isolation |
| Inter-layer Communication | In-process method calls    | Network calls (HTTP, RPC, etc.)  |
| Deployment                | Usually one app            | Multi-server or multi-host       |
| Testing                   | Easier to test in one unit | Requires integration testing     |
| DevOps Complexity         | Simple                     | Higher                           |


**12. What is Clean Architecture?**

**Clean Architecture** is a software design pattern proposed by **Robert C. Martin (Uncle Bob)** that emphasizes **separation of concerns** and **dependency inversion**.

  ✅ **Core idea:** Organize the system so that **business rules are independent** of frameworks, UI, databases, or any external dependencies.

```
Clean Architecture Layers/
├── Presentation/ # API, Entry point - Controllers, Swagger, Auth
├── Application/ # DTOs, Commands, Queries, Handlers, Interfaces
├── Domain/ # Entities (Account, JournalEntry, User)
├── Infrastructure/ # SP, repository, services, token service
├── Persistence/ # DbContext, migration config
```
**What are the main layers in Clean Architecture?**

1. **Presentation Layer** – UI (Web API, MVC, Angular, etc.).
2. **Application Layer** – Use cases and business rules (orchestrates logic).
3. **Domain Layer** – Entities and core business logic (pure and independent).
4. **Infrastructure Layer(also Persistence)** – Database, file system, third-party services.

![Clean Architecture](https://github.com/user-attachments/assets/51940e2f-a0e9-4ec3-ab38-3139198924aa)

**🎯 Key Principles**

| Principle                  | Description                                                            |
| -------------------------- | ---------------------------------------------------------------------- |
| **Separation of Concerns** | Different responsibilities are placed in different layers              |
| **Independence**           | Business logic does not depend on UI, DB, or frameworks                |
| **Dependency Inversion**   | **Outer layers depend on inner layers via interfaces**                     |
| **Testability**            | Business rules can be tested without the UI, DB, or network            |
| **Flexibility**            | You can swap out the UI, DB, or frameworks without changing core logic |
| ***Dependency Direction****| Always from outer to inner |
| **Inner Layer**	           | Pure business rules (Entities, Use Cases) |
| **Outer Layer**	           | UI, Database, Frameworks |

****13. Monolith vs Modular Monolith vs Microservices****

In software architecture, any modern programming language, choosing between monolithic, modular monolithic, and microservices architecture depends on various factors like project size, team structure, scalability needs, and operational maturity.

🔷 1. Monolithic Architecture

📌 What is it?

- A single, tightly coupled application.
- All modules (UI, business logic, data access) are part of one project and deployed together.

✅ Pros:

- Simple to develop and deploy (good for small teams).
- Easy to debug and test as everything is in one place.
- Fewer infrastructure concerns.

❌ Cons:

- Difficult to scale parts independently.
- Becomes hard to maintain as it grows.
- A single bug can potentially crash the whole system.

🔷 2. Modular Monolithic Architecture

📌 What is it?

Still one deployable unit, but organized into well-defined internal modules or layers, often using domain-driven design (DDD) and enforcing clear boundaries.

✅ Pros:

- Best of both worlds (monolith + modularity).
- Easier to maintain than a pure monolith.
- Transition-friendly if planning to move to microservices later.
- Enforces clean architecture, separation of concerns, and loose coupling.

❌ Cons:

- Still deployed as a single unit (one part failing can affect the rest).
- Needs discipline to enforce module boundaries.

🔷 3. Microservices Architecture

📌 What is it?

- Application is split into independently deployable services, each handling a specific business capability.
- Services communicate over HTTP, gRPC, or messaging (e.g., RabbitMQ, Azure Service Bus).

✅ Pros:

- Independent scaling, development, deployment.
- Better fault isolation.
- Ideal for large, distributed teams.

❌ Cons:

- Complex to implement and manage.
- Requires DevOps maturity (monitoring, logging, service discovery, etc.).
- Distributed transactions are hard.
- Potential overkill for small to mid-sized applications.

🔍 **Which is Better?**

There is no "one-size-fits-all." But for most modern applications, modular monolithic is often the best starting point.

✅ Current Trend:

- ✅ Modular Monolithic is increasingly popular for most enterprise applications, especially with ASP.NET Core + Clean Architecture.
- ✅ Microservices are heavily used in cloud-native applications (e.g., Azure, AWS), especially in large organizations.
- ❌ Pure Monoliths are declining in popularity for new projects but still exist in legacy systems.

![image](https://github.com/user-attachments/assets/b72dadad-df7e-41d1-b869-9b83798c5627)

