using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class Llogaritja_pages
    {
        public void llogaritPagen(Input input)
        {
            List<Punonjes> punonjesit = input.lista_punonjes;
            List<punonjes_ore_pune> punonjesit_ore_pune = new List<punonjes_ore_pune>();

            int ditePune = ditePunePerMuajinAktual(DateTime.Now);
            foreach (var punonjes in punonjesit)
            {
                var oret = input.ore_pune.Where(o => o.id == punonjes.id).Select(o => o).ToList();
                punonjesit_ore_pune.Add(new punonjes_ore_pune {punonjes = punonjes, ore_pune = oret });
            }

            foreach (var punonjes in punonjesit_ore_pune)
            {
                decimal pagesaPerOre = llogaritPagenPerOre(punonjes.punonjes.Rroga, ditePune);

            }
        }

        public static int ditePunePerMuajinAktual(DateTime currentDate)
        {
            List<DateTime> teGjithaDitet = ditetPerMuajinAktual(currentDate);
            List<DateTime> ditetEFestave = diteFestePerMuajinAktual(currentDate);
            List<DateTime> datatEfundjaves = teGjithaDitet.Where(d => d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday).ToList();

            int ditePune = teGjithaDitet.Count - datatEfundjaves.Count() - diteFestePerMuajinAktual(currentDate).Count;
            return ditePune;
        }

        public static List<DateTime> diteFestePerMuajinAktual(DateTime currentDate)
        {
            int thisYear = currentDate.Year;
            int thisMonth = currentDate.Month;

            salaryEntities entities = new salaryEntities();
            var festat = entities.Datat_e_Festave_Zyrtare.Select(d=>d.data).ToList();

            var ditFestash = festat.Where(d => d.Month == thisMonth && d.Year == thisYear).ToList();

            return ditFestash;
        }
        public static List<DateTime> ditetPerMuajinAktual(DateTime currentDate)
        {
            int thisYear = currentDate.Year;
            int thisMonth = currentDate.Month;
            int days = DateTime.DaysInMonth(thisYear, thisMonth);
            List<DateTime> dates = new List<DateTime>();
            for (int i = 1; i <= days; i++)
            {
                dates.Add(new DateTime(thisYear, thisMonth, i));
            }
            return dates;
        }

        public decimal llogaritPagenPerOre(decimal paga,int ditePune)
        {
            decimal pagesaPerOre = ((paga / ditePune) / 8);
            return pagesaPerOre;
        }

    }
}