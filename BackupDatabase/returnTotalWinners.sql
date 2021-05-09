CREATE DEFINER=`root`@`localhost` PROCEDURE `returnTotalWinners`(in codproduct int, in cdc int)
BEGIN

SELECT winners.codProduct, winners.numCdc, SUM(winners.numWinners) FROM winners WHERE winners.codProduct = codproduct AND winners.numCdc = cdc
GROUP BY winners.codProduct, winners.numCdc ;

END