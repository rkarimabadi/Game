using Game.WordGame.Share.Interfaces;
using Game.WordGame.Share.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Game.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordGameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public WordGameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: <GamesController>
        [HttpGet]
        public Task<List<WordGameModel>> Get()
        {
            return _gameRepository.GetGames();
        }

        // GET <GamesController>/5
        [HttpGet("{id}")]
        public async Task<WordGameModel?> Get(Guid id)
        {
            return await _gameRepository.GetGame(id);
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] WordGameModel value)
        {
            _gameRepository.AddGame(value);
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] WordGameModel value)
        {
            var game = await _gameRepository.GetGame(id);
            if (game != null)
            {
                await _gameRepository.EditGame(value);
            }
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var game = await _gameRepository.GetGame(id);
            if (game != null)
            {
                await _gameRepository.RemoveGame(game);
            }
        }
    }
}
