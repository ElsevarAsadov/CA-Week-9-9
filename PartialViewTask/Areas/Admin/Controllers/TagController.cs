using Microsoft.AspNetCore.Mvc;
using PartialViewTask.Data;
using PartialViewTask.Models;

namespace PartialViewTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Show()
        {
            return View(_context.Tags.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TagModel oldTag)
        {
            if(oldTag is null)
            {

                return BadRequest();

            }

            TagModel newTag = _context.Tags.FirstOrDefault(x=>x.Id == oldTag.Id);

            if(newTag is null)
            {
                return View("Index");
            }


            if (ModelState.IsValid)
            {
                _context.Tags.Add(newTag);
                _context.SaveChanges();
            }


            return RedirectToAction("Show");

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }

            TagModel deleted = _context.Tags.FirstOrDefault(x => x.Id == id);

            if(deleted is null)
            {
                return NotFound();
            }


            _context.Tags.Remove(deleted);
            _context.SaveChanges();

            return NoContent();


        }

    }
}
