
namespace Artichokes.UnitTests.PlayerTests
{
    public class Player_DiscardHandShould
    {
        [Fact]
        public void HandIsEmptyAfterDiscard()
        {
            Player player1 = new Player();

            int previousHandCount = player1.Hand.Count;

            player1.DiscardHand();


            Assert.True(previousHandCount==5);
            Assert.True(player1.Hand.Count==0);
        }
        [Fact]
        public void DiscardPileHasFiveCardsAfterDiscard()
        {
            Player player1 = new Player();

            int previousDiscardCount = player1.DiscardPile.NumberOfCards();

            player1.DiscardHand();

            Assert.True(previousDiscardCount==0);
            Assert.True(player1.DiscardPile.NumberOfCards()==5);
            
        }
        [Fact]
        public void DiscardingEmptyHandChangesNothing()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            player1.DiscardHand();

            Assert.True(player1.Hand.Count==0);
            Assert.True(player1.DiscardPile.NumberOfCards()==5);
        }
        [Fact]
        public void DiscardHandDoesNothingIfPlayerNotActive()
        {
            Player player1 = new Player();
            Player player2 = player1.PlayerToRight;
            player2.DiscardHand();
            Assert.True(player2.Hand.Count==5);
            
        }
    }
}