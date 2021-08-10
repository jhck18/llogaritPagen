using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class ExpectedInput
    {
        [JsonProperty("lista_punonjes")]
        public List<Punonjes> lista_punonjes { get; set; }


        [JsonProperty("kushtet")]
        public Kushtet kushtet {get;set;}


        [JsonProperty("ore_pune")]
        public List<Ditet_e_punes> ore_pune {get;set;}


    }
    public class Kushtet
    {
        public decimal dite_festash { get; set; }
        public decimal fundjave { get; set; }
        public decimal jashte_orari { get; set; }
    }

}