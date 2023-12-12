namespace Artichokes;
public class Leek : ICard
{
    public string EncodeAsString()
    {
        return "l";
    }

    public string CardDescription => "Pick a player, if the top card of their drawpile"
            + " is an Artichoke it gets put on their discard pile."
            + " Otherwise the card goes to your Hand";

    public string CardName => "Leek";

    public string[] GetOptions(Player player)
    {
        string s = "Pick a player, if the top card of their drawpile"
            +" is an Artichoke it gets put on their discard pile."
            +" Otherwise the card goes to your Hand|";
        Player targetPlayer = player.PlayerToRight;
        for (int i = 0; i < 3; i++)
        {
            if (targetPlayer.DiscardPile.GetNumberOfCards() > 0 || targetPlayer.DrawPile.GetNumberOfCards() > 0)
            {
                s = s + targetPlayer.Name + "/";

            }
            targetPlayer = targetPlayer.PlayerToRight;
        }
        return new string[1] { s.Remove(s.Length - 1, 1) };

    }

    public bool MayBePlayed(Player player)
    {
        return true;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (selectedOptions.Length == 1)
        {
            Player targetPlayer = player.GetPlayerByName(selectedOptions[0]);
            targetPlayer.RefillDrawPileIfNeededAndPossible();
            ICard targetCard = targetPlayer.DrawPile.GetTopCard();
            if(targetCard.GetType().Equals(typeof(Artichoke))){
                targetPlayer.DiscardPile.Add(targetCard);
            }
            else{
                player.Hand.Add(targetCard);
            }
            targetPlayer.DrawPile.RemoveTopCard();
        }
    }
}