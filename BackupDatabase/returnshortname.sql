CREATE DEFINER=`cvega`@`%` PROCEDURE `returnshortname`(in CodGame int, in cdc int)
BEGIN
	SELECT states_usa.short_name
	FROM states_usa INNER JOIN winners ON states_usa.idstates_usa = winners.codStateUsa
	WHERE (winners.codProduct=CodGame AND winners.numCdc = cdc);
END