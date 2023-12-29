using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Models
{
    public class Book
    {
        [Display(Name="Book Id")]
        public int BookId { get; set; }

        [Required]
       
        public string? Name { get; set; }
       
        [Required]
        public string? Author { get; set; }

        [Required]
        public decimal? Price { get; set; }
        public bool Shelf { get; set; }
 
        public string? Image { get; set; } = string.Empty;
        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }
    } 
}
