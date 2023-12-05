namespace Artichokes.UnitTests.Garden;
using Artichokes;
public class GardenStockTests
{
    private int NumberOfCrops = 11;
    [Fact]
    public void GardenStockStartsWith6CardsPerType()
    {
        GardenStock gardenStock = new GardenStock();

        Assert.True(gardenStock.GetNumberOfCards() == NumberOfCrops * 6);

    }
    [Fact]
    public void RemoveCardRemovesACard()
    {
        GardenStock gardenStock = new GardenStock();
        gardenStock.RemoveTopCard();
        Assert.True(gardenStock.GetNumberOfCards() == NumberOfCrops * 6 - 1);
    }
}