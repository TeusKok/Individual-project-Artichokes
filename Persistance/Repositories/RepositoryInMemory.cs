
using Artichokes;
namespace Repositories;

public class RepositoryInMemory : IRepository
{
    private Dictionary<string, string> GameStrings = new Dictionary<string, string>();

    public void Save(string key, string artichokeGameString)
    {

        if (GameStrings.ContainsKey(key))
        {
            GameStrings.Remove(key);
        }
        GameStrings.Add(key, artichokeGameString);


    }

    public IArtichokeGame GetGame(string key)
    {
        return new ArtichokeGame(GameStrings[key]);
    }

    public bool ContainsKey(string key)
    {
        return GameStrings.ContainsKey(key);
    }

    public string GetGameString(string key)
    {
        return GameStrings[key];
    }
}