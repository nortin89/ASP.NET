USE WorkOrders

drop table if exists [Parts];
drop table if exists [Orders];
drop table if exists [Customers];
drop table if exists [Customer];



CREATE TABLE [dbo].[Customers](
	[CustomerId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrderNumber] [int] NULL,
	[ClientName] [varchar](50) NULL,
	--[FirstName] [varchar](50) NOT NULL,
	--[LastName] [varchar] (50) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](30) NOT NULL,
	[Zip] [varchar](10) NOT NULL
);

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] [int] NULL, 
	[RepairDate] [date] NULL,
	[TechName] [varchar](50) NULL,
	[LicencePlate] [varchar](10) NULL,
	[VehicleYear] [varchar](10) NULL,
	[VehicleMake] [varchar](50) NULL,
	[VehicleModel] [varchar](50) NULL,
	[Mileage] [varchar](50) NULL,
	[Lube] bit NULL,
	[OilChange] bit NULL,
	[FlushTransmission] bit NULL,
	[FlushDifferential] bit NULL,
	[Wash] bit NULL,
	[Polish] bit NULL,
	[LaborHours] [int] NULL,
	[LaborCostPerHour] [decimal](10,2) NULL,
	[TotalCostParts] [decimal](10,2) NULL,
	[TotalCostLabor] [decimal](10,2) NULL,
	[TotalCostLaborParts] [decimal](10,2) NULL,
	[TotalTax] [decimal](10,2) NULL,
	[GrandTotal] [decimal](10,2) NULL,
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),

);

CREATE TABLE [dbo].[Parts](
	[PartId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] [int] NULL,
	[OrderId] [int] NULL,
	[Quantity] [int] NULL,
	[PartNumber] [int] NULL,
	[PartCost] [decimal](8,2) NULL,
	FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
) ;