namespace Artichokes;
public class Carrot : ICard
{
    public string GetCardDescription()
    {
       return "Playing the carrot will remove it and two Artichokes from your end. This card has to be the first card you play on a turn, and also ends your turn";
    }

    public string GetCardName()
    {
        return "Carrot";
    }

    public bool MayBePlayed(Player player)
    {
        int count = 0;
        Boolean twoOrMoreArtichokes = false;
        if(player.Hand.Count==6){
            for (int i = 0; i < player.Hand.Count; i++)
            {
                if(player.Hand[i].GetType()==typeof(Artichoke)){
                    count++;
                    if(count>=2) {
                        twoOrMoreArtichokes =true;
                        break;
                    };
                } 
            }
            return twoOrMoreArtichokes;
        }
        else return false;
    }

    public void Play(Player player)
    {
        if(MayBePlayed(player)){

            List<ICard> cardsToRemove = new List<ICard>();
            IEnumerable<Carrot> carrots = player.Hand.OfType<Carrot>().Take(1);
            IEnumerable<Artichoke> artichokes = player.Hand.OfType<Artichoke>().Take(2);
           
            player.Hand.RemoveAll((ICard card)=>carrots.Contains(card));
            player.Hand.RemoveAll((ICard card)=>artichokes.Contains(card));
            player.EndTurn();
        }
    }
}