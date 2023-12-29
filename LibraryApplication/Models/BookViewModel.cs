namespace LibraryApplication.Models
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!; 
        public string? SelectedCategory { get; set; }
    }
}
