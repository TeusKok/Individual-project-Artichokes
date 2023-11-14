using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Artichokes.UnitTests.PlayerTests
{
    public class Player_ConstructorShould
    {
        [Fact]
        public void PlayerConstructorConstructsADifferentPlayerToTheRight()
        {
            Player player1 = new Player(4);
            Player player2 = player1.playerToRight;
            bool result = player1 != player2;

            Assert.True(result, "Player1 should not be player2");
        }

        [Fact]
        public void PlayerConstructorConstructs3PlayersToTheRight()
        {
            Player player1 = new Player();
            Player player4 = player1.playerToRight.playerToRight.playerToRight;
            bool result = player1 != player4;

            Assert.True(result, "Player1 should not be player4");
        }

        [Fact]
        public void PlayerConstructorConstructs4thPlayerWithFirstPlayerToItsRight()
        {
            Player player1 = new Player();
            Player player4 = player1.playerToRight.playerToRight.playerToRight;
            bool result = player1 == player4.playerToRight;

            Assert.True(result, "Player1 should to the right of player4");
        }

        [Fact]
        public void PlayerIsCreatedWithFiveCardsInHand()
        {
            Player player1 = new Player();

            Assert.True(player1.hand.Count == 5);
        }

        [Fact]
        public void PlayerIsCreatedWithFiveCardsInDrawPile()
        {
            Player player1 = new Player();

            Assert.True(player1.drawPile.NumberOfCards() == 5);
        }

        [Fact]
        public void PlayerIsCreatedWithEmptyDiscardPile()
        {
            Player player1 = new Player();

            Assert.True(player1.discardPile.NumberOfCards() == 0);
        }

        [Fact]
        public void PlayerIsCreatedWithFiveArtechokesInHand()
        {
            Player player1 = new Player();
            Artichoke artichoke = new Artichoke();
            List<ICard> hand = player1.hand;
            Assert.True(hand[0].GetType() == artichoke.GetType());
            Assert.True(hand[1].GetType() == artichoke.GetType());
            Assert.True(hand[2].GetType() == artichoke.GetType());
            Assert.True(hand[3].GetType() == artichoke.GetType());
            Assert.True(hand[4].GetType() == artichoke.GetType());
        }
    }
}