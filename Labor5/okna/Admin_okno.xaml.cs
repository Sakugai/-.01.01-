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

namespace Labor5.okna
{
    /// <summary>
    /// Логика взаимодействия для Admin_okno.xaml
    /// </summary>
    public partial class Admin_okno : Window
    {
        RoleTableAdapter roleTable = new RoleTableAdapter();

        public Admin_okno()
        {
            InitializeComponent();
            Grid.ItemsSource = roleTable.GetData();
        }

        private void Staff_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno_staff okna = new Admin_okno_staff();
            okna.Show();
            Close();
        }

        private void dda_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno_dda okna = new Admin_okno_dda();
            okna.Show();
            Close();
        }

        private void Dobav_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Role_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                roleTable.Dobav(Role_tb.Text);
                Admin_okno okna = new Admin_okno();
                Close();
                okna.Show();
            }
        }

        private void Ydal_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem != null)
            {
                if (Grid.ItemsSource == null)
                {
                    MessageBox.Show("Имеются пустые поля");
                }
                else
                {
                    object id = (Grid.SelectedItem as DataRowView).Row[0];
                    roleTable.Ydalit(Convert.ToInt32(id));
                    Admin_okno okna = new Admin_okno();
                    Close();
                    okna.Show();
                }
            }
        }

        private void Izmn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                roleTable.Izmenit(Role_tb.Text, Convert.ToInt32(id));
                Admin_okno okna = new Admin_okno();
                Close();
                okna.Show();
            }
        }
        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object Role = (Grid.SelectedItem as DataRowView).Row[1];
                Role_tb.Text = Role.ToString();
            }
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }
    }
}
