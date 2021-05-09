CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteWinnnerXproductXcdc`(in CodGame int, in cdc int)
BEGIN
DELETE FROM winners WHERE codProduct = CodGame AND numCdc = cdc;
END