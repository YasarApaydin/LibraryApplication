using LibraryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApplication.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Index(string q, string category)
        {
            var book = Repository.Books;
            if (!string.IsNullOrEmpty(q))
            {
                ViewBag.SearchString = q;
                book = book.Where(p => p.Name!.ToLower().Contains(q)).ToList();

            }
            if (!string.IsNullOrEmpty(category) && category != "0")
            {
                book = book.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }


            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name",category);
            var model = new BookViewModel
            {
                Books = book,
                Categories = Repository.Categories,
                SelectedCategory = category
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Book model, IFormFile imageFile)
        {
            var extension = "";


            if (imageFile!= null) 
            {  var allowedExtensions = new[] {".jpg",".png",".jpeg"};
            extension = Path.GetExtension(imageFile.FileName);
           

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("","Geçerli Bir Resim Seçiniz.");

                }
            }



            if (ModelState.IsValid)
            {
                if (imageFile != null) 
                {
                    var ramdomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ramdomFileName);

                    using (var stream= new FileStream(path,FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                } 
                    model.Image = ramdomFileName;
                    model.BookId = Repository.Books.Count + 1;
                Repository.CreateBook(model);
                return RedirectToAction("Index");
                }
               
              
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = Repository.Books.FirstOrDefault(p => p.BookId == id);
            if(entity == null)
            {
                return NotFound();
            }


            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Book model, IFormFile? imageFile)
        {
            if(id != model.BookId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if(imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var ramdomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ramdomFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream); 
                    }
                    model.Image = ramdomFileName;
                }
                Repository.EditBook(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");
            return View(model);
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = Repository.Books.FirstOrDefault(p=> p.BookId==id);
            if(entity == null)
            {
                return NotFound();
            }

            return View("DeleteConfirm",entity);
        }

        [HttpPost]
        public IActionResult Delete(int id, int BookId) 
        {
            if (id != BookId)
            {
                return NotFound();
            }
            var entity = Repository.Books.FirstOrDefault(p=> p.BookId==BookId);
            if (entity == null)
            {
                return NotFound();
            }
            Repository.DeleteBook(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditBooks(List<Book> Books) 
        {

            foreach (var item in Books)
            {
            Repository.EditShelf(item); 
            }
            return RedirectToAction("Index");
                
        
       }

    }
}
