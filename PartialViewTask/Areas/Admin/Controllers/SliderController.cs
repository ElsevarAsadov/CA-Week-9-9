using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartialViewTask.Areas.Admin.Service;
using PartialViewTask.Data;
using PartialViewTask.Models;

namespace PartialViewTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context) {

            _context = context;
            
        }
        public IActionResult Show()
        {
            return View(_context.Sliders.ToList());
        }

        [HttpDelete]
        public IActionResult Delete(int? id) {

            if (id is null) return BadRequest();

            PartialViewTask.Models.Slider deleted = _context.Sliders.FirstOrDefault(x=>x.Id == id);

            if (deleted is null) return NotFound();


            FileService.delete(deleted.Image);
            _context.Sliders.Remove(deleted);
            _context.SaveChanges();

            return NoContent();
            
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PartialViewTask.Models.Slider newSlider) { 
        
            if(newSlider is null)
            {
                return BadRequest();
            }

            if(newSlider.UploadedImage is null)
            {
                ModelState.AddModelError("UploadedImage", "Invalid image");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            string filename = FileService.saveImage(newSlider.UploadedImage);
            newSlider.Image = filename;



            _context.Sliders.Add(newSlider);
            _context.SaveChanges();



            return RedirectToAction("Show"); 
        }
    }
}
