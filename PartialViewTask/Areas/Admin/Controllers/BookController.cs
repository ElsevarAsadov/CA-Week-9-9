using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialViewTask.Areas.Admin.Service;
using PartialViewTask.Data;
using PartialViewTask.Models;

namespace PartialViewTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Show()
        {
            return View(_context.Books.Include(x=>x.Tags).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookModel newBook)
        {

            if (ModelState.IsValid)
            {
              


                if(newBook.TagIds is not null)
                {
                    newBook.Tags = _context.Tags.Where(x=>newBook.TagIds.Contains(x.Id) ).ToList();

                }

                if (newBook.UpdatedImages is not null)
                {
                    List<BookImageModel> images = new List<BookImageModel>();

                    foreach(IFormFile image in newBook.UpdatedImages)
                    {
                        string filename = FileService.saveImage(image);
                        
                        var newImage = new BookImageModel() { Filename=filename};

                        images.Add(newImage);
                    }

                    newBook.Images = images;
                }


                if(newBook.UpdatedSlideImage is not null)
                {
                    string filename = FileService.saveImage(newBook.UpdatedSlideImage);

                    newBook.SlideImage = filename;
                }


                if (newBook.UpdatedHoverImage is not null)
                {
                    string filename = FileService.saveImage(newBook.UpdatedHoverImage);

                    newBook.HoverImage = filename;
                }


                _context.Books.Add(newBook);
                _context.SaveChanges();

                return RedirectToAction("Show");


            }
            else
            {
                return View("Create");
            }



            //success
            return RedirectToAction("Show");
        }



        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }

            BookModel deleted = _context.Books.Include(x=>x.Images).FirstOrDefault(x => x.Id == id);

            if(deleted is null)
            {
                return NotFound(); //404;
            }

            foreach(var image in deleted.Images)
            {
                FileService.delete(image.Filename);
            }

            if(deleted.HoverImage is not null)
            {
                FileService.delete(deleted.HoverImage);
            }

            if(deleted.SlideImage is not null)
            {
                FileService.delete(deleted.SlideImage);
            }

            _context.Books.Remove(deleted);
            
            _context.SaveChanges();

            return NoContent(); // 204;
        }
    }
}
