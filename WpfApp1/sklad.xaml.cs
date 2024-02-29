using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для sklad.xaml
    /// </summary>
    public partial class sklad : Window
    {
        Entities entities = new Entities();
        public sklad()
        {
            InitializeComponent();
            foreach (var listbox in entities.Sklad)
                listbox_sklad.Items.Add(listbox);
            foreach (var combobox in entities.Produkti)
                combobox_produkti.Items.Add(combobox);
        }

        private void listbox_sklad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listboxx = listbox_sklad.SelectedItem as Sklad;
            if (listboxx != null)
            {
                textbox_kolvo.Text = listboxx.Kolichestvo.ToString();
                combobox_produkti.SelectedItem = (from Produkti in entities.Produkti where Produkti.Id_Produkti == listboxx.Id_Produktii select Produkti).Single<Produkti>();
                Datapicker_postupleniya.Text = listboxx.Data_postupleniya.ToString();
            }
            else
            {
                textbox_kolvo.Text = "";
                Datapicker_postupleniya.Text = "";
                combobox_produkti.SelectedIndex = 0;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var soxranit = listbox_sklad.SelectedItem as Sklad;
            if (textbox_kolvo.Text == "" || Datapicker_postupleniya.Text == "" || combobox_produkti.SelectedIndex == -1)
                MessageBox.Show("Заполнины не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (soxranit == null)
                {
                    soxranit = new Sklad();

                    entities.Sklad.Add(soxranit);
                    listbox_sklad.Items.Add(soxranit);
                }
                try
                {
                    soxranit.Kolichestvo = int.Parse(textbox_kolvo.Text);
                    soxranit.Id_Produktii = (combobox_produkti.SelectedItem as Produkti).Id_Produkti;
                    soxranit.Data_postupleniya = Datapicker_postupleniya.SelectedDate.Value;

                    entities.SaveChanges();
                    listbox_sklad.Items.Refresh();
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
            var delitevika = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delitevika == MessageBoxResult.No)
                return;
            var delete_listtttt = listbox_sklad.SelectedItem as Sklad;
            if (delete_listtttt != null)
            {
                entities.Sklad.Remove(delete_listtttt);

                entities.SaveChanges();
                textbox_kolvo.Clear();
                listbox_sklad.Items.Remove(delete_listtttt);
                Datapicker_postupleniya.SelectedDate = null;
                combobox_produkti.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Нету удаляемых объектов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            textbox_kolvo.Text = "";
            Datapicker_postupleniya.SelectedDate = null;
            listbox_sklad.SelectedIndex = -1;
            combobox_produkti.SelectedIndex = -1;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            piki wwwindow = new piki();
            wwwindow.Show();
            this.Close();
        }
    }
}
