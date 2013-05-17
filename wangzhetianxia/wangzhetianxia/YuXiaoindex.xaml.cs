using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using wangzhetianxia.Resources;

namespace wangzhetianxia
{
    public partial class YuXiaoindex : PhoneApplicationPage
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
        public static String Username;
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        public YuXiaoindex()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/example.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string querystringvalue = "";
            if (NavigationContext.QueryString.TryGetValue("msg", out querystringvalue))
                Username = querystringvalue;
            


        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/YuXiaoidea1.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/YuXiaoidea1add.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Xiaohanidea1.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Xiaohanidea1add1.xaml", UriKind.Relative));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Zhaobinidea1.xaml", UriKind.Relative));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Wangshengidea1.xaml", UriKind.Relative));
        }


        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/example.xaml", UriKind.Relative));
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Wangshengidea3.xaml", UriKind.Relative));
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Wangshengidea2.xaml", UriKind.Relative));
        }

       


    }
}