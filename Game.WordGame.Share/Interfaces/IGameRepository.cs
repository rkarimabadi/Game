using Game.WordGame.Share.Models;

namespace Game.WordGame.Share.Interfaces
{
    public interface IGameRepository
    {
        Task AddGame(WordGameModel game);
        Task<WordGameModel?> GetGame(Guid id);
        Task<List<WordGameModel>> GetGames();
        Task RemoveGame(WordGameModel game);
        Task EditGame(WordGameModel game);
    }
}