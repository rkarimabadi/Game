using Game.WordGame.Share.Interfaces;
using Game.WordGame.Share.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Game.WordGame.Services
{
    public class GameNotification : IGameNotification, IAsyncDisposable
    {
        private readonly HubConnection hubConnectin;

        public GameNotification(NavigationManager navigationManager)
        {
            hubConnectin = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/GameNotificationHub"))
                .Build();
            hubConnectin.On<WordGameModel>("GameCreated", (game) => GameCreated?.Invoke(game));
            hubConnectin.On<WordGameModel>("GameUpdated", (game) => GameUpdated?.Invoke(game));
            hubConnectin.StartAsync();
        }

        public Action<WordGameModel> GameCreated { get; set; }
        public Action<WordGameModel> GameUpdated { get; set; }

        public async Task CreateGame(WordGameModel game)
        {
            await hubConnectin.SendAsync("CreateGame", game);
        }


        public async Task UpdateGame(WordGameModel game)
        {
            await hubConnectin.SendAsync("UpdateGame", game);
        }
        public async ValueTask DisposeAsync()
        {
            await hubConnectin.DisposeAsync();
        }
    }
}
