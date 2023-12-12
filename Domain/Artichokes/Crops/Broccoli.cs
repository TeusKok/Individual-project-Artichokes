namespace Artichokes;
public class Broccoli : ICard
{
    public string CardDescription => "If you have three or more Artichokes in your hand, one will be removed";

    public string CardName => "Broccoli";

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Count() >= 3;
    }

    public String EncodeAsString()
    {
        return "i";
    }

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (MayBePlayed(player))
        {
            IEnumerable<Artichoke> artichoke = player.Hand.OfType<Artichoke>().Take(1);
            player.Hand.Remove(artichoke.First());
        }
    }
}