namespace Artichokes.UnitTests.Crops;

public class BeetTests
{
    [Fact]
    public void MaybePlayedReturnsTrue()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Beet());

        Assert.True(player1.Hand[5].MayBePlayed(player1));
    }
    [Fact]
    public void AsStringGivesTheLetterT()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Beet());

        Assert.True(player1.Hand[5].AsString()=="t"); 
    }
    [Fact]
    public void GetOptionsGivesTheNamesOfTheOtherPlayers()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Beet());
        string[] options = player1.Hand[5].GetOptions(player1);
        string[] Answers = options[0].Split("|")[1].Split("/");


        Assert.Equal("Joop",Answers[0]); 
        Assert.Equal("Jan",Answers[1]); 
        Assert.Equal("Jaap",Answers[2]); 
    }
    [Fact]
    public void PLayShouldDoNothingIfNoChoiceWasSupplied()
    {
        Player player1 = new Player();
        ICard beet = new Beet();
        player1.Hand.Add(beet);
        player1.Hand[5].Play(player1,Array.Empty<string>());
        Assert.Contains(beet, player1.Hand);
    }
    [Fact]
    public void PlayShouldRemoveBeetFromHand()
    {
        Player player1 = new Player();
        ICard beet = new Beet();
        player1.Hand.Add(beet);
        player1.Hand[5].Play(player1,new string[]{"Joop"});
        Assert.DoesNotContain(beet, player1.Hand);
    }
    [Fact]
    public void PlayShouldAddBeetToDiscardPile()
    {
        
        Player player1 = new Player();
        ICard beet = new Beet();
        player1.Hand.Add(beet);
        player1.Hand[5].Play(player1,new string[]{"Joop"});
        Assert.Contains(beet, player1.DiscardPile.GetCards());
    }
    [Fact]
    public void PlayShouldRemoveTheSelectedCardsIfTheyAreBothArtichokes()
    {
        Player player1 = new Player();
        ICard beet = new Beet();
        player1.Hand.Add(beet);
        player1.Hand[5].Play(player1,new string[]{"Joop"});

        Assert.True(player1.Hand.Count==4);
        Assert.True(player1.PlayerToRight.Hand.Count==4);
    }
    [Fact]
    public void PlayShouldNotRemoveTheSelectedCardsIfOneOfThemIsNotAnArtichoke()
    {
        Player player1 = new Player();
        player1.Hand.Clear();
        ICard[] cards = { new Carrot(), new Carrot(), new Carrot(), new Carrot(), new Carrot(), new Beet() };
        player1.Hand.AddRange(new List<ICard>(cards));
        player1.Hand[5].Play(player1,new string[]{"Joop"});

        Assert.True(player1.Hand.Count==5);
        Assert.True(player1.PlayerToRight.Hand.Count==5);
    }
    [Fact]
    public void PlayShouldSwapCardsTheSelectedIfOneOfThemIsNotAnArtichoke()
    {
         Player player1 = new Player();
        player1.Hand.Clear();
        ICard[] cards = { new Carrot(), new Carrot(), new Carrot(), new Carrot(), new Carrot(), new Beet() };
        player1.Hand.AddRange(new List<ICard>(cards));
        player1.Hand[5].Play(player1,new string[]{"Joop"});

        Assert.True(player1.Hand.OfType<Artichoke>().Count()==1);
        Assert.True(player1.Hand.OfType<Carrot>().Count()==4);
        Assert.True(player1.PlayerToRight.Hand.OfType<Carrot>().Count()==1);
        Assert.True(player1.PlayerToRight.Hand.OfType<Artichoke>().Count()==4);
    }
}