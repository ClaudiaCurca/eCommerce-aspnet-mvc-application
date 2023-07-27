using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Cinema:IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Logo")]
		[Required(ErrorMessage = "Logo Url is required")]
		public string LogoUrl { get; set; }

		[Display(Name = "Cinema Name")]
		[Required(ErrorMessage = "Cinema name is required")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }

		//Relationship

		public List<Movie>? Movies { get; set; }
	}
}
