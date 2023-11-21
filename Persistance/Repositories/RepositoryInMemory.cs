
using Artichokes;
namespace Repositories;

public class RepositoryInMemory: IRepository{
    private Dictionary<string,IArtichokeGame> games = new Dictionary<string, IArtichokeGame>();

    public void Save(string key, IArtichokeGame game){
        
        if(games.ContainsKey(key)){
            games.Remove(key);
        }
        games.Add(key,game);

        
    }

    public IArtichokeGame Get(string key){
        return games[key];
    }
}