create database IntelCPU;
go
use IntelCPU;
go
create table Processors
(
	Id int not null primary key identity(1,1),
	Family nvarchar(30) not null,
	Socket nvarchar(10) not null,
	Generation nvarchar(20) not null,
	Cores tinyint not null,
	CoreSpeed decimal(5,1) not null,
	BusSpeed decimal(5,1) not null,
	Graphics bit not null,
	Price int not null
);
go
insert into Processors (Family, Generation, Cores, CoreSpeed, BusSpeed, Socket, Price, Graphics)
values ('Core i5', 'Haswell (4)', 4, 3.2, 5, 's1150', 5142, 1), 
('Core i3', 'Haswell (4)', 2, 3.7, 5, 's1150', 3299, 1), 
('Pentium', 'Haswell (4)', 2, 3.3, 5, 's1150', 1637, 1),
('Core i3', 'Haswell (4)', 2, 3.6, 5, 's1150', 3199, 1),
('Core i7', 'Haswell (4)', 4, 4.0, 5, 's1150', 9790, 1),
('Core i5', 'Haswell (4)', 4, 3.3, 5, 's1150', 5590, 1),
('Pentium', 'Haswell (4)', 2, 3.2, 5, 's1150', 1590, 1),
('Core i5', 'Skylake (6)', 4, 3.2, 8, 's1151', 5899, 1),
('Core i7', 'Skylake (6)', 4, 4.0, 8, 's1151', 10990, 1),
('Pentium', 'Haswell (4)', 2, 3.1, 5, 's1150', 1566, 1),
('Core i5', 'Skylake (6)', 4, 2.7, 8, 's1151', 5254, 1),
('Core i5', 'Skylake (6)', 4, 3.3, 8, 's1151', 6300, 1),
('Core i3', 'Skylake (6)', 2, 3.7, 8, 's1151', 3580, 1);
go
create procedure AvgPrice
@res int output
as
select @res = avg(Price) from Processors;
