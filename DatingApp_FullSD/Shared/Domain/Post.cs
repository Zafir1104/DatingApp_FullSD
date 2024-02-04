using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_FullSD.Shared.Domain
{
    public class Post : BaseDomainModel
    {
        public int PostID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "UserName Is too Long.")]
        public string? PostText { get; set; }

        [Required]
        [RegularExpression(@"^(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png|jpeg)$", ErrorMessage = "Invalid Image URL format.")]
        public string? PostPicture { get; set; }

        public byte[]? PostVideo { get; set; }

        public int PostLikes { get; set; }

        public string? PostComments { get; set; }

        public string? UserName { get; set; }

        public virtual Profile? PUserName { get; set; }
    }
}
