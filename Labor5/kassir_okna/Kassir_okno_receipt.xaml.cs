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

namespace Labor5.kassir_okna
{
    /// <summary>
    /// Логика взаимодействия для Kassir_okno_receipt.xaml
    /// </summary>
    public partial class Kassir_okno_receipt : Window
    {
        ProductsTableAdapter productsTable = new ProductsTableAdapter();
        public Kassir_okno_receipt()
        {
            InitializeComponent();
            Grid.ItemsSource = productsTable.GetData();
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void Warehouse_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno_ware kassir_okna = new Kassir_okno_ware();
            Close();
            kassir_okna.Show();
        }

        private void Product_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno kassir_okna = new Kassir_okno();
            Close();
            kassir_okna.Show();
        }

        List <Chek> chek = new List<Chek>();

        public string Names { get; private set; }

        private void Tyda_btn_Click(object sender, RoutedEventArgs e)
        {
            Names = (Grid.SelectedItem as DataRowView).Row[1].ToString();

        }
    }
}
