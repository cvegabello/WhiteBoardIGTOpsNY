CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateJackPot`(in jackPotDbl double, in sysCodeProductInt int)
BEGIN
UPDATE PRODUCT SET PRODUCT.currentJackPot = jackPotDbl
WHERE (((PRODUCT.productSysCode)=sysCodeProductInt));

END