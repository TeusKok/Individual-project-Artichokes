namespace Artichokes;

public class DiscardPile : ICardCollection{
    private List<ICard> discardPile = new List<ICard>();

    public void Add(ICard card){
        discardPile.Add(card);
    }

    public int NumberOfCards(){
        return discardPile.Count;
    }

    public List<ICard> EmptyDiscardPile(){
        List<ICard> cards = new List<ICard>();
        cards.AddRange(discardPile);
        discardPile.Clear();
        return cards;
    }

    public void shuffle()
    {
        throw new NotImplementedException();
    }

    public List<ICard> getCards(){
        return this.discardPile;
    }
}