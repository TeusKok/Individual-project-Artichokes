namespace Artichokes.UnitTests.PlayerTests;

public class Player_HarvestCardShould{

    [Fact]
    public void AddOneCardToHandIfThereAreFiveCardsInGardenSupply()
    {
       Player player1 = new Player();

       player1.HarvestCardFromGardenSupply(1);
       
       Assert.True(player1.Hand.Count == 6);
    }

    [Fact]
    public void RemoveOneCardFromGardenSupplyIfThereAreFiveCardsInGardenSupply()
    {
       Player player1 = new Player();

       player1.HarvestCardFromGardenSupply(1);
       
       Assert.True(player1.SharedGardenSupply.GetNumberOfCards() == 4);
    }

    [Fact]
    public void SwitchPlayerHarvestedCardToTrue()
    {
      Player player1 = new Player();

      player1.HarvestCardFromGardenSupply(2);
      Assert.True(player1.HarvestedCard);
    }

    [Fact]
    public void DoNothingIfPlayerHasHarvestedCardAlready()
    {
        Player player1 = new Player();

       player1.HarvestCardFromGardenSupply(1);
       player1.HarvestCardFromGardenSupply(1);
       
       Assert.True(player1.SharedGardenSupply.GetNumberOfCards() == 4);
       Assert.True(player1.Hand.Count == 6);
    }

    [Fact]
    public void DoNothingIfTheCardNumberIsInvalid()
    {
      Player player1 = new Player();

      player1.HarvestCardFromGardenSupply(0);
      player1.HarvestCardFromGardenSupply(6);
       
      Assert.True(player1.SharedGardenSupply.GetNumberOfCards() == 5);
      Assert.True(player1.Hand.Count == 5);
      Assert.False(player1.HarvestedCard);
    }
    [Fact]
    public void DoNothingIfPlayerIsInactive()
    {
      Player player1 = new Player();

      player1.PlayerToRight.HarvestCardFromGardenSupply(2);

       
      Assert.True(player1.SharedGardenSupply.GetNumberOfCards() == 5);
      Assert.True(player1.Hand.Count == 5);
      Assert.False(player1.HarvestedCard);
    }
   
    
}