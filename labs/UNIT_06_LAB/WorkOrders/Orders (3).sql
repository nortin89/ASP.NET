
--drop table if exists[Parts];
--drop table if exists [Orders];
--drop table if exists [Customers]
--GO
--create table Orders (
--	OrderId INT,
--	CustomerId VARCHAR(50),
--	RepairDate DATE,
--	TechName VARCHAR(50),
--	LicencePlate VARCHAR(50),
--	VehicleYear VARCHAR(50),
--	VehicleMake VARCHAR(50),
--	VehicleModel VARCHAR(50),
--	Mileage VARCHAR(50),
--	Lube VARCHAR(50),
--	OilChange VARCHAR(50),
--	FlushTransmission VARCHAR(50),
--	FlushDifferential VARCHAR(50),
--	Wash VARCHAR(50),
--	Polish VARCHAR(50),
--	LaborHours VARCHAR(50),
--	LaborCostPerHour VARCHAR(50),
--	TotalCostParts VARCHAR(50),
--	TotalCostLabor VARCHAR(50),
--	TotalCostLaborParts VARCHAR(50),
--	TotalTax VARCHAR(50),
--	GrandTotal VARCHAR(50)
--);
SET IDENTITY_INSERT Orders On;

insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, TotalTax, GrandTotal) values (1, '615854', '9/15/2019', 'Tawsha Simko', '841311', 2011, 'Mazda', 'CX-9', '46643979', null, null, null, null, null, null, null, null, null, null, null, null, null);
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, TotalTax, GrandTotal) values (2, '114932', '6/4/2019', 'Hieronymus Timeby', '352765', 2003, 'MINI', 'Cooper', '08875145', null, null, null, null, null, null, null, null, null, null, null, null, null);
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, TotalTax, GrandTotal) values (3, '125490', '4/30/2019', 'Coralie Buttrick', '601108', 2009, 'Honda', 'Element', '78630543', null, null, null, null, null, null, null, null, null, null, null, null, null);
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, TotalTax, GrandTotal) values (4, '841784', '5/20/2019', 'Greggory Borrett', '208939', 2008, 'Scion', 'xB', '21811085', null, null, null, null, null, null, null, null, null, null, null, null, null);
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, TotalTax, GrandTotal) values (5, '401481', '10/20/2018', 'Morten Domesday', '814045', 2002, 'Ford', 'Thunderbird', '21580538', null, null, null, null, null, null, null, null, null, null, null, null, null);

SET IDENTITY_INSERT Orders OFF;
GO

SELECT * 
FROM Orders