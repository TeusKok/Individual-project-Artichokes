namespace Artichokes;
public class Eggplant : ICard
{
    public string AsString()
    {
        return "e";
    }

    public string GetCardDescription()
    {
        return "Both the Eggplant and one artichoke from your hand are removed from the game. "
            + "Then two random cards of each player are passed to the player to their left";
    }

    public string GetCardName()
    {
        return "Eggplant";
    }

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Any();
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (MayBePlayed(player))
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().First();
            player.Hand.Remove(artichoke);
            player.Hand.Remove(this);
        }
    }
}