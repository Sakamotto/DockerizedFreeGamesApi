using DockerizedCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerizedCrud.Interfaces
{
    public interface IGameService
    {
        public Task<IList<Game>> GetAll();

        public Task<IList<Game>> GetByPlatform(string platform);

        public Task<IList<Game>> GetByCategory(string category);
    }
}
