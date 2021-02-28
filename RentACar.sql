
CREATE TABLE [dbo].[Brands] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
	[CarName] NVARCHAR (50) NULL,
    [ModelYear]    NVARCHAR (50) NULL,
    [DailyPrice]   DECIMAL (35)  NULL,
    [Descriptions] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id])
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    [Password]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NULL,
    [CompanyName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

CREATE TABLE [dbo].[CarImages ] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [CarId]     INT             NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [ImageDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);

INSERT INTO Colors(ColorName) VALUES
	('Kırmızı'),
	('Mavi'),
	('Siyah');

INSERT INTO Brands(BrandName) VALUES
	('Fiat'),
	('Hyundai'),
	('Nissan');
	
INSERT INTO Cars(BrandId,ColorId,CarName,ModelYear,DailyPrice,Descriptions) VALUES
	(1,1,'Linea','2013',130,'Benzin'),
	(1,2,'Egea','2015',250,'Dizel'),
	(2,1,'Accent','2017',400,'Benzin'),
	(2,2,'i20','2019',625,'Dizel');
	
INSERT INTO Users(FirstName,LastName,Email,Password) VALUES
	('Ali','Şahin','alisahin@email.com','ali2021'),
	('Büşra','Yelkenli','busrayelkenli@gmail.com','busra2021'),
	('Temel','Dursun','temeldursun@gmail.com','temel2021');
	
INSERT INTO Customers(UserId,CompanyName) VALUES
	(1,'Teda A.'),
	(2,'Ovonel A.'),
	(3,'Simya A.');

INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate) VALUES
	(1,1,'2021-01-05','2021-01-08'),
	(2,2,'2021-02-07','2021-02-09'),
	(3,3,'2021-02-10',null);
	
	