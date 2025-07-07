## Database related questions and answers
**1. What is a database?**

A database is an organized collection of data that can be easily accessed, managed, and updated. Examples include relational databases (like SQL Server,Oracle Database, MySQL) 
and non-relational databases (like MongoDB).

**🔁 Relational Database (RDBMS)**

A **relational database** is a type of database that stores data in **structured tables** with predefined **rows and columns**. Each table represents
a specific entity and uses **keys** (primary and foreign) to maintain **relationships** between tables. It follows a **schema** and ensures **data integrity** using **ACID** properties (Atomicity, Consistency, Isolation, Durability).

🧩 **Example:** MySQL, PostgreSQL, SQL Server, Oracle

**🔄 Non-Relational Database (NoSQL)**

A **non-relational database** is a type of database that stores data in a **non-tabular format**, such as **key-value pairs, documents, graphs, or wide-columns**.
It is **schema-less** or has a flexible schema, making it ideal for **unstructured or semi-structured data**. It often follows **BASE** properties (Basically Available,
Soft state, Eventually consistent) and is designed for **scalability and high performance**.

🧩 **Example:** MongoDB (document), Redis (key-value), Cassandra (wide-column), Neo4j (graph)

**Difference between Relational and Non-Relational Databases**

| Feature            | Relational Database (RDBMS)   | Non-Relational Database (NoSQL)          |
| ------------------ | ----------------------------- | ---------------------------------------- |
| **Data Structure** | Tables (rows & columns)       | Documents, key-value, graph, wide-column |
| **Schema**         | Fixed (predefined)            | Flexible or schema-less                  |
| **Query Language** | SQL                           | Varies (e.g., JSON-based, APIs)          |
| **Joins**          | Supports joins                | Typically not supported(Limited support in MongoDB)                  |
| **Scalability**    | Vertical (scale-up)           | Horizontal (scale-out)                   |
| **Examples**       | MySQL, PostgreSQL, SQL Server | MongoDB, Redis, Cassandra, Neo4j         |



