namespace Artichokes.UnitTests.Drawpile
{
    public class DrawPileShould
    {
        [Fact]
        public void DrawShouldReduceDrawPileByOne()
        {
            DrawPile drawPile = new DrawPile();
            int drawPileStartingNumber = drawPile.NumberOfCards();
            drawPile.Draw();

            Assert.True(drawPile.NumberOfCards() == drawPileStartingNumber-1);

        }
        
    }
}