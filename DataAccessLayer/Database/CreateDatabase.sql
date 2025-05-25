-- CREATE DATABASE LawnmowerDatabase;


-- Reset database
IF EXISTS(SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('Lawnmower'))
BEGIN
    ALTER TABLE Lawnmower DROP CONSTRAINT lawnmowerBrand;
END
IF EXISTS(SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('Order'))
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT orderProduct;
END


DROP TABLE IF EXISTS Brand;
DROP TABLE IF EXISTS Lawnmower;
DROP TABLE IF EXISTS [Order];

-- Create tables
CREATE TABLE Brand (
  Id          int IDENTITY NOT NULL, 
  Name        varchar(20) NOT NULL, 
  Description varchar(255) NOT NULL, 
  PRIMARY KEY (Id));

CREATE TABLE Lawnmower (
  Id              int IDENTITY NOT NULL, 
  Name            varchar(50) NOT NULL UNIQUE, 
  Description     varchar(255) NOT NULL, 
  Price           decimal(8, 2) NOT NULL, 
  QuantityInStock int NOT NULL, 
  Photo           image NULL, 
  FuelDetails     varchar(100) NOT NULL, 
  LastUpdated     date NOT NULL, 
  Type			  varchar(50) NOT NULL,
  TopSpeed        int NULL, 
  Weight          int NULL, 
  BrandId         int NOT NULL, 
  PRIMARY KEY (Id));

CREATE TABLE [Order] (
  Id            int IDENTITY NOT NULL, 
  Quantity      int NOT NULL, 
  TimeCreated   datetime NOT NULL DEFAULT GETDATE(), 
  ItemPrice     decimal(8, 2) NOT NULL, 
  CustomerName  varchar(50) NOT NULL, 
  CustomerEmail varchar(50) NOT NULL, 
  CustomerPhone varchar(20) NOT NULL, 
  ProductId     int NOT NULL, 
  Completed		bit NOT NULL DEFAULT 0,
  PRIMARY KEY (Id));

ALTER TABLE Lawnmower ADD CONSTRAINT lawnmowerBrand FOREIGN KEY (BrandId) REFERENCES Brand (Id);
ALTER TABLE [Order] ADD CONSTRAINT orderProduct FOREIGN KEY (ProductId) REFERENCES Lawnmower (Id) ON DELETE CASCADE;
-- Cascade delete not ideal but added to simply this POC


-- Add data
INSERT INTO Brand (Name, Description)
VALUES ('Tooler', 'High quality tools for professionals.'),
	('MowGo', 'Tools for the everyday person.');

INSERT INTO Lawnmower (Name, Price, QuantityInStock, Photo, FuelDetails, LastUpdated, Type, TopSpeed, Weight, BrandId, Description)
VALUES 
	('Turf Terrorisor X', 5999.99, 4, null, 'Petrol, 20 litre tank', GETDATE(), 'RideOn', 15.5, null, 1,
		'Tooler’s Turf Terroriser X is a powerhouse ride-on lawnmower built for domination overgrown lawns, taming them into manicured masterpieces with speed and precision.'),
	('Lawn Pro 2022', 449.99, 10, null, 'Electric, 60V 4Ah battery', GETDATE(), 'Push', null, 32.4, 1,
		'Tooler’s Lawn Pro 2022 is a budget friendly lawnmower for homeowners or professionals alike. With five different blade high settings, you can get your lawn trimmed to any length you desire.'),
	('Grass Guzzler 9000', 1999.99, 8, null, 'Petrol, 10 litre tank', GETDATE(), 'Push', null, 165.5, 2,
		'MowGo presents a reenvisioned version of their award-winning homeowner’s lawnmower. The all-new Grass Guzzler 9000 will help you get your lawns tidy in no time.'),
	('Xtreme', 3999.99, 7, null, 'Petrol, 20 litre tank', GETDATE(), 'RideOn', 10, null, 2,
		'MowGo''s Xtreme is the only ride-on lawnmower you''ll need. Taming any wild lawn will bcome an easy task.');

INSERT INTO [Order] (Quantity, ProductId, TimeCreated, ItemPrice, CustomerName, CustomerEmail, CustomerPhone, Completed)
VALUES (3, 1, GETDATE(), 5999.99, 'John Doe', 'john.doe@email.com', '1234567890', 1),
	(1, 2, GETDATE(), 449.99, 'John Smith', 'john.smith@email.com', '1234567890', 1),
	(1, 4, GETDATE(), 3999.99, 'Jane Doe', 'jane.doe@email.com', '1234567890', 0),
	(5, 2, GETDATE(), 499.99, 'John Doe', 'jane.doe@email.com', '1234567890', 0);