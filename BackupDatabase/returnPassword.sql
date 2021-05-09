CREATE DEFINER=`root`@`localhost` PROCEDURE `returnPassword`(in username varchar(45))
BEGIN

SELECT user.passwordcol, user.coddepartment FROM user WHERE user.usernamecol = username;

END