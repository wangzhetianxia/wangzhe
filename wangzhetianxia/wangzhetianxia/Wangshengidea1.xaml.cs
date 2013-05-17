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
    public partial class Wangshengidea1 : PhoneApplicationPage
    {
        String username;
        public Wangshengidea1()
        {
            InitializeComponent();
            username = YuXiaoindex.Username;
        }
    }
    

}