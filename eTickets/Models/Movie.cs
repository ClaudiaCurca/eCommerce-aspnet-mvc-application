using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie:IEntityBase
	{
		[Key]
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
        public string ImageUrl { get; set;}

		[Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

		[Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public MovieCategory MovieCategory { get; set; }

		//Relationship

		public List<Actor_Movie>? Actors_Movies { get; set; }

		public int CinemaId { get; set; }

		[ForeignKey("CinemaId")]
		public Cinema Cinema { get; set; }

		public int ProducerId { get; set; }

		[ForeignKey("ProducerId")]
		public Producer Producer { get; set; }



	}
}
