namespace PartialViewTask.Models
{
    public class BookImageModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public BookModel Book { get; set; }
        public int BookId { get; set; }
    }
}
