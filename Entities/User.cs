using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; } // Unique identifier for each user

        public int Age { get; set; } // Age of the user

        public string Gender { get; set; } // Gender of the user

        public string Occupation { get; set; } // Occupation of the user

        public string ZipCode { get; set; } // Zip code of the user
    }
}
