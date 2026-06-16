# SQL - Comprehensive Notes

## 📌 Overview

SQL (Structured Query Language) is the standard language for managing and querying relational databases. It enables you to create, read, update, and delete data from databases, as well as manage database schemas and permissions. SQL is essential for any application that stores data.

**Key Point:** SQL is the universal language for data manipulation and retrieval in relational databases.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Master SQL SELECT queries and filtering
- [ ] Understand different JOIN types and relationships
- [ ] Write complex queries with subqueries
- [ ] Implement aggregation and grouping
- [ ] Manage database schemas and constraints
- [ ] Optimize query performance

---

## 📚 Core Concepts Learned

### 1. **Basic SQL Syntax**

**SELECT Statement:**
```sql
SELECT column1, column2, ...
FROM table_name
WHERE condition
ORDER BY column_name ASC/DESC
LIMIT 10;
```

**Common Clauses:**
- `SELECT` - Specify columns to retrieve
- `FROM` - Specify table(s)
- `WHERE` - Filter rows
- `ORDER BY` - Sort results
- `LIMIT/TOP` - Limit number of rows
- `DISTINCT` - Remove duplicates

### 2. **Data Manipulation (CRUD)**

**INSERT:**
```sql
INSERT INTO users (name, email, age)
VALUES ('John', 'john@example.com', 30);

INSERT INTO users
SELECT name, email, age FROM temp_users;
```

**UPDATE:**
```sql
UPDATE users
SET age = 31, email = 'newemail@example.com'
WHERE id = 1;
```

**DELETE:**
```sql
DELETE FROM users
WHERE age < 18;
```

**SELECT:**
```sql
SELECT * FROM users;
SELECT name, email FROM users WHERE age > 18;
```

### 3. **Filtering & WHERE Clause**

```sql
-- Comparison operators
WHERE age > 18
WHERE age >= 18
WHERE age = 30
WHERE age != 30
WHERE age BETWEEN 18 AND 65

-- Logical operators
WHERE age > 18 AND city = 'NYC'
WHERE age > 18 OR city = 'NYC'
WHERE NOT (age < 18)

-- Pattern matching
WHERE name LIKE 'J%'         -- Starts with J
WHERE email LIKE '%@gmail.com' -- Ends with

-- IN operator
WHERE city IN ('NYC', 'LA', 'Chicago')

-- NULL checks
WHERE email IS NULL
WHERE email IS NOT NULL
```

### 4. **JOINs**

**INNER JOIN:**
```sql
SELECT u.name, o.order_id
FROM users u
INNER JOIN orders o ON u.id = o.user_id;
```

**LEFT JOIN:**
```sql
SELECT u.name, COUNT(o.id) as order_count
FROM users u
LEFT JOIN orders o ON u.id = o.user_id
GROUP BY u.id, u.name;
```

**RIGHT JOIN:**
```sql
SELECT u.name, o.order_id
FROM users u
RIGHT JOIN orders o ON u.id = o.user_id;
```

**FULL OUTER JOIN:**
```sql
SELECT u.name, o.order_id
FROM users u
FULL OUTER JOIN orders o ON u.id = o.user_id;
```

**CROSS JOIN:**
```sql
SELECT u.name, p.product_name
FROM users u
CROSS JOIN products p;
```

### 5. **Aggregation Functions**

```sql
SELECT 
    COUNT(*) as total_users,
    SUM(age) as total_age,
    AVG(age) as average_age,
    MIN(age) as youngest,
    MAX(age) as oldest
FROM users;
```

**GROUP BY:**
```sql
SELECT 
    city,
    COUNT(*) as user_count,
    AVG(age) as avg_age
FROM users
GROUP BY city
HAVING COUNT(*) > 5
ORDER BY user_count DESC;
```

### 6. **Subqueries**

```sql
-- Subquery in WHERE
SELECT name FROM users
WHERE id IN (
    SELECT user_id FROM orders
    WHERE total > 100
);

-- Subquery in FROM
SELECT avg_price FROM (
    SELECT AVG(price) as avg_price
    FROM products
    WHERE category = 'Electronics'
) AS price_stats;

-- Correlated subquery
SELECT u.name,
    (SELECT COUNT(*) FROM orders WHERE user_id = u.id) as order_count
FROM users u;
```

