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

namespace game
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            descriptionTextBlock.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            descriptionTextBlock.Text = "Khel is a 2 player game which has a running counter, a player gets his chance after computer to increase the counter. First one(computer or player) to take the counter to 100 will win. Please choose the difficulty level.";
        }
        private void easyButton_Click(object sender, RoutedEventArgs e)
        {
            string gameMode = "easy";
            NavigationService.Navigate(new Uri("/Page1.xaml?gameMode="+gameMode, UriKind.Relative));
        }

        private void hardButton_Click(object sender, RoutedEventArgs e)
        {
            string gameMode = "hard";
             NavigationService.Navigate(new Uri("/Page1.xaml?gameMode="+gameMode, UriKind.Relative));
        }

        private void challengeButton_Click(object sender, RoutedEventArgs e)
        {
            string gameMode = "challenge";
            NavigationService.Navigate(new Uri("/Page1.xaml?gameMode=" + gameMode, UriKind.Relative));
        }
    }
}
