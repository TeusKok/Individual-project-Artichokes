
namespace Artichokes.UnitTests.PlayerTests
{
    public class Player_FillHandShould
    {
        [Fact]
        public void RaiseNumberOfCardsInHandToFive()
        {
            Player player1 = new Player();
            player1.DiscardHand();
            player1.FillHand();
            Assert.True(player1.Hand.Count==5);
        }
        [Fact]
        public void ReduceDrawPileByNumberOfDrawnCards()
        {
            Player player1 = new Player();
            int startingNumberOfDrawPileCards = player1.DrawPile.NumberOfCards();
            player1.DiscardHand();
            player1.FillHand();
            Assert.True(player1.DrawPile.NumberOfCards()==0);
            Assert.True(startingNumberOfDrawPileCards == 5);
        }
        [Fact]
        public void WhenDrawPileHasLessCardsThenDrawnAmountDiscardPileBecomesDrawpile()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            player1.FillHand();
            player1.DiscardHand();
            player1.FillHand();

            Assert.True(player1.DrawPile.NumberOfCards()==5);
            Assert.True(player1.Hand.Count==5);
        }
        [Fact]
        public void FillHandDoesNothingIfPlayerNotActive()
        {
            Player player1 = new Player();

            player1.DiscardHand();
            player1.EndTurn();
            player1.FillHand();
            
            Assert.True(player1.Hand.Count==0);

             

        }
    }
}