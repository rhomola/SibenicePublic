using Sibenice.obesenec_obrazky;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sibenice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Prohra_Window prohra_Window;
        WindowNejlepsiHraci windowNejlepsiHraci;
        GeneraceSlov generaceSlov;
        public PrezdivkaMain prezdivkaWindow;
     


        public MainWindow()
        {
            InitializeComponent();
            tip_TextBox.IsEnabled = false;
            tipnout_Button.IsEnabled = false;
            uvodniObr.Visibility = Visibility.Visible;
           


    }

        private void NactiConfig()
        {
            
            VyberDat_Window vyberDat_Window = new VyberDat_Window();
            string uloziste = "";
            string connectionString = "";
            string slova = "";
            

            uloziste = vyberDat_Window.VyberUloziste;
            if (uloziste != "interni")
            {
                
                connectionString = vyberDat_Window.Con;
                slova = vyberDat_Window.TypSlov;

                Uloziste_Label.Content = "z databáze";
                Slovicko_Label.Content = slova;
            }
            else
            {
                Uloziste_Label.Content = "z interní paměti";
                Slovicko_Label.Content = "české";

            }
            generaceSlov = new GeneraceSlov(uloziste, connectionString, slova);

        }
        private void tipnout_Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                if (generaceSlov.ObsahujeZnak(tip_TextBox.Text))
                {
                    konecneSlovo_TextBlock.Text = generaceSlov.VypisPoleTipu();
                    
                    if (generaceSlov.VyhralJsi())
                    {
                        konecneSlovo_TextBlock.Text = generaceSlov.VypisPoleTipu();
                        prezdivkaWindow = new PrezdivkaMain(generaceSlov.PocetChybnychTipu);
                        prezdivkaWindow.Topmost = true;
                        tip_TextBox.IsEnabled = false;
                        tipnout_Button.IsEnabled = false;
                        prezdivkaWindow.Show();

                    }
                }
                else
                {
                    ZmenObrazek();
                     if (generaceSlov.PocetChybnychTipu == 9)
                    {
                        tip_TextBox.IsEnabled = false;
                        tipnout_Button.IsEnabled = false;
                        prohra_Window = new Prohra_Window(generaceSlov.NahodneSlovo);
                        prohra_Window.Topmost = true;
                        prohra_Window.Show();
                        
                    }
                  
                        else
                        {
                            konecneSlovo_TextBlock.Text = generaceSlov.VypisPoleTipu();
                        }
                    
                }
                tip_TextBox.Text = "";
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message,"Chyba",MessageBoxButton.OK, MessageBoxImage.Error );    
            }
            tip_TextBox.Focus();
        }

        private void tip_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(char.Parse(e.Text)))
            {
                e.Handled = true;
            }
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            tip_TextBox.Focus();
        }

             
        private void nejlepsi_Button_Click(object sender, RoutedEventArgs e)
        {
            if (windowNejlepsiHraci == null || !windowNejlepsiHraci.IsVisible)
            {
                SpravaSouboruHracu spravaSouboruHracuVypis = new SpravaSouboruHracu();
                spravaSouboruHracuVypis.Nacti();

                //vytvoření nové instance windowNejlepsiHraci s aktualní instancí main sloužící pro otevření pouze jednoho okna windowNejlepsiHraci pomocí nejlepsi_Button.IsEnabled 
                WindowNejlepsiHraci windowNejlepsiHraci = new WindowNejlepsiHraci(spravaSouboruHracuVypis,this);
                windowNejlepsiHraci.Topmost = true;
                windowNejlepsiHraci.Show();
                nejlepsi_Button.IsEnabled= false;
            }
        }


        private void ZmenObrazek()
        {
           /* uvodniObr.Visibility = generaceSlov.PocetChybnychTipu == 0 ? Visibility.Visible : Visibility.Hidden;
            obr1.Visibility = generaceSlov.PocetChybnychTipu > 0 ? Visibility.Visible : Visibility.Hidden;
            obr2.Visibility = generaceSlov.PocetChybnychTipu > 1 ? Visibility.Visible : Visibility.Hidden;
            obr3.Visibility = generaceSlov.PocetChybnychTipu > 2 ? Visibility.Visible : Visibility.Hidden;
            obr4.Visibility = generaceSlov.PocetChybnychTipu > 3 ? Visibility.Visible : Visibility.Hidden;
            obr5.Visibility = generaceSlov.PocetChybnychTipu > 4 ? Visibility.Visible : Visibility.Hidden;
            obr6.Visibility = generaceSlov.PocetChybnychTipu > 5 ? Visibility.Visible : Visibility.Hidden;
            obr7.Visibility = generaceSlov.PocetChybnychTipu > 6 ? Visibility.Visible : Visibility.Hidden;
            obr8.Visibility = generaceSlov.PocetChybnychTipu > 7 ? Visibility.Visible : Visibility.Hidden;
            obr9.Visibility = generaceSlov.PocetChybnychTipu > 8 ? Visibility.Visible : Visibility.Hidden;
            obr10.Visibility =generaceSlov.PocetChybnychTipu > 9 ? Visibility.Visible : Visibility.Hidden;

            */
            if (generaceSlov.PocetChybnychTipu == 0)
            {
                uvodniObr.Visibility = Visibility.Visible;
                obr1.Visibility = Visibility.Hidden;
            }
            else
            {
            uvodniObr.Visibility = Visibility.Hidden;
            }

                if (generaceSlov.PocetChybnychTipu >= 1)
                {
                   // uvodniObr.Visibility = Visibility.Hidden;
                    obr1.Visibility = Visibility.Visible;
                    obr2.Visibility = Visibility.Visible;
                }
                else { obr2.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 2)
                    obr3.Visibility = Visibility.Visible;
                else { obr3.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 3)
                    obr4.Visibility = Visibility.Visible;
                else { obr4.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 4)
                    obr5.Visibility = Visibility.Visible;
                else { obr5.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 5)
                    obr6.Visibility = Visibility.Visible;
                else { obr6.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 6)
                    obr7.Visibility = Visibility.Visible;
                else { obr7.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 7)
                    obr8.Visibility = Visibility.Visible;
                else { obr8.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 8)
                    obr9.Visibility = Visibility.Visible;
                else { obr9.Visibility = Visibility.Hidden; }

                if (generaceSlov.PocetChybnychTipu >= 9)
                    obr10.Visibility = Visibility.Visible;
                else { obr10.Visibility = Visibility.Hidden; }

            
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            VyberDat_Window vyberDat_Window = new VyberDat_Window();
            tip_TextBox.IsEnabled = false;
            tipnout_Button.IsEnabled = false;
            vyberDat_Window.Topmost = true;
            vyberDat_Window.Show();
          
        }

        private void NovaHra_Button_Click(object sender, RoutedEventArgs e)
        {
            //uvodniObr.Visibility = Visibility.Visible;
            tip_TextBox.Text = "";
            tip_TextBox.IsEnabled = true;
            tipnout_Button.IsEnabled = true;
            tip_TextBox.Focus();
            NactiConfig();
            konecneSlovo_TextBlock.Text = generaceSlov.VypisPoleTipu();
            ZmenObrazek();
            tip_TextBox.IsEnabled = true;

        }

        private void JakHrat_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            JakHratWindow jakHratHru_window = new JakHratWindow();
            jakHratHru_window.Topmost = true;
            jakHratHru_window.Show();
        }

        private void OProgramu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OProgramu_window oProgramu_window= new OProgramu_window();
           oProgramu_window.Topmost=true;
            oProgramu_window.Show();
        }

        private void Main_Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter)&&(tipnout_Button.IsEnabled==true))
            {
                tipnout_Button_Click(sender, e);
            }

        }
    }
}
