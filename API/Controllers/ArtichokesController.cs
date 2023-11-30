using Artichokes;
using Repositories;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Diagnostics.CodeAnalysis;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtichokesController : ControllerBase
{
    private IRepository _repository;
    private const string SessionGameState = "_GameState";
    private const string SessionClientID = "_ClientId";


    public ArtichokesController(IRepository repository)
    {
        _repository = repository;
    }
    [HttpPost()]
    [Consumes("application/json")]
    public IActionResult Post(Dictionary<string, string> body)
    {
        string Id;
        IArtichokeGame game;
        if ((!body["Id"].Equals("404")) && _repository.ContainsKey(body["Id"]))
        {
            Id = body["Id"];
            HttpContext.Session.SetString(SessionClientID, Id);
            game = _repository.GetGame(Id);
        }
        else
        {
            Id = Guid.NewGuid().ToString();
            HttpContext.Session.SetString(SessionClientID, Id);
            game = new ArtichokeGame(body["name1"], body["name2"], body["name3"], body["name4"]);
        }

        return SaveGameAndConvertToDTO(Id, game);
    }
    [HttpPost("endturn")]
    [Consumes("application/json")]
    public IActionResult PostEndTurn(Dictionary<string, string> body)
    {
        IArtichokeGame game;
        string Id = body["Id"];
        game = GetGameFromSessionOrRepository(Id);

        int playerNumber = game.getPlayerNumberByName(body.First().Value);
        game.endTurn(playerNumber);

        return SaveGameAndConvertToDTO(Id, game);
    }
    [HttpPost("harvest")]
    [Consumes("application/json")]
    public IActionResult PostHarvest(Dictionary<string, string> body)
    {
        IArtichokeGame game;
        string Id = body["Id"];
        game = GetGameFromSessionOrRepository(Id);

        Player player = game.getActivePlayer();
        player.HarvestCardFromGardenSupply(Int32.Parse(body.First().Value));

        return SaveGameAndConvertToDTO(Id, game);
    }



    [HttpPost("playcard")]
    [Consumes("application/json")]
    public IActionResult PostPlayCard(PlayCardBody body)
    {
        IArtichokeGame game;
        string Id = body.Id;
        game = GetGameFromSessionOrRepository(Id);

        Player player = game.getActivePlayer();
        player.PlayCardFromHandByNumber(body.cardToPlay, body.selectedOptions);

        return SaveGameAndConvertToDTO(Id, game);
    }

    [HttpPost("newgame")]
    [Consumes("application/json")]
    public IActionResult PostNewGame(Dictionary<string, string> body)
    {
        string Id = body["Id"];
        IArtichokeGame game = new ArtichokeGame(body["name1"], body["name2"], body["name3"], body["name4"]);
        return SaveGameAndConvertToDTO(Id, game);
    }

    private IArtichokeGame GetGameFromSessionOrRepository(string Id)
    {
        IArtichokeGame game;
        if (HttpContext.Session.Get(SessionGameState) == null)
        {
            game = _repository.GetGame(Id);
        }
        else
        {
            game = new ArtichokeGame(HttpContext.Session.GetString(SessionGameState) ?? "");
        }
        return game;
    }

    private IActionResult SaveGameAndConvertToDTO(string Id, IArtichokeGame game)
    {
        string gameString = game.AsString();

        HttpContext.Session.SetString(SessionGameState, gameString);
        _repository.Save(Id, gameString);

        ArtichokeGameDTO gameDTO = new ArtichokeGameDTO(game, Id);
        return Ok(gameDTO);
    }
}

public class PlayCardBody{
    public int cardToPlay {get; set;}
    
    public string Id {get; set;}
    public string[] selectedOptions {get; set;}

}