﻿using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
	public interface IMoviesServices : IEntityBaseRepository<Movie>
	{
		Task<Movie> GetMovieByIdAsync(int id);
		//Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
		//Task AddNewMovieAsync(NewMovieVM data);
		//Task UpdateMovieAsync(NewMovieVM data);
	}
}
