using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Zakazyn.xaml
    /// </summary>
    public partial class Zakazyn : Window
    {
        Entities entities = new Entities();
        public Zakazyn()
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
            piki wwwindow = new piki();
            wwwindow.Show();
            this.Close();
        }
    }
}
