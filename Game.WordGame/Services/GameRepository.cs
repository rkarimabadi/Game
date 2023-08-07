using Game.WordGame.Helpers;
using Game.WordGame.Share.Interfaces;
using Game.WordGame.Share.Models;
using System.Net.Http.Json;

namespace Game.WordGame.Services
{
    public class GameRepository : IGameRepository
    {
        private readonly HttpClient HttpClient;
        public GameRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task AddGame(WordGameModel game)
        {
            await HttpClient.PostAsJsonAsync("/WordGame", game);
        }

        public async Task EditGame(WordGameModel game)
        {
            await HttpClient.PutAsJsonAsync($"/WordGame/{game.Id}", game);
        }

        public async Task<WordGameModel?> GetGame(Guid id)
        {
            return await HttpClient.GetFromJsonAsync<WordGameModel?>($"/WordGame/{id}");
        }

        public async Task<List<WordGameModel>> GetGames()
        {
            return await HttpClient.GetFromJsonAsync<List<WordGameModel>>($"/WordGame/") ?? new List<WordGameModel>();
        }

        public async Task RemoveGame(WordGameModel game)
        {
            await HttpClient.DeleteAsJsonAsync($"/WordGame/{game.Id}", game);
        }
    }
}
