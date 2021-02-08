
CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([BrandID] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorID]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ColorID] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [CarID]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandID]      INT           NULL,
    [ColorID]      INT           NULL,
	[Name] NVARCHAR (50) NULL,
    [ModelYear]    NVARCHAR (50) NULL,
    [DailyPrice]   DECIMAL (18)  NULL,
    [Descriptions] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CarID] ASC),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ColorID]),
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID])
);


INSERT INTO Colors(ColorName) VALUES
	('Kırmızı'),
	('Mavi'),
	('Siyah');

INSERT INTO Brands(BrandName) VALUES
	('Mercedes'),
	('Seat'),
	('Bugatti');
	
	
INSERT INTO Cars(BrandID,ColorID,Name,ModelYear,DailyPrice,Descriptions) VALUES
	('2','1','Passat','2013','130','Benzin'),
	('2','2','Doğan Slx','2015','250','Dizel'),
	('3','3','Accent','2017','400','Benzin'),
	('1','2','Elantra','2019','625','Dizel');