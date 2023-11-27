namespace Artichokes;
public class Broccoli : ICard
{
    public string GetCardDescription()
    {
        return "If you have three or more Artichokes in your hand, one will be removed";
    }

    public string GetCardName()
    {
        return "Broccoli";
    }

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Count() >= 3;
    }

    public void Play(Player player)
    {
        if (MayBePlayed(player))
        {
            IEnumerable<Artichoke> artichoke = player.Hand.OfType<Artichoke>().Take(1);
            player.Hand.Remove(artichoke.First());
        }
    }

    public String AsString()
    {
        return "i";
    }
}