namespace Artichokes;
public class Carrot : ICard
{
    public string GetCardDescription()
    {
        return "Playing the carrot will remove it and two Artichokes from your end. This card has to be the first card you play on a turn, and also ends your turn";
    }

    public string GetCardName()
    {
        return "Carrot";
    }

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Count() >= 2 && player.Hand.Count == 6;

    }

    public void Play(Player player)
    {
        if (this.MayBePlayed(player))
        {
            List<ICard> cardsToRemove = new List<ICard>();
            IEnumerable<Artichoke> artichokes = player.Hand.OfType<Artichoke>().Take(2);
            player.Hand.Remove(this);
            player.Hand.RemoveAll((ICard card) => artichokes.Contains(card));
            player.EndTurn();
        }
    }
}