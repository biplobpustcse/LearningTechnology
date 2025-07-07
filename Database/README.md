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

**2. What is the difference between DELETE, TRUNCATE, and DROP?**

| Operation  | Description           | Can Rollback | Affects Structure? | Resets Identity? |
| ---------- | --------------------- | ------------ | ------------------ | ---------------- |
| `DELETE`   | Deletes selected rows | Yes          | No                 | No               |
| `TRUNCATE` | Deletes all rows      | No           | No                 | Yes              |
| `DROP`     | Deletes the table     | No           | Yes                | N/A              |

**3. What is a Primary Key and Unique Key?**

**Primary Key:**

A **primary key** uniquely identifies each record in a table. It **cannot be NULL** and must be **unique** for every row.

**Unique Key:**

A **Unique Key** ensures all values in a column (or a group of columns) are distinct—i.e., no duplicate values are allowed.It **allows a NULL** value.

**🔄 Difference Between Primary Key and Unique Key:**

| Feature        | Primary Key        | Unique Key               |
| -------------- | ------------------ | ------------------------ |
| Uniqueness     | Must be unique     | Must be unique           |
| Nulls Allowed  | ❌ Not allowed      | ✅ Allowed (1 per column) |
| Number Allowed | Only one per table | Can have multiple        |


**4. What is a Foreign Key?**

A **foreign key** is a field in a table that is the **primary key in another table**. It enforces referential integrity between two related tables.

**5. What are Constraints in SQL?**

**Constraints** in SQL are rules applied to columns in a table to enforce **data integrity, accuracy, and consistency**. They restrict the type of data that can be inserted or updated in a table.

| Constraint      | Description                                               |
| --------------- | --------------------------------------------------------- |
| **PRIMARY KEY** | Uniquely identifies each row in a table. Cannot be null.  |
| **FOREIGN KEY** | Enforces a link between the data in two tables.           |
| **UNIQUE**      | Ensures all values in a column are different.             |
| **NOT NULL**    | Prevents null values from being inserted into a column.   |
| **CHECK**       | Validates values in a column against a logical condition. |
| **DEFAULT**     | Sets a default value for a column if none is provided.    |

**6. What is normalization?**

**Normalization** is the process of **organizing data** to **reduce redundancy** and improve **data integrity**. It involves dividing large tables into smaller, related tables.

**7. What are the different types of JOINs in SQL?**

- **INNER JOIN:** Matches records in both tables.
- **LEFT JOIN:** All records from left table + matched records from right.
- **RIGHT JOIN:** All records from right table + matched from left.
- **FULL OUTER JOIN:** All records from both tables.
- **CROSS JOIN:** Cartesian product.

**8. What is an Index? What are its types?**

An **index** is a database object that improves the **speed of data retrieval** operations on a table. It acts like a **lookup table** that helps the database find rows more quickly—similar to an index in a book.

**Types:**

- **Clustered Index:** Sorts data physically in table.
- **Non-Clustered Index:** Creates a separate structure for quick lookup.

**🔄 Difference Between Clustered and Non-Clustered Index:**

| Feature              | Clustered Index                         | Non-Clustered Index                     |
| -------------------- | --------------------------------------- | --------------------------------------- |
| **Data Storage**     | Sorts and stores actual table data      | Stores index separately from table data |
| **Number per Table** | Only **one**                            | Can be **multiple**                     |
| **Access Speed**     | Faster for range queries                | Slightly slower, uses pointer to data   |
| **Example Use**      | Primary key or frequently sorted column | Columns used in search filters or joins |

**9. What is a View in SQL?**

A **View** is a **virtual table** based on the result of a query. It **doesn't store data itself**, only the SQL logic to retrieve data.

**10. What is a Stored Procedure ans Function?**

**Stored Procedure:**

A **stored procedure** is a precompiled collection of **SQL statements** stored in the database. It improves performance, security, and reusability.

**Stored Function:**

A **Function** is a database object that takes input parameters, performs calculations or operations, and **returns a single value or a table**. It’s mainly used in SELECT, WHERE, or JOIN clauses.

