
using Artichokes;

public class Repository{
    private Dictionary<string,ArtichokeGame> games = new Dictionary<string, ArtichokeGame>();

    public void save(string key, ArtichokeGame game){
        
        if(games.ContainsKey(key)){
            games.Remove(key);
        }
        games.Add(key,game);

        
    }

    public ArtichokeGame Get(string key){
        return games[key];
    }
}