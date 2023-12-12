namespace Artichokes.UnitTests.PlayerTests;

public class Player_PlayCardShould{
    [Fact]
    public void RemoveCardFromHandIfPlayedCardValid()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);
        Assert.True(player1.Hand.Count==5);
    }

    [Fact]
    public void NotRemoveCardFromHandIfPlayedCardInvalid()
    {
        Player player1 = new Player();
        player1.DiscardHand();
        player1.FillHand();
        player1.DiscardPile.EmptyDiscardPile();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);
        Assert.True(player1.Hand.Count==6);
        
    }
    [Fact]
    public void turnPlayedCardToTrue()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);
        Assert.True(player1.PlayedCard);
    }
}