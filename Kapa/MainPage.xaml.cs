using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Kapa
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateGrid();
        }

        List<Product> products = new List<Product>();

        void UpdateGrid()
        {
            products.Clear();
            DataGridProduct.ItemsSource = null;
            foreach (Product product in Database.DB.Product)
            {
                products.Add(product);
            }
            DataGridProduct.ItemsSource = products;
        }

        private void findText_TextChanged(object sender, TextChangedEventArgs e)
        {
            products.Clear();
            Regex findTxt = new Regex(@"^" + findText.Text.ToLower() + ".*");
            foreach (Product product in Database.DB.Product)
            {
                if (findTxt.IsMatch(product.ProductName.ToLower()))
                {
                    products.Add(product);
                }
            }
            DataGridProduct.ItemsSource = null;
            DataGridProduct.ItemsSource = products;
        }

        private void AutoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = (MainWindow)Window.GetWindow(this);
            MW.NVG.Navigate(new AutoPage());
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            products.Clear();
            Regex findTxt = new Regex(@"^" + findText.Text.ToLower() + ".*");
            if (findText.Text != "")
            {
                foreach (Product product in Database.DB.Product)
                {
                    if (findTxt.IsMatch(product.ProductName.ToLower()))
                    {
                        products.Add(product);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ничего нет в поле поиска");
                UpdateGrid();
            }
            DataGridProduct.ItemsSource = null;
            DataGridProduct.ItemsSource = products;
        }
    }
}
