CREATE DATABASE OfficeManagementDB;
GO

USE OfficeManagementDB;
GO

CREATE TABLE Workers
(
    WorkerID INT PRIMARY KEY,
    WorkerName VARCHAR(50),
    SectionName VARCHAR(50),
    SalaryAmount DECIMAL(10,2)
);
GO

INSERT INTO Workers VALUES
(301,'Varun','Accounts',62000),
(302,'Keerthi','Sales',57000),
(303,'Manoj','Accounts',76000),
(304,'Pooja','Marketing',69000),
(305,'Harish','Sales',61000);
GO

CREATE PROCEDURE GetWorkersBySection
    @SectionName VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Workers
    WHERE SectionName=@SectionName;
END;
GO

EXEC GetWorkersBySection @SectionName='Accounts';
GO

SELECT * FROM Workers;
GO