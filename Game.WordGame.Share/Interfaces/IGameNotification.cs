using Game.WordGame.Share.Models;

namespace Game.WordGame.Share.Interfaces
{
    public interface IGameNotification
    {
        Action<WordGameModel> GameCreated { get; set; }
        Action<WordGameModel> GameUpdated { get; set; }
        Task CreateGame(WordGameModel game);
        Task UpdateGame(WordGameModel game);
    }
}
