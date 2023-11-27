namespace Artichokes.UnitTests.Game;

public class ArtichokeGameTests{
    [Fact]
    public void TestName()
    {
        ArtichokeGame game = new ArtichokeGame("piet","jan","joop","jaap");
        String gameAsString = game.AsString();
        ArtichokeGame gameCopy = new ArtichokeGame(gameAsString);
        string gameCopyString =gameCopy.AsString();
        Assert.Equal(gameAsString,gameCopyString);
    }
}