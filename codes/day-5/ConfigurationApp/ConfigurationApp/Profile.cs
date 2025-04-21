using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApp
{
    public class Profile
    {
        public required DatabaseConnection Development { get; set; }
        public required DatabaseConnection Production { get; set; }
    }
}
