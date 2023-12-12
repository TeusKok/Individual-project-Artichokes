namespace Artichokes;
public class Eggplant : ICard
{
    public string EncodeAsString()
    {
        return "e";
    }

    public string CardDescription => "Both the Eggplant and one artichoke from your hand are removed from the game. "
            + "Then two random cards of each player are passed to the player to their left";

    public string CardName => "Eggplant";

    public string GetOption(Player player)
    {
        return string.Empty;
    }

    public bool MayBePlayedBy(Player player)
    {
        return player.Hand.OfType<Artichoke>().Any();
    }

    public void Play(Player player, string selectedOption)
    {
        if (MayBePlayedBy(player))
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().First();
            player.Hand.Remove(artichoke);
            player.Hand.Remove(this);
            player.MakeAllPlayersGiveTwoCardsToTheLeft();
        }
    }
}