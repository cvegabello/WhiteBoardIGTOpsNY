CREATE DEFINER=`root`@`localhost` PROCEDURE `insertWinnnerXstate`(in codproduct int, in cdc int, in codstate int, in numwinners int, in dateTimeInsert datetime)
BEGIN

INSERT INTO winners (codProduct, numCdc, codStateUsa, numWinners, InsertDateTime)
VALUES (codproduct, cdc, codstate, numwinners, dateTimeInsert);

END