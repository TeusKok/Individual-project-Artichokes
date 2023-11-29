using Artichokes;
namespace Repositories;

public interface IRepository
{
    public void Save(string key, string artichokeGameString);

    public IArtichokeGame GetGame(string key);
    public string GetGameString(string key);

    public Boolean ContainsKey(string key);
}