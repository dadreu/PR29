using Microsoft.EntityFrameworkCore.Update;
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

namespace PR29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Main Main;
        Models.Clubs Club;
        public Add(Main main, Models.Clubs club = null)
        {
            InitializeComponent();
            Main = main;
            if (club != null )
            {
                Club = club;
                Name.Text = club.Name;
                Address.Text = club.Address;
                WorkTime.Text = club.WorkTime;
                BtnAdd.Content = "Изменить";
            }
        }

        private void AddClub(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Club == null)
                {
                    Club = new Models.Clubs();
                    Club.Name = this.Name.Text;
                    Club.Address = this.Address.Text;
                    Club.WorkTime = this.WorkTime.Text;
                    this.Main.AllClub.Clubs.Add(this.Club);
                }
                else
                {
                    Club.Name = this.Name.Text;
                    Club.Address = this.Address.Text;
                    Club.WorkTime = this.WorkTime.Text;
                }
                this.Main.AllClub.SaveChanges();
                MainWindow.init.OpenPages(new Pages.Clubs.Main());
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
