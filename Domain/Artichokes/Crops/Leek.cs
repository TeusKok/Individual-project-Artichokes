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

    public string GetOption(Player player)
    {
        string s = "Pick a player, if the top card of their drawpile"
            +" is an Artichoke it gets put on their discard pile."
            +" Otherwise the card goes to your Hand|";
        Player targetPlayer = player.PlayerToRight;
        for (int i = 0; i < 3; i++)
        {
            if (targetPlayer.DiscardPile.GetNumberOfCards() > 0 || targetPlayer.DrawPile.GetNumberOfCards() > 0)
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
        if (selectedOption.Length > 0)
        {
            Player targetPlayer = player.GetPlayerByName(selectedOption);
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