
namespace Artichokes.UnitTests.PlayerTests
{
    public class Player_DiscardHandShould
    {
        [Fact]
        public void HandIsEmptyAfterDiscard()
        {
            Player player1 = new Player();

            int previousHandCount = player1.hand.Count;

            player1.DiscardHand();


            Assert.True(previousHandCount==5);
            Assert.True(player1.hand.Count==0);
        }
        [Fact]
        public void DiscardPileHasFiveCardsAfterDiscard()
        {
            Player player1 = new Player();

            int previousDiscardCount = player1.discardPile.NumberOfCards();

            player1.DiscardHand();

            Assert.True(previousDiscardCount==0);
            Assert.True(player1.discardPile.NumberOfCards()==5);
            
        }
        [Fact]
        public void DiscardingEmptyHandChangesNothing()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            player1.DiscardHand();

            Assert.True(player1.hand.Count==0);
            Assert.True(player1.discardPile.NumberOfCards()==5);
        }
    }
}