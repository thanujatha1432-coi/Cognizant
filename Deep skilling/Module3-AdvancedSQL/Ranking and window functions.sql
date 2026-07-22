CREATE DATABASE ShoppingCenterDB;
GO

USE ShoppingCenterDB;
GO

CREATE TABLE Items
(
    ItemID INT PRIMARY KEY,
    ItemName VARCHAR(50),
    ItemCategory VARCHAR(50),
    Cost DECIMAL(10,2)
);
GO

INSERT INTO Items VALUES
(1,'Gaming Laptop','Electronics',95000),
(2,'Wireless Mouse','Electronics',2500),
(3,'Office Chair','Furniture',12000),
(4,'Study Table','Furniture',9500),
(5,'Bluetooth Speaker','Electronics',6000),
(6,'Bookshelf','Furniture',14000),
(7,'Smart Watch','Electronics',22000),
(8,'Dining Table','Furniture',30000),
(9,'Headphones','Electronics',4500),
(10,'Wardrobe','Furniture',45000);
GO

SELECT
ItemCategory,
ItemName,
Cost,

ROW_NUMBER() OVER
(
PARTITION BY ItemCategory
ORDER BY Cost DESC
) AS RowNumber,

RANK() OVER
(
PARTITION BY ItemCategory
ORDER BY Cost DESC
) AS RankNumber,

DENSE_RANK() OVER
(
PARTITION BY ItemCategory
ORDER BY Cost DESC
) AS DenseRank

FROM Items;
GO