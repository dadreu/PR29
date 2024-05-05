using PR29.Classes;
using PR29;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Linq;

namespace PR29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public UserContext AllUsers = new UserContext();
        public Main()
        {
            InitializeComponent();
            CreateUI();
            CreateCmbxBtn();
        }
        private void CreateUI()
        {
            Parent.Children.Clear();
            foreach (Models.Users User in AllUsers.Users)
            {
                Parent.Children.Add(new Elements.Item(User, this));
            }
        }
        private void CreateCmbxBtn()
        {
            CmbxUsers.Items.Clear();
            ComboBoxItem withoutSort = new ComboBoxItem();
            withoutSort.Tag = 0; withoutSort.Content = "Без сортировки";
            CmbxUsers.Items.Add(withoutSort);
            ComboBoxItem SortByFIO = new ComboBoxItem();
            SortByFIO.Tag = 1; SortByFIO.Content = "По ФИО (A-Z;А-Я)";
            CmbxUsers.Items.Add(SortByFIO);
            ComboBoxItem SortByRentDate = new ComboBoxItem();
            SortByRentDate.Tag = 2; SortByRentDate.Content = "По дате аренды";
            CmbxUsers.Items.Add(SortByRentDate);
            ComboBoxItem SortByClubName = new ComboBoxItem();
            SortByClubName.Tag = 3; SortByClubName.Content = "По клубу";
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Users.Add(this));
        }
        private void CmbxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbxUsers.SelectedIndex == 0)
            {
                CreateUI();
            }
            if (CmbxUsers.SelectedIndex == 1)
            {
                Parent.Children.Clear();
                foreach (Models.Users SortedUser in AllUsers.Users.OrderBy(x => x.FIO))
                {
                    Parent.Children.Add(new Elements.Item(SortedUser, this));
                }
            }
            if (CmbxUsers.SelectedIndex == 2)
            {
                Parent.Children.Clear();
                foreach (Models.Users SortedUser in AllUsers.Users.OrderBy(x => x.RentStart))
                {
                    Parent.Children.Add(new Elements.Item(SortedUser, this));
                }
            }
            if (CmbxUsers.SelectedIndex == 3)
            {
                Parent.Children.Clear();
                foreach (Models.Users SortedUser in AllUsers.Users.OrderBy(x => x.IdClub))
                {
                    Parent.Children.Add(new Elements.Item(SortedUser, this));
                }
            }
        }
    }
}
