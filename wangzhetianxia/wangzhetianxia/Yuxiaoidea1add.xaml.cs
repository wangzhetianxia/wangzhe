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
    
    public partial class Yuxiaoidea1add : PhoneApplicationPage
    {
       

        String Username;
        private MobileServiceCollection<thing, thing> items;
        private IMobileServiceTable<thing> todoTable = App.MobileService.GetTable<thing>();
        int a=0;
        public Yuxiaoidea1add()
        {
            InitializeComponent();
            Username = YuXiaoindex.Username;
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String time = Time.Text;
            char[] s = new char[1];
            s[0] = '/';
            String[] t = time.Split(s);
            if (t.Length != 3)
            {
                MessageBox.Show("格式不匹配");
            }
            else
            //Time.Text = t[0] + t[1] + t[2];
            {
                if (t[0].Length == 4 && t[1].Length == 2 && t[2].Length == 2 && t[0].ElementAt(0) == '2' && t[0].ElementAt(1) == '0' && t[0].ElementAt(2) == '1' && (t[0].ElementAt(3) == '3' || t[0].ElementAt(3) == '4')
                    && (int)(t[1].ElementAt(0)) - 48 >= 0 && (int)(t[1].ElementAt(0)) - 48 <= 1 && (int)(t[1].ElementAt(1)) - 48 >= 0 && (int)(t[1].ElementAt(0)) - 48 <= 9 && (int)(t[2].ElementAt(0)) - 48 >= 0 && (int)(t[2].ElementAt(0)) - 48 <= 3 && (int)(t[2].ElementAt(1)) - 48 >= 0 && (int)(t[2].ElementAt(1)) - 48 <= 9)
                {
                    int year = int.Parse(t[0]);
                    int month = int.Parse(t[1]);
                    int day = int.Parse(t[2]);
                    var addthing = new thing { User = Username, Content = content.Text, Month = month, Year = year, Day = day };
                    if (geren.IsChecked == true)
                        addthing.Type = "个人";

                    if (tuanti.IsChecked == true)
                        addthing.Type = "团体";

                    if (richang.IsChecked == true)
                        addthing.Level = "日常";

                    if (zhouqi.IsChecked == true)
                        addthing.Level = "周期";

                    if (teshu.IsChecked == true)
                        addthing.Level = "特殊";

                    if (shengsiyouguan.IsChecked == true)
                        addthing.Level = "生死攸关";

                    addthing.Is = "未完成";
                    String S = hour.Text;
                    if ((S[0] == '0' || S[0] == '1' || S[0] == '2') && (int)(S[1]) - 48 >= 0 && (int)(S[1]) - 48 <= 9)
                    {
                        addthing.Hour = int.Parse(hour.Text);
                        addthing.Text = addthing.Content + " " + addthing.Type + " " + addthing.Level + " " + addthing.Hour + " " + addthing.Is;
                        add(addthing);
                    }
                    else
                        MessageBox.Show("格式不匹配");
                }
                else
                {
                    MessageBox.Show("格式不匹配");
                }
            }
        }

        private async void add(thing addthing)
        {
            await todoTable.InsertAsync(addthing);
        }

      

       

       
    }
}