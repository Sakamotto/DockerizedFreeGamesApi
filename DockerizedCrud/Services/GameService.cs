using DockerizedCrud.Interfaces;
using DockerizedCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerizedCrud.Services
{
    public class GameService : IGameService
    {
        private GameHttpService _gameHttpService { get; set; }

        public GameService(GameHttpService gameHttpService)
        {
            _gameHttpService = gameHttpService;
        }

        public virtual async Task<IList<Game>> GetAll() =>
            await _gameHttpService.GetAll();

        public async Task<IList<Game>> GetByPlatform(string platform) =>
            await _gameHttpService.GetByPlatform(platform);

        public async Task<IList<Game>> GetByCategory(string category) =>
            await _gameHttpService.GetByCategory(category);
    }
}
