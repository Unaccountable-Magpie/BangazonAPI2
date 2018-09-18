DELETE FROM Computers;
DELETE FROM Employees;
DELETE FROM Departments;
DELETE FROM TrainingPrograms;
DELETE FROM EmployeeComputers;
DELETE FROM EmployeeTrainingPrograms;
DELETE FROM Customers;
DELETE FROM PaymentTypes;
DELETE FROM Orders;
DELETE FROM ProductTypes;
DELETE FROM Products;
DELETE FROM ProductOrders;


ALTER TABLE EmployeeComputers DROP CONSTRAINT [FK_Employees];
ALTER TABLE EmployeeComputers DROP CONSTRAINT [FK_Computers];

ALTER TABLE EmployeeTrainingPrograms DROP CONSTRAINT [FK_EmployeeTraining];
ALTER TABLE EmployeeTrainingPrograms DROP CONSTRAINT [FK_TrainingPrograms];

ALTER TABLE PaymentTypes DROP CONSTRAINT [FK_Customers];
ALTER TABLE Orders DROP CONSTRAINT [FK_CustomerOrders];
ALTER TABLE Orders DROP CONSTRAINT [FK_PaymentTypeOrders];

ALTER TABLE Products DROP CONSTRAINT [FK_CustomerProducts];
ALTER TABLE Products DROP CONSTRAINT [FK_ProductTypeProducts];

ALTER TABLE ProductOrders DROP CONSTRAINT [FK_ProductOrders];
ALTER TABLE ProductOrders DROP CONSTRAINT [FK_OrdersProducts];




DROP TABLE IF EXISTS Computers;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
DROP TABLE IF EXISTS TrainingPrograms;
DROP TABLE IF EXISTS EmployeeComputers;
DROP TABLE IF EXISTS EmployeeTrainingPrograms;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS PaymentTypes;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS ProductTypes;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS ProductOrders;




CREATE TABLE Computers (
    Id    INTEGER NOT NULL PRIMARY KEY IDENTITY,
    DatePurchased    DATE NOT NULL,
    DecommissionedDate    DATE NOT NULL,
    Malfunctioned BIT NOT NULL
);
CREATE TABLE Employees (
    Id    INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName    varchar(80) NOT NULL,
    LastName    varchar(80) NOT NULL,
    Supervisor BIT NOT NULL
);
CREATE TABLE Departments (
    Id  INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name varchar(80) NOT NULL,
    Budget varchar(80) NOT NULL
);
CREATE TABLE TrainingPrograms (
    Id  INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ProgramName  varchar(80) NOT NULL,
    MaxAttendees INTEGER NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);
CREATE TABLE EmployeeComputers (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    EmployeesId INTEGER NOT NULL,
    ComputersId INTEGER NOT NULL,
    AssignStartDate DATE NOT NULL,
    AssignEndDate DATE NOT NULL,
    CONSTRAINT FK_Employees FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
    CONSTRAINT FK_Computers FOREIGN KEY(ComputersId) REFERENCES Computers(Id)
);
CREATE TABLE EmployeeTrainingPrograms (
	 Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	 EmployeesId INTEGER NOT NULL,
	 TrainingProgramsId INTEGER NOT NULL,
     CONSTRAINT FK_EmployeeTraining FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
     CONSTRAINT FK_TrainingPrograms FOREIGN KEY(TrainingProgramsId) REFERENCES TrainingPrograms(Id)
);
CREATE TABLE Customers (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName    varchar(80) NOT NULL,
    LastName    varchar(80) NOT NULL,
    DateCreated DATE NOT NULL,
    LastActivity DATE NOT NULL,
);
CREATE TABLE PaymentTypes (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name varchar(80) NOT NULL,
    AccountNumber INTEGER NOT NULL,
	CustomersId INTEGER NOT NULL,
    CONSTRAINT FK_Customers FOREIGN KEY(CustomersId) REFERENCES Customers(Id),

);

CREATE TABLE Orders (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	CustomersId INTEGER NOT NULL,
	PaymentTypesId INTEGER NOT NULL,
     CONSTRAINT FK_CustomerOrders FOREIGN KEY(CustomersId) REFERENCES Customers(Id),
     CONSTRAINT FK_PaymentTypeOrders FOREIGN KEY(PaymentTypesId) REFERENCES PaymentTypes(Id)
);

CREATE TABLE ProductTypes (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name  varchar(80) NOT NULL,
);
CREATE TABLE Products (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Price INTEGER NOT NULL,
    Title varchar(80) NOT NULL,
    Description varchar(80) NOT NULL,
    Quantity INTEGER NOT NULL,
	CustomersId INTEGER NOT NULL,
	ProductTypesId INTEGER NOT NULL,
     CONSTRAINT FK_CustomerProducts FOREIGN KEY(CustomersId) REFERENCES Customers(Id),
    CONSTRAINT FK_ProductTypeProducts FOREIGN KEY(ProductTypesId) REFERENCES ProductTypes(Id),
);
CREATE TABLE ProductOrders (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	ProductsId INTEGER NOT NULL,
	OrdersId INTEGER NOT NULL,
     CONSTRAINT FK_ProductOrders FOREIGN KEY(ProductsId) REFERENCES Products(Id),
     CONSTRAINT FK_OrdersProducts FOREIGN KEY(OrdersId) REFERENCES Orders(Id),

);