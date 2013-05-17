using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace wangzhetianxia
{
    public partial class zhaobinidea1 : PhoneApplicationPage
    {
        String username;
        public zhaobinidea1()
        {
            InitializeComponent();
            username = YuXiaoindex.Username;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Zhaobinidea1add1.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Zhaobinidea1add2.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Zhaobinidea1add3.xaml", UriKind.Relative));
        }
    }
}