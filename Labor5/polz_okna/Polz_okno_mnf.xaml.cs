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
using Labor5.Lab5DataSetTableAdapters;

namespace Labor5.polz_okna
{
    /// <summary>
    /// Логика взаимодействия для Polz_okno_mnf.xaml
    /// </summary>
    public partial class Polz_okno_mnf : Window
    {
        ManufacturerTableAdapter mnfTable = new ManufacturerTableAdapter();
        public Polz_okno_mnf()
        {
            InitializeComponent();
            Grid.ItemsSource = mnfTable.GetData();
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void Product_btn_Click(object sender, RoutedEventArgs e)
        {
            Polz_okno polz_okna = new Polz_okno();
            Close();
            polz_okna.Show();
        }
    }
}
