namespace Artichokes.UnitTests.DiscardPile
{
    public class DiscardPileTests
    {
        [Fact]
        public void EmptyDiscardPileShouldEmptyDiscardPile()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            int numberOfCards  = player1.discardPile.NumberOfCards();
            player1.discardPile.EmptyDiscardPile();

            Assert.True(numberOfCards == 5);
            Assert.True(player1.discardPile.NumberOfCards() == 0);

        }
    }
}