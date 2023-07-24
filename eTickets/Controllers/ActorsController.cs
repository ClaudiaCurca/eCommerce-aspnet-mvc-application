using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IActorsService _service;

		public ActorsController(IActorsService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var allActors = await _service.GetAll();
			return View(allActors);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
		{
			if(!ModelState.IsValid)
			{
				return View(actor);
			}
			_service.Add(actor);
			return RedirectToAction(nameof(Index));
		}
	}
}
