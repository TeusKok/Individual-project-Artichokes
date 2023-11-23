namespace DTO;
using Artichokes;

public class HandDTO{
    public CardDTO[] Cards {get;} 

    public HandDTO(Player player){
        
        Cards = new CardDTO[player.Hand.Count];
        for (int i = 0; i < player.Hand.Count; i++)
        {
            Cards[i] = new CardDTO{
                CardName = player.Hand[i].GetCardName(),
                CardDescription = player.Hand[i].GetCardDescription(),
                MayBePlayed = player.Hand[i].MayBePlayed(player),
            };
        }
        
    }
}