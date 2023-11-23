using System;

namespace Artichokes;
public class Artichoke : ICard
{

    public Artichoke()
    {

    }
    public void Play(Player player)
    {
        throw new NotImplementedException();
    }

    public string GetCardName()
    {
        return "Artichoke";
    }

    public string GetCardDescription()
    {
        return "This is an Artichoke";
    }

    public bool MayBePlayed(Player player)
    {
        return false;
    }
}
