using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp_FullSD.Shared.Domain
{
    public class Profile : BaseDomainModel
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="UserName Is too Long.")]
        public string? UserName { get; set; }

        public string? Location { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s]+,\s*[\w\s]+(,\s*[\w\s]+)*$", ErrorMessage = "Invalid occupation format. Use comma-separated values with mandatory spaces.")]
        public string? Interest { get; set; }

        public string? Picture { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid birthdate format. Use yyyy-mm-dd.")]
        public string? Birthdate { get; set; }

        public string? Gender { get; set; }

        public string? Occupation { get; set; }

    }
}
