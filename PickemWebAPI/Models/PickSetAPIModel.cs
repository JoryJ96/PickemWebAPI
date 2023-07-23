using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickemWebAPI.Models
{
    public class PickSetAPIModel
    {
        public string UserID { get; set; }
        public string MNFSelection { get; set; }
        public string SNFSelection { get; set; }
        public string DalOrOptSelection { get; set; }
        public string FirstOptionalSelection { get; set; }
        public string SecondOptionalSelection { get; set; }
        public string TripleOption { get; set; }
    }
}