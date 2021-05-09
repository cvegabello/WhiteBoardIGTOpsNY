CREATE DEFINER=`root`@`localhost` PROCEDURE `updateAppVersion`(in appversion varchar(20), in appname varchar(20), in userNameStr varchar(20))
BEGIN

UPDATE terminal_application SET terminal_application.version = appversion, update_datetime = now(), username = userNameStr
WHERE terminal_application.application_name = appname;

END