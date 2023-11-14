using System;

namespace Artichokes;
public class Artichoke : ICard
{
    

    public Crops Type {get; private set;} = Crops.Artichoke;

    public Artichoke()
    {

    }
    public void Play()
    {
        throw new NotImplementedException();
        
    }

    
}
