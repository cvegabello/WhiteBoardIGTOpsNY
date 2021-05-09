CREATE DEFINER=`root`@`localhost` PROCEDURE `updateOnCall`(in onCallNameStr varchar(45), in currentLevelInt int )
BEGIN

DECLARE phoneNumber varchar(45);
SET phoneNumber = (SELECT oncalltbl.phoneNumber FROM oncalltbl WHERE oncalltbl.oncallName = onCallNameStr);

UPDATE oncallcurrent SET oncallcurrent.oncallcurrentname = onCallNameStr, oncallcurrent.oncallcurrentphone = phoneNumber
WHERE oncallcurrent.oncallcurrentlevel = currentLevelInt;

END