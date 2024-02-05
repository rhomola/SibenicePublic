using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sibenice
{
    public class SpravaSouboruHracu
    {
        /// <summary>
       /// kolekce nejlepších hráču definovaná jako vlastnost
      /// </summary>
        public ObservableCollection<NejlepsiHrac> ListHracu { get; set; }

        public NejlepsiHrac Hrac { get; set; }
        //cesta ke složce kde se ukládá xml soubor nejlepších hráču
        private string cesta;
        //název a cesta k souboru kde se ukládá 
        private string cestaKSouboru;

        /// <summary>
        // konstruktor sloužící pro vypsání pouze seznamu nejlepšíh hraču je volán v main bez vytvoření hráče
        /// </summary>
        public SpravaSouboruHracu()
        {
            Hrac=null;
            ListHracu = new ObservableCollection<NejlepsiHrac>();
            cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sibenice");
            cestaKSouboru = Path.Combine(cesta, "WindowNejlepsiHraci.xml");
        }
    //konstruktor volaný při při hře hráče a přidání do souboru
        public SpravaSouboruHracu(NejlepsiHrac hrac)
        {
            Hrac = hrac;
            ListHracu = new ObservableCollection<NejlepsiHrac>();
            cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sibenice");
            cestaKSouboru = Path.Combine(cesta, "WindowNejlepsiHraci.xml");
            
        }
        //uložení seznamu výherních hráču do Xml souboru pomocí serilizace
        public void Uloz()
        {
            XmlSerializer serializer = new XmlSerializer(ListHracu.GetType());
            using (StreamWriter sw = new StreamWriter(cestaKSouboru))
            {
                serializer.Serialize(sw, ListHracu);
            }
        }
        // načtení nejlepších hráču do kolekce ze souboru xml a přidání dalšího hráče pokud nějaký byl. Deserilizace
        public void Nacti()
        {
            XmlSerializer serilizer = new XmlSerializer(ListHracu.GetType());
            if (File.Exists(cestaKSouboru))
            {
                using (StreamReader sr = new StreamReader(cestaKSouboru))
                {
                    ListHracu = (ObservableCollection<NejlepsiHrac>)serilizer.Deserialize(sr);

                }
            }
            //pokud nebyl vytvořen hráč slouží pouze pro vypsání ze souboru xml
            if (Hrac != null)
            {
                ListHracu.Add(Hrac);
            }
            SeradPodleChyb();
        }
        //seřazení hráčů podle počtu chyb od nejméně chyb
        private void SeradPodleChyb()
        {
            var razeni = new ObservableCollection<NejlepsiHrac>(ListHracu.OrderBy(o => o.PocetChyb));
            ListHracu = razeni;
        }




    }
}
