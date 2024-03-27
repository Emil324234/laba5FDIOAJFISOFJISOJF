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

namespace practa5laba5
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public enum UserRole
    {
        Admin,
        User
    }

    public partial class LoginWindow : Window
    {
        public UserRole Role { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "admin" && passwordBox.Password == "admin")
            {
                Role = UserRole.Admin;
                DialogResult = true;
            }
            else if (usernameTextBox.Text == "user" && passwordBox.Password == "user")
            {
                Role = UserRole.User;
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}