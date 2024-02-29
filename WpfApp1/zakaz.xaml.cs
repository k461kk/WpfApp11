using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    public partial class zakaz : Window
    {
        Entities entities = new Entities();
        public zakaz()
        {
            InitializeComponent();
            foreach (var gigi in entities.Zakazy)
                listbox_zakazy.Items.Add(gigi);
            foreach (var kino in entities.Produkti)
                combobox_produktii.Items.Add(kino);
        }

        private void listbox_zakazy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gigini = listbox_zakazy.SelectedItem as Zakazy;
            if (gigini != null)
            {
                textbox_cena.Text = gigini.Stoimost.ToString();
                textbox_kolichestvo.Text = gigini.Kolichestvo.ToString();
                combobox_produktii.SelectedItem = (from Produkti in entities.Produkti where Produkti.Id_Produkti == gigini.Id_Produkti select Produkti).Single<Produkti>();
                Datepicker_zakazy.Text = gigini.Data_zakaza.ToString();
            }
            else
            {
                textbox_cena.Text = "";
                textbox_kolichestvo.Text = "";
                Datepicker_zakazy.Text = "";
                combobox_produktii.SelectedIndex = 0;
            }
        }

        private void Saves_Click(object sender, RoutedEventArgs e)
        {
            var superist = listbox_zakazy.SelectedItem as Zakazy;
            if (textbox_cena.Text == "" || Datepicker_zakazy.Text == "" || combobox_produktii.SelectedIndex == -1 || textbox_kolichestvo.Text == "")
                MessageBox.Show("Заполнины не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (superist == null)
                {
                    superist = new Zakazy();

                    entities.Zakazy.Add(superist);
                    listbox_zakazy.Items.Add(superist);
                }
                try
                {
                    superist.Stoimost = int.Parse(textbox_cena.Text);
                    superist.Kolichestvo = int.Parse(textbox_kolichestvo.Text);
                    superist.Id_Produkti = (combobox_produktii.SelectedItem as Produkti).Id_Produkti;
                    superist.Data_zakaza = Datepicker_zakazy.SelectedDate.Value;

                    entities.SaveChanges();
                    listbox_zakazy.Items.Refresh();
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
            var delites = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delites == MessageBoxResult.No)
                return;
            var delete_listik = listbox_zakazy.SelectedItem as Zakazy;
            if (delete_listik != null)
            {
                entities.Zakazy.Remove(delete_listik);

                entities.SaveChanges();
                textbox_cena.Clear();
                textbox_kolichestvo.Clear();
                listbox_zakazy.Items.Remove(delete_listik);
                Datepicker_zakazy.SelectedDate = null;
                combobox_produktii.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Нету удаляемых объектов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void news_Click(object sender, RoutedEventArgs e)
        {
            textbox_cena.Text = "";
            textbox_kolichestvo.Text = "";
            Datepicker_zakazy.SelectedDate = null;
            combobox_produktii.SelectedIndex = -1;
            listbox_zakazy.SelectedIndex = -1;
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            //if (login.Roli.ToString() == "1" || login.Roli.ToString() == "2")
            //{

            //}
            //else
            //{
            //    MessageBox.Show("У вас нет прав!");
            //    return;
            //}

            //string[,] items_data = new string[listbox_zakazy.Items.Count, 5];

            //for (int i = 0; i < listbox_zakazy.Items.Count; i++)
            //{
            //    string srtoka = listbox_zakazy.Items[i].ToString();
            //    srtoka = srtoka.Replace("Запись №", "");
            //    srtoka = srtoka.Replace("-", " ");
            //    var stroka_ = srtoka.Split(' ');

            //    for (int j = 0; j < stroka_.Length; j++)
            //    {
            //        items_data[i, j] = stroka_[j];
            //    }


            //}

            //Excel.Application exApp = new Excel.Application();
            //exApp.Workbooks.Add();
            //Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            //wsh.Cells[1, 1] = $"Запись №";
            //wsh.Cells[1, 2] = $"id абонемента";
            //wsh.Cells[1, 3] = $"Вход/выход";
            //wsh.Cells[1, 4] = $"Дата";
            //wsh.Cells[1, 5] = $"Время";

            //int maxrow = Excel.Items.Count;
            //int maxcol = 5;

            //for (int row = 0; row < maxrow; row++)
            //{
            //    for (int col = 0; col < maxcol; col++)
            //    {
            //        wsh.Cells[row + 2, col + 1] = $"{items_data[row, col]}";
            //    }
            //}

            //exApp.Visible = true;
        }        

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Window1 wwwindow = new Window1();
            wwwindow.Show();
            this.Close();
        }
    }
}
