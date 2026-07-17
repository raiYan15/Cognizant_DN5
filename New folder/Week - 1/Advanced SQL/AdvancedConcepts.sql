-- Advanced SQL Hands-On Solutions
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetails;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00),
(5, 'Monitor', 'Accessories', 250.00),
(6, 'Keyboard', 'Accessories', 90.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2025-01-15'),
(2, 1, '2025-01-18'),
(3, 1, '2025-01-25'),
(4, 1, '2025-02-01'),
(5, 2, '2025-02-10'),
(6, 3, '2025-03-05'),
(7, 4, '2025-01-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3),
(5, 5, 5, 2),
(6, 6, 6, 4),
(7, 7, 1, 1);
GO

-- Exercise 1: Ranking and Window Functions
SELECT
    Category,
    ProductName,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNumberRank,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankValue,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankValue
FROM Products;
GO

SELECT *
FROM (
    SELECT
        Category,
        ProductName,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNumberRank
    FROM Products
) AS RankedProducts
WHERE RowNumberRank <= 3;
GO

-- Exercise 2: Aggregation with GROUPING SETS, ROLLUP, and CUBE
SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold,
    SUM(od.Quantity * p.Price) AS TotalSales
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS ((c.Region, p.Category), (c.Region), (p.Category), ())
ORDER BY GROUPING(c.Region), c.Region, GROUPING(p.Category), p.Category;
GO

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category)
ORDER BY c.Region, p.Category;
GO

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category)
ORDER BY c.Region, p.Category;
GO

-- Exercise 3: CTEs and MERGE
WITH Calendar AS (
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    SELECT DATEADD(DAY, 1, CalendarDate)
    FROM Calendar
    WHERE CalendarDate < '2025-01-31'
)
SELECT *
FROM Calendar
OPTION (MAXRECURSION 0);
GO

IF OBJECT_ID('dbo.StagingProducts', 'U') IS NOT NULL DROP TABLE dbo.StagingProducts;
CREATE TABLE StagingProducts (
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
GO

INSERT INTO StagingProducts (ProductID, ProductName, Category, Price) VALUES
(2, 'Smartphone', 'Electronics', 750.00),
(3, 'Tablet', 'Electronics', 620.00),
(7, 'Speaker', 'Accessories', 180.00);
GO

MERGE INTO Products AS Target
USING StagingProducts AS Source
ON Target.ProductID = Source.ProductID
WHEN MATCHED THEN
    UPDATE SET Target.Price = Source.Price
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);
GO

SELECT * FROM Products ORDER BY ProductID;
GO

-- Exercise 4: PIVOT and UNPIVOT
SELECT
    p.ProductName,
    FORMAT(o.OrderDate, 'MMMM') AS OrderMonth,
    SUM(od.Quantity) AS QuantitySold
INTO #MonthlySales
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName, FORMAT(o.OrderDate, 'MMMM');
GO

SELECT * FROM #MonthlySales;
GO

SELECT ProductName, [January], [February], [March], [April]
FROM (
    SELECT ProductName, OrderMonth, QuantitySold
    FROM #MonthlySales
) AS SourceTable
PIVOT (
    SUM(QuantitySold)
    FOR OrderMonth IN ([January], [February], [March], [April])
) AS PivotTable;
GO

SELECT ProductName, MonthName, QuantitySold
FROM (
    SELECT ProductName, [January], [February], [March], [April]
    FROM (
        SELECT ProductName, OrderMonth, QuantitySold
        FROM #MonthlySales
    ) AS SourceTable
    PIVOT (
        SUM(QuantitySold)
        FOR OrderMonth IN ([January], [February], [March], [April])
    ) AS PivotTable
) AS p
UNPIVOT (
    QuantitySold FOR MonthName IN ([January], [February], [March], [April])
) AS Unpivoted;
GO

DROP TABLE #MonthlySales;
GO

-- Exercise 5: Using CTE to Simplify a Query
WITH CustomerOrderCounts AS (
    SELECT
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount
    FROM Orders o
    GROUP BY o.CustomerID
)
SELECT
    c.CustomerID,
    c.Name,
    coc.OrderCount
FROM CustomerOrderCounts coc
JOIN Customers c ON c.CustomerID = coc.CustomerID
WHERE coc.OrderCount > 3;
GO
