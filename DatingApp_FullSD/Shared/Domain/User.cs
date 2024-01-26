using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_FullSD.Shared.Domain
{
    public class User : BaseDomainModel
    {
        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? Location { get; set; }

        public string? Interest { get; set; }

        public byte[]? Picture { get; set; }

        public string? Birthdate { get; set; }

        public string? Gender { get; set; }

        public string? Occupation { get; set; }

    }
}
