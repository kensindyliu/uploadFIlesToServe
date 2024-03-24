using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; } // Primary Key: Unique identifier for each movie.
        public string Title { get; set; } // Title of the movie.
        public DateTime ReleaseDate { get; set; } // Release date of the movie.
        public string NoColName1 { get; set; }
        public string IMDbLink { get; set; } // Link to the IMDb page of the movie.

        public bool Action { get; set; }
        public bool Adventure { get; set; }
        public bool Comedy { get; set; }
        public bool Drama { get; set; }
        public bool Romance { get; set; }
        public bool Thriller { get; set; }
        public bool ScienceFiction { get; set; }
        public bool Animation { get; set; }
        public bool Fantasy { get; set; }
        public bool Horror { get; set; }
        public bool Musical { get; set; }
        public bool Mystery { get; set; }
        public bool Documentary { get; set; }
        public bool War { get; set; }
        public bool Crime { get; set; }
        public bool Western { get; set; }
        public bool FilmNoir { get; set; }
        public bool Childrens { get; set; }
        public bool Other { get; set; }

        // Additional properties or methods can be added as needed
    }
}
