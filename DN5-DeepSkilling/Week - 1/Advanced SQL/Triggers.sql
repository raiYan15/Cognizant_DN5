-- Advanced SQL Triggers Hands-On Solutions
IF OBJECT_ID('dbo.trg_AfterSalaryUpdate', 'TR') IS NOT NULL DROP TRIGGER dbo.trg_AfterSalaryUpdate;
IF OBJECT_ID('dbo.trg_PreventEmployeeDelete', 'TR') IS NOT NULL DROP TRIGGER dbo.trg_PreventEmployeeDelete;
IF OBJECT_ID('dbo.trg_UpdateAnnualSalary', 'TR') IS NOT NULL DROP TRIGGER dbo.trg_UpdateAnnualSalary;
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
IF OBJECT_ID('dbo.EmployeeChanges', 'U') IS NOT NULL DROP TABLE dbo.EmployeeChanges;
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
    JoinDate DATE,
    AnnualSalary DECIMAL(12,2) NULL
);

CREATE TABLE EmployeeChanges (
    ChangeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');
GO

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate, AnnualSalary) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15', 5000.00 * 12),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22', 6000.00 * 12),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01', 5500.00 * 12);
GO

CREATE TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary)
        SELECT d.EmployeeID, d.Salary, i.Salary
        FROM deleted d
        JOIN inserted i ON d.EmployeeID = i.EmployeeID;
    END;
END;
GO

CREATE TRIGGER trg_PreventEmployeeDelete
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('Employee deletions are not allowed.', 16, 1);
    ROLLBACK TRANSACTION;
END;
GO

CREATE TRIGGER trg_UpdateAnnualSalary
ON Employees
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE e
    SET e.AnnualSalary = i.Salary * 12
    FROM Employees e
    JOIN inserted i ON e.EmployeeID = i.EmployeeID;
END;
GO

-- Example trigger modification using ALTER
ALTER TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary)
        SELECT d.EmployeeID, d.Salary, i.Salary
        FROM deleted d
        JOIN inserted i ON d.EmployeeID = i.EmployeeID;
    END;
END;
GO

-- Example trigger deletion
DROP TRIGGER IF EXISTS trg_PreventEmployeeDelete;
GO

-- Sample update to verify the AFTER trigger and AnnualSalary trigger
UPDATE Employees
SET Salary = 5200.00
WHERE EmployeeID = 1;
GO

SELECT * FROM EmployeeChanges;
GO
SELECT EmployeeID, Salary, AnnualSalary FROM Employees;
GO
