using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }

        [Required]
        public required string Title { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public bool IsStatus { get; set; } = false;
    }
}
