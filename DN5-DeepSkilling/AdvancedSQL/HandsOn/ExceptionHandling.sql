-- Advanced SQL Exception Handling Hands-On Solutions
IF OBJECT_ID('dbo.AuditLog', 'U') IS NOT NULL DROP TABLE dbo.AuditLog;
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Salary DECIMAL(10,2),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE AuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Action VARCHAR(100),
    ErrorMessage VARCHAR(4000),
    ActionDate DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');
GO

INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID) VALUES
(1, 'John', 'Doe', 'john.doe@example.com', 5000.00, 1),
(2, 'Jane', 'Smith', 'jane.smith@example.com', 6000.00, 2);
GO

CREATE PROCEDURE AddEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF @Salary <= 0
        BEGIN
            RAISERROR('Salary must be greater than zero.', 16, 1);
        END
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (@EmployeeID, @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());
        IF ERROR_SEVERITY() >= 16
        BEGIN
            THROW;
        END
    END CATCH
END;
GO

EXEC AddEmployee @EmployeeID = 3, @FirstName = 'Bob', @LastName = 'Johnson', @Email = 'bob.johnson@example.com', @Salary = 5500.00, @DepartmentID = 3;
GO

EXEC AddEmployee @EmployeeID = 4, @FirstName = 'Anne', @LastName = 'Taylor', @Email = 'anne.taylor@example.com', @Salary = -100.00, @DepartmentID = 2;
GO

CREATE PROCEDURE TransferEmployee
    @EmployeeID INT,
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @DepartmentID)
        BEGIN
            RAISERROR('Department does not exist.', 16, 1);
        END
        UPDATE Employees
        SET DepartmentID = @DepartmentID
        WHERE EmployeeID = @EmployeeID;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('TransferEmployee', ERROR_MESSAGE());
        IF XACT_STATE() <> 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        THROW;
    END CATCH
END;
GO

EXEC TransferEmployee @EmployeeID = 1, @DepartmentID = 4;
GO

CREATE PROCEDURE BatchInsertEmployees
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (5, 'Sara', 'Lee', 'sara.lee@example.com', 5200.00, 1);
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (6, 'Tom', 'White', 'tom.white@example.com', 4600.00, 2);
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (7, 'Jim', 'Green', 'jim.green@example.com', -50.00, 3);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('BatchInsertEmployees', ERROR_MESSAGE());
        IF XACT_STATE() <> 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
    END CATCH
END;
GO

EXEC BatchInsertEmployees;
GO

-- Add warning and error severity handling in AddEmployee
ALTER PROCEDURE AddEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF @Salary < 0
        BEGIN
            RAISERROR('Salary must be greater than zero.', 16, 1);
        END
        ELSE IF @Salary < 1000
        BEGIN
            RAISERROR('Salary is below recommended minimum.', 10, 1);
        END
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES (@EmployeeID, @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());
        IF ERROR_SEVERITY() >= 16
        BEGIN
            THROW;
        END
    END CATCH
END;
GO

EXEC AddEmployee @EmployeeID = 8, @FirstName = 'Grace', @LastName = 'Brown', @Email = 'grace.brown@example.com', @Salary = 900.00, @DepartmentID = 2;
GO
