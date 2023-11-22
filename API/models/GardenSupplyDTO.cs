namespace DTO;
using Artichokes;
public class GardenSupplyDTO
{
    public CardDTO[] Cards {get;}
    public Boolean CardHarvestingAllowed{get;set;}

    public GardenSupplyDTO(GardenSupply gardenSupply,Boolean cardHarvestingAllowed){
        int numberOfCards = gardenSupply.GetNumberOfCards();
        Cards = new CardDTO[numberOfCards];
        this.CardHarvestingAllowed = cardHarvestingAllowed;
        for (int i = 0; i < numberOfCards; i++)
        {
            ICard card = gardenSupply.GetCardByNumber(i+1);
            Cards[i] = new CardDTO{
                CardName = card.getCardName(),
                CardDescription = card.getCardDescription()
            };
        }
    }
}