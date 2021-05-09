CREATE DEFINER=`root`@`localhost` PROCEDURE `insertdraw`(in numDrawInt int, in numCDCInt int, in nomProductStr varchar(45), in codigoProductInt int, in numWinnerStr varchar(45), in JackpotDbl Double, in dayWeekNameStr varchar(45))
BEGIN
INSERT INTO HISTORY_DRAW ( NumDraw, NumCDC, nomProduct, codProduct, Winners, Jackpot, dayWeekName)
VALUES (numDrawInt, numCDCInt, nomProductStr, codigoProductInt, numWinnerStr, JackpotDbl, dayWeekNameStr);

END