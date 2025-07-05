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



