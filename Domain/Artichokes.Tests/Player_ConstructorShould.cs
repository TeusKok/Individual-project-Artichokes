using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Artichokes.UnitTests.PlayerTests
{
    public class Player_ConstructorShould
    {
        [Fact]
        public void PlayerConstructorConstructsADifferentPlayerToTheRight()
        {
            Player player1 = new Player(4);
            Player player2 = player1.PlayerToRight;
            bool result = player1 != player2;

            Assert.True(result, "Player1 should not be player2");
        }

        [Fact]
        public void PlayerConstructorConstructs3PlayersToTheRight()
        {
            Player player1 = new Player();
            Player player4 = player1.PlayerToRight.PlayerToRight.PlayerToRight;
            bool result = player1 != player4;

            Assert.True(result, "Player1 should not be player4");
        }

        [Fact]
        public void PlayerConstructorConstructs4thPlayerWithFirstPlayerToItsRight()
        {
            Player player1 = new Player();
            Player player4 = player1.PlayerToRight.PlayerToRight.PlayerToRight;
            bool result = player1 == player4.PlayerToRight;

            Assert.True(result, "Player1 should to the right of player4");
        }

        [Fact]
        public void PlayerIsCreatedWithFiveCardsInHand()
        {
            Player player1 = new Player();

            Assert.True(player1.Hand.Count == 5);
        }

        [Fact]
        public void PlayerIsCreatedWithFiveCardsInDrawPile()
        {
            Player player1 = new Player();

            Assert.True(player1.DrawPile.NumberOfCards() == 5);
        }

        [Fact]
        public void PlayerIsCreatedWithEmptyDiscardPile()
        {
            Player player1 = new Player();

            Assert.True(player1.DiscardPile.NumberOfCards() == 0);
        }

        [Fact]
        public void PlayerIsCreatedWithFiveArtechokesInHand()
        {
            Player player1 = new Player();
            Artichoke artichoke = new Artichoke();
            List<ICard> hand = player1.Hand;
            Assert.True(hand[0].GetType() == artichoke.GetType());
            Assert.True(hand[1].GetType() == artichoke.GetType());
            Assert.True(hand[2].GetType() == artichoke.GetType());
            Assert.True(hand[3].GetType() == artichoke.GetType());
            Assert.True(hand[4].GetType() == artichoke.GetType());
        }
        [Fact]
        public void PlayerIsCreatedWithGardenSupply()
        {
            Player player1 = new Player();
            Assert.True(player1.SharedGardenSupply != null);
        }
        [Fact]
        public void SecondaryPlayersAreCreatedWithAReferenceToTheSameGardenSupply()
        {
            Player player1 = new Player();
            Assert.True(player1.PlayerToRight.SharedGardenSupply != null);
            Assert.True(player1.PlayerToRight.PlayerToRight.SharedGardenSupply != null);
            Assert.True(player1.SharedGardenSupply == player1.PlayerToRight.SharedGardenSupply);

        }

        [Fact]
        public void FirstPlayerStartsAsActive()
        {
            Player player1 = new Player();
            Assert.True(player1.IsActivePlayer);
        }
        [Fact]
        public void OtherPlayersStartAsInactive()
        {
            Player player1 = new Player();
            Assert.False(player1.PlayerToRight.IsActivePlayer);
            Assert.False(player1.PlayerToRight.PlayerToRight.IsActivePlayer);
            Assert.False(player1.PlayerToRight.PlayerToRight.PlayerToRight.IsActivePlayer);
        }
    }
}