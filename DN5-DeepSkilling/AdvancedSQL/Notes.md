# Advanced SQL - Comprehensive Notes

## 📌 Overview

Advanced SQL focuses on query optimization, performance tuning, and leveraging advanced SQL features for complex data analysis. This module builds upon SQL fundamentals and explores enterprise-level SQL concepts.

**Key Point:** Advanced SQL is about writing efficient, scalable queries that perform well under real-world conditions.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Optimize SQL queries using execution plans
- [ ] Master advanced joining and indexing strategies
- [ ] Write complex window functions and CTEs
- [ ] Implement query performance tuning
- [ ] Work with transactions and concurrency
- [ ] Use advanced analytical functions

---

## 📚 Core Concepts Learned

### 1. **Common Table Expressions (CTEs)**

```sql
-- Simple CTE
WITH RankedProducts AS (
    SELECT *,
           ROW_NUMBER() OVER (ORDER BY price DESC) as rank
    FROM products
)
SELECT * FROM RankedProducts WHERE rank <= 10;

-- Recursive CTE
WITH RecursiveNumbers AS (
    -- Base case
    SELECT 1 as number
    
    UNION ALL
    
    -- Recursive case
    SELECT number + 1
    FROM RecursiveNumbers
    WHERE number < 10
)
SELECT * FROM RecursiveNumbers;

-- Multiple CTEs
WITH UserOrders AS (
    SELECT user_id, COUNT(*) as order_count
    FROM orders
    GROUP BY user_id
),
ActiveUsers AS (
    SELECT * FROM UserOrders
    WHERE order_count > 5
)
SELECT * FROM ActiveUsers;
```

### 2. **Window Functions**

```sql
SELECT 
    name,
    salary,
    -- Row number
    ROW_NUMBER() OVER (ORDER BY salary DESC) as row_num,
    
    -- Rank (same salary gets same rank, next rank skips)
    RANK() OVER (ORDER BY salary DESC) as rank,
    
    -- Dense rank (no gaps)
    DENSE_RANK() OVER (ORDER BY salary DESC) as dense_rank,
    
    -- Lag/Lead (previous/next values)
    LAG(salary) OVER (ORDER BY salary DESC) as prev_salary,
    LEAD(salary) OVER (ORDER BY salary DESC) as next_salary,
    
    -- Running calculations
    SUM(salary) OVER (ORDER BY salary DESC) as running_total,
    AVG(salary) OVER (ORDER BY salary DESC) as running_avg,
    
    -- Partitioning
    ROW_NUMBER() OVER (PARTITION BY department ORDER BY salary DESC) as dept_rank
FROM employees;
```

### 3. **Advanced Aggregation**

```sql
-- Grouping Sets - Multiple GROUP BY combinations
SELECT 
    department,
    job_title,
    COUNT(*) as employee_count,
    AVG(salary) as avg_salary
FROM employees
GROUP BY GROUPING SETS (
    (department, job_title),
    (department),
    (job_title),
    ()
);

-- ROLLUP - Hierarchical aggregation
SELECT 
    YEAR(order_date) as year,
    MONTH(order_date) as month,
    SUM(total) as total_sales
FROM orders
GROUP BY ROLLUP (
    YEAR(order_date),
    MONTH(order_date)
);

-- CUBE - All combinations
SELECT 
    category,
    brand,
    COUNT(*) as product_count
FROM products
GROUP BY CUBE (category, brand);
```

### 4. **Indexes & Query Optimization**

```sql
-- Create different index types
CREATE INDEX idx_email ON users(email);
CREATE UNIQUE INDEX idx_username ON users(username);
CREATE NONCLUSTERED INDEX idx_department ON employees(department);

-- Composite index
CREATE INDEX idx_user_created ON orders(user_id, created_date);

-- Filtered index
CREATE INDEX idx_active_users ON users(id)
WHERE status = 'active';

-- View execution plan
-- In SQL Server: SET STATISTICS IO ON / SET STATISTICS TIME ON
SET STATISTICS IO ON;
SELECT * FROM users WHERE email = 'test@example.com';
SET STATISTICS IO OFF;

-- Query hints (use sparingly)
SELECT /*+ INDEX(orders idx_user_created) */ *
FROM orders
WHERE user_id = 1
AND created_date > '2024-01-01';
```

### 5. **Transactions & ACID Properties**

