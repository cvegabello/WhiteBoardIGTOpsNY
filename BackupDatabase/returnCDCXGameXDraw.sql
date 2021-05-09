CREATE DEFINER=`root`@`localhost` PROCEDURE `returnCDCXGameXDraw`(in drawGame int, in codGame int)
BEGIN

SELECT history_draw.numCDC FROM history_draw WHERE history_draw.numDraw = drawGame AND history_draw.codProduct = codGame;

END