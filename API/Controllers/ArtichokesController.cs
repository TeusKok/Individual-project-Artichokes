using Artichokes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtichokesController : ControllerBase
{
    ArtichokeGame saved;
    [HttpPost()]
    [Consumes("application/json")]
    public IActionResult Post(Dictionary<string,string> names)
    {
       ArtichokeGame game = new ArtichokeGame(names["name1"],names["name2"],names["name3"],names["name4"]);
       ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
       saved = game;
       return Ok(gameDTO);
    }
    [HttpPost("endturn")]
    public IActionResult Post()
    {


        ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(saved);
        
        return Ok(gameDTO);
    }
}