CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateDrawDateCurrent`(in drawDateCurrent datetime, in idProduct int)
BEGIN
UPDATE product SET product.drawDateCurrent = drawDateCurrent
WHERE PRODUCT.IdProduct = idProduct;
END