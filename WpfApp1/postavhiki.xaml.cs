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
    /// Логика взаимодействия для postavhiki.xaml
    /// </summary>
    public partial class postavhiki : Window
    {
        Entities entities = new Entities();
        public postavhiki()
        {
            InitializeComponent();
            foreach (var entity in entities.Postavchiki)
                listbox_postavshiki.Items.Add(entity);
        }

        private void listbox_postavshiki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lisichka = listbox_postavshiki.SelectedItem as Postavchiki;
            if (lisichka != null)
            {
                textbox_nazvanie.Text = lisichka.Naimenovanie.ToString();
                textbox_adres.Text = lisichka.Adres.ToString();
                textbox_telefon.Text = lisichka.Telefon.ToString();
            }
            else
            {
                textbox_nazvanie.Text = "";
                textbox_adres.Text = "";
                textbox_telefon.Text = "";
            }
        }

        private void Saveses_Click(object sender, RoutedEventArgs e)
        {
            var savesss = listbox_postavshiki.SelectedItem as Postavchiki;
            if (textbox_nazvanie.Text == "" || textbox_adres.Text == "" || textbox_telefon.Text == "")
                MessageBox.Show("Заполнины не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (savesss == null)
                {
                    savesss = new Postavchiki();

                    entities.Postavchiki.Add(savesss);
                    listbox_postavshiki.Items.Add(savesss);
                }
                try
                {
                    savesss.Naimenovanie = textbox_nazvanie.Text;
                    savesss.Adres = textbox_adres.Text;
                    savesss.Telefon = int.Parse(textbox_telefon.Text);

                    entities.SaveChanges();
                    listbox_postavshiki.Items.Refresh();
                    MessageBox.Show("Записи сохранены!", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность ввденых данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Deletes_Click(object sender, RoutedEventArgs e)
        {
            var del = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (del == MessageBoxResult.No)
                return;
            var delitesss = listbox_postavshiki.SelectedItem as Postavchiki;
            if (delitesss != null)
            {
                entities.Postavchiki.Remove(delitesss);

                entities.SaveChanges();
                textbox_nazvanie.Clear();
                textbox_telefon.Clear();
                textbox_adres.Clear();
                listbox_postavshiki.Items.Remove(delitesss);                
            }
            else
            {
                MessageBox.Show("Нету удаляемых объектов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void neweses_Click(object sender, RoutedEventArgs e)
        {
            textbox_nazvanie.Text = "";
            textbox_telefon.Text = "";
            textbox_adres.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            piki wwwwindow = new piki();
            wwwwindow.Show();
            this.Close();
        }
    }
}
