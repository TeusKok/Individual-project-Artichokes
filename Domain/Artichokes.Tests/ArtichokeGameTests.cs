namespace Artichokes.UnitTests.Game;

public class ArtichokeGameTests
{
    [Fact]
    public void GameObjectedCreatedFromGameStringGivesSameStringWithAsStringMethod()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");
        String gameAsString = game.AsString();
        ArtichokeGame gameCopy = new ArtichokeGame(gameAsString);
        string gameCopyString = gameCopy.AsString();
        Assert.Equal(gameAsString, gameCopyString);

    }

    [Fact]
    public void GetPlayerNumberByNameGivesCorrectNumber()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");

        Assert.Equal(1, game.getPlayerNumberByName("Piet"));
        Assert.Equal(2, game.getPlayerNumberByName("Jan"));
        Assert.Equal(3, game.getPlayerNumberByName("Joop"));
        Assert.Equal(4, game.getPlayerNumberByName("Jaap"));
        Assert.Equal(0, game.getPlayerNumberByName("NotAKnownName1234"));
    }
    [Fact]
    public void GetPlayerByNumberGivesCorrectPlayer()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");


        Assert.Equal("Piet", game.getPlayerByNumber(1).Name);
        Assert.Equal("Jan", game.getPlayerByNumber(2).Name);
        Assert.Equal("Joop", game.getPlayerByNumber(3).Name);
        Assert.Equal("Jaap", game.getPlayerByNumber(4).Name);
    }
    [Fact]
    public void GetPlayerByNumberThrowsExceptionIfNumberIncorrect()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");
        Assert.Throws<InvalidOperationException>(() => game.getPlayerByNumber(0));
        Assert.Throws<InvalidOperationException>(() => game.getPlayerByNumber(-1));
        Assert.Throws<InvalidOperationException>(() => game.getPlayerByNumber(5));
    }
    [Fact]
    public void getActivePlayerGivesCorrectPlayer()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");
        Player player1 = game.getPlayerByNumber(1);

        Player firstActivePlayer = game.getActivePlayer();
        game.endTurnOfPlayer(1);
        Player secondActivePlayer = game.getActivePlayer();
        game.endTurnOfPlayer(2);
        Player thirdActivePlayer = game.getActivePlayer();
        game.endTurnOfPlayer(3);
        Player fourthActivePlayer = game.getActivePlayer();
        game.endTurnOfPlayer(4);
        Player fifthActivePlayer = game.getActivePlayer();

        Assert.Equal(player1, firstActivePlayer);
        Assert.Equal(player1.PlayerToRight, secondActivePlayer);
        Assert.Equal(player1.PlayerToRight.PlayerToRight, thirdActivePlayer);
        Assert.Equal(player1.PlayerToRight.PlayerToRight.PlayerToRight, fourthActivePlayer);
        Assert.Equal(player1, fifthActivePlayer);
    }
    [Fact]
    public void GetWinnerReturnsNoOneYetIfGameNotOver()
    {
        ArtichokeGame game = new ArtichokeGame("Piet", "Jan", "Joop", "Jaap");

        Assert.Equal(IArtichokeGame.Winner.NoOneYet,game.GetWinner());
    }
    [Fact]
    public void GetWinnerReturnsCorrectPlayerIfThatPlayerHasWon()
    {
        ArtichokeGame game = new ArtichokeGame("Piet/aaaaa/0/0/0/1|Jan/PPPPP/0/0/0/0|Joop/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|0|0");

        Assert.Equal(IArtichokeGame.Winner.PlayerTwo,game.GetWinner());
    }
}