
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
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [Email]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
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
	
INSERT INTO CarImages(CarId,ImagePath,ImageDate) VALUES
	(null,'C:\Users\onurb\source\repos\ReCapProject\WebAPI\wwwroot\Images\default.jpeg',null);
