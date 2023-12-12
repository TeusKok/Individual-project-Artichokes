namespace Artichokes;

public class Onion : ICard
{
    public string EncodeAsString()
    {
        return "o";
    }

    public string CardDescription => "Removes an Artichoke from your hand. Then choose a player," +
        " the Onion will be put on their discardPile";

    public string CardName => "Onion";

    public string GetOption(Player player)
    {
        string s = $"Pick a player, the onion card will end up on their discardPile|" +
            $"{player.PlayerToRight.Name}/{player.PlayerToRight.PlayerToRight.Name}/" +
            $"{player.PlayerToRight.PlayerToRight.PlayerToRight.Name}";
        return s;
    }

    public bool MayBePlayedBy(Player player)
    {
        return player.Hand.OfType<Artichoke>().Any();
    }

    public void Play(Player player, string selectedOption)
    {
        if (MayBePlayedBy(player) && selectedOption.Length > 0)
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().Take(1).First();
            player.Hand.Remove(artichoke);
            Player targetPlayer = player.GetPlayerByName(selectedOption);
            targetPlayer.DiscardPile.Add(this);
            player.Hand.Remove(this);
        }
    }
}