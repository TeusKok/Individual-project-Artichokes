namespace Artichokes;
public class Beet : ICard
{
    public string GetCardDescription()
    {
        return "Pick a player, one card from your hand and one card from their hand gets picked at random," +
            " these cards are removed if both are artichokes or swapped if at least one is not";
    }

    public string GetCardName()
    {
        return "Beet";
    }

    public string[] GetOptions(Player player)
    {
        string s = "Pick a player, one card from you and one card from them gets picked at random,"
            + " these cards are removed if both are artichokes or swapped if at least one is not|"
            + player.PlayerToRight.Name + "/"
            + player.PlayerToRight.PlayerToRight.Name + "/"
            + player.PlayerToRight.PlayerToRight.PlayerToRight.Name;
        return new string[1] { s };
    }

    public bool MayBePlayed(Player player)
    {
        return true;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (selectedOptions.Length > 0)
        {

            player.Hand.Remove(this);
            player.DiscardPile.Add(this);
            Player targetPlayer = player.GetPlayerByName(selectedOptions[0]);
            Random rng = new Random();
            ICard playerCard = player.Hand[rng.Next(player.Hand.Count)];
            ICard targetCard = targetPlayer.Hand[rng.Next(targetPlayer.Hand.Count)];
            if (playerCard.GetType() != typeof(Artichoke)|| targetCard.GetType() != typeof(Artichoke)){
                player.Hand.Add(targetCard);
                targetPlayer.Hand.Add(playerCard);
            }
            player.Hand.Remove(playerCard);
            targetPlayer.Hand.Remove(targetCard);
        }
    }
    public string AsString()
    {
        return "t";
    }
}