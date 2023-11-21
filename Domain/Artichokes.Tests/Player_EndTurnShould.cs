namespace Artichokes.UnitTests.PlayerTests;
public class Player_EndTurnShould{
    [Fact]
    public void EndTurnShouldTurnActivePlayerToInactive()
    {
        Player player1 = new Player();
        player1.EndTurn();

        Assert.False(player1.isActivePlayer);
    }
    [Fact]
    public void EndTurnShouldMakePlayerToRightOfActivePlayerActive()
    {
        Player player1 = new Player();
        player1.EndTurn();

        Assert.True(player1.PlayerToRight.isActivePlayer);
    }
    [Fact]
    public void EndTurnShouldDoNothingIfPlayerIsNotActive()
    {
        Player player1 = new Player();
        Player player2 = player1.PlayerToRight;
        player2.EndTurn();

        Assert.True(player1.isActivePlayer);
        Assert.False(player2.isActivePlayer);
        Assert.False(player2.PlayerToRight.isActivePlayer);
        Assert.False(player2.PlayerToRight.PlayerToRight.isActivePlayer);
    }
}