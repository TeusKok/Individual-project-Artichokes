namespace Artichokes;

public class DiscardPile
{
    private List<ICard> Cards { get; set; } = new List<ICard>();
    private static readonly Random Rng = new Random();

    public DiscardPile()
    {

    }

    public DiscardPile(string discardPileString)
    {
        char[] cardChars = discardPileString.ToCharArray();
        foreach (char cardChar in cardChars)
        {
            if (!cardChar.Equals('0'))
            {
                this.Cards.Add(Utilities.CardFromCharacter(cardChar));
            }
        }
    }

    public void Add(ICard card)
    {
        Cards.Add(card);
    }

    public int GetNumberOfCards()
    {
        return Cards.Count;
    }

    public void EmptyDiscardPile()
    {

        Cards.Clear();

    }

    public void Shuffle()
    {
        this.Cards = this.Cards.OrderBy(a => Rng.Next()).ToList();
    }

    public List<ICard> GetCards()
    {
        return this.Cards;
    }

    /// <summary>
    /// Encodes DiscardPile contents as string
    /// </summary>
    /// <returns>String with one character for each card in order</returns>
    public string EncodeAsString()
    {
        string s = "";
        if (Cards.Count > 0)
        {
            foreach (ICard card in Cards)
            {
                s += card.EncodeAsString();
            }
        }
        else
        {
            s += "0";
        }

        return s;
    }
}