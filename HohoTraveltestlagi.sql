create database HohoTraveltestlagi
drop database HohoTraveltestlagi
use HohoTraveltestlagi
create table Package(
PackID int PRIMARY KEY NOT NULL  IDENTITY (1,1),
PackName varchar(50),
PackTrip varchar(max),
PackPrice int,
IsDeleted varchar
)

create table Admin(
AdmID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
AdmName varchar (50),
AdmEmail varchar(50),
AdmPhNo varchar(50),
Password varchar(50),
)

create table Booking (
BookID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
BookDate date,
PackID int Foreign Key references package(packID),
CustName varchar(50),
CustEmail varchar(50),
CustPhNum varchar(15),
TravelDate date,
Quantity int,
BookMessage varchar(max),
RekNo varchar(50),
RekName varchar(50),
BookStatus varchar,
IsDeleted varchar,
BookPrice int
)

select * from booking

drop table Booking

use HohoTraveltestlagi
select * from Package
select * from Booking
select * from Admin

insert into Admin (AdmName, AdmEmail, AdmPhNo, Password) values('Admin', 'admin','085716567667','123')
insert into Booking  (BookDate, PackID, CustName, CustEmail, CustPhNum, TravelDate, Quantity, BookMessage, RekNo, RekName, BookStatus, IsDeleted, BookPrice) values ('2019-07-03','1','Rires','rires@gmail.com','081311597681','2019-08-01','2','nope','','','','1','')

truncate table booking

/*dari sini kebawah, cuma kalo butuh aja yaa*/
use HohoTraveltestlagi

use HohoTraveltestlagi

insert into Package (PackName,PackDesc,PackTime,PackMaxUser,PackPrice,PackStatus) 
values('Fun Day3','Ini contoh deskripsi ku buat panjang banget biar keliatan bisa dimasukin sepanjang ini atau nggak gitu loh maksudnya','12/11/2019',10,1500000000,1);

select * from Package

Update Package set IsDeleted = '1' where PackID = 1

select * from Booking

Update Booking set IsDeleted = '2' where BookID = 1

select * from Package

truncate Table Booking

select * from Booking
