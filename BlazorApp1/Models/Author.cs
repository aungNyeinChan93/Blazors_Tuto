using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<Todo>? Todos { get; set; }

    }
}
