--create container
CREATE DATABASE PROJECT
GO
-- Persons one-to-one Users
-- +Authors 
-- + Books -издательство

--drop database PROJECT
--DROP DATABASE PROJECT

--activate container
USE PROJECT
GO

-- create custom types 
CREATE TYPE t_name
FROM VARCHAR(45) NOT NULL
GO

CREATE TYPE t_int
FROM INT NOT NULL
GO

CREATE TYPE t_Adress
FROM VARCHAR(255) NOT NULL
GO

CREATE TYPE t_date
FROM DATE NOT NULL
GO

-- parent tables
CREATE TABLE UserStatus (
  Id t_int IDENTITY(1,1) PRIMARY KEY ,
  StatusName t_name UNIQUE)

CREATE TABLE Persons (
  Id t_int PRIMARY KEY,
  FirstName t_name,
  MiddleName VARCHAR(45),
  LastName VARCHAR(45),
  Adress VARCHAR(45),
  Telephone VARCHAR(18),
  BirthDate t_date)

CREATE TABLE Authors (
  Id t_int PRIMARY KEY,
  FirstName t_name,
  MiddleName VARCHAR(45),
  LastName VARCHAR(45),
  PenName VARCHAR(45),
  Telephone VARCHAR(18),
  BirthDate DATE)

CREATE TABLE Genre  (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  GenreName t_name UNIQUE)

CREATE TABLE Language (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  LanguageName t_name UNIQUE)

CREATE TABLE Currency (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  CurrencyName t_name UNIQUE)

CREATE TABLE Availability (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  AvailabilityName t_name UNIQUE)

CREATE TABLE OrderStatus (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  OrderstatusName t_name UNIQUE)

-- parent-children
CREATE TABLE Users (
  Id t_int IDENTITY(1,1) PRIMARY KEY,
  PersonId t_int FOREIGN KEY REFERENCES Persons(Id),
  UserstatusId t_int FOREIGN KEY REFERENCES UserStatus (Id),
  Email t_name UNIQUE,
  Parole t_name check (Parole>=8),
  RegistrationDate t_date,
  Username varchar(45))

CREATE TABLE Orders (
  Id int  IDENTITY(1,1) PRIMARY KEY,
  CartId t_int,
  Quantity t_int,
  ShippingAdr t_Adress,
  OrderDate datetime2 NOT NULL UNIQUE,
  OrderstatusId t_int FOREIGN KEY REFERENCES OrderStatus(Id),
  OrderPrice DECIMAL(8,2) CHECK (OrderPrice>0) NOT NULL)


CREATE TABLE Books (
  Id int IDENTITY(1,1) PRIMARY KEY,
  Isbn t_name UNIQUE,
  Title t_name,
  AuthorId t_int FOREIGN KEY REFERENCES Authors (Id),
  GenreId t_int FOREIGN KEY REFERENCES Genre  (Id),
  ReleaseDate t_date,
  LanguageId t_int FOREIGN KEY REFERENCES Language (Id),
  PageNumber t_int,
  Price DECIMAL (5,2) NOT NULL CHECK (Price > 0),
  CurrencyId t_int FOREIGN KEY REFERENCES Currency (Id),
  AvailabilityId t_int FOREIGN KEY REFERENCES Availability (Id))

-- children 
CREATE TABLE UsersOrders (
  UserId t_int FOREIGN KEY REFERENCES Users(Id),
  OrderId t_int FOREIGN KEY REFERENCES Orders(Id))

CREATE TABLE BooksOrders (
 BookId t_int FOREIGN KEY REFERENCES Books (Id),
 OrderId t_int FOREIGN KEY REFERENCES Orders (Id))


--insert
INSERT INTO UserStatus 
VALUES		( 'free'),
			( 'basic paid'),
			( 'premium paid'),
			( 'admin')

			select *  FROM UserStatus

INSERT INTO Persons (Id, Adress, Telephone, FirstName, MiddleName, LastName, BirthDate)
VALUES		
			(1, 'MDA, Ocniti','+37360054188', 'Alina', '','Gutul', '2004-06-10' ),
			(2, 'MDA, Chisinau, bd. Mircea cel Batrin 21/5', '+37369237701', 'Valeria', 'Alex', 'Stelmashemko','2004-12-01'),
			(3, 'MDA, Chisinau, str. Igor Vieru 5', '+37378229019','Alex', ' Alex', 'Iakob', '2003-12-12'),
			(4, 'MDA, Chisinau, str. Ion Domeniuc 12', '+37378000121', 'Daria', 'Valentin', 'Zaporojan', '2001-01-23')

INSERT INTO Authors(Id, FirstName, LastName)
VALUES		(1, 'Dante', 'Aligieri'),
			(2, 'Oscar', 'Wilde'),
			(3, 'Jane', 'Austen'),
			(4, 'Ray', 'Bradbury'),
			(5, 'John', 'Green'),
			(6, 'Rick', 'Riordan'),
			(7, 'Kerstin', 'Gier'),
			(8, 'Kiera', 'Cass'),
			(9, 'Lauren', 'Oliver')

