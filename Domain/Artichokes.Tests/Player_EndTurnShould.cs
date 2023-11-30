namespace Artichokes.UnitTests.PlayerTests;
public class Player_EndTurnShould
{
    [Fact]
    public void EndTurnShouldTurnActivePlayerToInactive()
    {
        Player player1 = new Player();
        player1.EndTurn();

        Assert.False(player1.IsActivePlayer);
    }
    [Fact]
    public void EndTurnShouldMakePlayerToRightOfActivePlayerActive()
    {
        Player player1 = new Player();
        player1.EndTurn();

        Assert.True(player1.PlayerToRight.IsActivePlayer);
    }
    [Fact]
    public void EndTurnShouldDoNothingIfPlayerIsNotActive()
    {
        Player player1 = new Player();
        Player player2 = player1.PlayerToRight;
        player2.EndTurn();

        Assert.True(player1.IsActivePlayer);
        Assert.False(player2.IsActivePlayer);
        Assert.False(player2.PlayerToRight.IsActivePlayer);
        Assert.False(player2.PlayerToRight.PlayerToRight.IsActivePlayer);
    }
    [Fact]
    public void SetPlayerHarvestedToTrue()
    {
        Player player1 = new Player();
        player1.HarvestCardFromGardenSupply(1);
        player1.EndTurn();

        Assert.False(player1.HarvestedCard);
    }
    [Fact]
    public void RefillHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveAt(4);
        player1.EndTurn();
        Assert.True(player1.Hand.Count == 5);
    }
    [Fact]
    public void DiscardHandAndThenRefillHand()
    {
        Player player1 = new Player();
        ICard potato = new Potato();
        player1.Hand.Add(potato);
        player1.EndTurn();
        Assert.DoesNotContain(potato, player1.Hand);
    }
    [Fact]
    public void SetPlayedCardToFalse()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Potato());
        player1.PlayCardFromHandByNumber(6,Array.Empty<string>());
        player1.EndTurn();
        Assert.False(player1.PlayedCard);

    }
}