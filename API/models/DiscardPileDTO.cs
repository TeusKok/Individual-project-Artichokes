namespace DTO;
using Artichokes;

public class DiscardPileDTO
{
    public CardDTO TopCard { get; set; }
    public DiscardPileDTO(DiscardPile discardPile)
    {
        List<ICard> cards = discardPile.getCards();
        if (cards.Count > 0)
        {
            ICard topCard = cards[cards.Count - 1];
            this.TopCard = new CardDTO
            {
                CardName = topCard.GetCardName(),
                CardDescription = topCard.GetCardDescription(),
                MayBePlayed = false,
            };
        }
        else
        {
            this.TopCard = new CardDTO
            {
                CardName = "Empty",
                CardDescription = "",
                MayBePlayed = false,
            };
        }
    }
}