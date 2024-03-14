CREATE DATABASE ObchodDB;
GO

USE ObchodDB;
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY,
    Jmeno NVARCHAR(100),
    Prijmeni NVARCHAR(100),
    Email NVARCHAR(255),
    RegistraceDatum DATETIME
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Nazev NVARCHAR(255),
    Cena FLOAT,
    Skladem BIT,
    VyrobniDatum DATETIME
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT,
    DatumObjednavky DATETIME,
    Stav NVARCHAR(100),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Mnozstvi INT,
    CenaZaKus FLOAT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY,
    Nazev NVARCHAR(255),
    Kontakt NVARCHAR(255),
    Hodnoceni INT
);

CREATE TABLE ProductSuppliers (
    ProductID INT,
    SupplierID INT,
    Cena FLOAT,
    PRIMARY KEY (ProductID, SupplierID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
