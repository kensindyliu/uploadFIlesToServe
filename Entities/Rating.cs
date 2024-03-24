using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rating
    {
        [ForeignKey("User")]
        public int UserID { get; set; } // Foreign key referencing UserID in the Users table

        [ForeignKey("Movie")]
        public int MovieID { get; set; } // Foreign key referencing MovieID in the Movies table

        public int RatingValue { get; set; } // Rating given by the user for the movie

        public DateTime Timestamp { get; set; } // Timestamp indicating when the rating was given

    }
}
