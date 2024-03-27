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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        MebelEntitiess context = new MebelEntitiess();
        public UserWindow()
        {
            InitializeComponent();
            TablitsaDGR.ItemsSource = context.ShourumContent.ToList();

            typeCbx.ItemsSource = context.FurnitureType.ToList();
            typeCbx.DisplayMemberPath = "NameFT";

            showroomCbx.ItemsSource = context.Shourum.ToList();
            showroomCbx.DisplayMemberPath = "NameShourum";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Furniture furn = new Furniture();
                if (mebelName.Text == string.Empty)
                {
                    throw new Exception();
                }
                furn.NameF = mebelName.Text;

                if (typeCbx.SelectedItem != null)
                {
                    foreach (var item in context.FurnitureType.ToList())
                    {
                        if (item.Equals(typeCbx.SelectedItem))
                        {
                            furn.ID_FurnitureType = item.ID_FurnitureType;
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }
                context.Furniture.Add(furn);
                context.SaveChanges();

                ShourumContent showroom = new ShourumContent();
                showroom.ID_Furniture = furn.ID_Furniture;
                if (showroomCbx.SelectedItem != null)
                {
                    foreach (var item in context.Shourum.ToList())
                    {
                        if (item.Equals(showroomCbx.SelectedItem))
                        {
                            showroom.ID_Shourum = item.ID_Shourum;
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }
                int num = 0;
                bool result = int.TryParse(amount.Text, out num);
                if (result == true)
                {
                    showroom.Kolichestvo = Convert.ToInt32(amount.Text);
                }
                else
                {
                    throw new Exception();
                }
                context.ShourumContent.Add(showroom);
                context.SaveChanges();
            }
            catch
            {
                if (mebelName.Text == string.Empty || amount.Text == string.Empty || typeCbx.SelectedItem == null ||
                showroomCbx.SelectedItem == null)
                {
                    MessageBox.Show("Не все поля заполнены!", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (mebelName.Text != string.Empty || amount.Text != string.Empty || typeCbx.SelectedItem != null ||
                showroomCbx.SelectedItem != null)
                {
                    MessageBox.Show("Не все поля заполнены корректно!", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            TablitsaDGR.ItemsSource = context.ShourumContent.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TablitsaDGR.SelectedItem != null)
            {
                var selected = TablitsaDGR.SelectedItem as ShourumContent;

                if (typeCbx.SelectedItem != null)
                {
                    foreach (var item in context.FurnitureType.ToList())
                    {
                        if (item.Equals(typeCbx.SelectedItem))
                        {
                            selected.Furniture.ID_FurnitureType = item.ID_FurnitureType;
                        }
                    }
                }

                if (showroomCbx.SelectedItem != null)
                {
                    foreach (var item in context.Shourum.ToList())
                    {
                        if (item.Equals(showroomCbx.SelectedItem))
                        {
                            selected.ID_Shourum = item.ID_Shourum;
                        }
                    }
                }

                context.SaveChanges();

                TablitsaDGR.ItemsSource = context.ShourumContent.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TablitsaDGR.SelectedItem != null)
            {
                context.ShourumContent.Remove(TablitsaDGR.SelectedItem as ShourumContent);
                context.SaveChanges();

                TablitsaDGR.ItemsSource = context.ShourumContent.ToList();
            }
        }

        private void TablitsaDGR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = TablitsaDGR.SelectedItem as ShourumContent;
            mebelName.Text = selected.Furniture.NameF;
            typeCbx.Text = selected.Furniture.FurnitureType.NameFT;
            amount.Text = selected.Kolichestvo.ToString();
            showroomCbx.Text = selected.Shourum.NameShourum;
        }
    }
}
