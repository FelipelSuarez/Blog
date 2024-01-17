using System.ComponentModel.DataAnnotations;

namespace Projeto_Bolg.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }
    }
}