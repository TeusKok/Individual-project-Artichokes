namespace Artichokes.UnitTests.Crops;

public class BroadBeanTests
{
    [Fact]
    public void MayBePlayedReturnsTrue()
    {
        Player player1 = new Player();
        player1.Hand.Add(new BroadBean());
        Assert.True(player1.Hand[5].MayBePlayed(player1));
    }
    [Fact]
    public void GetOptionsShouldGiveStringWithTopTwoCardsFromGardenStockForEachOtherPlayer()
    {
        Player player1 = new Player("Piet/aaaaab/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|pCc|0");

        string[] options = player1.Hand[5].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");

        Assert.Equal("Potato", Answers[0].Split(">")[0].Trim());
        Assert.Equal("Joop", Answers[0].Split(">")[1].Trim());

        Assert.Equal("Potato > Jan", Answers[1].Trim());
        Assert.Equal("Potato > Jaap", Answers[2].Trim());
        Assert.Equal("Corn > Joop", Answers[3].Trim());
    }
    [Fact]
    public void PlayShouldAddTheRightCardsToTheRigthDiscardPiles()
    {
        Player player1 = new Player("Piet/aaaaab/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|pCc|0");

        string[] options = player1.Hand[5].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");
        player1.Hand[5].Play(player1,new string[]{Answers[0]});

        Assert.Equal(2,player1.DiscardPile.GetNumberOfCards());
        Assert.Equal(1,player1.PlayerToRight.DiscardPile.GetNumberOfCards());

        Assert.Equal(typeof(BroadBean),player1.DiscardPile.GetCards()[0].GetType());
        Assert.Equal(typeof(Corn),player1.DiscardPile.GetCards()[1].GetType());
        Assert.Equal(typeof(Potato),player1.PlayerToRight.DiscardPile.GetCards()[0].GetType());
    }
    [Fact]
    public void PlayShouldReduceTheGardenstockBy2Cards()
    {
        Player player1 = new Player("Piet/aaaaab/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|pCc|0");

        string[] options = player1.Hand[5].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");
        player1.Hand[5].Play(player1,new string[]{Answers[0]});

        Assert.Equal(1,player1.SharedGardenSupply.gardenStock.GetNumberOfCards());
    }
}