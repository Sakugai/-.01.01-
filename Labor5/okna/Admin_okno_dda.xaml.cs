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
    /// Логика взаимодействия для Admin_okno_dda.xaml
    /// </summary>
    public partial class Admin_okno_dda : Window
    {
        Authorization_dataTableAdapter ddaTable = new Authorization_dataTableAdapter();
        RoleTableAdapter roleTable = new RoleTableAdapter();

        public Admin_okno_dda()
        {
            InitializeComponent();
            Grid.ItemsSource = ddaTable.GetData();

            Role_cb.ItemsSource = roleTable.GetData();
            Role_cb.DisplayMemberPath = "Роль";
            Role_cb.SelectedValuePath = "ID";
        }

        private void Role_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno okna = new Admin_okno();
            okna.Show();
            Close();
        }

        private void Staff_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno_staff okna = new Admin_okno_staff();
            okna.Show();
            Close();
        }

        private void Dobav_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Login_tb.Text) || String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                ddaTable.Dobav(Login_tb.Text, Password.Password, Convert.ToInt32(Role_cb.SelectedValue));
                Admin_okno_dda okna = new Admin_okno_dda();
                Close();
                okna.Show();
            }
        }

        private void Izmn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Login_tb.Text) || String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                ddaTable.Izmenit(Login_tb.Text, Password.Password, Convert.ToInt32(Role_cb.SelectedValue), Convert.ToInt32(id));
                Admin_okno_dda okna = new Admin_okno_dda();
                Close();
                okna.Show();
            }
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid.SelectedItem != null || String.IsNullOrWhiteSpace(Login_tb.Text) || String.IsNullOrWhiteSpace(Password.Password) )
            {
                Login_tb.Text = (Grid.SelectedItem as DataRowView).Row[1].ToString();
                Password.Password = (Grid.SelectedItem as DataRowView).Row[2].ToString();
                Role_cb.Text = (Grid.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void Nazad_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void Ydal_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null )
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                ddaTable.Ydalit(Convert.ToInt32(id));
                Admin_okno_staff okna = new Admin_okno_staff();
                Close();
                okna.Show();
            }
        }
    }
}
