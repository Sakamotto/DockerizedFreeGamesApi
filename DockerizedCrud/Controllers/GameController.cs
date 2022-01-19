using DockerizedCrud.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DockerizedCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        public IGameService GameService { get; set; }

        public GameController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await GameService.GetAll());

        [HttpGet]
        [Route("platform")]
        public async Task<IActionResult> GetByPlatform([Required] string platform) =>
            Ok(await GameService.GetByPlatform(platform));


        [HttpGet]
        [Route("category")]
        public async Task<IActionResult> GetByCategory([Required] string category) =>
            Ok(await GameService.GetByCategory(category));
    }
}
