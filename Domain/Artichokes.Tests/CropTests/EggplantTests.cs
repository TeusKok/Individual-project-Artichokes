namespace Artichokes.UnitTests.Crops;

public class EggplantTests
{
    [Fact]
    public void MayBePlayedShouldReturnFalseIfThereAreNoArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.Clear();
        player1.Hand.Add(new Eggplant());
        Assert.False(player1.Hand[0].MayBePlayed(player1));
    }
    [Fact]
    public void MayBePlayedShouldReturnTrueIfThereIsOneArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 4);
        player1.Hand.Add(new Eggplant());
        Assert.True(player1.Hand[1].MayBePlayed(player1));
    }
    [Fact]
    public void PlayShouldRemoveTheEggplantAndOneArtichoke()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Eggplant());
        player1.Hand[5].Play(player1, Array.Empty<string>());
        Assert.Equal(4,player1.Hand.Count);
    }
    [Fact]
    public void PlayShouldMoveUpToTwoCardOfEachPlayerToThePlayerToTheirLeft()
    {
        Player player1 = new Player("Piet/a/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/r/0/0/0/0|Jaap/ccccc/0/0/0/0|0|0");
        player1.Hand.Add(new Eggplant());
        player1.Hand[1].Play(player1, Array.Empty<string>());

        Assert.Equal(2,player1.Hand.Count);
        Assert.Equal(2,player1.GetPlayerByName("Jan").Hand.Count);
        Assert.Equal(3,player1.GetPlayerByName("Jaap").Hand.Count);
        Assert.Equal(4,player1.GetPlayerByName("Joop").Hand.Count);
        Assert.True(player1.Hand.OfType<Potato>().Count()==2);
        Assert.True(player1.GetPlayerByName("Joop").Hand.OfType<Rubarb>().Count()==1);
        Assert.True(player1.GetPlayerByName("Jan").Hand.OfType<Carrot>().Count()==2);
        Assert.True(player1.GetPlayerByName("Jaap").Hand.OfType<Carrot>().Count()==3);
    }
}