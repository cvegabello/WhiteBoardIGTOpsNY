CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteHistoryDrawXproductXcdc`(in CodGame int, in cdc int)
BEGIN

DELETE FROM history_draw WHERE codProduct = CodGame AND numCdc = cdc

END