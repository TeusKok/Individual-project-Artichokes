using System.Runtime.CompilerServices;

namespace Artichokes.UnitTests.Crops;

public class CarrotTests
{
    [Fact]
    public void MayBePlayedShoudlReturnFalseIfACardWasPlayed()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.Hand.Add(new Carrot());
        player1.PlayCardFromHandByNumber(6, string.Empty);

        Assert.True(player1.Hand[5].GetType() == typeof(Carrot));
        Assert.False(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void MayBePlayedShouldReturnFalseIfThereAreLessThanTwoArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 4);
        ICard[] cards = { new Carrot(), new Carrot(), new Carrot(), new Carrot(), new Carrot() };
        player1.Hand.AddRange(new List<ICard>(cards));

        Assert.True(player1.Hand[4].GetType() == typeof(Carrot));
        Assert.False(player1.Hand[4].MayBePlayedBy(player1));
    }

    [Fact]
    public void MayBePlayedShouldReturnTrueIfTwoArtichokesNoCardsWerePlayedYet()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 3);
        player1.Hand.Add(new Carrot());

        Assert.True(player1.Hand[2].GetType() == typeof(Carrot));
        Assert.True(player1.Hand[2].MayBePlayedBy(player1));
    }
    [Fact]
    public void MayBePlayedShouldReturnTrueIfMoreThanTwoArtichokesAndNoCardsWerePlayedYet()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Carrot());

        Assert.True(player1.Hand[5].GetType() == typeof(Carrot));
        Assert.True(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void IfCarrotMayBePlayedPlayShouldRemoveCarrotAndTwoArtichokesFromHandWithTwoArtichokesAndOneCarrotInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 3);
        ICard carrot = new Carrot();
        ICard[] cards = { new Potato(), new Potato(), new Potato(), carrot };
        player1.Hand.AddRange(new List<ICard>(cards));
        player1.Hand[5].Play(player1, string.Empty);

        List<ICard> discardPile = player1.DiscardPile.GetCards();

        Assert.True(discardPile.Count == 3);
        Assert.True(discardPile[0].GetType() == typeof(Potato));
        Assert.True(discardPile[1].GetType() == typeof(Potato));
        Assert.True(discardPile[2].GetType() == typeof(Potato));
    }

    [Fact]
    public void IfCarrotMayBePlayedPlayShouldRemoveCarrotAndTwoArtichokesFromHandWithMoreThanTwoArtichokesAndMoreThanOneCarrotInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveAt(0);
        ICard[] cards = { new Carrot(), new Carrot() };
        player1.Hand.AddRange(new List<ICard>(cards));
        player1.Hand[5].Play(player1, string.Empty);
        List<ICard> discardPile = player1.DiscardPile.GetCards();

        Assert.True(discardPile.Count == 3);
        Assert.True(discardPile[0].GetType() == typeof(Artichoke));
        Assert.True(discardPile[1].GetType() == typeof(Artichoke));
        Assert.True(discardPile[2].GetType() == typeof(Carrot));
    }

    [Fact]
    public void playShouldDoNothingIfCarrotMayNotBePlayed()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);
        player1.Hand.Add(new Carrot());
        player1.Hand[5].Play(player1, string.Empty);

        Assert.True(player1.Hand.Count == 6);
        Assert.True(player1.DiscardPile.GetNumberOfCards() == 1);
    }

    [Fact]
    public void PlayingCarrotShouldEndTurn()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Carrot());
        player1.Hand[5].Play(player1, string.Empty);

        Assert.False(player1.IsActivePlayer);
    }
}