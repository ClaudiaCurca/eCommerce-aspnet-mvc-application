using eTickets.Data.Base;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
	public class MoviesService : EntityBaseRepository<Movie>, IMoviesServices
	{
		private AppDBContext _context;
		public MoviesService(AppDBContext context) : base(context) 
		{
			_context = context;
		}

		public async Task AddNewMovieAsync(NewMovieVM data)
		{
			var newMovie = new Movie()
			{
				Name = data.Name,
				Description = data.Description,
				Price = data.Price,
				ImageUrl = data.ImageUrl,
				CinemaId = data.CinemaId,
				StartDate = data.StartDate,
				EndDate = data.EndDate,
				MovieCategory = data.MovieCategory,
				ProducerId = data.ProducerId
			};
			await _context.Movies.AddAsync(newMovie);
			await _context.SaveChangesAsync();

			//Add Movie Actors
			foreach (var actorId in data.ActorIds)
			{
				var newActorMovie = new Actor_Movie()
				{
					MovieId = newMovie.Id,
					ActorId = actorId
				};
				await _context.Actors_Movies.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			var movieDetails = await _context.Movies
			  .Include(c => c.Cinema)
			  .Include(p => p.Producer)
			  .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
			  .FirstOrDefaultAsync(n => n.Id == id);
			await _context.SaveChangesAsync();

			return movieDetails;
		}

		public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
		{
			var response = new NewMovieDropdownsVM()
			{
				Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
				Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
				Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
			};

			return response;
		}

		public async Task UpdateMovieAsync(NewMovieVM data)
		{
			var movie = await _context.Movies.Where(x => x.Id == data.Id).FirstOrDefaultAsync();
			if (movie != null)
			{
				movie.Name = data.Name;
				movie.Description = data.Description;
				movie.Price = data.Price;
				movie.StartDate= data.StartDate;
				movie.EndDate = data.EndDate;
				movie.ImageUrl = data.ImageUrl;
				movie.MovieCategory= data.MovieCategory;
				movie.ProducerId = data.ProducerId;
				movie.CinemaId = data.CinemaId;
				await _context.SaveChangesAsync();
			}

			//remove actors
			var existingActors = _context.Actors_Movies.Where(x=>x.MovieId== data.Id).ToList();
			_context.Actors_Movies.RemoveRange(existingActors);
			await _context.SaveChangesAsync();

			//add new actors
			foreach(var actorId in data.ActorIds)
			{
				var newActorMovie = new Actor_Movie()
				{
					MovieId = data.Id,
					ActorId = actorId
				};
				await _context.Actors_Movies.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();

		}
	}
}
