DROP TABLE Category 
DROP TABLE Product
DROP TABLE Shipping
DROP TABLE Segment
DROP TABLE Region
DROP TABLE Customer
DROP TABLE [Order]


CREATE TABLE Category (
    CatID int,
    CatName NVARCHAR(100)
    PRIMARY KEY (CatID)
)

CREATE TABLE Product (
    ProdID NVARCHAR(100),
    CatID int,
    [Description] NVARCHAR(500),
    UnitPrice int 
    PRIMARY KEY (ProdID),
    FOREIGN KEY (CatID) REFERENCES Category
)

CREATE TABLE  Shipping (
    ShipMode NVARCHAR(100),
    PRIMARY KEY (ShipMode)
)

CREATE TABLE Segment (
    SegID int,
    SegName NVARCHAR(100),
    PRIMARY KEY (SegID)

)

CREATE TABLE Region (
    Region NVARCHAR(100),
    PRIMARY KEY (Region)
)

CREATE TABLE Customer (
    CustID NVARCHAR(100),
    FullName NVARCHAR(100),
    SegID int,
    Country NVARCHAR(100),
    City NVARCHAR(100),
    [State] NVARCHAR(100),
    PostCode int,
    Region NVARCHAR(100),
    PRIMARY KEY (CustID),
    FOREIGN KEY (SegID) REFERENCES Segment,
    FOREIGN KEY (Region) REFERENCES Region 

)

CREATE TABLE [Order] (
    OrderDate NVARCHAR(100),
    CustID NVARCHAR(100),
    ShipMode NVARCHAR(100),
    ProdID NVARCHAR(100),
    Quantity int,
    ShipDate NVARCHAR(100),
    PRIMARY KEY (OrderDate, CustID, ProdID),
    FOREIGN KEY (CustID) REFERENCES Customer,
    FOREIGN KEY (ShipMode) REFERENCES Shipping, 
    FOREIGN KEY (ProdID) REFERENCES Product
) 
