namespace Artichokes;
public class Broccoli : ICard
{
    public string GetCardDescription()
    {
        return "If you have three or more Artichokes in your hand, one will be removed";
    }

    public string GetCardName()
    {
        return "Broccoli";
    }

    public bool MayBePlayed(Player player)
    {
        int count = 0;
        for (int i = 0; i < player.Hand.Count; i++)
        {
            if(player.Hand[i].GetType()==typeof(Artichoke)){
                count++;
                if(count>=3) return true;
            }
            
        }
        return false;
    }

    public void Play(Player player)
    {
        if(MayBePlayed(player)){
            for (int i = 0; i < player.Hand.Count; i++)
            {
                if(player.Hand[i].GetType()==typeof(Artichoke)){
                    player.Hand.RemoveAt(i);
                    break;
                }
                
            }
        }
    }
}