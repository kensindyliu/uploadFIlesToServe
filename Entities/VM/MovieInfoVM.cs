using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.VM
{
    public class MovieInfoVM
    {
        public int MoviesCount = 0;
        public int UsersCount = 0;
        public int RatingsCount = 0;

        public List<Movie> Movies { get; set; }
        public List<User> Users { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
