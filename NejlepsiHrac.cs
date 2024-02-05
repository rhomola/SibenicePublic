using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibenice
{
    public class NejlepsiHrac
    {

        public int PocetChyb { get;  set; }
        public string Prezdivka { get; set; }
        public NejlepsiHrac(int pocetChyb, string prezdivka)
        {
            PocetChyb = pocetChyb;
            Prezdivka = prezdivka;

        }

        public NejlepsiHrac()
        {

        }

        public override string ToString()
        {
            return Prezdivka+ " - "+"počet chyb: "+PocetChyb;
        }








    }
}
