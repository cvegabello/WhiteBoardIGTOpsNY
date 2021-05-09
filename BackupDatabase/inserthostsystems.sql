CREATE DEFINER=`root`@`localhost` PROCEDURE `inserthostsystems`(in primaryHost int, in secondaryHost int, in spare1 int, in spare2 int, in spare3 int, in dateday date, in updateDate datetime, in updateUser varchar(45))
BEGIN
INSERT INTO hostsystemstbl (primaryHost, secondaryHost, spare1, spare2, spare3 , dateday, updateDate, updateUser)
VALUES (primaryHost, secondaryHost, spare1, spare2, spare3, dateday, updateDate, updateUser);

END