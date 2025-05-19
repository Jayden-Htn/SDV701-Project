DROP DATABASE IF EXISTS LawnmowerDatabase;

CREATE DATABASE LawnmowerDatabase;
USE LawnmowerDatabase;


CREATE TABLE Lawnmower (
  Id              int IDENTITY NOT NULL, 
  Name            varchar(50) NOT NULL UNIQUE, 
  Description     varchar(255) NOT NULL, 
  Price           decimal(8, 2) NOT NULL, 
  QuantityInStock int NOT NULL, 
  Photo           image NULL, 
  FuelDetails     varchar(100) NOT NULL, 
  LastUpdated     date NOT NULL, 
  Type            varchar(10) NOT NULL, 
  TopSpeed        int NULL, 
  Weight          int NULL, 
  BrandId         int NOT NULL, 
  PRIMARY KEY (Id));

CREATE TABLE Brand (
  Id          int IDENTITY NOT NULL, 
  Name        varchar(20) NOT NULL, 
  Description varchar(255) NOT NULL, 
  PRIMARY KEY (Id));

CREATE TABLE [Order] (
  Id            int IDENTITY NOT NULL, 
  Quantity      int NOT NULL, 
  TimeCreated   int NOT NULL, 
  ItemPrice     decimal(8, 2) NOT NULL, 
  CustomerName  varchar(50) NOT NULL, 
  CustomerEmail varchar(50) NOT NULL, 
  CustomerPhone varchar(20) NOT NULL, 
  ProductId     int NOT NULL, 
  Completed		bit NOT NULL DEFAULT 0,
  PRIMARY KEY (Id));

ALTER TABLE Lawnmower ADD CONSTRAINT brand FOREIGN KEY (BrandId) REFERENCES Brand (Id);
ALTER TABLE [Order] ADD CONSTRAINT product FOREIGN KEY (ProductId) REFERENCES Lawnmower (Id);


INSERT INTO Brand (Name, Description)
VALUES ('Tooler', 'High quality tools for professionals.'),
	('MowGo', 'Tools for the everyday person.');

INSERT INTO Lawnmower (Name, Price, QuantityInStock, Photo, FuelDetails, LastUpdated, TopSpeed, Weight, BrandId, Description)
VALUES 
	('Turf Terrorisor X', 5999.99, 4, null, 'Petrol, 20 litre tank', DateTime.Now(), 15.5, null, 1,
		'Tooler’s Turf Terroriser X is a powerhouse ride-on lawnmower built for domination overgrown lawns, taming them into manicured masterpieces with speed and precision.'),
	('Lawn Pro 2022', 449.99, 10, null, 'Electric, 60V 4Ah battery', DateTime.Now(), null, 32.4, 1,
		'Tooler’s Lawn Pro 2022 is a budget friendly lawnmower for homeowners or professionals alike. With five different blade high settings, you can get your lawn trimmed to any length you desire.'),
	('Grass Guzzler 9000', 1999.99, 8, null, 'Petrol, 10 litre tank', DateTime.Now(), null, 165.5, 2,
		'MowGo presents a reenvisioned version of their award-winning homeowner’s lawnmower. The all-new Grass Guzzler 9000 will help you get your lawns tidy in no time.'),
	('Xtreme', 3999.99, 7, null, 'Petrol, 20 litre tank', DateTime.Now(), 10, null, 2,
		'MowGo''s Xtreme is the only ride-on lawnmower you''ll need. Taming any wild lawn will bcome an easy task.');

INSERT INTO [Order] (Quantity, ProductId, TimeCreated, ItemPrice, CustomerName, CustomerEmail, CustomerPhone)
VALUES (3, 1, DateTime.Now(), 5999.99, 'John Doe', 'john.doe@email.com', '1234567890'),
	(1, 2, DateTime.Now(), 449.99, 'John Smith', 'john.smith@email.com', '1234567890'),
	(1, 4, DateTime.Now(), 3999.99, 'Jane Doe', 'jane.doe@email.com', '1234567890'),
	(5, 2, DateTime.Now(), 499.99, 'John Doe', 'jane.doe@email.com', '1234567890');