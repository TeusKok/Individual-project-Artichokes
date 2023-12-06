namespace Artichokes;
public class Rubarb : ICard
{
    public string AsString()
    {
        return "r";
    }

    public string GetCardDescription()
    {
        return "refreshes the Garden Supply, you may then harvest a card from the new Supply";
    }

    public string GetCardName()
    {
        return "Rubarb";
    }

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }

    public bool MayBePlayed(Player player)
    {
        return true;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        while (player.SharedGardenSupply.GetNumberOfCards() > 0)
        {
            player.SharedGardenSupply.RemoveCardByNumber(player.SharedGardenSupply.GetNumberOfCards());
        }

        player.SharedGardenSupply.refillGardenSupply();
        player.SetHarvestedCardToFalse();
    }
}