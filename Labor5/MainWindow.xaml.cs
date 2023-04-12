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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labor5.kassir_okna;
using Labor5.Lab5DataSetTableAdapters;
using Labor5.okna;
using Labor5.polz_okna;

namespace Labor5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Authorization_dataTableAdapter authorization = new Authorization_dataTableAdapter();

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var vxod = authorization.GetData().Rows;
            Boolean oa = true;
            if (String.IsNullOrWhiteSpace(Login.Text)|| String.IsNullOrWhiteSpace(Password.Password ))
                MessageBox.Show("Имеются пустые поля");
            else
            {
                for (int i = 0; i < vxod.Count; i++)
                {
                    if (vxod[i][1].ToString() == Login.Text && vxod[i][2].ToString() == Password.Password)
                    {
                        string role = vxod[i][3].ToString();
                        switch (role)
                        {
                            case "Администратор":
                                Admin_okno okna = new Admin_okno();
                                okna.Show();
                                Close();
                                oa = false;
                                break;
                            case "Пользователь":
                                Polz_okno polz_okna = new Polz_okno();
                                polz_okna.Show();
                                Close();
                                oa = false;
                                break;
                            case "Кассир":
                                Kassir_okno kassir_okna = new Kassir_okno();
                                kassir_okna.Show();
                                Close();
                                oa= false;
                                break;
                        }
                    }
                }
                if (oa != false)
                {
                    MessageBox.Show("Неверен логин или пароль");
                }
            }
        }
    }
}
