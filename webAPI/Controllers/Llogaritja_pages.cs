using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class Llogaritja_pages
    {
        public List<string[]> llogaritPagen(ExpectedInput input)
        {
            List<Punonjes> punonjesit = input.lista_punonjes;
            List<punonjes_ore_pune> punonjesit_ore_pune = new List<punonjes_ore_pune>();
            List<string[]> rezultati = new List<string[]>();

            int ditePune = ditePunePerMuajinAktual(DateTime.Now);
            foreach (var punonjes in punonjesit)
            {
                var oret = input.ore_pune.Where(o => o.id_punonjes == punonjes.id_punonjes).Select(o => o).ToList();
                punonjesit_ore_pune.Add(new punonjes_ore_pune { punonjes = punonjes, ore_pune = oret });
            }

            foreach (var punonjes in punonjesit_ore_pune)
            {
                decimal rrogaTotale = 0;
                decimal pagesaPerOre = Decimal.Round(llogaritPagenPerOre(punonjes.punonjes.paga_mujore, ditePune), 1);

                var ditetEPunuarNeFundjave = llogaritDitetTePunuaraNeFundjave(punonjes.ore_pune);
                var ditetEPunuaraNeFesta = llogaritDitetTePunuaraNeFesta(punonjes.ore_pune);
                
                var ditetNormale = punonjes.ore_pune.Where(p => ditetEPunuarNeFundjave.All(p2 => p2.data != p.data)).ToList();
                ditetNormale = punonjes.ore_pune.Where(p => ditetEPunuaraNeFesta.All(p2 => p2.data != p.data)).ToList();
                
                decimal oretTePunuaraNeFundjave = (decimal)ditetEPunuarNeFundjave.Sum(d => d.ore_pune);
                decimal oretTePunuaraNeFesta = (decimal)ditetEPunuaraNeFesta.Sum(o => o.ore_pune);
                decimal[] oretPerDitetNormale = oretPerDiteNormale(ditetNormale);

                decimal totalOretNormale = oretPerDitetNormale[0] * pagesaPerOre;
                decimal totalOretShtese = oretPerDitetNormale[1] * pagesaPerOre * input.kushtet.jashte_orari;
                decimal totalOretFundajve = oretTePunuaraNeFundjave * pagesaPerOre * input.kushtet.fundjave;
                decimal totalOretFesta = oretTePunuaraNeFesta * pagesaPerOre * input.kushtet.dite_festash;

                rrogaTotale = totalOretNormale + totalOretShtese + totalOretFundajve + totalOretFesta;
                rezultati.Add(new string[] { punonjes.punonjes.emri, rrogaTotale.ToString() });
            }
            return rezultati;
        }

        private decimal[] oretPerDiteNormale(List<Ditet_e_punes> ditetNormale)
        {
            decimal koheEPlote = 0;
            decimal oreShtese = 0;
            foreach (var dite in ditetNormale)
            {
                if (dite.ore_pune <= 8)
                {
                    koheEPlote = koheEPlote + (decimal)dite.ore_pune;
                }
                else
                {
                    koheEPlote = koheEPlote + 8;
                    oreShtese = oreShtese + (decimal)(dite.ore_pune - 8);
                }
            }
            return new decimal[] {koheEPlote,oreShtese};
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
            var festat = entities.Datat_e_Festave_Zyrtare.Select(d => d.data).ToList();

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

        public decimal llogaritPagenPerOre(decimal paga, int ditePune)
        {
            decimal pagesaPerOre = ((paga / ditePune) / 8);
            return pagesaPerOre;
        }

        public List<Ditet_e_punes> llogaritDitetTePunuaraNeFundjave(List<Ditet_e_punes> datat)
        {
            return datat.Where(d => d.data.DayOfWeek == DayOfWeek.Sunday || d.data.DayOfWeek == DayOfWeek.Saturday).ToList();
        }

        public List<Ditet_e_punes> llogaritDitetTePunuaraNeFesta(List<Ditet_e_punes> datat)
        {
            List<DateTime> dts = datat.Select(d => d.data).ToList();
            List<DateTime> festat = diteFestePerMuajinAktual(dts[0]);

            return datat.Where(d => festat.Contains(d.data)).ToList();

        }
        public string getJsonData()
        {
            salaryEntities se = new salaryEntities();

            ExpectedInput fakeInput = new ExpectedInput();
            Kushtet kushtet = new Kushtet();

            kushtet.dite_festash = 1.5m;
            kushtet.fundjave = 1.25m;
            kushtet.jashte_orari = 1.25m;

            fakeInput.kushtet = kushtet;

            fakeInput.lista_punonjes = se.Punonjes.ToList();
            fakeInput.ore_pune = se.Ditet_e_punes.ToList();

            var a = JsonConvert.SerializeObject(fakeInput);

            return a;
        }

    }
}