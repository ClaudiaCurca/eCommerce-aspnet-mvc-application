using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
	{
		private readonly IMoviesServices _service;

		public MoviesController(IMoviesServices service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var allMovies = await _service.GetAllAsync(n => n.Cinema);
			return View(allMovies);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Description,Price,ImageUrl,StartDate,EndDate,MovieCategory")] Movie movie)
		{
			if (!ModelState.IsValid)
			{
				return View(movie);
			}
			await _service.AddAsync(movie);
			return RedirectToAction(nameof(Index));
		}

        public async Task<IActionResult> Details(int id)
        {
			var movieDetail = await _service.GetMovieByIdAsync(id);
			return View(movieDetail);
		}

        //public async Task<IActionResult> Create()
        //{
        //	var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //	ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //	ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //	ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //	return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(NewMovieVM movie)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //		ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //		ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //		ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //		return View(movie);
        //	}

        //	await _service.AddNewMovieAsync(movie);
        //	return RedirectToAction(nameof(Index));
        //}
    }
}
