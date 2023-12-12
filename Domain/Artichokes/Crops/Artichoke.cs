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

    public bool MayBePlayed(Player player)
    {
        return false;
    }

    public String EncodeAsString()
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
