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
    /// Логика взаимодействия для piki.xaml
    /// </summary>
    public partial class piki : Window
    {
        public piki()
        {
            InitializeComponent();
        }

        private void sklad_Click_1(object sender, RoutedEventArgs e)
        {
            sklad sklad = new sklad();
            sklad.Show();
            this.Close();
        }

        private void Zakazy_Click(object sender, RoutedEventArgs e)
        {
            Zakazyn zakazzzzy = new Zakazyn();
            zakazzzzy.Show();
            this.Close();
        }

        private void Postavshiki_Click(object sender, RoutedEventArgs e)
        {
            postavhiki post = new postavhiki();
            post.Show();
            this.Close();
        }

        private void Produkti_Click(object sender, RoutedEventArgs e)
        {
            produkti Prod = new produkti();
            Prod.Show();
            this.Close();
        }

        private void Adminpanel_Click(object sender, RoutedEventArgs e)
        {
            Admin adm = new Admin();
            adm.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
