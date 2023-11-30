using System.ComponentModel.DataAnnotations.Schema;

namespace PartialViewTask.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? UploadedImage { get; set; }

    }
}
