-- Create the database
CREATE DATABASE SalesForecastingDb;
GO

-- Use the new database
USE SalesForecastingDb;
GO

-- Create SalesEntries table
CREATE TABLE SalesEntries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Date DATE NOT NULL,
    SalesAmount FLOAT NOT NULL
);


INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-01-01', 1200);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-02-01', 1350);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-03-01', 1600);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-04-01', 1700);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-05-01', 1500);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-06-01', 1800);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-07-01', 1750);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-08-01', 1900);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-09-01', 2000);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-10-01', 2100);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-11-01', 2200);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2023-12-01', 2300);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-01-01', 2250);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-02-01', 2400);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-03-01', 2450);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-04-01', 2500);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-05-01', 2600);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-06-01', 2700);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-07-01', 2800);
INSERT INTO SalesEntries (Date, SalesAmount) VALUES ('2024-08-01', 2900);

select *from SalesEntries