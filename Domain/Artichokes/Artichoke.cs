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

    public string getCardName()
    {
        return "Artichoke";
    }

    public string getCardDescription()
    {
        return "This is an Artichoke";
    }
}
