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
    /// Interaction logic for Prohra_Window.xaml
    /// </summary>
    public partial class Prohra_Window : Window
    {
        public Prohra_Window(string slovo)
        {

            InitializeComponent();
            ZapisSpravneSlovo(slovo);
        }

       private void ZapisSpravneSlovo(string slovo)
        {
            HledaneSlovo_TextBlock.Text = slovo;
        }

        
    }
}
