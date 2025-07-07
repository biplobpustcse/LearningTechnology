## Oracle Database related questions and answers

**1. What is Oracle Database?**

Oracle is a multi-model, enterprise-grade **Relational Database Management System (RDBMS)** developed by Oracle Corporation. It supports SQL and PL/SQL, and it's known for features like scalability, concurrency, and high availability.

**2. What is the difference between VARCHAR and VARCHAR2 in Oracle?**

- **VARCHAR2** is used to store variable-length strings and is the recommended type.
- **VARCHAR** is reserved for future use and behaves like VARCHAR2 in current versions but may change.

**3. What is a ROWID**?

**ROWID** is a unique identifier for a row in a table. It represents the physical location of the row (data block, row slot, etc.).

```
SELECT ROWID, * FROM Employees;
```

**4. What is a dual table in Oracle?**

**DUAL** is a special **one-row, one-column table** present by default. It’s often used for selecting pseudo-columns or evaluating expressions.

```
SELECT SYSDATE FROM DUAL;
```

**5. What are the main Oracle data types?**

- VARCHAR2, CHAR – character strings
- NUMBER – numeric values
- DATE, TIMESTAMP – date/time
- BLOB, CLOB – binary and character large objects

**6. What is PL/SQL?**

**PL/SQL** (Procedural Language for SQL) is Oracle’s procedural extension to SQL. It supports variables, conditions, loops, procedures, and exception handling.

**7. How do you handle exceptions in PL/SQL?**
```
BEGIN
  -- some SQL operations
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('No data found');
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
```

**8. What are triggers in Oracle?**

**Triggers** are stored PL/SQL blocks that automatically execute in response to events like **INSERT, UPDATE, or DELETE**.

```
CREATE OR REPLACE TRIGGER emp_before_insert
BEFORE INSERT ON Employees
FOR EACH ROW
BEGIN
  :NEW.CreatedDate := SYSDATE;
END;
```

**9. What is the difference between DELETE, TRUNCATE, and DROP in Oracle?**

| Operation  | Deletes Data | Rollback | Resets Identity | Affects Structure |
| ---------- | ------------ | -------- | --------------- | ----------------- |
| `DELETE`   | Yes          | Yes      | No              | No                |
| `TRUNCATE` | Yes (all)    | No       | Yes             | No                |
| `DROP`     | Yes (table)  | No       | N/A             | Yes               |


**10. What are Oracle sequences?**

**Sequences** are objects used to generate unique numeric values, often used for primary keys.

```
CREATE SEQUENCE emp_seq START WITH 1 INCREMENT BY 1;
```

**11. How to find the 3rd highest salary in Oracle?**
```
SELECT * FROM (
  SELECT DISTINCT Salary FROM Employees ORDER BY Salary DESC
) WHERE ROWNUM <= 3
MINUS
SELECT * FROM (
  SELECT DISTINCT Salary FROM Employees ORDER BY Salary DESC
) WHERE ROWNUM < 3;
```

**OR using DENSE_RANK:**
```
SELECT * FROM (
  SELECT Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS rnk
  FROM Employees
)
WHERE rnk = 3;
```
**12. What is an Oracle Cursor?**

A **cursor** is a pointer to the context area for SQL statement execution. It can be implicit (automatically created) or explicit (manually declared and controlled).

```
DECLARE
  CURSOR emp_cursor IS SELECT Name FROM Employees;
  emp_name Employees.Name%TYPE;
BEGIN
  OPEN emp_cursor;
  LOOP
    FETCH emp_cursor INTO emp_name;
    EXIT WHEN emp_cursor%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE(emp_name);
  END LOOP;
  CLOSE emp_cursor;
END;
```

**13. What is a materialized view in Oracle?**

A **materialized view** stores the result of a query physically and can be refreshed periodically. It improves performance for complex joins or aggregations.

```
CREATE MATERIALIZED VIEW dept_mv
REFRESH FAST
START WITH SYSDATE
NEXT SYSDATE + 1
AS
SELECT DepartmentId, COUNT(*) FROM Employees GROUP BY DepartmentId;
```

**14. What is the difference between IN, EXISTS, and JOIN?**

- **IN**: Faster when subquery returns small result sets.
- **EXISTS**: Faster when outer query returns small result sets.
- **JOIN**: Used to fetch data from multiple tables, returns combined results.

**15. What is Oracle RAC?**

Oracle **RAC** (Real Application Clusters) allows multiple instances to access a single database for high availability and load balancing.

**16. What is the use of ANALYZE and AUTOTRACE in Oracle?**

- **ANALYZE**: Collects statistics on tables/indexes (older method).
- **AUTOTRACE**: Used to display execution plan and resource usage.

**17. How to check execution plan of a query in Oracle?**
```
EXPLAIN PLAN FOR
SELECT * FROM Employees WHERE DepartmentId = 10;

SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);
```

**18. What is Oracle Data Pump?**

**Data Pump** (expdp/impdp) is a utility for fast export/import of data and metadata between Oracle databases.

**19. What are Oracle Temporary Tables?**

**Temporary tables** are used to store session-specific or transaction-specific data temporarily.

```
CREATE GLOBAL TEMPORARY TABLE temp_emps (
  Id NUMBER, Name VARCHAR2(50)
) ON COMMIT DELETE ROWS;
```

**20. What are the types of Indexes in Oracle?**

- B-tree Index (default)
- Bitmap Index
- Function-based Index
- Composite Index








