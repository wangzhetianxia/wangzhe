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
    public partial class Wangshengidea3 : PhoneApplicationPage
    {
        public Wangshengidea3()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = 0;
            
            index = Convert.ToInt32(Textbox1.Text) + Convert.ToInt32(Textbox2.Text);
            index = index + 16;
            index = index % 24;
            Textbox5.Text = index.ToString(); 
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = 0;
           
            index = Convert.ToInt32(Textbox1.Text) - Convert.ToInt32(Textbox4.Text);
            index = index + 16;
            index = index % 24;
            Textbox3.Text = index.ToString(); 
        }

        
    }
}