using System;

namespace Artichokes;


public class Crop : ICard
{
    public Crops Type {get; private set;}
    public string Description {get; private set;}

    public Crop(Crops type, string description ){
        this.Type = type;
        this.Description = description;
    }

    public void Play(Player player)
    {
        throw new NotImplementedException();
    }

    public string getCardName()
    {
        throw new NotImplementedException();
    }

    public string getCardDescription()
    {
        throw new NotImplementedException();
    }
}
