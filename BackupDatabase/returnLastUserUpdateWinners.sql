CREATE DEFINER=`root`@`localhost` PROCEDURE `returnLastUserUpdateWinners`()
BEGIN

SELECT userCol, dateCol, actiondescriptionCol FROM log_login WHERE actiondescriptionCol = 'UPDATE WINNERS.'  ORDER BY idlog_login DESC limit 1;

END