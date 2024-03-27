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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MebelEntitiess context = new MebelEntitiess();

        public AdminWindow()
        {
            InitializeComponent();
            TablitsaDGR.ItemsSource = context.Client.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client cl = new Client();
                cl.NameC = NameCl.Text;

                if (midNameCl.Text == string.Empty)
                {
                    cl.MiddleName = "-";
                }
                else
                {
                    cl.MiddleName = midNameCl.Text;
                }

                cl.AddressC = eAddressCl.Text;

                cl.PhoneNumberC = phoneCl.Text;

                long num = 0;
                bool result = long.TryParse(cl.PhoneNumberC, out num);
                if (result == true && cl.PhoneNumberC.Length >= 10)
                {
                    context.Client.Add(cl);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                if (NameCl.Text == string.Empty || midNameCl.Text == string.Empty || eAddressCl.Text == string.Empty ||
                phoneCl.Text == string.Empty)
                {
                    MessageBox.Show("Не все поля заполнены!", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (NameCl.Text != string.Empty && midNameCl.Text != string.Empty && eAddressCl.Text != string.Empty &&
                phoneCl.Text != string.Empty)
                {
                    MessageBox.Show("Не все поля заполнены корректно!", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            TablitsaDGR.ItemsSource = context.Client.ToList();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TablitsaDGR.SelectedItem != null)
            {
                context.SaveChanges();
                TablitsaDGR.ItemsSource = context.Client.ToList();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TablitsaDGR.SelectedItem != null)
            {
                context.Client.Remove(TablitsaDGR.SelectedItem as Client);
                context.SaveChanges();
                TablitsaDGR.ItemsSource = context.Client.ToList();
            }
        }

        private void TablitsaDGR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = TablitsaDGR.SelectedItem as Client;
            NameCl.Text = selected.NameC;
            midNameCl.Text = selected.MiddleName;
            eAddressCl.Text = selected.AddressC;
            phoneCl.Text = selected.PhoneNumberC;
        }
    }
}
