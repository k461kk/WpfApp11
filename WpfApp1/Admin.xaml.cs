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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        Entities entities = new Entities();
        public Admin()
        {
            InitializeComponent();
            foreach (var listboxxxx in entities.Login)
                Adminlist.Items.Add(listboxxxx);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window1 wwwindow = new Window1();
            wwwindow.Show();
            this.Close();
        }

        private void Adminlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Admin = Adminlist.SelectedItem as Login;
            if (Admin != null)
            {
                textbox_rol.Text = Admin.Roli.ToString();
            }
            else
            {
                textbox_rol.Text = "";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var adminsuperlist = Adminlist.SelectedItem as Login;
            if (textbox_rol.Text == "")
                MessageBox.Show("Заполнины не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (adminsuperlist == null)
                {
                    adminsuperlist = new Login();

                    entities.Login.Add(adminsuperlist);
                    Adminlist.Items.Add(adminsuperlist);
                }
                try
                {
                    adminsuperlist.Roli = int.Parse(textbox_rol.Text);

                    entities.SaveChanges();
                    Adminlist.Items.Refresh();
                    MessageBox.Show("Записи сохранены!", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность ввденых данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var deli = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deli == MessageBoxResult.No)
                return;
            var admindellist = Adminlist.SelectedItem as Login;
            if (admindellist != null)
            {
                entities.Login.Remove(admindellist);

                entities.SaveChanges();
                textbox_rol.Clear();
                Adminlist.Items.Remove(admindellist);
            }
            else
            {
                MessageBox.Show("Нету удаляемых объектов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