```sql
-- Basic transaction
BEGIN TRANSACTION;

UPDATE accounts SET balance = balance - 100 WHERE id = 1;
UPDATE accounts SET balance = balance + 100 WHERE id = 2;

-- Rollback if error
IF @@ERROR <> 0
    ROLLBACK TRANSACTION;
ELSE
    COMMIT TRANSACTION;

-- Savepoints
BEGIN TRANSACTION;

INSERT INTO logs VALUES ('Step 1');
SAVE TRANSACTION after_step1;

DELETE FROM logs WHERE id > 100;
-- Rollback only to savepoint
ROLLBACK TRANSACTION after_step1;

COMMIT TRANSACTION;

-- Transaction isolation levels
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
-- Serializable - highest isolation, lowest concurrency
COMMIT;

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
-- Dirty reads possible but faster
```

### 6. **Advanced JOINs & Correlated Subqueries**

```sql
-- CROSS JOIN for Cartesian product
SELECT u.name, p.product_name
FROM users u
CROSS JOIN products p;

-- Self-join
SELECT e1.name, e2.name as manager
FROM employees e1
INNER JOIN employees e2 ON e1.manager_id = e2.id;

-- Multiple JOIN conditions
SELECT *
FROM orders o
INNER JOIN order_items oi ON o.id = oi.order_id AND oi.quantity > 0
INNER JOIN products p ON oi.product_id = p.id;

-- Correlated subquery
SELECT name,
    (SELECT COUNT(*) FROM orders WHERE user_id = users.id) as order_count
FROM users;

-- EXISTS for better performance
SELECT * FROM users u
WHERE EXISTS (
    SELECT 1 FROM orders o
    WHERE o.user_id = u.id
);
```

### 7. **JSON Features (SQL Server)**

```sql
-- JSON path expressions
SELECT 
    JSON_VALUE(data, '$.name') as name,
    JSON_VALUE(data, '$.email') as email
FROM users
WHERE JSON_VALUE(data, '$.status') = 'active';

-- Extract JSONarray
SELECT 
    id,
    JSON_QUERY(data, '$.addresses') as addresses
FROM users;

-- Convert to JSON
SELECT * FROM employees
FOR JSON PATH;

-- Modify JSON
UPDATE users
SET data = JSON_MODIFY(data, '$.status', 'inactive')
WHERE id = 1;
```

### 8. **Performance Monitoring & Tuning**

```sql
-- Find slow queries
SELECT TOP 10
    qs.creation_time,
    qs.execution_count,
    CAST(qs.total_elapsed_time / 1000000 AS FLOAT) / qs.execution_count AS avg_elapsed_time_ms,
    st.text
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
ORDER BY qs.total_elapsed_time DESC;

-- Index fragmentation
SELECT 
    OBJECT_NAME(ips.object_id) as table_name,
    i.name as index_name,
    ips.avg_fragmentation_in_percent
FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'LIMITED') ips
INNER JOIN sys.indexes i ON ips.object_id = i.object_id
    AND ips.index_id = i.index_id
WHERE ips.avg_fragmentation_in_percent > 10;

-- Rebuild fragmented indexes
ALTER INDEX idx_email ON users REBUILD;
ALTER INDEX idx_email ON users REORGANIZE;
```

---

## 💻 Hands-On Exercises

### Exercise 1: Window Functions
**Task:** Write queries using RANK, LAG/LEAD, and running totals

### Exercise 2: CTEs
**Task:** Build complex queries with CTEs and recursion

### Exercise 3: Execution Plans
**Task:** Analyze and optimize slow queries

### Exercise 4: Transactions
**Task:** Implement ACID compliance in multi-step operations

### Exercise 5: JSON
**Task:** Work with JSON data in SQL Server

---

## 📝 Assignments

1. **Sales Analysis Dashboard Queries**
   - Revenue trends using window functions
   - Year-over-year comparison
   - Top products by category

2. **Data Migration Script**
   - Use transactions for data consistency
   - Handle concurrency issues
   - Implement rollback mechanisms

3. **Performance Optimization Project**
   - Profile slow queries
   - Identify missing indexes
   - Rewrite queries for better performance

---

## 🔗 References

### Official Documentation:
- [SQL Server Documentation](https://docs.microsoft.com/sql/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [MySQL Documentation](https://dev.mysql.com/doc/)

### Tutorials:
- [SQL Performance Tuning](https://www.sqlshack.com/)
- [Mode Analytics SQL Tutorial](https://mode.com/sql-tutorial/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] CTEs & Window Functions
- [ ] Advanced Aggregation
- [ ] Indexing & Optimization
- [ ] Transactions
- [ ] Performance Tuning

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

**Queries Optimized:** ______

---

**Last Updated:** June 2026
**Completion Status:** Not Started
