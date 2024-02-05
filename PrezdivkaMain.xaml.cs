using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sibenice
{
    /// <summary>
    /// Interaction logic for PrezdivkaMain.xaml
    /// </summary>
    public partial class PrezdivkaMain : Window
    {
       
        private string prezdivka;
        //public SpravaSouboruHracu spravaSouboruHracu;
        SpravaSouboruHracu spravaSouboruHracu;
        private int PocetChyb { get;  set; }
        public PrezdivkaMain(int pocetChyb)
        {
            InitializeComponent();
            PocetChyb = pocetChyb;
            
           

    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            prezdivka_TextBox.Focus();
            if (prezdivka_TextBox.Text == "")
            { prezdivka = "Anonym"; }
            else
            {
                prezdivka = prezdivka_TextBox.Text;
            }
            NejlepsiHrac nejlepsiHrac= new NejlepsiHrac(PocetChyb,prezdivka);
            spravaSouboruHracu= new SpravaSouboruHracu(nejlepsiHrac);
            Prezdivka_Window.Close();
            ZobrazHrace();


        }

        public void ZobrazHrace()
        {
            
            spravaSouboruHracu.Nacti();
            WindowNejlepsiHraci windowNejlepsiHraci = new WindowNejlepsiHraci(spravaSouboruHracu);
            windowNejlepsiHraci.Topmost = true;
            windowNejlepsiHraci.Show();
            



        }
    }
}
