using System.Reflection.Metadata;

namespace Artichokes;
public class BroadBean : ICard
{
    public string AsString()
    {
        return "b";
    }

    public string GetCardDescription()
    {
        return "Playing this card will reveal the top two cards of the Garden Stock."
            + " You may choose which card goes to the discard pile of one other player,"
            + " the other card goes to your discard pile.";
    }

    public string GetCardName()
    {
        return "Broad Bean";
    }

    public string[] GetOptions(Player player)
    {
        string[] playerNames = new string[]{
            player.PlayerToRight.Name
            ,player.PlayerToRight.PlayerToRight.Name
            ,player.PlayerToRight.PlayerToRight.PlayerToRight.Name};
        string[] cardNames = new string[]{
            player.SharedGardenSupply.gardenStock.GetTopCard().GetCardName()
            ,player.SharedGardenSupply.gardenStock.GetSecondCard().GetCardName()};
        string s = "Pick One of these cards, it will be placed on the discard pile of the specified player. The other card gets placed on your discard pile|";
        
        s=s+cardNames[0]+" > "+playerNames[0]+"/"+cardNames[0]+" > "+playerNames[1]+"/"+cardNames[0]+" > "+playerNames[2]+"/"
            +cardNames[1]+" > "+playerNames[0]+"/"+cardNames[1]+" > "+playerNames[1]+"/"+cardNames[1]+" > "+playerNames[2];
    
        
        return new string[1] { s };

    }

    public bool MayBePlayed(Player player)
    {
        return true;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (MayBePlayed(player) && selectedOptions.Length == 1)
        {
            player.MoveCardToDiscardPileIfStillInHand(this);
            string selectedCardName = selectedOptions[0].Split(">")[0].Trim();
            string selectedPlayerName = selectedOptions[0].Split(">")[1].Trim();
            Player targetPlayer = player.GetPlayerByName(selectedPlayerName);
            
            ICard topCard = player.SharedGardenSupply.gardenStock.GetTopCard();
            ICard secondCard = player.SharedGardenSupply.gardenStock.GetSecondCard();
            if(selectedCardName.Equals(topCard.GetCardName())){
                player.DiscardPile.Add(secondCard);
                targetPlayer.DiscardPile.Add(topCard);
            }
            else{
                player.DiscardPile.Add(topCard);
                targetPlayer.DiscardPile.Add(secondCard);
            }
            player.SharedGardenSupply.gardenStock.RemoveTopCard();
            player.SharedGardenSupply.gardenStock.RemoveTopCard();
            
        }
    }
}