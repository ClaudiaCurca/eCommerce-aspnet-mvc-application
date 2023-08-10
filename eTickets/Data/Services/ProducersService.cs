using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
	public class ProducersService : EntityBaseRepository<Producer>, IProducersServices
	{
		public ProducersService(AppDBContext context) : base(context)
		{
		}
	}
}
