using Game.WordGame.Share.Interfaces;
using Game.WordGame.Share.Models;
using Microsoft.AspNetCore.SignalR;

namespace Game.WordGame.Share.SignalRHub
{
    public class GameNotificationHub : Hub
    {
        private readonly IGameRepository _gameRepository;

        public GameNotificationHub(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task CreateGame(WordGameModel game)
        {
            await _gameRepository.AddGame(game);
            await Clients.All.SendAsync("GameCreated", game);
        }
        public async Task UpdateGame(WordGameModel game)
        {
            await _gameRepository.EditGame(game);
            await Clients.All.SendAsync("GameUpdated", game);
        }
    }
}
