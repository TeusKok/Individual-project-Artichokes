namespace Artichokes.UnitTests.Crops;

public class BroccoliTests{
    [Fact]
    public void MayBePlayedShoudlReturnTrueIfThereAreThreeOrMoreArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Broccoli());
        Assert.True(player1.Hand[5].MayBePlayed(player1));
    }
    [Fact]
    public void MayBePlayedShoudlReturnFalseIfThereAreLessThanThreeArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0,3);
        player1.Hand.Add(new Broccoli());
        Assert.False(player1.Hand[2].MayBePlayed(player1));
    }

    [Fact]
    public void PlayingBroccoliShouldRemoveOneArtichokeFromHand()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Broccoli());
        player1.Hand[5].Play(player1);
        Assert.True(player1.Hand.Count == 5);
        Assert.True(player1.Hand[4].GetType()==typeof(Broccoli));
    }
}