CREATE DEFINER=`root`@`localhost` PROCEDURE `insertdbapp`(in pridbInt int, in prippdbInt int, in prib2bappInt int, in prippappInt int)

BEGIN
	DELETE FROM serverdb_app;
	INSERT INTO  serverdb_app(priDB, prippdb, prib2bapp, prippapp )
	VALUES (pridbInt, prippdbInt, prib2bappInt, prippappInt);
END