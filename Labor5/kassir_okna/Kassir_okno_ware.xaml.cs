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
    /// Логика взаимодействия для Kassir_okno_ware.xaml
    /// </summary>
    public partial class Kassir_okno_ware : Window
    {
        WarehouseTableAdapter warehouseTable = new WarehouseTableAdapter();
        
        public Kassir_okno_ware()
        {
            InitializeComponent();

            Grid.ItemsSource = warehouseTable.GetData();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid.SelectedItem != null || String.IsNullOrWhiteSpace(Adress_tb.Text) || String.IsNullOrWhiteSpace(Capacity_tb.Text))
            {
                Adress_tb.Text = (Grid.SelectedItem as DataRowView).Row[1].ToString();
                Capacity_tb.Text = (Grid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void Product_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno kassir_okna = new Kassir_okno();
            Close();
            kassir_okna.Show();
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }
        private void Dobav_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Adress_tb.Text) || String.IsNullOrWhiteSpace(Capacity_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                warehouseTable.Dobav(Adress_tb.Text, Convert.ToInt32(Capacity_tb.Text));
                Kassir_okno_ware kassir_okna = new Kassir_okno_ware();
                Close();
                kassir_okna.Show();
            }
        }
        private void Izmen_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Adress_tb.Text) || String.IsNullOrWhiteSpace(Capacity_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                warehouseTable.Izmenit(Adress_tb.Text, Convert.ToInt32(Capacity_tb.Text), Convert.ToInt32(id));
                Kassir_okno_ware kassir_okna = new Kassir_okno_ware();
                Close();
                kassir_okna.Show();
            }
        }
        private void Ydal_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Adress_tb.Text) || String.IsNullOrWhiteSpace(Capacity_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                warehouseTable.DeleteQuery(Convert.ToInt32(id));
                Kassir_okno_ware kassir_okna = new Kassir_okno_ware();
                Close();
                kassir_okna.Show();
            }
        }

        private void Receipt_btn_Click(object sender, RoutedEventArgs e)
        {
            Kassir_okno_receipt kassir_okna = new Kassir_okno_receipt();
            Close();
            kassir_okna.Show();
        }
    }
}
