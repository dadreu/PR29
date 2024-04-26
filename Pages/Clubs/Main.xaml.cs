using PR29.Classes;
using PR29.Models;
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

namespace PR29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubContext AllClub = new ClubContext();
        public Main()
        {
            InitializeComponent();
            CreateUI();
            CreateCmbxItems();
        }
        private void CreateUI()
        {
            Parent.Children.Clear();
            foreach (Models.Clubs Club in AllClub.Clubs)
            {
                Parent.Children.Add(new Elements.Item(Club, this));
            }
        }
        private void CreateCmbxItems()
        {
            CmbxSort.Items.Clear();
            ComboBoxItem WithoutSort = new ComboBoxItem();
            WithoutSort.Tag = 0; WithoutSort.Content = "Без сортировки";
            CmbxSort.Items.Add(WithoutSort);
            ComboBoxItem SortByName = new ComboBoxItem();
            SortByName.Tag = 1; SortByName.Content = "По наименованию (А-Я;A-Z)";
            CmbxSort.Items.Add(SortByName);
            ComboBoxItem SortByWorkTime = new ComboBoxItem();
            SortByWorkTime.Tag = 2; SortByWorkTime.Content = "По времени работы";
            CmbxSort.Items.Add(SortByWorkTime);
        }
        private void AddClub(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this));

        private void CmbxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbxSort.SelectedIndex == 0)
            {
                CreateUI();
            }
            if (CmbxSort.SelectedIndex == 1)
            {
                Parent.Children.Clear();
                foreach (Models.Clubs SortedClub in AllClub.Clubs.OrderBy(x => x.Name))
                {
                    Parent.Children.Add(new Elements.Item(SortedClub, this));
                }
            }
            if (CmbxSort.SelectedIndex == 2)
            {
                Parent.Children.Clear();
                foreach (Models.Clubs SortedClub in AllClub.Clubs.OrderBy(x => x.WorkTime))
                {
                    Parent.Children.Add(new Elements.Item(SortedClub, this));
                }
            }
        }
    }
}
