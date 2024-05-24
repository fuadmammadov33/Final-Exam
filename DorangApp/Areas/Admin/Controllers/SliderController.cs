using DorangApp.DAL;

using DorangApp.Models;
using DorangApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DorangApp.Areas.admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly DorangContext _context;

		public HomeController(DorangContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Explorer.ToListAsync());
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(DorangGetVM vm)
		{
			if (!ModelState.IsValid) return View();
			await _context.Explorer.AddAsync(new Explore
			{
				Subtitle=vm.Subtitle,
				Title=vm.Title,
				Description=vm.Description,
				ImageUrl=vm.ImageUrl,

				
			});
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			var result = await _context.Explorer.FirstOrDefaultAsync(x => x.Id == id);
			if (result == null) return NotFound();
			return View(result);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, DorangGetVM tm)
		{
			if (id == null || id < 1) return BadRequest();
			var result = await _context.Explorer.FirstOrDefaultAsync(x => x.Id == id);
			if (result == null) return NotFound();
			result.Subtitle = tm.Subtitle;
			result.Description = tm.Description;
			result.ImageUrl = tm.ImageUrl;
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			var result = await _context.Explorer.FirstOrDefaultAsync(x => x.Id == id);
			if (result == null) return NotFound();
			_context.Remove(result);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}


	}
}