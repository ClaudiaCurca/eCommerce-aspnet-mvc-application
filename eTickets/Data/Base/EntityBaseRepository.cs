using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
	public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDBContext _context;

		public EntityBaseRepository(AppDBContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var result = GetByIdAsync(id);
			_context.Set<T>().Remove(result.Result);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var result = await _context.Set<T>().ToListAsync();
			return result;
		}
		public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
			return await query.ToListAsync();

		}

		public async Task<T> GetByIdAsync(int id)
		{
			var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
			return result;
		}

		public async Task<T> UpdateAsync(int id, T entiry)
		{
			_context.Set<T>().Update(entiry);
			await _context.SaveChangesAsync();
			return entiry;
		}
	}
}
