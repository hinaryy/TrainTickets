use TrainTickets

--create table [Users]
--(
--	[id] int identity primary key,
--	[name] nvarchar(50) not null,
--	[email] nvarchar(50) not null unique,
--	[password] nvarchar(50) not null
--)

--go

create table [Stations]
(
	[id] int identity primary key,
	[name] nvarchar(50) not null
)

go

create table [Routes]
(
	[id] int identity primary key,
	[from (station)] int not null,
	[to (station)] int not null,
	[date] date not null,
	[price] float not null default 0.29
)

go

