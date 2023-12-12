using System;
using System.Runtime.CompilerServices;

namespace Artichokes;


public enum Crops
{
    Broccoli = 1,
    Beet = 2,
    Eggplant = 3,
    Potato = 4,
    Corn = 5,
    Leek = 6,
    Carrot = 7,
    Pepper = 8,
    Onion = 9,
    Bean = 10,
    Rubarb = 11,
    Artichoke = 12,
}


public interface ICard
{

    void Play(Player player, String[] selectedOptions);

    String CardName { get; }

    String CardDescription { get; }

    Boolean MayBePlayed(Player player);

    String EncodeAsString();

    String[] GetOptions(Player player);




}
