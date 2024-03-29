namespace Artichokes.UnitTests.Crops;
public class PotatoTests
{
    [Fact]
    public void IfPotatoIsPlayedOneArtichokeIsRemovedFromTheTopOfDrawPile()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);

        Assert.True(player1.DrawPile.GetNumberOfCards() == 4);

    }
    [Fact]
    public void IfPotatoIsPlayedAndTopCardIsNotArtichokeTopCardIsAddedToDiscardPile()
    {
        Player player1 = new Player();
        player1.Hand.Clear();
        player1.Hand.Add(new Potato());
        player1.DiscardHand();
        player1.FillHand();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);
        Assert.True(player1.DiscardPile.GetNumberOfCards() == 2);
        Assert.True(player1.Hand.Count == 5);
        Assert.True(player1.DrawPile.GetNumberOfCards() == 0);
    }

    [Fact]
    public void IfPotatoIsPlayedThatPotatoGoesToDiscardPile()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);

        Assert.True(player1.DiscardPile.GetNumberOfCards() == 1);
        Assert.True(player1.DiscardPile.GetCards()[0].GetType() == typeof(Potato));
    }
    [Fact]
    public void IfPotatoIsPlayedThatPotatoIsRemovedFromHand()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6, string.Empty);

        Assert.True(player1.Hand.Count == 5);
        Assert.True(player1.Hand[4].GetType() == typeof(Artichoke));
    }
}