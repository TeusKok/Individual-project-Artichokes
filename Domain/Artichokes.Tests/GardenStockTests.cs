namespace Artichokes.UnitTests.Garden;
using Artichokes;
public class GardenStockTests{
    [Fact]
    public void GardenStockStartsWith6CardsPerType()
    {
        GardenStock gardenStock = new GardenStock();

        Assert.True(gardenStock.GetNumberOfCards()==6);

    }
    [Fact]
    public void RemoveCardRemovesACard()
    {
       GardenStock gardenStock = new GardenStock();
       gardenStock.removeTopCard();
       Assert.True(gardenStock.GetNumberOfCards()==5);
    }
    [Fact]
    public void RemovingCardFromEmptyPileThrowsException()
    {
        GardenStock gardenStock = new GardenStock();
       gardenStock.removeTopCard();
       gardenStock.removeTopCard();
       gardenStock.removeTopCard();
       gardenStock.removeTopCard();
       gardenStock.removeTopCard();
       gardenStock.removeTopCard();
        Assert.ThrowsAny<Exception>(()=>{gardenStock.removeTopCard();});
    }
}