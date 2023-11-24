
namespace Artichokes;

public class GardenStock{
    private List<ICard> Cards{ get; set;}= new List<ICard>(); 
    private static Random rng = new Random();
    

    public GardenStock(){
        for (int i = 0; i < 6; i++)
        {
            Cards.Add(new Potato());
            Cards.Add(new Broccoli());
            Cards.Add(new Carrot());
            Shuffle();

        }
    }

    public ICard getTopCard()
    {
        return Cards[0];
    }

    public void removeTopCard()
    {
        Cards.RemoveAt(0);
    }

    public int GetNumberOfCards(){
        return Cards.Count;
    }

    public void Shuffle(){
        this.Cards = this.Cards.OrderBy(a => rng.Next()).ToList();
    }
}