using Game.WordGame.Share.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Game.WordGame.Share.Models
{
    public class Question : IHasGuid
    {
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        public bool? Answer { get; set; }
    }
}