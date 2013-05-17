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
    public class user
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "gp")]
        public int gp { get; set; }

        [JsonProperty(PropertyName = "tp")]
        public int tp { get; set; }
       
    }

    public partial class MainPage : PhoneApplicationPage
    {
        // MobileServiceCollectionView implements ICollectionView (useful for databinding to lists) and 
        // is integrated with your Mobile Service to make it easy to bind your data to the ListView

        private MobileServiceCollection<user, user> items;
        private IMobileServiceTable<user> todoTable = App.MobileService.GetTable<user>();
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            search();
            
        }

        private async void testsearch()
        {
              try
            {
                   items= await todoTable
                    .Where(userItem => (userItem.Username == rusername.Text) && (userItem.Password == rpassword.Text))
                    .ToCollectionAsync();
                   if (items.Count > 0)
                   {
                       rusername.Text = "你妹，用户名已存在！";
                       
                   }
                   else
                   {

                       
                       var adduser = new user { Username = rusername.Text, Password = rpassword.Text };
                       await todoTable.InsertAsync(adduser);
                       rusername.Text = "注册成功！";
                   }
            }
              catch (MobileServiceInvalidOperationException e)
              {
                  MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
              }
        }

        private async void testupdate()
        {
            user u = new user { Id=2 };
            await todoTable.DeleteAsync(u);
        }

        private async void search()
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
            try
            {
                 //  items= await todoTable
                //    .Where(userItem => (userItem.Username == username.Text) )
                //    .ToCollectionAsync();
                 //  if (items.Count > 0)
                       NavigationService.Navigate(new Uri("/YuXiaoindex.xaml?msg=" + username.Text, UriKind.Relative));
                 //  else
                 //      username.Text = "NO SUCH USER!";
            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            testsearch();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            testupdate();
        }
       
    }
}