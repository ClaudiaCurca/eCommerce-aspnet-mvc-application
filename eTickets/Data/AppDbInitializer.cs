using eTickets.Models;

namespace eTickets.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

				context.Database.EnsureCreated();

				//Cinema
				if (!context.Cinemas.Any())
				{
					context.Cinemas.AddRange(new List<Cinema>()
					{
						new Cinema()
						{
							Name = "Cinema1",
							LogoUrl="https://clipground.com/cinema-logo-clipart.html",
							Description="This is the description of the cinema"
						},
						new Cinema()
						{
							Name = "Cinema2",
							LogoUrl="https://clipground.com/cinema-logo-clipart.html",
							Description="This is the description of the cinema"
						}
					});
				}
				context.SaveChanges();
				//Actors
				if (!context.Actors.Any())
				{
					context.Actors.AddRange(new List<Actor>()
					{
						new Actor()
						{
							FullName = "Will Smith",
							ProfilePictureURL="https://www.billboard.com/wp-content/uploads/2020/07/will-smith-jan-8-2020-billboard-1548-1594312302.jpg?w=942&h=623&crop=1&resize=942%2C623",
							Bio="This is the description of Will Smith"
						},
						new Actor()
						{
							FullName = "ScoobyDoo",
							ProfilePictureURL="https://tse1.mm.bing.net/th?id=OIP.FZd1hS_vkLHX_qfRZ2v3_gHaJl&pid=Api&P=0&h=180",
							Bio = "Scooby doby dooo"
						}
					});
					context.SaveChanges();
				}
				//Producers
				if (!context.Producers.Any())
				{
					context.Producers.AddRange(new List<Producer>()
					{
						new Producer()
						{
							FullName = "Producer1",
							ProfilePictureURL="https://www.billboard.com/wp-content/uploads/2020/07/will-smith-jan-8-2020-billboard-1548-1594312302.jpg?w=942&h=623&crop=1&resize=942%2C623",
							Bio="This is the description of the producer"
						},
						new Producer()
						{
							FullName = "Producer2",
							ProfilePictureURL="https://www.billboard.com/wp-content/uploads/2020/07/will-smith-jan-8-2020-billboard-1548-1594312302.jpg?w=942&h=623&crop=1&resize=942%2C623",
							Bio="This is the description of the producer"
						}
					});
					context.SaveChanges();
				}
				//Movies
				if (!context.Movies.Any())
				{
					context.Movies.AddRange(new List<Movie>()
					{
						new Movie()
						{
							Name = "ScoobyDoo",
							Description = "ScoobyDoo and his friends solving the egipt mistery",
							Price=20,
							ImageUrl="",
							StartDate = DateTime.Now.AddDays(-10),
							EndDate= DateTime.Now.AddDays(-2),
							CinemaId = 1,
							ProducerId = 1,
							MovieCategory = Enums.MovieCategory.Comedy
						},
						new Movie()
						{
							Name = "Men in Black",
							Description = "A veteran (Tommy Lee Jones) and a rookie (Will Smith) track aliens on Earth",
							Price=20,
							ImageUrl="https://www.themoviedb.org/t/p/w220_and_h330_face/uLOmOF5IzWoyrgIF5MfUnh5pa1X.jpg",
							StartDate = DateTime.Now.AddDays(-10),
							EndDate= DateTime.Now.AddDays(-2),
							CinemaId = 2,
							ProducerId=2,
							MovieCategory = Enums.MovieCategory.Action
						}
					});
					context.SaveChanges();
				}
				//Actors&Movies
				if (!context.Actors_Movies.Any())
				{
					context.Actors_Movies.AddRange(new List<Actor_Movie>()
					{
						new Actor_Movie()
						{
							ActorId= 1,
							MovieId= 2,
						},
						new Actor_Movie()
						{
							ActorId= 2,
							MovieId= 1,
						}

					});
					context.SaveChanges();
				}
			}
		}
	}
}
