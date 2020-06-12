IF DB_ID('RestaurantMiticPrpos') IS NULL
CREATE DATABASE RestaurantMiticPrpos
GO
USE RestaurantMiticPrpos;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblOrder')
drop table tblOrder;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblMenu')
drop table tblMenu;


Create table tblMenu (
MenuID int identity (1,1) primary key,
Pizza int ,
Chicken int,
Sandwich int,
Pasta int,
Soup int 
)

Create table tblOrder (
OrderID int identity (1,1) primary key,
MenuID int foreign key (MenuID) references tblMenu(MenuID) not null,
OrderTime date,
OrderNumber int
)







