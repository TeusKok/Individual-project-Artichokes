
namespace Artichokes;

public class GardenStock
{
    private List<ICard> Cards { get; set; } = new List<ICard>();
    private static Random rng = new Random();


    public GardenStock()
    {
        for (int i = 0; i < 6; i++)
        {
            Cards.Add(new Potato());
            Cards.Add(new Broccoli());
            Cards.Add(new Carrot());
            Cards.Add(new Onion());
            Cards.Add(new Beet());
            Cards.Add(new Rubarb());
            Cards.Add(new Corn());
            Cards.Add(new Bellpepper());
            Shuffle();
        }
    }

    public GardenStock(string gardenStockString)
    {
        char[] cardChars = gardenStockString.ToCharArray();
        foreach (char cardChar in cardChars)
        {
            if (!cardChar.Equals('0'))
            {
                this.Cards.Add(Utilities.CardFromCharacter(cardChar));
            }
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

    public int GetNumberOfCards()
    {
        return Cards.Count;
    }

    public void Shuffle()
    {
        this.Cards = this.Cards.OrderBy(a => rng.Next()).ToList();
    }

    public string AsString()
    {
        string s = "";
        if (Cards.Count > 0)
        {
            foreach (ICard card in Cards)
            {
                s += card.AsString();
            }
        }
        else
        {
            s += "0";
        }
        return s;
    }
}