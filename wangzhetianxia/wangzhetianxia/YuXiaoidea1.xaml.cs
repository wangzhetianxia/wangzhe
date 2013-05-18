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
using System.Windows.Media;

namespace wangzhetianxia
{
    public class thing
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "hour")]
        public int Hour { get; set; }

        [JsonProperty(PropertyName = "isfinish")]
        public String Is { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

    }

    public class yestodaysubpoints
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "sgp")]
        public int Sgp { get; set; }

        [JsonProperty(PropertyName = "stp")]
        public int Stp { get; set; }

        

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

    }

    public class todayaddpoints
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "nowgp")]
        public int Nowgp { get; set; }

        [JsonProperty(PropertyName = "nowtp")]
        public int Nowtp { get; set; }

        [JsonProperty(PropertyName = "isadd")]
        public bool Isadd { get; set; }

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

    }

    public class fthing
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "fhour")]
        public int Fhour { get; set; }
       

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

    }
    public partial class YuXiaoidea1 : PhoneApplicationPage
    {
        DateTime now;
        String Username;
        private MobileServiceCollection<thing, thing> items;
        private MobileServiceCollection<thing, thing> items1;
        private MobileServiceCollection<thing, thing> items2;
        private MobileServiceCollection<thing, thing> yitems;
        private MobileServiceCollection<fthing, fthing> nfitems;
        private MobileServiceCollection<fthing, fthing> fitems;
        private MobileServiceCollection<fthing, fthing> lfitems;
        private MobileServiceCollection<fthing, fthing> jfitems;
        private MobileServiceCollection<todayaddpoints, todayaddpoints> todaypoints;
        private MobileServiceCollection<todayaddpoints, todayaddpoints> ys;
        private MobileServiceCollection<todayaddpoints, todayaddpoints> submityes;
        private MobileServiceCollection<yestodaysubpoints, yestodaysubpoints> yestodaypoints;
        
        private IMobileServiceTable<thing> todoTable = App.MobileService.GetTable<thing>();
        private IMobileServiceTable<fthing> ftodoTable = App.MobileService.GetTable<fthing>();
        private IMobileServiceTable<todayaddpoints> tftodoTable = App.MobileService.GetTable<todayaddpoints>();
        private IMobileServiceTable<todayaddpoints> ya = App.MobileService.GetTable<todayaddpoints>();
        private IMobileServiceTable<todayaddpoints> suby = App.MobileService.GetTable<todayaddpoints>();
        private IMobileServiceTable<yestodaysubpoints> ytftodoTable = App.MobileService.GetTable<yestodaysubpoints>();
        private MobileServiceCollection<user, user> uitems;
        private IMobileServiceTable<user> ut = App.MobileService.GetTable<user>(); user u = new user();

        int ngpoint;
        int pgoint;
        int sgpoint;
        int ntpoint;
        int ptoint;
        int stpoint;
        int Zw;
        int Zd;
        List<thing> l=new List<thing>();
        int year;
        int month;
        int day;
        public YuXiaoidea1()
        {
            InitializeComponent();
            Username=YuXiaoindex.Username;
            now = DateTime.Now;
            Time.Text = now.Year + "/" + now.Month + "/" + now.Day;
            RefreshTodoItems();
          //  back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(111, 255, 0, 255));
            
            


            //username.Text = Username;
        }
        void fuzhi()
        {


            
           

            

        }

        private async void getpoints()
        {
            uitems = await ut
                        .Where(userItem => userItem.Username == Username)
                        .ToCollectionAsync();
           u = uitems.First();
           pgoint = u.gp;
           ptoint = u.tp;
           tp.Text = ptoint.ToString();
           gp.Text = pgoint.ToString();
           zw.Text = Zw.ToString();
           zd.Text = Zd.ToString();
           if (pgoint <= 10)
           {
               gn.Text = "平民";
               piao.Visibility = Visibility.Visible;
               xin.Visibility = Visibility.Collapsed;
               qiang.Visibility = Visibility.Collapsed;
               wang.Visibility = Visibility.Collapsed;
               pang.Visibility = Visibility.Collapsed;
           }
           if (pgoint > 10 && pgoint <= 30)
           {
               gn.Text = "武士";
               piao.Visibility = Visibility.Collapsed;
               xin.Visibility = Visibility.Visible;
               qiang.Visibility = Visibility.Collapsed;
               wang.Visibility = Visibility.Collapsed;
               pang.Visibility = Visibility.Collapsed;
           }
           if (pgoint > 30 && pgoint <= 80)
           {
               gn.Text = "剑客";
               piao.Visibility = Visibility.Collapsed;
               xin.Visibility = Visibility.Collapsed;
               qiang.Visibility = Visibility.Visible;
               wang.Visibility = Visibility.Collapsed;
               pang.Visibility = Visibility.Collapsed;
           }
           if (pgoint > 80 && pgoint <= 120)
           {
               gn.Text = "大侠";
               piao.Visibility = Visibility.Collapsed;
               xin.Visibility = Visibility.Collapsed;
               qiang.Visibility = Visibility.Collapsed;
               wang.Visibility = Visibility.Visible;
               pang.Visibility = Visibility.Collapsed;
           }
           if (pgoint > 120)
           {
               gn.Text = "武神";
               piao.Visibility = Visibility.Collapsed;
               xin.Visibility = Visibility.Collapsed;
               qiang.Visibility = Visibility.Collapsed;
               wang.Visibility = Visibility.Collapsed;
               pang.Visibility = Visibility.Visible;
           }
           if (ptoint <= 10)
           {
               dw.Text = "士兵";
               yanse.Text = "淡刚蓝，从士兵做起吧！";
           }
           if (ptoint > 10 && ptoint <= 30)
           {
               dw.Text = "百人将";
               back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 149, 237));
               yanse.Text = "矢车菊的蓝色,领导你的百人队伍去战斗！";
           }
           if (ptoint > 30 && ptoint <= 80)
           {
               dw.Text = "千人将";
               back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 65, 105, 225));
               yanse.Text = "皇军蓝,掌握1000人的生死命运！";
           }

           if (ptoint > 80 && ptoint <= 120)
           {
               dw.Text = "将军";
               back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 128));
               yanse.Text = "海军蓝, 这就是将军眼中的景象！";

           }
           if (ptoint > 120)
           {
               dw.Text = "帝王";
               back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 25, 25, 112));
               yanse.Text = "午夜的蓝色, 江山如何坐稳，一声叹息一缕白发成！";
           }
           
           
        }

       private async void addyestoday()
        {
            Zw = Zd = 0;
            ys = await ya.Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day - 1 && fthingItem.User == Username)
                    .ToCollectionAsync();
            if (ys.Count == 0)
            {
                todayaddpoints t = new todayaddpoints();
                t.Isadd = false;
                t.Year = year;
                t.Month = month;
                t.Day = day - 1;
                t.User = Username;
                t.Nowgp = 0;
                t.Nowtp = 0;
               await ya.InsertAsync(t);
            }
            
            if (ys.Count != 0)
            {
                
                 /*   uitems = await ut
                        .Where(userItem => userItem.Username == Username)
                        .ToCollectionAsync();
                    user u = uitems.First();
                    u.tp = u.tp + ys.First().Nowtp;
                    u.gp = u.gp + ys.First().Nowgp;
                   

                    await ut.UpdateAsync(u);*/
                    
                    Zw += ys.First().Nowgp;
                    Zd += ys.First().Nowtp; 
                
            }

        }

        private async void subyestoday()
        {
            Zw = Zd = 0;
            yestodaypoints = await ytftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day - 1 && fthingItem.User == Username)
                    .ToCollectionAsync();
            if (yestodaypoints.Count == 0)
            {
                yitems = await todoTable
                    .Where(thingItem => thingItem.Year == year && thingItem.Month == month && thingItem.Day == day - 1 && thingItem.User == Username && thingItem.Is == "未完成")
                    .ToCollectionAsync();
                if (yitems.Count != 0)
                {
                    int g = 0;
                    int t = 0;
                    thing[] th = yitems.ToArray();
                    int i = 0;
                    while (i < th.Length)
                    {
                        if (th[i].Type == "个人")
                        {
                            if (th[i].Level == "日常")
                                g += 24;
                            if (th[i].Level == "周期")
                                g += 30;
                            if (th[i].Level == "特殊")
                                g += 40;
                            if (th[i].Level == "生死攸关")
                                g += 50;

                        }
                        if (th[i].Type == "团体")
                        {
                            if (th[i].Level == "日常")
                                t += 30;
                            if (th[i].Level == "周期")
                                t += 44;
                            if (th[i].Level == "特殊")
                                t += 60;
                            if (th[i].Level == "生死攸关")
                                t += 80;

                        }
                        i++;
                    }
                    yestodaysubpoints y = new yestodaysubpoints() { Year = year, Month = month, Day = day - 1, User = Username, Sgp = g, Stp = t };
                    await ytftodoTable.InsertAsync(y);
                }

                yestodaypoints = await ytftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day - 1 && fthingItem.User == Username)
                    .ToCollectionAsync();
                if (yestodaypoints.Count != 0)
                {
                    stpoint = yestodaypoints.First().Stp;
                    sgpoint = yestodaypoints.First().Sgp;
                    /* uitems = await ut
                         .Where(userItem => userItem.Username == Username)
                         .ToCollectionAsync();
                     user u = uitems.First();
                     u.tp = u.tp - stpoint;
                     u.gp = u.gp - sgpoint;

                     await ut.UpdateAsync(u);*/
                    Zw -= sgpoint;
                    Zd -= stpoint;
                }
                // subyestoday();
            }
            else
            {
                stpoint = yestodaypoints.First().Stp;
                sgpoint = yestodaypoints.First().Sgp;
                /* uitems = await ut
                     .Where(userItem => userItem.Username == Username)
                     .ToCollectionAsync();
                 user u = uitems.First();
                 u.tp = u.tp - stpoint;
                 u.gp = u.gp - sgpoint;

                 await ut.UpdateAsync(u);*/
                Zw -= sgpoint;
                Zd -= stpoint;
            }
            
        }
       

        

        private async void nowpoints()
        {
            nfitems = await ftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day && fthingItem.User == Username)
                    .ToCollectionAsync();
            int g = 0;
            int t=0;
            fthing[] n = nfitems.ToArray();
            DateTime d = DateTime.Now;
            int i = 0;
            while (i < n.Length)
            {
                if (n[i].Type == "个人")
                {
                    if (n[i].Level == "日常")
                        g += 5;
                    if (n[i].Level == "周期")
                        g += 8;
                    if (n[i].Level == "特殊")
                        g += 16;
                    if (n[i].Level == "生死攸关")
                        g += 30;
                    g -= n[i].Fhour;
                }
                if (n[i].Type == "团体")
                {
                    if (n[i].Level == "日常")
                        t += 5;
                    if (n[i].Level == "周期")
                        t += 8;
                    if (n[i].Level == "特殊")
                        t += 16;
                    if (n[i].Level == "生死攸关")
                        t += 30;
                    t -= n[i].Fhour;
                }
                i++;
            }
            ntpoint = t;
            ngpoint = g;
        }
        private async void tr()
        {
            String time = Time.Text;
            char[] s = new char[1];
            s[0] = '/';
            String[] t = time.Split(s);
            //Time.Text = t[0] + t[1] + t[2];
            year = int.Parse(t[0]);
            month = int.Parse(t[1]);
            day = int.Parse(t[2]);

            try
            {
                items = await todoTable
                    .Where(thingItem => thingItem.Year == year && thingItem.Month == month && thingItem.Day == day && thingItem.User == Username)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            ListItems.ItemsSource = items;
        }

        private async void getyestodaynfthings()
        {
            try
            {
                items1 = await todoTable
                    .Where(thingItem => thingItem.Year == year && thingItem.Month == month && thingItem.Day == day-1 && thingItem.User == Username &&thingItem.Is=="未完成")
                    .ToCollectionAsync();

            }

            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            ListItems1.ItemsSource = items1;
        }

        private async void getyestodayfthings()
        {
            try
            {
                items2 = await todoTable
                    .Where(thingItem => thingItem.Year == year && thingItem.Month == month && thingItem.Day == day - 1 && thingItem.User == Username && thingItem.Is == "已完成")
                    .ToCollectionAsync();

            }

            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            ListItems2.ItemsSource = items2;
        }

        private async void RefreshTodoItems()
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
            
            Zw = Zd = 0;
            j1.Text = j2.Text = j3.Text = "";
            String time = Time.Text;
            char[] s = new char[1];
            s[0] = '/';
            String[] t = time.Split(s);
            //Time.Text = t[0] + t[1] + t[2];
            year = int.Parse(t[0]);
            month = int.Parse(t[1]);
            day = int.Parse(t[2]);
            
            try
            {
                items = await todoTable
                    .Where(thingItem => thingItem.Year == year && thingItem.Month == month && thingItem.Day == day&&thingItem.User==Username)
                    .ToCollectionAsync();
                thing[] th = items.ToArray();
                int i, j;
                thing T;
                for (i = 0; i < th.Length - 1; i++)
                {
                    for (j = 0; j < th.Length - i - 1; j++)
                    {
                        if (th[j + 1].Hour > th[j].Hour)
                        { T = th[j + 1]; th[j + 1] = th[j]; th[j] = T; }
                    }
                }
                if (th.Length > 0)
                {
                    j1.Text = th[0].Text;
                    if (th.Length > 1)
                    { j2.Text = th[1].Text; }
                    if(th.Length>2)
                    j3.Text = th[2].Text;
                }

            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            ListItems.ItemsSource = items;
            
            subyestoday();
            addyestoday();
            getpoints();
            getyestodaynfthings();
            getyestodayfthings();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            submit();
            
        }

        private async void submit()
        {
            submityes = await suby
                   .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day - 1 && fthingItem.User == Username)
                   .ToCollectionAsync();
            todayaddpoints tt=submityes.First();

            if (tt.Isadd == false)
            {
                todayaddpoints t = submityes.First();
                t.Isadd = true;
                await tftodoTable.UpdateAsync(t);
                pgoint += Zw;
                ptoint += Zd;
                tp.Text = ptoint.ToString();
                gp.Text = pgoint.ToString();
                uitems = await ut
                        .Where(userItem => userItem.Username == Username)
                        .ToCollectionAsync();
                user u = uitems.First();
                u.gp = pgoint;
                u.tp = ptoint;

               await  ut.UpdateAsync(u);

                
            }
            
        }

        private async void UpdateCheckedTodoItem(thing item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            RefreshTodoItems();
            //  items.Remove(item);
        }

        private async void fadd(thing item)
        {
            DateTime d = DateTime.Now;
            //a.Text = d.Year.ToString();
            jfitems = await ftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day && fthingItem.User == Username && fthingItem.Level == item.Level && fthingItem.Type == item.Type && fthingItem.Content == item.Content)
                    .ToCollectionAsync();
            if (jfitems.Count == 0)
            {
                fthing f = new fthing { Year = year, Month = month, Day = day, User = Username, Level = item.Level, Type = item.Type, Content = item.Content,Fhour=d.Hour-item.Hour };
                await  ftodoTable.InsertAsync(f);
            }

        }

        private async void addtotodaypoints()
    {
        todaypoints = await tftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day &&fthingItem.User==Username )
                    .ToCollectionAsync();
        if (todaypoints.Count != 0)
        {
            todayaddpoints[] ty = todaypoints.ToArray();
            
               await tftodoTable.DeleteAsync(ty[0]); 
              
        }


        var p = new todayaddpoints() {Year=year,Month=month,Day=day,User=Username,Nowgp=ngpoint,Nowtp=ntpoint };
            
       await tftodoTable.InsertAsync(p); 
    }

        private async void fremove(thing item)
        {
            
            jfitems = await ftodoTable
                    .Where(fthingItem => fthingItem.Year == year && fthingItem.Month == month && fthingItem.Day == day && fthingItem.User == Username && fthingItem.Level == item.Level && fthingItem.Type == item.Type && fthingItem.Content == item.Content)
                    .ToCollectionAsync();
            if (jfitems.Count > 0)
            {

                await ftodoTable.DeleteAsync(jfitems.First());
            }

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.IsChecked = false;
            thing item = cb.DataContext as thing;
            if (item.Is == "未完成")
            {
                item.Is = "已完成";
                item.Text = item.Content + " " + item.Type + " " + item.Level +" "+ item.Hour+" " + "已完成";
                fadd(item);

            }

            else  if (item.Is == "已完成")
            {
                item.Is = "未完成";
                item.Text = item.Content + " " + item.Type + " " + item.Level + " " + item.Hour + " " + "未完成";
                fremove(item);
            }
            // i.Text = "sadasd";
            l.Add(item);
            UpdateCheckedTodoItem(item); 
        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Username = YuXiaoindex.Username;
            RefreshTodoItems();
            subyestoday();
            addyestoday();
            getpoints();
            fuzhi();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Zw = Zd = 0;

            Username = YuXiaoindex.Username;
            RefreshTodoItems();
            subyestoday();
            addyestoday();
            getpoints();
            fuzhi();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Username = YuXiaoindex.Username;
            RefreshTodoItems();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            nowpoints();
            // a.Text = ntpoint.ToString() + ngpoint.ToString();
            MessageBox.Show("已获得今日经验值" +"\n如果明天对今天的战果表示认可，提交战果即可获得相应属性提升,点击‘查看战果’以查看详情");
            addtotodaypoints();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("武力：+"+ngpoint.ToString()+"\n大将之风：+"+ntpoint.ToString());
            addtotodaypoints();
        }



    }
}