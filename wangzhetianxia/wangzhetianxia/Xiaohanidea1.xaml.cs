using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace wangzhetianxia
{
    public partial class Xiaohanidea1 : PhoneApplicationPage
    {
        String username;
        String time;
        String name;

        private MobileServiceCollection<birthday, birthday> birth;
        private MobileServiceCollection<birthday, birthday> birth2;
        private IMobileServiceTable<birthday> todoTable = App.MobileService.GetTable<birthday>();
        private IMobileServiceTable<birthday> todoTable2 = App.MobileService.GetTable<birthday>();
        public Xiaohanidea1()
        {
            InitializeComponent();
            //username = YuXiaoindex.Username;
            //i.Text = username;
            RefreshBirth2();
        }

        private async void RefreshBirth2()
        {
            DateTime date = DateTime.Now;
            String nowdate = date.Month.ToString();
            nowdate += "/";
            nowdate += date.Day.ToString();
            birth2 = await todoTable2.Where(birthday => birthday.Time == nowdate).ToCollectionAsync(); 
            ListItems2.ItemsSource = birth2;
        }

        private async void RefreshBirth()
        {
            try
            {
                birth = await todoTable.Where(birthday => birthday.Time == textbox3.Text).ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }
            ListItems1.ItemsSource = birth;
        }

        private void textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshBirth();
        }

    }
}