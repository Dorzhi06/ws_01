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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kapa
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.NVG.Navigate(new MainPage());
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(User user in Database.DB.User)
            {
                if(user.UserLogin == loginBox.Text && user.UserPassword == passwordBox.Password)
                {
                    if(user.UserRole == 1)
                    {
                        MainWindow mw = (MainWindow)Window.GetWindow(this);
                        mw.NVG.Navigate(new AdminPage());
                    }else
                    {
                        MessageBox.Show("Недостаточно прав для админ панели");
                    }
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            mw.NVG.Navigate(new MainPage());
        }
    }
}