INSERT INTO Authors(Id, FirstName,MiddleName, LastName)
VALUES		(10, 'Fransis', 'Scott', 'Fitzgerald'),
			(11, 'Jerome', 'David' , 'Salinger')
			
INSERT INTO Authors (Id, FirstName, LastName, BirthDate)
VALUES		(12, 'Joanne', 'Rowling', '1965-07-31')

INSERT INTO Genre  
VALUES		( 'Biograhy'),
			( 'Educational'),
			( 'Informational Techology'),
			( 'Detectives'),
			( 'Documentary'),
			( 'Dramaturgy'),
			( 'Romance')

INSERT INTO Language 
VALUES		('Russian'),
			('English'),
			('Romanian'),
			('Ukraine'),
			('French'),
			('Spanish'),
			('Chezsh') 

INSERT INTO Currency 
VALUES		( 'USD'),
			('RUB'),
			( 'MDL'),
			( 'EUR'),
			( 'GBP'),
			( 'ROL'),
			( 'PDN')

INSERT INTO Availability  
VALUES		( 'Available'),
			( 'Unavailable'),
			( 'Pre-order'),
			( 'Must-go')

INSERT INTO OrderStatus   
VALUES		( 'New'),
			( 'In process of coordinating'),
			( 'Coordinated'),
			( 'In process of completing'),
			( 'Сompleted'),
			( 'Handed over for delivery'),
			( 'Transmitted'),
			( 'On return')

			SELECT * FROM Users
			SELECT * FROM Persons

INSERT INTO Users (PersonId, UserstatusId, Email, Parole, RegistrationDate, Username)
VALUES		( 1, 1, 'alinagutul3@gmail.com', '11111111', '2020-03-02', 'alinochka'),
			( 2, 2, 'tpwrzz@gmail.com', '12345678', '2019-12-22', 'theReaper'),
			( 3, 3, 'alexalex@gmail.com', '88888888','2020-01-21', 'xoxo12'),
			( 4, 1, 'dzapq021@mail.com', '1244411', '2021-02-12', 'ZapZap')

INSERT INTO Orders   (CartId, Quantity, ShippingAdr, OrderDate, OrderstatusId, OrderPrice)
VALUES		( 2000, 2, 'MDA, Chisinau, bd. Mircea cel Batrin 21/5', '2020-01-02 01:10:12', 5, 200),
			( 2000, 1, 'MDA, Chisinau, bd. Mircea cel Batrin 21/5', '2020-01-02 01:10:13', 3, 76.12),
			( 2000, 1, 'MDA, Chisinau, bd. Mircea cel Batrin 21/5', '2020-01-02 01:10:14', 4, 112),
			( 2001, 1, 'MDA, Chisinau, bd. Mircea cel Batrin 20', '2021-01-22 12:13:55', 6, 155),
			( 2001, 1, 'MDA, Chisinau, bd. Mircea cel Batrin 20', '2021-01-22 12:13:56', 6, 400),
			( 2002, 2, 'MDA, Chisinau, str.Igor Vieru', '2021-03-03 21:24:52', 1, 400.50),
			( 2003, 2, 'MDA, Chisinau, str.Ion Domeniuc 24', '2021-04-10 10:01:19', 8, 100.89),
			( 2002, 18, 'MDA, Chisinau, str.Igor Vieru', '2021-10-30 22:30:20', 7, 240.78)

			select * from orders
			select * from Genre 
			select * from Currency
			select * from Availability
			select * from Language
			select * from Authors
			
INSERT INTO Books  (Isbn, Title, AuthorId, GenreId, ReleaseDate, LanguageId, PageNumber, Price, CurrencyId, AvailabilityId) 
VALUES		( '12BN1892L', 'The Great Gatsby', 10, 6, '1925-04-10', 1, 148, 2.99, 5,1),
			( 'J1K2JJ413', 'Pride and prejudice', 3, 7, '1813-01-28', 1, 368, 2.99, 5,1),
			( 'AJ1J99JLF', 'The picture of Dorian Gray', 2, 7, '1890-07-01', 2, 194, 2.99, 5,1),
			( 'OIRWE5I3J', 'The  Cather in the Rye', 11, 6, '1951-04-16', 2, 213, 2.99, 5,1),
			( '289SDKLAP', 'The dandelion wine', 4, 7, '1957-01-01', 2, 352, 2.99, 5,1),
			( 'J124AKS87', 'Виноваты звезды', 5, 7, '2012-01-10', 3, 313, 530, 2,2),
			( 'J102JE-QK', 'Круги ада', 1 , 7, '1472-01-01', 1, 56, 50, 3, 4)

			select * from Books

			delete from books where Id=9
			select* from Orders

INSERT INTO UsersOrders   (UserId, OrderId)
VALUES		(1, 1),
			(1, 2),
			(1, 3),
			(2, 4),
			(2, 5),
			(2, 6),
			(4, 7),
			(3, 8)

 INSERT INTO BooksOrders (BookId, OrderId)
 values (2,1),
		(2,2),
		(2,3),
		(3,4),
		(3,5),
		(4,6),
		(5,7),
		(6,1)

		select* from BooksOrders
		go

