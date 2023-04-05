using MatchScore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchScore.Web.ViewModels.LocationViewModels
{
    public class LocationCreateVM
    {
        public string City { get; set; }

        public Countries Country { get; set; }
    }
}
