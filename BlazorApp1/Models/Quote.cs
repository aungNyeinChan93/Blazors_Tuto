using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Quote
    {

        public int QuoteId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Author { get; set; }

    }
}
