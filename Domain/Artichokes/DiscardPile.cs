namespace Artichokes;

public class DiscardPile
{
    private List<ICard> Cards { get; set; } = new List<ICard>();
    private static readonly Random Rng = new Random();

    public void Add(ICard card)
    {
        Cards.Add(card);
    }

    public int NumberOfCards()
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
}