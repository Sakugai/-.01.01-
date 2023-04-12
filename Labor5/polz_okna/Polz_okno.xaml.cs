using System;
using System.Collections.Generic;
using System.Data;
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
using Labor5.Lab5DataSetTableAdapters;

namespace Labor5.polz_okna
{
    public partial class Polz_okno : Window
    {
        ProductsTableAdapter productTable = new ProductsTableAdapter();

        public Polz_okno()
        {
            InitializeComponent();
            Grid.ItemsSource = productTable.GetData();

        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }
        private void Manufacturer_btn_Click(object sender, RoutedEventArgs e)
        {
            Polz_okno_mnf polz_okna = new Polz_okno_mnf();
            Close();
            polz_okna.Show();
        }
    }
}
