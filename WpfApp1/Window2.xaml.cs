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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Entities entities = new Entities();
        public Window2()
        {
            InitializeComponent();
            var query = from заказы in entities.Zakazy
                        join продукты in entities.Produkti on заказы.Id_Produkti equals продукты.Id_Produkti
                        select new
                        {
                            заказы.Id_Produkti,
                            заказы.Data_zakaza,
                            заказы.Stoimost,
                            заказы.Kolichestvo,

                            продукты.Naimenovanie
                        };

            // Проверяем, есть ли результаты запроса
            if (query.Count() == 0)
            {
                MessageBox.Show("Ошибка компиляции");
                return;
            }

            // Очищаем содержимое DataGrid
            dataGrid.Items.Clear();

            // Добавляем каждый элемент из результата запроса в DataGrid
            foreach (var item in query)
            {
                dataGrid.Items.Add(item);
            }

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void учше_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wwwindow = new MainWindow();
            wwwindow.Show();
            this.Close();
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.Sheets[1];
            app.Visible = true;
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGrid.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGrid.Columns[i - 1].Header;
            }
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    var value = (dataGrid.Columns[j].GetCellContent(dataGrid.Items[i]) as TextBlock)?.Text;
                    worksheet.Cells[i + 2, j + 1] = value != null ? value : "";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Poisk.Text))
            {
                var rez = entities.Produkti.ToList();
                var filteredRez = rez.Where(p => p.Naimenovanie.ToLower().Contains(Poisk.Text.ToLower())).ToList();
                dataGrid.Items.Clear();
                int totalRecords = rez.Count;
                int searchRecords = filteredRez.Count;
                if (searchRecords > 0)
                {
                    foreach (var item in filteredRez)
                    {
                        dataGrid.Items.Add(item);
                    }
                    // Отобразить общее количество записей и количество записей в режиме поиска 
                    MessageBox.Show($"Общее количество записей: {totalRecords}, Количество записей в режиме поиска: {searchRecords}");
                }
                else
                {
                    MessageBox.Show("Нет результатов");
                }
            }
            else
            {
                MessageBox.Show("Поле поиска пустое. Введите текст для выполнения поиска.");
            }
        }
    }
}
