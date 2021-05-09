CREATE DEFINER=`root`@`localhost` PROCEDURE `returnAppVersion`(in appname varchar(20))
BEGIN

SELECT terminal_application.version
FROM terminal_application
WHERE terminal_application.application_name = appname;

END