CREATE DEFINER=`root`@`localhost` PROCEDURE `returnLastUser`(in activity varchar(45))
BEGIN

SELECT userCol, dateCol, actiondescriptionCol FROM log_login WHERE actiondescriptionCol = activity  ORDER BY idlog_login DESC limit 1;

END