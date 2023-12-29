using System.Net;
using System.Xml.Linq;

namespace LibraryApplication.Models
{
    public class Repository
    {
        private static readonly List<Book> _content = new();
        public static readonly List<Category> _categories = new();




        static Repository()
        {
            _categories.Add(new Category {CategoryId =1, Name= "Fantastik" });
            _categories.Add(new Category { CategoryId = 2, Name = "Romantik" });
            _categories.Add(new Category { CategoryId = 3, Name = "Gerilim ve Gizem" });
            _categories.Add(new Category { CategoryId = 4, Name = "Bilim Kurgu" });
            _categories.Add(new Category { CategoryId = 5, Name = "Drama" });
            _categories.Add(new Category { CategoryId = 6, Name = "Roman" });
            _content.Add(new Book { BookId=1, Name="Bir Kuzey Macerası",Author="Jack London",Price=200,Shelf=false,Image="1.png",CategoryId=2  });
            _content.Add(new Book { BookId = 2, Name = "Sırça Köşk", Author = "Sabahattin Ali", Price = 250, Shelf = false, Image = "2.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 3, Name = "Bir İdam Mahkumunun Son Günü", Author = "Vıctor Hugo", Price = 230, Shelf = false, Image = "3.png", CategoryId = 5 });
            _content.Add(new Book { BookId = 4, Name = "Kendime Düşünceler", Author = "Marcus Aurelıus", Price = 100, Shelf = false, Image = "4.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 5, Name = "Nasıl Ölünür", Author = "Emile Zola", Price = 500, Shelf = true,  Image = "5.png", CategoryId = 5 });
            _content.Add(new Book { BookId = 6, Name = "Mecburiyet", Author = "Stefan Zweig", Price = 210, Shelf = false, Image = "6.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 7, Name = "Olduğum Yer", Author = "Jhumpa Lahırı", Price = 60, Shelf = true,  Image = "7.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 8, Name = "Mutluluğun Kazanılması", Author = "Farabı", Price = 100, Shelf = true, Image = "8.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 9, Name = "Kibarlık Budalası", Author = "Molıere", Price = 30, Shelf = true, Image = "9.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 10, Name = "Savaş Sanatı", Author = "Sun Zi(Sun Tzu)", Price = 30, Shelf = false,  Image = "10.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 11, Name = "Babalar ve Oğullar", Author = "Ivan Sergeyeviç Turgenyev", Price = 20, Shelf = true,Image = "11.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 12, Name = "Ateş Yakmak", Author = "Jack London", Price = 40, Shelf = false,  Image = "12.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 13, Name = "Zacharıus Usta", Author = "Jules Verne", Price = 80, Shelf = true, Image = "13.png", CategoryId = 6 });
            _content.Add(new Book { BookId = 14, Name = "Babaya Mektup", Author = "Fransz Kafka", Price = 1000, Shelf = true, Image = "14.png", CategoryId = 6 });
                }



        public static List<Book> Books
        {
            get {
                return _content;
            }
        }

        public static void CreateBook(Book entity)
        {
            _content.Add(entity);
        }
        public static void DeleteBook(Book deleteBook) 
            {
            var entity = _content.FirstOrDefault(p=> p.BookId== deleteBook.BookId);
            if (entity != null)
            {
                _content.Remove(entity);
            }
        }

        public static void EditBook(Book updateBook)
        {
            var entity = _content.FirstOrDefault(p => p.BookId == updateBook.BookId);
            if(entity != null)
            {
                entity.Name = updateBook.Name;
                     entity.Author = updateBook.Author;
                entity.Price = updateBook.Price;
                entity.Shelf = updateBook.Shelf;

                entity.Image = updateBook.Image;
                entity.CategoryId = updateBook.CategoryId;
            }
        }
        public static void EditShelf(Book updateBook)
        {
            var entity = _content.FirstOrDefault(p => p.BookId == updateBook.BookId);
            if (entity != null)
            {
                
                entity.Shelf = updateBook.Shelf;

              
            }
        }
        public static List<Category> Categories 
        {
        get
            {
                return _categories;
            }
        }




    }
}
