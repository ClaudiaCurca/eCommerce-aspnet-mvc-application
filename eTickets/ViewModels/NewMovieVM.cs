using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
	public class NewMovieVM
	{
		
		public int Id { get; set; }

		[Display(Name = "Name")]
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }

		[Display(Name = "Price")]
		[Required(ErrorMessage = "Price is required")]
		public double Price { get; set; }

		[Display(Name = "Image")]
		[Required(ErrorMessage = "Image is required")]
		public string ImageUrl { get; set; }

		[Display(Name = "Start Date")]
		[Required(ErrorMessage = "Start Date is required")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		[Required(ErrorMessage = "End Date is required")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Movie Category")]
		[Required(ErrorMessage = "Movie Category is required")]
		public MovieCategory MovieCategory { get; set; }

		//Relationships
		[Display(Name = "Select actor(s)")]
		[Required(ErrorMessage = "Movie actor(s) is required")]
		public List<int> ActorIds { get; set; }

		[Display(Name = "Select a cinema")]
		[Required(ErrorMessage = "Movie cinema is required")]
		public int CinemaId { get; set; }

		[Display(Name = "Select a producer")]
		[Required(ErrorMessage = "Movie producer is required")]
		public int ProducerId { get; set; }
	}
}
