namespace Artichokes.UnitTests.Crops;
public class RubarbTests
{
    [Fact]
    public void MayBePlayedReturnsTrue()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Rubarb());
        Assert.True(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void PlayShouldDiscardAndRefreshGardenSupply()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Rubarb());
        Int32 oldNumberOfCardsInStock = player1.SharedGardenSupply.gardenStock.GetNumberOfCards();
        ICard oldFirstCardInSupply = player1.SharedGardenSupply.GetCardByNumber(1);

        player1.Hand[5].Play(player1, string.Empty);

        Assert.NotEqual(oldFirstCardInSupply,player1.SharedGardenSupply.GetCardByNumber(1));
        Assert.True(oldNumberOfCardsInStock -5 == player1.SharedGardenSupply.gardenStock.GetNumberOfCards());
    }
    [Fact]
    public void PlayShouldSetHarvestedCardOnFalse()
    {
        Player player1 = new Player();
        player1.HarvestCardFromGardenSupply(1);
        player1.Hand.Add(new Rubarb());

        Assert.True(player1.Hand[6].GetType() == typeof(Rubarb));

        player1.Hand[6].Play(player1, string.Empty);
        Assert.False(player1.HarvestedCard);
    }
}