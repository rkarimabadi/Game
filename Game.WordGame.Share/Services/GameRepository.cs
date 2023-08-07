using Game.WordGame.Share.Interfaces;
using Game.WordGame.Share.Models;

namespace Game.WordGame.Share.Services
{
    public class GameRepository : IGameRepository
    {
        private readonly List<WordGameModel> _games = new();
        public Task AddGame(WordGameModel game)
        {
            _games.Add(game);
            return Task.CompletedTask;
        }
        public Task RemoveGame(WordGameModel game)
        {
            _games.Remove(game);
            return Task.CompletedTask;
        }
        public Task<WordGameModel?> GetGame(Guid id)
        {
            return Task.FromResult(_games.FirstOrDefault(g => g.Id == id));
        }
        public Task<List<WordGameModel>> GetGames()
        {
            return Task.FromResult(_games);
        }
        public Task EditGame(WordGameModel game)
        {
            var index = _games.FindIndex(g => g.Id == game.Id);
            if (index >= 0)
            {
                _games.RemoveAt(index);
                _games.Add(game);
            }
            return Task.CompletedTask;
        }
    }
}
