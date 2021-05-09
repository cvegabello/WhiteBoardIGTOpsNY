CREATE DEFINER=`root`@`localhost` PROCEDURE `returnNewJackpot`(in CodGame int)
BEGIN

SELECT PRODUCT.currentJackpot
FROM PRODUCT
WHERE PRODUCT.IdProduct = CodGame;

END