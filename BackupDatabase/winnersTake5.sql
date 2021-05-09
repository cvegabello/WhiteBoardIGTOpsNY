CREATE DEFINER=`root`@`localhost` PROCEDURE `winnersTake5`(in limite int)
BEGIN

SELECT dayWeekName, numCDC, numDraw, Winners FROM 
(SELECT dayWeekName, numCDC, numDraw, Winners FROM HISTORY_DRAW WHERE codProduct = 2 ORDER BY numDraw DESC limit limite) as t
ORDER BY numDraw;


END