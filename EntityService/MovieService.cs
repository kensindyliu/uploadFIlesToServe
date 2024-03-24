using Entities;
using EntityService.DBContext;

namespace EntityService
{
    public class MovieService
    {
        public List<Movie> GetMovies()
        {
            EntityDbContext entityDb = new();
            List<Movie> movies = entityDb.Movies.ToList();
            return movies;

        }
    }
}
