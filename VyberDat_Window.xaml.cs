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
using System.Configuration;
using Npgsql;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;

namespace Sibenice
{
    /// <summary>
    /// Interaction logic for VyberDat_Window.xaml
    /// </summary>
    public partial class VyberDat_Window : Window
    {
        /// <summary>
        ///  proměnná connection string načtená z konfiguračního souboru
        /// </summary>
        /// 
        public string Con { get; private set;}
        public string VyberUloziste { get; private set;}
        public string TypSlov { get; private set;}


        private string con = "";
        public VyberDat_Window()
        {

            InitializeComponent();
            NactiConfiguraci();
        }

        /// <summary>
        /// nastavení viditelnosti výběru podla nastavení radiobuttonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void databaze_RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            connectionString_label.Visibility = Visibility.Visible;
            connectionString_TextBox.Visibility = Visibility.Visible;
            typSlov_GroupBox.Visibility = Visibility.Visible;
            napoveda_label.Visibility = Visibility.Visible;
            ceske_radioButton.IsChecked = true;

        }

        /// <summary>
        /// nastavení viditelnosti výběru podla nastavení radiobuttonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void interni_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            connectionString_label.Visibility = Visibility.Hidden;
            connectionString_TextBox.Visibility = Visibility.Hidden;
            typSlov_GroupBox.Visibility = Visibility.Hidden;
            napoveda_label.Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// Nactení konfigurace z konfiguračního souboru. Nacte se hodnota výběru slovníku zda interního nebo z databáze, 
        /// connection string do textboxu a proměnné con a výběr typu slovíku 
        /// pokud se hodnoty nepodaří načíst nastaví se výběr defalt slovník jako interní
        /// </summary>
        private void NactiConfiguraci()
        {
            
            try
            {
                databaze_RadioButton.IsChecked = Properties.Settings.Default.VyberUlozisteSlovicek_Setting;
                interni_RadioButton.IsChecked = !Properties.Settings.Default.VyberUlozisteSlovicek_Setting;
               string slovicka = Properties.Settings.Default.TypSlovicek_Setting;
                //zapsání vlastnosti z ulozeneho config pro vyčtení pro generování slov
                if (Properties.Settings.Default.VyberUlozisteSlovicek_Setting == true)
                {
                    VyberUloziste = "databazove";
                   
                    //zapsání vlastnosti z ulozeneho config 
                    Con = Properties.Settings.Default.ConnectionString_Setting;
                    connectionString_TextBox.Text = Con;

                    //overeni spojenia ponactení
                  if(!TestPripojeni(Con))
                    {
                        throw new Exception ("Připojení k databázi se nezdařilo, ověřte správný formát Connection string, konfigurační soubor *user.conf*, popřípadě upravte konfiguraci databáze");
                    }

                }


                else
                {
                    VyberUloziste = "interni";
                }


                if (slovicka == "české")
                {
                    ceske_radioButton.IsChecked = true;
                    //zapsání vlastnosti z ulozeneho config pro vyčtení pro generování slov
                    TypSlov = "české";
                }
                else
                {
                    if (slovicka == "anglické")
                    {
                        anglicke_radioButton.IsChecked = true;
                        //zapsání vlastnosti z ulozeneho config pro vyčtení pro generování slov
                        TypSlov = "anglické";
                    }
                    else
                    {
                        ceskoAnglicke_RadioButton.IsChecked = true;
                        //zapsání vlastnosti z ulozeneho config pro vyčtení pro generování slov
                        TypSlov = "česko-anglické";
                    }
                }
                



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                interni_RadioButton.IsChecked = true;
                //zapsání vlastnosti z ulozeneho config pro vyčtení pro generování slov
                VyberUloziste = "interni";
            }


        }

        /// <summary>
        /// Test připojení k databázi pomocí vstupního overovacího connection Stringu
        /// </summary>
        /// <param name="overovacíCon"></param>
        /// <returns></returns>
        private bool TestPripojeni(string overovacíCon)
        {
            try
            {
                using (var connection = new NpgsqlConnection(overovacíCon))
                    connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Oveření zda jsou strávně zdadány hodnoty pro připojení k databázi, pokud ano jsou hodnoty uloženy do konfiguračního souboru 
        /// </summary>
        private void OverPripojeniDatabaze()
        {
            con = connectionString_TextBox.Text;
            if (!string.IsNullOrEmpty(con))
            {
                bool pripojeni = TestPripojeni(con);
                if (!pripojeni)
                {
                    //postgress povolení připojení přes ip adresu, host name  v souborech postgresql.conf -> listen_addresses = '*' a pg_hba.conf host ->   all all "adresa rozsah adresy" md5
                    MessageBox.Show("Připojení k databázi se nezdařilo, ověřte správný formát Connection string, popřípadě upravte konfiguraci databáze");
                }
                else
                {
                    Con = con;
                    UlozConfiguraci();
                }
              
            }
            else { 
                MessageBox.Show("Nebyl zadán žádný Connection string");
                 }

           
        }
        /// <summary>
        /// uložení konfigurace  vyběru uložiště,  connection stringu a výběr typu slovíček 
        /// </summary>
        private void UlozConfiguraci()
        {

            Properties.Settings.Default.VyberUlozisteSlovicek_Setting = databaze_RadioButton.IsChecked ?? false;

            if (ceske_radioButton.IsChecked == true)
                Properties.Settings.Default.TypSlovicek_Setting = "české";
            else
            { if (anglicke_radioButton.IsChecked == true)
                    Properties.Settings.Default.TypSlovicek_Setting = "anglické";
                else
                {
                    Properties.Settings.Default.TypSlovicek_Setting = "českoAnglické";
                }
            }
            Properties.Settings.Default.ConnectionString_Setting = connectionString_TextBox.Text;
          

            Properties.Settings.Default.Save();

        }


        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            //kontrola výběru slovíček z databáze a jeho správné připojení 
            if (databaze_RadioButton.IsChecked == true)
            {
                OverPripojeniDatabaze();

            }
            // zvoleno interní uložiště a jeho uložení do konfigurace
            else
            {
                UlozConfiguraci();
            }
          VyberDat_Window1.Close();
        }

        private void napoveda_label_MouseEnter(object sender, MouseEventArgs e)
        {
            napoveda_label.ToolTip = "Host: je IP adresa serveru, kde je umístěna vaše databáze, nebo localhost pokud je na dataáze na lokálním uložišti .\r\nPort: je port, na kterém je databáze hostována pokud je standartně na portu 5432 nemusí se vůbec zadávat Port:5432.\r\nUsername: je uživatelské jméno pro přístup k databázi.\r\nPassword: je heslo pro přístup k databázi.\r\nDatabase: je název databáze, ke které se chcete připojit.";
        }
    }
}
