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
    /// Логика взаимодействия для Admin_okno_staff.xaml
    /// </summary>
    public partial class Admin_okno_staff : Window
    {
        StaffTableAdapter staffTable = new StaffTableAdapter();
        Authorization_dataTableAdapter ddaTable = new Authorization_dataTableAdapter();

        public Admin_okno_staff()
        {
            InitializeComponent();
            Grid.ItemsSource = staffTable.GetData();

            Pole_cb.ItemsSource = ddaTable.GetData();
            Pole_cb.DisplayMemberPath = "Логин";
            Pole_cb.SelectedValuePath = "ID";
        }

        private void Role_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_okno okna = new Admin_okno();
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
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Patronymic_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {

                staffTable.Dobav(Surname_tb.Text, Name_tb.Text, Patronymic_tb.Text, Convert.ToInt32(Pole_cb.SelectedValue));
                Admin_okno_staff okna = new Admin_okno_staff();
                Close();
                okna.Show();
            }
        }
        private void Ydal_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem != null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Patronymic_tb.Text))
            {
                if (Grid.ItemsSource == null)
                {
                    MessageBox.Show("Имеются пустые поля");
                }
                else
                {
                    object id = (Grid.SelectedItem as DataRowView).Row[0];
                    staffTable.Ydalit(Convert.ToInt32(id));
                    Admin_okno_staff okna = new Admin_okno_staff();
                    Close();
                    okna.Show();
                }
            }
        }

        private void Izmn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text) || String.IsNullOrWhiteSpace(Patronymic_tb.Text))
            {
                MessageBox.Show("Имеются пустые поля");
            }
            else
            {
                object id = (Grid.SelectedItem as DataRowView).Row[0];
                staffTable.Izmenit(Surname_tb.Text, Name_tb.Text, Patronymic_tb.Text, Convert.ToInt32(Pole_cb.SelectedValue), Convert.ToInt32(id));
                Grid.ItemsSource = staffTable.GetData();
                Admin_okno_staff okna = new Admin_okno_staff();
                Close();
                okna.Show();
            }
        }
        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid.SelectedItem != null || String.IsNullOrWhiteSpace(Surname_tb.Text) || String.IsNullOrWhiteSpace(Name_tb.Text)  ||  String.IsNullOrWhiteSpace(Patronymic_tb.Text))
            {
                Surname_tb.Text = (Grid.SelectedItem as DataRowView).Row[1].ToString();
                Name_tb.Text = (Grid.SelectedItem as DataRowView).Row[2].ToString();
                Patronymic_tb.Text = (Grid.SelectedItem as DataRowView).Row[3].ToString();
                Pole_cb.Text = (Grid.SelectedItem as DataRowView).Row[4].ToString();
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
