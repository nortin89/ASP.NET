USE WorkOrders

SET IDENTITY_INSERT Parts On;
insert into Parts (PartId, CustomerId, OrderId, Quantity, PartNumber, PartCost) values (1, '615854', 1, null, null, null);
insert into Parts (PartId, CustomerId, OrderId, Quantity, PartNumber, PartCost) values (2, '114932', 2, null, null, null);
insert into Parts (PartId, CustomerId, OrderId, Quantity, PartNumber, PartCost) values (3, '70651', 3, null, null, null);
insert into Parts (PartId, CustomerId, OrderId, Quantity, PartNumber, PartCost) values (4, '79340', 4, null, null, null);
insert into Parts (PartId, CustomerId, OrderId, Quantity, PartNumber, PartCost) values (5, '85946', 5, null, null, null);
SET IDENTITY_INSERT Parts Off;

SELECT * 
FROM Parts