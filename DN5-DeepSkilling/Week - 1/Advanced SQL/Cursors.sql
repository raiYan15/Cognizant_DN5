-- Advanced SQL Cursor Hands-On Solutions
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE dbo.Employees;
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Salary DECIMAL(10,2)
);
GO

INSERT INTO Employees (EmployeeID, FirstName, LastName, Salary) VALUES
(1, 'John', 'Doe', 5000.00),
(2, 'Jane', 'Smith', 6000.00),
(3, 'Bob', 'Johnson', 5500.00);
GO

-- Exercise 1: Create a Cursor
DECLARE emp_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, Salary
FROM Employees;

OPEN emp_cursor;

DECLARE @EmployeeID INT, @FirstName VARCHAR(50), @LastName VARCHAR(50), @Salary DECIMAL(10,2);
FETCH NEXT FROM emp_cursor INTO @EmployeeID, @FirstName, @LastName, @Salary;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CONCAT('Employee ', @EmployeeID, ': ', @FirstName, ' ', @LastName, ' - Salary: ', @Salary);
    FETCH NEXT FROM emp_cursor INTO @EmployeeID, @FirstName, @LastName, @Salary;
END;

CLOSE emp_cursor;
DEALLOCATE emp_cursor;
GO

-- Exercise 2: Types of Cursors
DECLARE static_cursor CURSOR STATIC FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

DECLARE dynamic_cursor CURSOR DYNAMIC FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

DECLARE forward_cursor CURSOR FORWARD_ONLY FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;

DECLARE keyset_cursor CURSOR KEYSET FOR
SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;
GO

OPEN static_cursor;
PRINT 'Static cursor opened';
CLOSE static_cursor;
DEALLOCATE static_cursor;
GO

OPEN dynamic_cursor;
PRINT 'Dynamic cursor opened';
CLOSE dynamic_cursor;
DEALLOCATE dynamic_cursor;
GO

OPEN forward_cursor;
PRINT 'Forward-only cursor opened';
CLOSE forward_cursor;
DEALLOCATE forward_cursor;
GO

OPEN keyset_cursor;
PRINT 'Keyset-driven cursor opened';
CLOSE keyset_cursor;
DEALLOCATE keyset_cursor;
GO
