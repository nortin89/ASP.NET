--USE WorkOrders

--drop table if exists [Parts];
--drop table if exists [Orders];
--drop table if exists [Customers];
--drop table if exists [Customer];



SET IDENTITY_INSERT Orders On;

insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('658', '8543065', '9/26/2019', 'Salomo Moran', '777-sjv-4qi', 2003, 'Lexus', 'ES', 0, 1, 0, 1, 0, 1, 0, 1, '34.46', '681254.89', '80.86', '345446.77', '8426260.94');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('678', '6029346', '5/25/2019', 'Fara Gossop', '669-skq-1ot', 2010, 'Land Rover', 'Range Rover', 1, 0, 0, 0, 0, 1, 0, 38, '35.83', '4901332.26', '9905.45', '3467663.27', '6091009.14');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('768', '9900706', '6/12/2019', 'Christye Woodburne', '792-jns-9xt', 2004, 'Chrysler', 'Sebring', 1, 1, 0, 0, 1, 0, 1, 17, '13.76', '8464113.45', '281.51', '8848835.23', '7538359.34');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('135', '2185640', '4/15/2019', 'Neile Losbie', '292-din-7ug', 2003, 'GMC', 'Sonoma', 0, 0, 1, 0, 1, 0, 0, 43, '11.77', '6256466.46', '5255.35', '6448256.77', '7094634.17');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('844', '7865377', '8/2/2019', 'Maisie Mushett', '542-fbg-3og', 2006, 'Hyundai', 'Tiburon', 0, 0, 0, 0, 0, 0, 1, 50, '31.50', '7238874.79', '432.02', '7544623.58', '9141847.74');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('364', '5933931', '1/6/2019', 'Meier Stoneley', '992-gfu-3wh', 2006, 'Ford', 'GT', 1, 1, 1, 0, 1, 1, 1, 61, '23.57', '7419480.14', '3807.13', '8832540.09', '1211467.55');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('061', '8499197', '2/16/2019', 'Kirstyn Noto', '476-crl-4uq', 2010, 'Chevrolet', 'Tahoe', 0, 0, 1, 0, 0, 1, 0, 50, '49.90', '1022911.04', '5602.96', '5981324.39', '6538099.42');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('807', '1649074', '1/27/2019', 'Griffin Frascone', '722-jve-5pg', 1992, 'Buick', 'Skylark', 0, 0, 1, 0, 0, 0, 1, 73, '37.62', '5190216.31', '6939.70', '4305613.60', '2139753.49');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('324', '0087665', '2/18/2019', 'Dyanne Benzie', '400-kgk-2ha', 2005, 'Pontiac', 'Sunfire', 1, 0, 1, 0, 1, 1, 1, 73, '17.57', '687328.11', '506.02', '7756645.79', '8903893.61');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('573', '2735736', '12/9/2018', 'Ericha Lynds', '929-fii-3ms', 2006, 'Mercedes-Benz', 'CLK-Class', 0, 0, 1, 1, 1, 1, 1, 23, '16.67', '2435619.34', '7806.21', '7651457.37', '5357427.02');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('571', '9990905', '7/30/2019', 'Tonye Kinsell', '223-qoi-8np', 1998, 'GMC', 'Yukon', 0, 0, 0, 1, 1, 0, 1, 71, '38.34', '1953390.79', '954.52', '3106250.16', '3768032.99');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('130', '1839627', '1/24/2019', 'Riva Wilprecht', '271-iuj-8zq', 1996, 'Mazda', 'Millenia', 1, 0, 0, 0, 1, 0, 1, 26, '21.62', '4920294.68', '296.60', '8818515.78', '7096548.08');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('737', '2252706', '7/20/2019', 'Lay Mowett', '767-zad-3kb', 1989, 'Dodge', 'Colt', 0, 1, 1, 1, 1, 1, 0, 75, '25.40', '795331.70', '1360.48', '9262209.79', '4844751.72');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('487', '5623136', '12/15/2018', 'Maud Ciotto', '053-ulu-2ul', 1995, 'Chevrolet', 'Cavalier', 1, 1, 0, 0, 1, 1, 1, 20, '9.83', '5114590.35', '6076.79', '8581805.63', '5739305.99');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('398', '0693811', '7/2/2019', 'Udell Henriet', '512-dmg-8zh', 2001, 'Hyundai', 'XG300', 0, 1, 0, 0, 1, 1, 0, 59, '49.09', '3682704.74', '3279.72', '997508.37', '6857012.03');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('399', '7745023', '12/19/2018', 'Pate Jarlmann', '626-nut-3ao', 2006, 'Volkswagen', 'GTI', 1, 1, 0, 0, 0, 0, 0, 59, '27.64', '8191846.17', '1080.95', '5497799.84', '6421618.29');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('854', '3558032', '12/24/2018', 'Legra Gaughan', '992-kdz-5dx', 2009, 'BMW', 'Z4 M', 1, 0, 0, 1, 1, 0, 1, 2, '36.57', '9043811.44', '5403.11', '9091344.16', '3160358.77');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('434', '0109651', '12/7/2018', 'Eileen Matthis', '146-bup-4ok', 1999, 'Nissan', 'Sentra', 1, 0, 1, 1, 1, 1, 0, 56, '10.80', '442189.45', '8111.55', '5533283.74', '9202366.50');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('598', '9358192', '1/8/2019', 'Delbert Geeson', '202-gxl-6oj', 2006, 'BMW', '7 Series', 1, 1, 1, 0, 0, 0, 0, 10, '20.46', '8869707.96', '6129.51', '5626845.19', '2359678.85');
insert into Orders (OrderId, CustomerId, RepairDate, TechName, LicencePlate, VehicleYear, VehicleMake, VehicleModel, Mileage, Lube, OilChange, FlushTransmission, FlushDifferential, Wash, Polish, LaborHours, LaborCostPerHour, TotalCostParts, TotalCostLabor, TotalCostLaborParts, GrandTotal) values ('716', '9537017', '7/20/2019', 'Tana Meacher', '170-xer-7aw', 2011, 'Jeep', 'Patriot', 1, 1, 0, 1, 1, 1, 1, 67, '22.66', '8119591.07', '4692.12', '1589917.51', '9218896.07');

SET IDENTITY_INSERT Orders Off;