-------------------------------------------------------ФИЛЬТРАЦИЯ и СОРТИРОВКА----------------------------------------------------------
--1
-- Вывести полное имя автора "Вино из одуванчиков"
SELECT FirstName, MiddleName, LastName
FROM Authors
WHERE AuthorId = 
					(SELECT AuthorId
					FROM Books
					WHERE Title = 'The dandelion wine') 

-- Вывести всех людей, у кого есть номер телефон от оператора молдчел
Select *
From Persons 
Where Telephone IS NOT NULL AND Telephone LIKE '+3737%'
ORDER BY BirthDate ASC


SELECT  * 
FROM OrdersView 
WHERE ShippingAdr LIKE '%Mircea cel Batrin%'
ORDER BY OrderPrice, Quantity ASC
GO
----------------------------- --------------------------ПРЕДСТАВЛЕНИЯ-------------------------------------------------------

select  * from Books go
--1 
--Полная информация по книгам
CREATE OR ALTER VIEW BooksView AS
SELECT Books.BookId, Isbn, Title, 
p.FirstName, p.MiddleName, p.LastName,
g.GenreName, ReleaseDate, l.LanguageName,
PageNumber, Price, c.CurrencyName, av.AvailabilityName
FROM Books inner join Authors p on Books.AuthorId=p.AuthorId, Genre  g, Availability av, Currency c, Language l
WHERE  Books.GenreId=g.GenreId 
		AND Books.LanguageId = l.LanguageId AND Books.CurrencyId = c.CurrencyId
		AND Books.AvailabilityId = av.AvailabilityId
GO

--Информация по авторам
CREATE OR ALTER VIEW AuthorsView AS
SELECT p.AuthorId ,p.FirstName, p.MiddleName, p.LastName,
 p.BirthDate, Books.Isbn, Books.Title
FROM Authors as p inner join Books
on p.AuthorId = Books.AuthorId
go

select * from Authors

SELECT FirstName, LastNameFROM BooksView
GO
--2
--Полная информация по пользователям интернет-магазина книг
CREATE VIEW UsersView AS
SELECT u.UserId, p.FirstName, p.MiddleName, p.LastName,
 p.BirthDate, p.Adress, p.Telephone, u.Email, Username, StatusName, RegistrationDate
FROM Users u INNER JOIN Persons p ON u.PersonId= p.PersonId, UserStatus 
WHERE StatusId = u.UserstatusId
GO

SELECT * FROM UsersView
GO
--3
--Полная информация по заказам за все время
CREATE or alter VIEW OrdersView AS
SELECT DISTINCT Orders.OrderId, Orders.CartId, Orders.Quantity, Orders.ShippingAdr, Orders.OrderDate,
OrderStatus.OrderstatusName, Orders.OrderPrice, Books.Isbn, Books.Title, Books.Price
FROM Orders INNER JOIN BooksOrders INNER JOIN Books
ON BooksOrders.BookId = Books.BookId
ON Orders.OrderId =BooksOrders.OrderId, OrderStatus
WHERE OrderStatus.OrderstatusId = Orders.OrderstatusId
GO

SELECT * FROM OrdersView
GO
--CREATE VIEW SalesView AS
--SELECT OrdersView.Quantity, OrdersView.Quantity, OrdersView.Isbn, BookView.nam
--4
--Полная информация по заказам и заказчикам за все время
CREATE or alter VIEW OrdersUsersView AS
SELECT DISTINCT OrdersView.OrderId, OrdersView.CartId, OrdersView.Quantity, OrdersView.ShippingAdr, OrdersView.OrderDate,
OrdersView.OrderstatusName, OrdersView.OrderPrice, OrdersView.Isbn, OrdersView.Title, UsersView.UserId, UsersView.FirstName, UsersView.LastName,
UsersView.Telephone, UsersView.Email, UsersView.StatusName
FROM UsersView INNER JOIN UsersOrders INNER JOIN OrdersView
ON UsersOrders.OrderId = OrdersView.OrderId
ON UsersView.UserId = UsersOrders.UserId
GO

SELECT * FROM OrdersUsersView
GO
--------------------------------------------------------------------------------
SELECT * FROM BooksView  ORDER BY BookId DESC go
--------------------------------------------------------------------------------
create or ALTER view codesUsersOrders as
SELECT DISTINCT Orders.OrderId, Orders.CartId, Orders.Quantity, Orders.ShippingAdr, Orders.OrderDate,
Orders.OrderstatusId, 
UsersView.Telephone, UsersView.Email,UsersView.UserId
FROM UsersView INNER JOIN UsersOrders INNER JOIN Orders
ON UsersOrders.OrderId = Orders.OrderId
ON UsersView.UserId = UsersOrders.UserId
GO


--Информация для заказов
CREATE OR ALTER VIEW BooksOrdersUsersView As
Select distinct OrdersUsersView.*,
BooksView.GenreName,  BooksView.LanguageName,
BooksView.Price, BooksView.CurrencyName
from OrdersUsersView inner join BooksView
on BooksView.Isbn = OrdersUsersView.Isbn
Go
