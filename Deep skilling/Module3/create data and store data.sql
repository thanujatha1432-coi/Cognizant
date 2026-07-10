CREATE DATABASE CompanyRecordsDB;
GO

USE CompanyRecordsDB;
GO

CREATE TABLE Staff
(
    StaffID INT PRIMARY KEY,
    StaffName VARCHAR(50),
    Team VARCHAR(50),
    MonthlySalary DECIMAL(10,2)
);
GO

INSERT INTO Staff VALUES
(201,'Akash','Development',72000),
(202,'Neha','Testing',54000),
(203,'Rohit','Support',48000),
(204,'Divya','Development',81000),
(205,'Anjali','HR',60000);
GO

CREATE PROCEDURE DisplayAllStaff
AS
BEGIN
    SELECT * FROM Staff;
END;
GO

EXEC DisplayAllStaff;
GO