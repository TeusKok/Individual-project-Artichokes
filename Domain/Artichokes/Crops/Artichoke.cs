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

    public string CardName => "Artichoke";

    public string CardDescription => "This is an Artichoke";

    public bool MayBePlayedBy(Player player)
    {
        return false;
    }

    public String EncodeAsString()
    {
        return "a";
    }

    public void Play(Player player, string selectedOption)
    {
        throw new InvalidCardPlayedException("An artichoke can not be played");
    }

    public string GetOption(Player player)
    {
        return string.Empty;
    }
}
