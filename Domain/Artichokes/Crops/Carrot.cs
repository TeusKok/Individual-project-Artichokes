namespace Artichokes;
public class Carrot : ICard
{
    public string CardDescription => "Playing the carrot will remove it and two Artichokes from your end. "
        + "This card has to be the first card you play on a turn, and also ends your turn";

    public string CardName => "Carrot";

    public bool MayBePlayedBy(Player player)
    {
        return player.Hand.OfType<Artichoke>().Count() >= 2 && !player.PlayedCard;

    }

    public String EncodeAsString()
    {
        return "c";
    }

    public string GetOption(Player player)
    {
        return string.Empty;
    }

    public void Play(Player player, string selectedOption)
    {
        if (this.MayBePlayedBy(player))
        {
            List<ICard> cardsToRemove = new List<ICard>();
            IEnumerable<Artichoke> artichokes = player.Hand.OfType<Artichoke>().Take(2);
            player.Hand.Remove(this);
            player.Hand.RemoveAll((ICard card) => artichokes.Contains(card));
            player.EndTurn();
        }
    }
}