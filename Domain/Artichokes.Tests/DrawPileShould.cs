namespace Artichokes.UnitTests.Drawpile
{
    public class DrawPileShould
    {
        [Fact]
        public void RemoveTopCardShouldReduceDrawPileByOne()
        {
            DrawPile drawPile = new DrawPile();
            int drawPileStartingNumber = drawPile.GetNumberOfCards();
            drawPile.GetTopCard();
            drawPile.RemoveTopCard();

            Assert.True(drawPile.GetNumberOfCards() == drawPileStartingNumber - 1);

        }

    }
}