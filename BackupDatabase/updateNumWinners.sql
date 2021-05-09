CREATE DEFINER=`root`@`localhost` PROCEDURE `updateNumWinners`(in CodGame int, in cdc int, in numWinnerStr varchar(45))
BEGIN

UPDATE history_draw SET history_draw.Winners = numWinnerStr
WHERE (history_draw.codProduct = CodGame AND history_draw.numCDC = cdc);

END