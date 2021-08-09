using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Input
    {
        [JsonProperty("lista_punonjes")]
        public List<Punonjes> lista_punonjes { get; set; }


        [JsonProperty("kushtet")]
        public List<Pagesat_dit_specifike> kushtet {get;set;}


        [JsonProperty("ore_pune")]
        public List<Ditet_e_punes> ore_pune {get;set;}


    }

}