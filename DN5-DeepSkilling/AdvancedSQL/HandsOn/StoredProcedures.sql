-- Advanced SQL Stored Procedure Hands-On Solutions
IF OBJECT_ID('dbo.sp_GetEmployeesByDepartment', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetEmployeesByDepartment;
IF OBJECT_ID('dbo.sp_InsertEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_InsertEmployee;
IF OBJECT_ID('dbo.sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetEmployeeCountByDepartment;
IF OBJECT_ID('dbo.sp_GetTotalSalaryByDepartment', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetTotalSalaryByDepartment;
IF OBJECT_ID('dbo.sp_UpdateEmployeeSalary', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_UpdateEmployeeSalary;
IF OBJECT_ID('dbo.sp_GiveBonus', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GiveBonus;
IF OBJECT_ID('dbo.sp_UpdateEmployeeSalaryWithTransaction', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_UpdateEmployeeSalaryWithTransaction;
IF OBJECT_ID('dbo.sp_GetEmployeeDetailsByFilter', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetEmployeeDetailsByFilter;
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');
GO

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');
GO

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID;
END;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

EXEC sp_InsertEmployee @FirstName = 'Anne', @LastName = 'Williams', @DepartmentID = 2, @Salary = 5800.00, @JoinDate = '2022-04-01';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;
GO

ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID;
END;
GO

DROP PROCEDURE IF EXISTS sp_InsertEmployee;
GO

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        @DepartmentID AS DepartmentID,
        COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 2;
GO

CREATE PROCEDURE sp_GetTotalSalaryByDepartment
    @DepartmentID INT,
    @TotalSalary DECIMAL(18,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

DECLARE @Total DECIMAL(18,2);
EXEC sp_GetTotalSalaryByDepartment @DepartmentID = 2, @TotalSalary = @Total OUTPUT;
SELECT @Total AS TotalSalary;
GO

CREATE PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmployeeID;
END;
GO

EXEC sp_UpdateEmployeeSalary @EmployeeID = 1, @NewSalary = 5200.00;
SELECT * FROM Employees WHERE EmployeeID = 1;
GO

CREATE PROCEDURE sp_GiveBonus
    @DepartmentID INT,
    @BonusAmount DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employees
    SET Salary = Salary + @BonusAmount
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_GiveBonus @DepartmentID = 1, @BonusAmount = 500.00;
SELECT * FROM Employees WHERE DepartmentID = 1;
GO

CREATE PROCEDURE sp_UpdateEmployeeSalaryWithTransaction
    @EmployeeID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmployeeID;
    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRANSACTION;
        RETURN;
    END;
    COMMIT TRANSACTION;
END;
GO

EXEC sp_UpdateEmployeeSalaryWithTransaction @EmployeeID = 3, @NewSalary = 6000.00;
SELECT * FROM Employees WHERE EmployeeID = 3;
GO

CREATE PROCEDURE sp_GetEmployeeDetailsByFilter
    @FilterColumn SYSNAME,
    @FilterValue NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sql NVARCHAR(MAX) = N'
        SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
        FROM Employees
        WHERE ' + QUOTENAME(@FilterColumn) + ' = @Value';
    EXEC sp_executesql @sql, N'@Value NVARCHAR(100)', @Value = @FilterValue;
END;
GO

EXEC sp_GetEmployeeDetailsByFilter @FilterColumn = 'LastName', @FilterValue = 'Doe';
GO
