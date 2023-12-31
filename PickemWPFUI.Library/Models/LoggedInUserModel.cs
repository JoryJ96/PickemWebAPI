﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickemWPFUI.Library.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string AuthToken { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Rank { get; set; }

        public List<UserPick> PickSet { get; set; }
    }
}
