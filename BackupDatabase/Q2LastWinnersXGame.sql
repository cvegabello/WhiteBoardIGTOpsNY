CREATE DEFINER=`root`@`localhost` PROCEDURE `Q2LastWinnersXGame`(in CodGame int)
BEGIN
SELECT dayWeekName, numCDC, Winners, Jackpot FROM HISTORY_DRAW WHERE codProduct = CodGame ORDER BY numDraw DESC limit 2;

END