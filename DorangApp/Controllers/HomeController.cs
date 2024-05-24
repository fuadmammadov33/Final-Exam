using DorangApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DorangApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DorangContext _context;

        public HomeController(DorangContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {

            return View(await _context.Explorer.ToListAsync());
        }
    }
}
