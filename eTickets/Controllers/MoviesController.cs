﻿using eTickets.Data.Services;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
	{
		private readonly IMoviesServices _service;
		private readonly UserManager<ApplicationUser> _userManager;

		public MoviesController(IMoviesServices service,UserManager<ApplicationUser> userManager)
		{
			_service = service;
			this._userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			ViewData["UserId"]=_userManager.GetUserId(this.User);
			var allMovies = await _service.GetAllAsync(n => n.Cinema);
			return View(allMovies);
		}

        public async Task<IActionResult> Details(int id)
        {
			var movieDetail = await _service.GetMovieByIdAsync(id);
			return View(movieDetail);
		}

		public async Task<IActionResult> Create()
		{
			var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

			ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
			ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(NewMovieVM movie)
		{
			if (!ModelState.IsValid)
			{
				var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

				ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

				return View(movie);
			}

			await _service.AddNewMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}
		//GET: Movies/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			if (movieDetails == null)
			{
				return View("NotFound");
			}
			var response = new NewMovieVM()
			{
				Id=movieDetails.Id,
				Name=movieDetails.Name,
				Description=movieDetails.Description,
				Price=movieDetails.Price,
				StartDate = movieDetails.StartDate,
				EndDate= movieDetails.EndDate,
				MovieCategory=movieDetails.MovieCategory,
				ImageUrl=movieDetails.ImageUrl,
				CinemaId = movieDetails.CinemaId,
				ProducerId = movieDetails.ProducerId,
				ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),

			};

			var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
			ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
			ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

			return View(response);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewMovieVM movie)
		{
			if (id != movie.Id)
			{
				return View("NotFound");
			}
			if (!ModelState.IsValid)
			{
				var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

				ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

				return View(movie);
			}
			await _service.UpdateMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			if (movieDetails == null)
			{
				return View("NotFound");
			}
			return View(movieDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);
			if (movieDetails == null)
			{
				return View("NotFound");
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
