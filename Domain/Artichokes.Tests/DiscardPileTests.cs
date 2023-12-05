namespace Artichokes.UnitTests.DiscardPile
{
    public class DiscardPileTests
    {
        [Fact]
        public void EmptyDiscardPileShouldEmptyDiscardPile()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            int numberOfCards = player1.DiscardPile.GetNumberOfCards();
            player1.DiscardPile.EmptyDiscardPile();

            Assert.True(numberOfCards == 5);
            Assert.True(player1.DiscardPile.GetNumberOfCards() == 0);

        }
    }
}