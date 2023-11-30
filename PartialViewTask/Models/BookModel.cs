using System.ComponentModel.DataAnnotations.Schema;

namespace PartialViewTask.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int SaleFraction { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNewArrival { get; set; }
        public bool IsMostViewed { get; set; }
        public List<BookImageModel>? Images { get; set; }
        public string? SlideImage { get; set; }
        public string? HoverImage { get; set; }
        public List<TagModel>? Tags { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }

        [NotMapped]
        public List<IFormFile> UpdatedImages { get; set; }

        [NotMapped]
        public IFormFile UpdatedSlideImage { get; set; }

        [NotMapped]
        public IFormFile UpdatedHoverImage { get; set; }

    }
}
