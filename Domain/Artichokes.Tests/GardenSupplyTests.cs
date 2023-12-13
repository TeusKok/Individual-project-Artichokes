namespace Artichokes.UnitTests.Garden;
using Artichokes;
public class GardenSupplyTests
{
    [Fact]
    public void WhenMadeIsFilledWithFiveCards()
    {
        GardenSupply gardenSupply = new GardenSupply();
        Assert.True(gardenSupply.GetNumberOfCards() == 5);
        Assert.True(gardenSupply.GetCardByNumber(1) != null);
        Assert.True(gardenSupply.GetCardByNumber(2) != null);
        Assert.True(gardenSupply.GetCardByNumber(3) != null);
        Assert.True(gardenSupply.GetCardByNumber(4) != null);
        Assert.True(gardenSupply.GetCardByNumber(5) != null);
    }
    [Fact]
    public void RemoveCardRemovesACard()
    {
        GardenSupply gardenSupply = new GardenSupply();
        gardenSupply.RemoveCardByNumber(3);
        gardenSupply.RemoveCardByNumber(3);
        Assert.True(gardenSupply.GetNumberOfCards() == 3);
    }

    [Fact]
    public void refillGardenSupplyRefillsGardenSupplyToFiveCards()
    {
        GardenSupply gardenSupply = new GardenSupply();
        gardenSupply.RemoveCardByNumber(3);
        gardenSupply.RefillGardenSupply();

        Assert.True(gardenSupply.GetNumberOfCards() == 5);

    }
    [Fact]
    public void refillGardenSupplyReducesGardenStockByANumberOfCards()
    {
        GardenSupply gardenSupply = new GardenSupply();
        int numberOfCardsInGardenSupply = gardenSupply.gardenStock.GetNumberOfCards();
        gardenSupply.RemoveCardByNumber(3);
        gardenSupply.RefillGardenSupply();

        Assert.True(gardenSupply.gardenStock.GetNumberOfCards() == numberOfCardsInGardenSupply - 1);
    }
}