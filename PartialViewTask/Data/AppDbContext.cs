using Microsoft.EntityFrameworkCore;
using PartialViewTask.Models;

namespace PartialViewTask.Data;

public class AppDbContext : DbContext
{

    public DbSet<BookModel> Books { get; set; }
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<BookImageModel> BookImages { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}