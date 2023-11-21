namespace DTO;
using Artichokes;

public class HandDTO{
    public CardDTO[] Cards {get;} 

    public HandDTO(List<ICard> cards){
        Cards = new CardDTO[cards.Count];
        for (int i = 0; i < cards.Count; i++)
        {
            Cards[i] = new CardDTO{
                CardName = cards[i].getCardName(),
                CardDescription = cards[i].getCardDescription()
            };
        }
        
    }
}