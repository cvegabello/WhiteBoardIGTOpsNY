CREATE DEFINER=`root`@`localhost` PROCEDURE `insertLog_login`(in updateUser varchar(45), in updateDate datetime, in descriptionAction varchar(45))
BEGIN

INSERT INTO log_login (userCol, dateCol, actiondescriptionCol)
VALUES (updateUser, updateDate, descriptionAction);

END