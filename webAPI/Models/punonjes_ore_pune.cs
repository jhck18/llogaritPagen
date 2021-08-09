using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class punonjes_ore_pune
    {
        public Punonjes punonjes { get; set; }
        public List<Ditet_e_punes> ore_pune { get; set; }
    }
}