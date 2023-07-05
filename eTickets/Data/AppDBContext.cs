using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
	public class AppDBContext:DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
		{

		}
	}
}
