-- Advanced SQL Views Hands-On Solutions
IF OBJECT_ID('dbo.vw_EmployeeReport', 'V') IS NOT NULL DROP VIEW dbo.vw_EmployeeReport;
IF OBJECT_ID('dbo.vw_EmployeeAnnualSalary', 'V') IS NOT NULL DROP VIEW dbo.vw_EmployeeAnnualSalary;
IF OBJECT_ID('dbo.vw_EmployeeFullName', 'V') IS NOT NULL DROP VIEW dbo.vw_EmployeeFullName;
IF OBJECT_ID('dbo.vw_EmployeeBasicInfo', 'V') IS NOT NULL DROP VIEW dbo.vw_EmployeeBasicInfo;
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

CREATE VIEW vw_EmployeeBasicInfo AS
SELECT
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

CREATE VIEW vw_EmployeeFullName AS
SELECT
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    e.FirstName + ' ' + e.LastName AS FullName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

CREATE VIEW vw_EmployeeAnnualSalary AS
SELECT
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    e.Salary,
    e.Salary * 12 AS AnnualSalary
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

CREATE VIEW vw_EmployeeReport AS
SELECT
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS FullName,
    d.DepartmentName,
    e.Salary * 12 AS AnnualSalary,
    (e.Salary * 12) * 0.10 AS Bonus
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID;
GO

SELECT * FROM vw_EmployeeBasicInfo;
GO
SELECT * FROM vw_EmployeeFullName;
GO
SELECT * FROM vw_EmployeeAnnualSalary;
GO
SELECT * FROM vw_EmployeeReport;
GO
