namespace Artichokes;
public class Beet : ICard
{
    public string CardDescription => "Pick a player, one card from your hand and one card from their hand gets picked at random," +
            " these cards are removed if both are artichokes or swapped if at least one is not";

    public string CardName => "Beet";

    public string GetOption(Player player)
    {
        string s = "Pick a player, one card from you and one card from them gets picked at random,"
            + " these cards are removed if both are artichokes or swapped if at least one is not|";
        Player targetPlayer = player.PlayerToRight;
        for (int i = 0; i < 3; i++)
        {
            if (targetPlayer.Hand.Count>0)
            {
                s = $"{s}{targetPlayer.Name}/";
                
            }
            targetPlayer = targetPlayer.PlayerToRight;
        }
        if (s.Last().Equals('/')) s = s.Remove(s.Length - 1, 1);
        return s;
    }

    public bool MayBePlayedBy(Player player)
    {
        return true;
    }

    public void Play(Player player, string selectedOption)
    {
        if (selectedOption.Length>0)
        {
            player.Hand.Remove(this);
            player.DiscardPile.Add(this);
            Player targetPlayer = player.GetPlayerByName(selectedOption);
            Random rng = new Random();
            ICard playerCard = player.Hand[rng.Next(player.Hand.Count)];
            ICard targetCard = targetPlayer.Hand[rng.Next(targetPlayer.Hand.Count)];
            if (playerCard.GetType() != typeof(Artichoke) || targetCard.GetType() != typeof(Artichoke))
            {
                player.Hand.Add(targetCard);
                targetPlayer.Hand.Add(playerCard);
            }
            player.Hand.Remove(playerCard);
            targetPlayer.Hand.Remove(targetCard);
        }
    }
    public string EncodeAsString()
    {
        return "t";
    }
}