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
    public class birthday
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
    }

    public partial class Xiaohanidea1add1 : PhoneApplicationPage
    {

        private IMobileServiceTable<birthday> todoTable = App.MobileService.GetTable<birthday>();
        String username;
        public Xiaohanidea1add1()
        {
            InitializeComponent();
            username = YuXiaoindex.Username;
        }

        private async void InsertBirth(birthday birth)
        {
            await todoTable.InsertAsync(birth);
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Boolean check = false;
            String index = textbox2.Text;            
            if ((index[1] == '/')||(index[2] == '/'))
            {
                check = true;
            }
            if ((textbox2.Text != null) && (check == true))
            {
                birthday item = new birthday { Username = "user", Time = textbox2.Text, Name = textbox1.Text };
                InsertBirth(item);
                try
                {
                }
                catch (MobileServiceInvalidOperationException e1)
                {
                    MessageBox.Show(e1.Message, "添加信息成功！", MessageBoxButton.OK);
                }
            }
            else
            {
                try
                {
                }
                catch (MobileServiceInvalidOperationException e2)
                {
                    MessageBox.Show(e2.Message, "输入格式错误！", MessageBoxButton.OK);
                }
            }
        }

        
    }
}