namespace Artichokes.UnitTests.Crops;

public class CornTests
{
    [Fact]
    public void MayBePlayedShouldReturnFalseIfThereAreNoArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.Clear();
        player1.Hand.Add(new Corn());
        Assert.False(player1.Hand[0].MayBePlayed(player1));
    }
    [Fact]
    public void MayBePlayedShouldReturnTrueIfThereIsOneArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 4);
        player1.Hand.Add(new Corn());
        Assert.True(player1.Hand[1].MayBePlayed(player1));
    }
    [Fact]
    public void MayBePlayedShouldReturnTrueIfThereAreMoreThanOneArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 2);
        player1.Hand.Add(new Corn());
        Assert.True(player1.Hand[3].MayBePlayed(player1));
    }
    [Fact]
    public void GetOptionsShouldGiveStringWithCardsFromGardenSupply()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Corn());
        string[] options = player1.Hand[5].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");
        Assert.Equal(Answers[0].Split(":")[1].Trim(), player1.SharedGardenSupply.GetCardByNumber(1).GetCardName());
        Assert.Equal(Answers[1].Split(":")[1].Trim(), player1.SharedGardenSupply.GetCardByNumber(2).GetCardName());

        Assert.Equal("1", Answers[0].Split(":")[0].Trim());
        Assert.Equal("2", Answers[1].Split(":")[0].Trim());
    }

    [Fact]
    public void PlayShouldMoveOneArtichokeFromHandToDiscardPile()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Corn());
        player1.Hand[5].Play(player1, new string[] { "1: NotImportantForPlayMethod" });
        Assert.True(player1.DiscardPile.GetNumberOfCards() == 1);
        Assert.True(player1.DiscardPile.GetCards()[0].GetType() == typeof(Artichoke));
        Assert.True(player1.Hand.Count == 5);
    }
    [Fact]
    public void PlayShouldAddTheSpecifiedCardFromGardenSupplyToTheTopOfTheDrawPile()
    {
        Player player1 = new Player("Piet/aaaaC/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|pppppppp|pitco");

        string[] options = player1.Hand[4].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");
        player1.Hand[4].Play(player1, new string[] { Answers[0] });

        Assert.True(player1.DrawPile.GetTopCard().GetType() == typeof(Potato));
        Assert.True(player1.SharedGardenSupply.GetNumberOfCards() == 4);
    }
}