
																																																																																																																																

ALTER TABLE EmployeeComputers DROP CONSTRAINT [FK_Employees];
ALTER TABLE EmployeeComputers DROP CONSTRAINT [FK_Computers];

ALTER TABLE EmployeeTrainingPrograms DROP CONSTRAINT [FK_EmployeeTraining];
ALTER TABLE EmployeeTrainingPrograms DROP CONSTRAINT [FK_TrainingPrograms];

ALTER TABLE Employees DROP CONSTRAINT [FK_Departments];

ALTER TABLE PaymentTypes DROP CONSTRAINT [FK_Customers];
ALTER TABLE Orders DROP CONSTRAINT [FK_CustomerOrders];
ALTER TABLE Orders DROP CONSTRAINT [FK_PaymentTypeOrders];

ALTER TABLE Products DROP CONSTRAINT [FK_CustomerProducts];
ALTER TABLE Products DROP CONSTRAINT [FK_ProductTypeProducts];

ALTER TABLE ProductOrders DROP CONSTRAINT [FK_ProductOrders];
ALTER TABLE ProductOrders DROP CONSTRAINT [FK_OrdersProducts];

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
    Malfunctioned BIT NOT NULL,
	IsDeleted BIT NOT NULL
);

INSERT INTO Computers
(DatePurchased, DecommissionedDate, Malfunctioned, IsDeleted)
VALUES
('2005-7-7', '2004-6-6', 0, 1);

INSERT INTO Computers
(DatePurchased, DecommissionedDate, Malfunctioned, IsDeleted)
VALUES
('2008-7-7', '2009-6-6', 1, 1);

INSERT INTO Computers
(DatePurchased, DecommissionedDate, Malfunctioned, IsDeleted)
VALUES
('2010-8-7', '2010-8-6', 0, 1);

CREATE TABLE Departments (
    Id  INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name varchar(80) NOT NULL,
    Budget varchar(80) NOT NULL,
	IsDeleted BIT NOT NULL

);

INSERT INTO Departments
(Name, Budget, IsDeleted)
VALUES
('Accounting', '12,000', 1);

INSERT INTO Departments
(Name, Budget, IsDeleted)
VALUES
('Sales', '50,000', 1);

INSERT INTO Departments
(Name, Budget, IsDeleted)
VALUES
('IT', '70,000', 1);

CREATE TABLE Employees (
    Id    INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName    varchar(80) NOT NULL,
    LastName    varchar(80) NOT NULL,
    Supervisor BIT NOT NULL,
	DepartmentsId INTEGER NOT NULL,
	CONSTRAINT FK_Departments FOREIGN KEY(DepartmentsId) REFERENCES Departments(Id),
	IsDeleted BIT NOT NULL

);

INSERT INTO Employees
(FirstName, LastName, Supervisor, DepartmentsId, IsDeleted)
VALUES
('Jose', 'Ramirez', 1, 1, 1);

INSERT INTO Employees
(FirstName, LastName, Supervisor, DepartmentsId, IsDeleted)
VALUES
('Pablo', 'Lopez', 0, 1, 1);

INSERT INTO Employees
(FirstName, LastName, Supervisor, DepartmentsId, IsDeleted)
VALUES
('Jesus', 'Sanchez', 1, 3, 1);

CREATE TABLE TrainingPrograms (
    Id  INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ProgramName  varchar(80) NOT NULL,
    MaxAttendees INTEGER NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
	IsDeleted BIT NOT NULL

);

INSERT INTO TrainingPrograms
(ProgramName, MaxAttendees, StartDate, EndDate, IsDeleted)
VALUES
('Anger Management', 25, '2017-2-12', '2017-2-17', 1);

INSERT INTO TrainingPrograms
(ProgramName, MaxAttendees, StartDate, EndDate, IsDeleted)
VALUES
('Boat Training', 20, '2017-4-12', '2017-4-19', 1);

INSERT INTO TrainingPrograms
(ProgramName, MaxAttendees, StartDate, EndDate, IsDeleted)
VALUES
('Bar Tending', 20, '2018-4-12', '2018-4-19', 1);

CREATE TABLE EmployeeComputers (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    EmployeesId INTEGER NOT NULL,
    ComputersId INTEGER NOT NULL,
    AssignStartDate DATE NOT NULL,
    AssignEndDate DATE,
    CONSTRAINT FK_Employees FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
    CONSTRAINT FK_Computers FOREIGN KEY(ComputersId) REFERENCES Computers(Id),

);

INSERT INTO EmployeeComputers
(EmployeesId, ComputersId, AssignStartDate, AssignEndDate)
VALUES
(1, 1, '2017-6-12', '2018-4-19');

INSERT INTO EmployeeComputers
(EmployeesId, ComputersId, AssignStartDate, AssignEndDate)
VALUES
(2, 3, '2016-6-12', '2018-3-3');

INSERT INTO EmployeeComputers
(EmployeesId, ComputersId, AssignStartDate, AssignEndDate)
VALUES
(3, 2, '2018-6-17', null);

