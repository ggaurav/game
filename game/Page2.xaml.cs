using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace game
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string userWon = "";
            base.OnNavigatedTo(e);
            bool itemExists = NavigationContext.QueryString.TryGetValue("userWon", out userWon);
            if (userWon == null)
                return;
            if (userWon == "yes")
                resultTextBlock.Text = "YOU WON !!!";
            else
                resultTextBlock.Text = "YOU LOST !!!";
        }
    }
}