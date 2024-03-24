using Entities.VM;
using EntityService.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace Importer_TXT_To_SQL_.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            EntityDbContext dbContext = new EntityDbContext();
            MovieInfoVM movieInfoVM = new MovieInfoVM();
            movieInfoVM.UsersCount = dbContext.Users.Count();
            movieInfoVM.MoviesCount = dbContext.Movies.Count();
            movieInfoVM.RatingsCount = dbContext.Ratings.Count();
            if (dbContext.Ratings.Count() > 3)
            {
                movieInfoVM.Ratings = dbContext.Ratings.Take(3).ToList();
            }
            if (dbContext.Movies.Count() > 3)
            {
                movieInfoVM.Movies = dbContext.Movies.Take(3).ToList();
            }
            if (dbContext.Users.Count() > 3)
            {
                movieInfoVM.Users = dbContext.Users.Take(3).ToList();
            }

            return View(movieInfoVM);
        }


    }
}
