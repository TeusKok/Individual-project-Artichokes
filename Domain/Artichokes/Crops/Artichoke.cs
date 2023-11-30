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

    public String AsString()
    {
        return "a";
    }

    public void Play(Player player, string[] selectedOptions)
    {
        throw new NotImplementedException();
    }

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }
}
