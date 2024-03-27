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

namespace practa5laba5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.DialogResult == true)
            {
                if (loginWindow.Role == UserRole.Admin)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.ShowDialog();
                }
                else if (loginWindow.Role == UserRole.User)
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.ShowDialog();
                }
            }
        }
    }
}
