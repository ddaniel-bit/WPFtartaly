using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tartaly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = false;
            txtAel.Text = "10";
            txtBel.IsEnabled = false;
            txtBel.Text = "10";
            txtCel.IsEnabled = false;
            txtCel.Text = "10";
        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = true;
            txtAel.Text = "";
            txtBel.IsEnabled = true;
            txtBel.Text = "";
            txtCel.IsEnabled = true;
            txtCel.Text = "";
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Tartaly tartaly = new Tartaly(txtNev.Text, int.Parse(txtAel.Text), int.Parse(txtBel.Text), int.Parse(txtCel.Text));
            tartalyok.Add(tartaly);
            lbTartalyok.Items.Add(tartaly.Info());
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("tartaly.txt");
            for (int i = 0; i < lbTartalyok.Items.Count; i++)
            {
                string sor = $"{tartalyok[i].Nev};{tartalyok[i].aEl};{tartalyok[i].bEl};{tartalyok[i].cEl}";
                sw.WriteLine(sor);
            }
            sw.Close();
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex != -1)
            {
                tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex != -1)
            {
                tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex != -1)
            { 
                tartalyok[lbTartalyok.SelectedIndex].Tolt(Convert.ToDouble(txtMennyitTolt.Text));
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
        }
    }
}
