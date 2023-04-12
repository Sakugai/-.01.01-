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
using Labor5.okna;

namespace Labor5.kassir_okna
{
    /// <summary>
    /// Логика взаимодействия для Kassir_okno.xaml
    /// </summary>
    public partial class Kassir_okno : Window
    {
        ProductsTableAdapter productTable = new ProductsTableAdapter();
        ManufacturerTableAdapter manufacturerTable = new ManufacturerTableAdapter();
        WarehouseTableAdapter warehouseTable = new WarehouseTableAdapter();
        Type_of_decorationTableAdapter type_Of_DecorationTable = new Type_of_decorationTableAdapter();
        Type_of_materialTableAdapter type_Of_MaterialTable = new Type_of_materialTableAdapter();

        public Kassir_okno()
        {
            InitializeComponent();
            Grid.ItemsSource = productTable.GetData();

            CompName_cb.ItemsSource = manufacturerTable.GetData();
            CompName_cb.DisplayMemberPath = "Название компании";
            CompName_cb.SelectedValuePath = "ID";

            Adress_cb.ItemsSource = warehouseTable.GetData();
            Adress_cb.DisplayMemberPath = "Адрес склада";
            Adress_cb.SelectedValuePath = "ID";

            Typemat_cb.ItemsSource = type_Of_MaterialTable.GetData();
            Typemat_cb.DisplayMemberPath = "Тип материала";
            Typemat_cb.SelectedValuePath = "ID";

            Typedec_cb.ItemsSource = type_Of_DecorationTable.GetData();
            Typedec_cb.DisplayMemberPath = "Тип декорации";
            Typedec_cb.SelectedValuePath = "ID";
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Grid.SelectedItem != null)
            {
                Name_tb.Text = (Grid.SelectedItem as DataRowView).Row[1].ToString();
                Price_tb.Text = (Grid.SelectedItem as DataRowView).Row[2].ToString();
                CompName_cb.Text = (Grid.SelectedItem as DataRowView).Row[3].ToString();
                Adress_cb.Text = (Grid.SelectedItem as DataRowView).Row[4].ToString();
                Typemat_cb.Text = (Grid.SelectedItem as DataRowView).Row[5].ToString();
                Typedec_cb.Text = (Grid.SelectedItem as DataRowView).Row[6].ToString();
            }
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void Dobav_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Price_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                productTable.Dobav(Name_tb.Text, Convert.ToInt32(Price_tb.Text), Convert.ToInt32(CompName_cb.SelectedValue), Convert.ToInt32(Adress_cb.SelectedValue), Convert.ToInt32(Typemat_cb.SelectedValue), Convert.ToInt32(Typedec_cb.SelectedValue));
                Kassir_okno kassir_okna = new Kassir_okno();
                Close();
                kassir_okna.Show();
            }
        }

        private void Ydal_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Price_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                productTable.Ydalit(Convert.ToInt32(id));
                Kassir_okno kassir_okna = new Kassir_okno();
                Close();
                kassir_okna.Show();
            }
        }

        private void Izmen_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Price_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                productTable.Izmenit(Name_tb.Text, Convert.ToInt32(Price_tb.Text), Convert.ToInt32(CompName_cb.SelectedValue), Convert.ToInt32(Adress_cb.SelectedValue), Convert.ToInt32(Typemat_cb.SelectedValue), Convert.ToInt32(Typedec_cb.SelectedValue), Convert.ToInt32(id));
                Kassir_okno kassir_okna = new Kassir_okno();
                Close();
                kassir_okna.Show();
            }
        }

        private void Warehouse_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno_ware kassir_okna = new Kassir_okno_ware();
            Close();
            kassir_okna.Show();
        }

        private void Receipt_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno_receipt kassir_okna = new Kassir_okno_receipt();
            Close();
            kassir_okna.Show();
        }
    }
}