### 7. **Database Schema**

**CREATE TABLE:**
```sql
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    age INT CHECK (age >= 0),
    created_at DATETIME DEFAULT GETDATE()
);
```

**ALTER TABLE:**
```sql
ALTER TABLE users ADD phone VARCHAR(20);
ALTER TABLE users DROP COLUMN age;
ALTER TABLE users ALTER COLUMN name VARCHAR(150);
```

**Constraints:**
- `PRIMARY KEY` - Unique identifier
- `FOREIGN KEY` - Relationship to another table
- `UNIQUE` - Ensure uniqueness
- `NOT NULL` - Mandatory field
- `CHECK` - Validate values
- `DEFAULT` - Default value

### 8. **String & Date Functions**

```sql
-- String functions
SELECT 
    UPPER(name),           -- Uppercase
    LOWER(email),          -- Lowercase
    LEN(name),             -- Length
    SUBSTRING(name, 1, 3), -- Substring
    CHARINDEX('a', name),  -- Find character
    CONCAT(first, ' ', last) -- Concatenate
FROM users;

-- Date functions
SELECT 
    GETDATE(),                    -- Current date
    DATEADD(DAY, 7, created_at),  -- Add days
    DATEDIFF(DAY, created_at, GETDATE()) as days_old,
    YEAR(created_at),
    MONTH(created_at),
    DAY(created_at)
FROM orders;
```

### 9. **Indexes & Performance**

```sql
-- Create index
CREATE INDEX idx_email ON users(email);
CREATE UNIQUE INDEX idx_username ON users(username);

-- View execution plan
EXPLAIN SELECT * FROM users WHERE id = 1;

-- Drop index
DROP INDEX idx_email ON users;
```

---

## 💻 Hands-On Exercises

### Exercise 1: Basic Queries
**Task:** Write SELECT queries with WHERE and ORDER BY clauses

### Exercise 2: JOINs
**Task:** Join multiple tables and retrieve related data

### Exercise 3: Aggregation
**Task:** Use GROUP BY and aggregate functions

### Exercise 4: Subqueries
**Task:** Write complex queries with subqueries

### Exercise 5: Database Design
**Task:** Design a relational schema for a real-world system

---

## 📝 Assignments

1. **Database Design & Implementation**
   - Design a database for an e-commerce system
   - Create tables with proper relationships
   - Add constraints and indexes
   - Write 10+ complex queries

2. **Reporting Queries**
   - Create reports for sales data
   - Revenue by product category
   - Customer purchase history
   - Inventory analysis

3. **Data Analysis**
   - Analyze customer behavior
   - Identify trends
   - Create summaries and statistics

---

## 🔗 References

### Official Documentation:
- [Microsoft SQL Server Docs](https://docs.microsoft.com/en-us/sql/)
- [MySQL Documentation](https://dev.mysql.com/doc/)
- [PostgreSQL Manual](https://www.postgresql.org/docs/)

### Tutorials:
- [SQL Tutorial - SQLTutorial.org](https://www.sqltutorial.org/)
- [W3Schools SQL](https://www.w3schools.com/sql/)
- [SQL Fundamentals Course](https://www.freecodecamp.org/)

### Practice:
- [LeetCode Database Problems](https://leetcode.com/problemset/database/)
- [HackerRank SQL](https://www.hackerrank.com/domains/sql)
- [Codewars SQL Katas](https://www.codewars.com/?language=sql)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Basic SELECT Queries
- [ ] WHERE & Filtering
- [ ] JOINs
- [ ] Aggregation
- [ ] Subqueries
- [ ] Schema Design
- [ ] Performance

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

**Projects Completed:**
1. ___________
2. ___________
3. ___________

**Next Steps:**
- Move to C# module
- Learn advanced SQL concepts
- Study database normalization

---

**Last Updated:** June 2026
**Completion Status:** Not Started
