using Microsoft.Win32;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities entities = new Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = text_box_login.Text.Trim();
                string password = password_box.Password.Trim();

                var user = entities.Login.FirstOrDefault(p => p.Name == login && p.Password == password);
                if (user != null)
                {
                    if (user.Roli == 1)
                    {
                        MessageBox.Show("Вы вошли как администратор, " + user.Name);
                        piki Adminchik = new piki();
                        Adminchik.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Вы вошли как пользователь, " + user.Name);
                        Window2 win = new Window2();
                        win.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                    text_box_login.Text = "";
                    password_box.Password = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Registracia registrWindow = new Registracia();
            registrWindow.Show();
            this.Close();
        }
    }
}
