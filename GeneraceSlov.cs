using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Sibenice
{
    class GeneraceSlov
    {


        private Random random = new Random();
        private int nahodneCislo;
        public string NahodneSlovo { get; set; }
        public string[] VstupniPoleSlov { get; set; }
        public string[] Pole { get; private set; }
        public int PocetChybnychTipu { get; private set; }
        




        public GeneraceSlov(string uloziste, string connectionString, string slova)
        {
            ZdrojDat zdrojDat = new ZdrojDat(uloziste, connectionString, slova);
            VstupniPoleSlov = zdrojDat.PoleSlov;

            nahodneCislo = random.Next(VstupniPoleSlov.Length);
            NahodneSlovo = VstupniPoleSlov[nahodneCislo];
            NaplnPole();
            PocetChybnychTipu = 0;
        }

        private string[] NaplnPole()
        {
            Pole = new string[NahodneSlovo.Length];
            Array.Fill(Pole, "_");
            return Pole;
        }

        public bool ObsahujeZnak(string znak)
        {
            if (znak != "")
            {

                znak = znak.ToLower();
                string NahodneSlovoMalePismena = NahodneSlovo.ToLower();
                int pocitadlo = 0;

                if (!((Pole.Contains(znak.ToLower())) || (Pole.Contains(znak.ToUpper()))))
                {
                    if (NahodneSlovoMalePismena.Contains(znak))
                    {
                        foreach (char a in NahodneSlovo)
                        {
                            pocitadlo++;
                            if (Char.ToLower(a) == char.Parse(znak))
                            {
                                Pole[pocitadlo - 1] = a.ToString();

                            }
                        }
                        
                        return true;
                    }
                    else
                    {
                        PocetChybnychTipu++;

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Zadaný znak jsi již zadals! \n SMŮLA TO TI NEUZNÁM!!");
                    PocetChybnychTipu++;
                    return false;

                }
            }
            throw new Exception("Nezadal jsi žádný znak");
        }


        public bool VyhralJsi()
        {

            if (!Pole.Contains("_"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



         public string VypisPoleTipu()
        {
            string retezec = null;
            foreach (string i in Pole)
            {
                 retezec = retezec + " " + i;

            }
            return retezec;
        }
      
            
            
    }
}
