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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registracia.xaml
    /// </summary>
    public partial class Registracia : Window
    {
        Entities entities = new Entities();
        public Registracia()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = textbox_register.Text.Trim();
                string password = PasswordBoxPass.Password.Trim();
                string password1 = PasswordBox1.Password.Trim();

                if (password != password1)
                {
                    MessageBox.Show("Пароли не совпадают");
                    PasswordBoxPass.Password = "";
                    PasswordBox1.Password = "";
                    return;
                }
                Login user = entities.Login.FirstOrDefault(p => p.Name == login);

                if (user != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    textbox_register.Text = "";
                    PasswordBoxPass.Password = "";
                    PasswordBox1.Password = "";
                    return;
                }
                else
                {
                    user = new Login()
                    {
                        Name = login,
                        Password = password,
                        Roli = 2

                    };

                    entities.Login.Add(user);
                    entities.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован как " + user.Name);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