CREATE TABLE EmployeeTrainingPrograms (
	 Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	 EmployeesId INTEGER NOT NULL,
	 TrainingProgramsId INTEGER NOT NULL,
     CONSTRAINT FK_EmployeeTraining FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
     CONSTRAINT FK_TrainingPrograms FOREIGN KEY(TrainingProgramsId) REFERENCES TrainingPrograms(Id),
	 

);

INSERT INTO EmployeeTrainingPrograms
(EmployeesId, TrainingProgramsId)
VALUES
(1, 1);

INSERT INTO EmployeeTrainingPrograms
(EmployeesId, TrainingProgramsId)
VALUES
(2, 1);

INSERT INTO EmployeeTrainingPrograms
(EmployeesId, TrainingProgramsId)
VALUES
(3, 1);

CREATE TABLE Customers (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName    varchar(80) NOT NULL,
    LastName    varchar(80) NOT NULL,
    DateCreated DATE NOT NULL,
    LastActivity DATE NOT NULL,
	IsDeleted BIT NOT NULL
);

INSERT INTO Customers
(FirstName, LastName, DateCreated, LastActivity, IsDeleted)
VALUES
('Scuba', 'Steve', '2017-4-12', '2018-4-19', 1);

INSERT INTO Customers
(FirstName, LastName, DateCreated, LastActivity, IsDeleted)
VALUES
('Sassy', 'Sally', '2015-4-12', '2017-8-10', 1);

INSERT INTO Customers
(FirstName, LastName, DateCreated, LastActivity, IsDeleted)
VALUES
('Pretty', 'Pete', '2012-4-12', '2018-2-10', 1);

CREATE TABLE PaymentTypes (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name varchar(80) NOT NULL,
    AccountNumber INTEGER NOT NULL,
	CustomersId INTEGER NOT NULL,
    CONSTRAINT FK_Customers FOREIGN KEY(CustomersId) REFERENCES Customers(Id),
	IsDeleted BIT NOT NULL

);

INSERT INTO PaymentTypes
(Name, AccountNumber, CustomersId, IsDeleted)
VALUES
('Visa', 3324, 2, 1);

INSERT INTO PaymentTypes
(Name, AccountNumber, CustomersId, IsDeleted)
VALUES
('MasterCard', 3327, 1, 1);

INSERT INTO PaymentTypes
(Name, AccountNumber, CustomersId, IsDeleted)
VALUES
('PayPal', 3301, 3, 1);

CREATE TABLE Orders (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	OrderCompleted BIT NOT NULL,
	CustomersId INTEGER NOT NULL,
	PaymentTypesId INTEGER,
     CONSTRAINT FK_CustomerOrders FOREIGN KEY(CustomersId) REFERENCES Customers(Id),
     CONSTRAINT FK_PaymentTypeOrders FOREIGN KEY(PaymentTypesId) REFERENCES PaymentTypes(Id),

);

INSERT INTO Orders
(OrderCompleted, CustomersId, PaymentTypesId)
VALUES
(1, 1, 3);

INSERT INTO Orders
(OrderCompleted, CustomersId, PaymentTypesId)
VALUES
(1, 2, 2);

INSERT INTO Orders
(OrderCompleted, CustomersId, PaymentTypesId)
VALUES
(1, 3, 1);

CREATE TABLE ProductTypes (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    Name  varchar(80) NOT NULL,
    IsDeleted BIT NOT NULL

);

INSERT INTO ProductTypes
(Name, IsDeleted)
VALUES
('Beauty', 1);

INSERT INTO ProductTypes
(Name, IsDeleted)
VALUES
('Home', 1);

INSERT INTO ProductTypes
(Name, IsDeleted)
VALUES
('Auto', 1);

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
	IsDeleted BIT NOT NULL

);

INSERT INTO Products
(Price, Title, Description, Quantity, CustomersId, ProductTypesId, IsDeleted)
VALUES
(7, 'Goat Milk Soap', 'Smells like lavender', 45, 1, 1, 1);

INSERT INTO Products
(Price, Title, Description, Quantity, CustomersId, ProductTypesId, IsDeleted)
VALUES
(12, 'Driver Seat Cover', 'Super fluffy seat cover', 15, 2, 3, 1);

INSERT INTO Products
(Price, Title, Description, Quantity, CustomersId, ProductTypesId, IsDeleted)
VALUES
(50, 'Night Stand', 'One Night Stand', 15, 2, 2, 1);

CREATE TABLE ProductOrders (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	ProductsId INTEGER NOT NULL,
	OrdersId INTEGER NOT NULL,
     CONSTRAINT FK_ProductOrders FOREIGN KEY(ProductsId) REFERENCES Products(Id),
     CONSTRAINT FK_OrdersProducts FOREIGN KEY(OrdersId) REFERENCES Orders(Id)
	 
);
INSERT INTO ProductOrders
(ProductsId, OrdersId)
VALUES
(2, 2);

INSERT INTO ProductOrders
(ProductsId, OrdersId)
VALUES
(3, 1);

INSERT INTO ProductOrders
(ProductsId, OrdersId)
VALUES
(1, 2);

SELECT * FROM Orders;