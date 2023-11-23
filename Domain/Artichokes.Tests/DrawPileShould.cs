namespace Artichokes.UnitTests.Drawpile
{
    public class DrawPileShould
    {
        [Fact]
        public void RemoveTopCardShouldReduceDrawPileByOne()
        {
            DrawPile drawPile = new DrawPile();
            int drawPileStartingNumber = drawPile.NumberOfCards();
            drawPile.GetTopCard();
            drawPile.RemoveTopCard();

            Assert.True(drawPile.NumberOfCards() == drawPileStartingNumber-1);

        }
        
    }
}