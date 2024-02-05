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
    /// Interaction logic for WindowNejlepsiHraci.xaml
    /// </summary>
    public partial class WindowNejlepsiHraci : Window
    {
        SpravaSouboruHracu SpravaSouboruHracu1 { get;  set; }
       public  MainWindow MainWindowThis { get; private set; }
        
            public WindowNejlepsiHraci(SpravaSouboruHracu spravaSouboruHracu)
        {

            SpravaSouboruHracu1 = spravaSouboruHracu;
            InitializeComponent();
            DataContext = SpravaSouboruHracu1;

            
        }
        //konstruktor s parametrem aktualní instance sloužící pro zobrazení vypisu přes tlačítko NEHLEPŠÍ HRÁČI
        public WindowNejlepsiHraci(SpravaSouboruHracu spravaSouboruHracu,MainWindow mainWindowThis)
        {
            SpravaSouboruHracu1 = spravaSouboruHracu;
            InitializeComponent();
            DataContext = SpravaSouboruHracu1;
            MainWindowThis = mainWindowThis;
          

        }

        private void nejlepsiHraci_Window_Closed(object sender, EventArgs e)
        {
            
           //Po zavření se se tlačítko aktualní instance Main zase zaktivní
          //Pokud okno bylo otevřeno přes tlačítko, tlačítko se zase zaktivní  
           if (MainWindowThis!=null)
              MainWindowThis.nejlepsi_Button.IsEnabled = true;
           SpravaSouboruHracu1.Uloz();
        }
    }
}
