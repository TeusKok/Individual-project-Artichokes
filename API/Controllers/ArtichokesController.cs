using Artichokes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtichokesController : ControllerBase
{
    [HttpPost()]
    [Consumes("application/json")]
    public IActionResult Post(Dictionary<string,string> names)
    {
       ArtichokeGame game = new ArtichokeGame(names["name1"],names["name2"],names["name3"],names["name4"]);
       ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
       return Ok(gameDTO);
    }
}