using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "ProfilePictureURL")]
		public string ProfilePictureURL { get; set; }
		[Display(Name = "FullName")]
		public string FullName { get; set; }
		[Display(Name = "Bio")]
		public string Bio { get; set; }

		//Relationship

		public List<Actor_Movie> Actors_Movies { get; set; }
	}
}
