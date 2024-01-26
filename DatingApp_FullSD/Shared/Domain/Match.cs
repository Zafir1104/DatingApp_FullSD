using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_FullSD.Shared.Domain
{
    public class Match : BaseDomainModel
    {
        public int MatchID { get; set; }

        public int User1 { get; set; }

        public virtual Profile? UserID1 { get; set; }

        public int User2 { get; set; }

        public virtual Profile? UserID2 { get; set; }

    }


}

