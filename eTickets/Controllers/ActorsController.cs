using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		private readonly AppDBContext _context;

		public ActorsController(AppDBContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var allActors = _context.Actors.ToList();
			return View();
		}
	}
}
