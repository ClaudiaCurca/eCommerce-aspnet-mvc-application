using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
	public class CinemasServices:EntityBaseRepository<Cinema>,ICinemasService
	{
		public CinemasServices(AppDBContext context) : base(context) { }
	}
}
