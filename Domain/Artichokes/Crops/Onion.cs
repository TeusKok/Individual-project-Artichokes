namespace Artichokes;

public class Onion : ICard
{
    public string EncodeAsString()
    {
        return "o";
    }

    public string CardDescription => "Removes an Artichoke from your hand. Then choose a player, the Onion will be put on their discardPile";

    public string CardName => "Onion";

    public string[] GetOptions(Player player)
    {
        string s = "Pick a player, the onion card will end up on their discardPile|" + player.PlayerToRight.Name + "/"
            + player.PlayerToRight.PlayerToRight.Name + "/"
            + player.PlayerToRight.PlayerToRight.PlayerToRight.Name;
        return new string[1] { s };
    }

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Count() >= 1;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (MayBePlayed(player) && selectedOptions.Length == 1)
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().Take(1).First();
            player.Hand.Remove(artichoke);
            Player targetPlayer = player.GetPlayerByName(selectedOptions[0]);
            targetPlayer.DiscardPile.Add(this);
            player.Hand.Remove(this);
        }
    }
}