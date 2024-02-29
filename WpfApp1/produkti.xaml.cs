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
    /// Логика взаимодействия для produkti.xaml
    /// </summary>
    public partial class produkti : Window
    {
        Entities entities = new Entities();
        public produkti()
        {
            InitializeComponent();
            foreach (var llll in entities.Produkti)
                listbox_produkti.Items.Add(llll);
        }

        private void listbox_produkti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listboxing = listbox_produkti.SelectedItem as Produkti;
            if (listboxing != null)
            {
                textbox_naimenovanie.Text = listboxing.Naimenovanie;
                textbox_kategoriya.Text = listboxing.Kategoriya.ToString();
                textbox_cena.Text = listboxing.Cena.ToString();
                Datapicker_produkti.Text = listboxing.Srok_godnosti.ToString();
            }
            else
            {
                textbox_naimenovanie.Text = "";
                textbox_kategoriya.Text = "";
                textbox_cena.Text = "";
                Datapicker_produkti.Text = "";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var Savescripting = listbox_produkti.SelectedItem as Produkti;
            if (textbox_naimenovanie.Text == "" || textbox_kategoriya.Text == "" || textbox_cena.Text == "" || Datapicker_produkti.Text == "")
                MessageBox.Show("Заполнины не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (Savescripting == null)
                {
                    Savescripting = new Produkti();

                    entities.Produkti.Add(Savescripting);
                    listbox_produkti.Items.Add(Savescripting);
                }
                try
                {
                    Savescripting.Naimenovanie = textbox_naimenovanie.Text;
                    Savescripting.Kategoriya = textbox_kategoriya.Text;
                    Savescripting.Cena = int.Parse(textbox_cena.Text);
                    Savescripting.Srok_godnosti = Datapicker_produkti.SelectedDate.Value;

                    entities.SaveChanges();
                    listbox_produkti.Items.Refresh();
                    MessageBox.Show("Записи сохранены!", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность ввденых данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Delite_Click(object sender, RoutedEventArgs e)
        {
            var delitest = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delitest == MessageBoxResult.No)
                return;
            var deliting = listbox_produkti.SelectedItem as Produkti;
            if (deliting != null)
            {
                entities.Produkti.Remove(deliting);

                entities.SaveChanges();
                textbox_naimenovanie.Clear();
                textbox_kategoriya.Clear();
                textbox_cena.Clear();
                Datapicker_produkti.SelectedDate = null;
                listbox_produkti.Items.Remove(deliting);
            }
            else
            {
                MessageBox.Show("Нету удаляемых объектов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void _new_Click(object sender, RoutedEventArgs e)
        {
            textbox_naimenovanie.Text = "";
            textbox_kategoriya.Text = "";
            textbox_cena.Text = "";
            Datapicker_produkti.SelectedDate = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            piki window = new piki();
            window.Show();
            this.Close();
        }
    }
}
