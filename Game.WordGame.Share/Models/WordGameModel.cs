using Game.WordGame.Share.Helpers;
using Game.WordGame.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Game.WordGame.Share.Models
{
    public class WordGameModel : IHasGuid
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The length of the answer should not exceed fifty characters.")]
        public string Answer { get; set; }
        public Person Owner { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid Id { get; set; }
        [Required]
        public int MaxAllowedQuestionsNumbers { get; set; } = 20;
        public List<Question> QuestionList { get; set; }
        private GameState _gameState = GameState.Ongoing;
        public GameState GameState
        {
            set
            {
                _gameState = value;
            }
            get
            {
                return _gameState;
            }
        }
    }
    public enum GameState
    {
        [EnumDescription("Won")]
        Won,
        [EnumDescription("lost")]
        Lost,
        [EnumDescription("On Going")]
        Ongoing,
        [EnumDescription("Awaiting the announcement of the result")]
        AwaitingResultAnnouncement,
    }
}
