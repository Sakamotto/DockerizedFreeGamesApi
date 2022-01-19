using DockerizedCrud.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DockerizedCrud.Services
{
    public class GameHttpService
    {
        public HttpClient Client { get; }

        public GameHttpService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://www.freetogame.com/api/");
            Client = httpClient;
        }

        public async Task<IList<Game>> GetAll() =>
            await Client.GetFromJsonAsync<IList<Game>>("games");

        public async Task<IList<Game>> GetByPlatform(string platform) =>
            await Client.GetFromJsonAsync<IList<Game>>($"games?platform={platform}");

        public async Task<IList<Game>> GetByCategory(string category) =>
            await Client.GetFromJsonAsync<IList<Game>>($"games?category={category}");
    }
}
