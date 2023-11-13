using System;

namespace Artichokes;

public enum Crops{
    Broccoli = 1,
    Beet = 2 ,
    Eggplant = 3,
    Potato = 4,
    Corn = 5,
    Leek = 6,
    Carrot = 7,
    Pepper = 8,
    Onion = 9 ,
    Bean  = 10,
    Rubarb = 11,

}
public class Crop : ICard
{
    public Crops Type {get; private set;}
    public string Description {get; private set;}

    public Crop(Crops type, string description ){
        this.Type = type;
        this.Description = description;
    }
}
