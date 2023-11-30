using PartialViewTask.Data;
using Microsoft.AspNetCore.Mvc;

namespace PartialViewTask.Areas.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _dbContext;
    public DashboardController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Author()
    {
        return View();
    }
}