**🔄 Difference Between Stored Procedure and Function:**

| Feature                   | Stored Procedure                                            | Function                                            |
| ------------------------- | ----------------------------------------------------------- | --------------------------------------------------- |
| **Return Type**           | Can return **0 or more values** using `OUT` or result sets  | Always returns **a single value** (scalar or table) |
| **Use in SQL Statements** | Cannot be used directly in SELECT statements                | Can be used **inside SELECT, WHERE, etc.**          |
| **DML Operations**        | ✅ Can perform INSERT, UPDATE, DELETE                       | 🚫 Generally **not recommended** for DML            |
| **Transaction Handling**  | ✅ Supports transactions (`BEGIN`, `COMMIT`)                | ❌ Cannot manage transactions                        |
| **Output Parameters**     | ✅ Supports `OUTPUT` parameters                             | ❌ No output parameters (just return value)          |
| **Exception Handling**    | ✅ Can use `TRY...CATCH`                                    | ❌ Limited or no error handling                      |

**11. What is a Transaction?**

A **transaction** in SQL is **a sequence of one or more SQL operations** that are executed as a **single unit of wor**k. A transaction ensures data **integrity** by following the **ACID** properties — meaning the operations **either all succeed or all fail**.

**Key Properties (ACID):**

| Property            | Meaning                                                                 |
| ------------------- | ----------------------------------------------------------------------- |
| **A - Atomicity**   | All operations in a transaction are completed, or none at all.          |
| **C - Consistency** | Brings database from one valid state to another. |
| **I - Isolation**   | Transactions don't affect each other.           |
| **D - Durability**  | Once committed, changes are permanently saved—even after a crash.       |

**Example:**
```
BEGIN TRANSACTION;

UPDATE Accounts SET Balance = Balance - 100 WHERE AccountID = 1;
UPDATE Accounts SET Balance = Balance + 100 WHERE AccountID = 2;

COMMIT;  -- or ROLLBACK; if something goes wrong
```
🔁 If any part of the transaction fails (e.g., second update), you can use ROLLBACK to undo all changes made in that transaction.

**12. What is the difference between WHERE and HAVING?**

- **WHERE**: Used to filter rows **before** grouping.
- **HAVING**: Used to filter groups **after** aggregation.

**14. What is the difference between OLTP and OLAP?**

| Feature               | **OLTP (Online Transaction Processing)**          | **OLAP (Online Analytical Processing)**          |
| --------------------- | ------------------------------------------------- | ------------------------------------------------ |
| **Purpose**           | Handles **day-to-day transactions**               | Performs **data analysis and reporting**         |
| **Operations**        | Read/write (INSERT, UPDATE, DELETE)               | Read-heavy (complex SELECT queries, aggregation) |
| **Data Volume**       | Deals with **small, transactional data**          | Handles **large volumes of historical data**     |
| **Query Complexity**  | Simple, short queries                             | Complex, long-running analytical queries         |
| **Normalization**     | Highly normalized (to reduce redundancy)          | Denormalized (to improve query performance)      |
| **Speed**             | Optimized for **fast processing of transactions** | Optimized for **query performance and analysis** |
| **Users**             | Operational users (cashiers, clerks, staff)       | Business analysts, decision-makers               |
| **Example Use Cases** | Banking, eCommerce, Reservation Systems           | Business intelligence, Data warehousing          |
| **Database Design**   | ER (Entity-Relationship) model                    | Star or Snowflake schema                         |
| **Backup Frequency**  | Frequent, critical                                | Periodic                                         |

**15. What are Common Table Expressions (CTEs)?**

CTEs are **temporary result sets** that can be referred to within a SELECT, INSERT, UPDATE, or DELETE.
It **improves query readability** and is especially useful for recursive queries or **breaking complex logic into simpler parts**.

```
WITH CTE_Example AS (
  SELECT Id, Name FROM Employees WHERE condition
)
SELECT * FROM CTE_Example WHERE another_condition;
```



