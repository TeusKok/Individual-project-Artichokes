namespace DTO;
using Artichokes;

public class DiscardPileDTO
{
    public CardDTO TopCard { get; set; }
    public DiscardPileDTO(DiscardPile discardPile)
    {
        List<ICard> cards = discardPile.GetCards();
        if (cards.Count > 0)
        {
            ICard topCard = cards[cards.Count - 1];
            this.TopCard = new CardDTO
            {
                CardName = topCard.CardName,
                CardDescription = topCard.CardDescription,
                MayBePlayed = false,
                Option = new OptionDTO
                {
                    Question = "",
                    Answers = Array.Empty<string>(),
                },
            };
        }
        else
        {
            this.TopCard = new CardDTO
            {
                CardName = "Empty",
                CardDescription = "",
                MayBePlayed = false,
                Option = new OptionDTO
                {
                    Question = "",
                    Answers = Array.Empty<string>(),
                },
            };
        }
    }
}