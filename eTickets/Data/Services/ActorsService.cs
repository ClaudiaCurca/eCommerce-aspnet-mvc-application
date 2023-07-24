using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
	public class ActorsService : IActorsService
	{
		private readonly AppDBContext _context;
		public ActorsService(AppDBContext context)
		{
			_context = context;
		}

		public void Add(Actor actor)
		{
			_context.Actors.Add(actor);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			_context.Actors.Remove(GetById(id));
			_context.SaveChanges();
			return true;

		}

		public async Task<IEnumerable<Actor>> GetAll()
		{
			var result = await _context.Actors.ToListAsync();
			return result;
		}

		public Actor GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Actor Update(int id, Actor newActor)
		{
			throw new NotImplementedException();
		}
	}
}
