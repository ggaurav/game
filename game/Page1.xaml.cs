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
    public partial class Page1 : PhoneApplicationPage
    {
        public static Int32 runningSum = 1;
        public static string gameMode = "easy";
        public static bool win = false;
        public static string userWon = "no";
        public static TextBlock aTextBlock;
        public Page1()
        {
            InitializeComponent();
        }

        private static void hardGame(TextBlock aTextBlock, string userInp)
        {
            Int32 a;
            Int32 b = 0;
            if (runningSum < 100)
            {
                string temp = userInp;
                b = Int32.Parse(temp);
                a = 11 - b;
                runningSum = runningSum + b;
                aTextBlock.Text = aTextBlock.Text + "\n\nYou choose " + b.ToString();
                runningSum = runningSum + a;
                aTextBlock.Text = aTextBlock.Text + "\n\nI choose " + a.ToString();
            }
        }

        private static void easyGame(TextBlock aTextBlock, string userInp)
        {
            Int32 a;
            Int32 b = 0;
            if (runningSum < 100)
            {
                string temp = userInp;
                b = Int32.Parse(temp);
                runningSum = runningSum + b;
                aTextBlock.Text = aTextBlock.Text + "\n\nYou choose " + b.ToString();
                if (runningSum >= 100)
                {
                    aTextBlock.Text = aTextBlock.Text + "\n\nOn your choosing, the sum is " + runningSum.ToString();
                    aTextBlock.Text = aTextBlock.Text + "\n\n You won!!!";
                    userWon = "yes";
                    return;
                }
                //a = 11 - b;
                Random random = new Random();
                a = random.Next(1, 11);
                runningSum = runningSum + a;
                aTextBlock.Text = aTextBlock.Text + "\n\nI choose " + a.ToString();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            bool itemExists = NavigationContext.QueryString.TryGetValue("gameMode", out gameMode);
            bTextBlock.Text = "Choose a number between 1 and 10 both inclusive and press Go";
            //aTextBlock.Text = "I choose 1 and the sum is 1";
            bListBox.Items.Clear();
            errorTextBlock.Text = "";
            for (int i = 1; i < 11; i++)
                bListBox.Items.Add(i.ToString());
            Random random = new Random();
            if (random.NextDouble() < 0.1)
                win = true;
            else
                win = false;
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            if (runningSum >= 100)
                return;
            if (bListBox.SelectedValue == null)
            {
                errorTextBlock.Text = "Please choose a number";
                return;
            }
            else
            {
                errorTextBlock.Text = "";
            }
            string userInp = (string)bListBox.SelectedValue;
            bListBox.SelectedIndex = -1;
            Random random = new Random();
            // if hard p = 0.4 for easy and 0.6 for hard
            if (gameMode.Equals("hard"))
            {
                if (random.NextDouble() < 0.4)
                    easyGame(aTextBlock, userInp);
                else
                    hardGame(aTextBlock, userInp);
            }
            // if challenge p = 0.1 for easy and 0.9 for hard 
            else if (gameMode.Equals("challenge"))
            {
                if (win == true)
                    easyGame(aTextBlock, userInp);
                else
                    hardGame(aTextBlock, userInp);
            }
            //if easy p = 1 so direcly easy game
            else
            {
                easyGame(aTextBlock, userInp);
            }
            sumTextBlock.Text = "Sum: " + runningSum;
            aScrollViewer.ScrollToVerticalOffset(1000.0);
            if (runningSum >= 100)
            {
                NavigationService.Navigate(new Uri("/Page2.xaml?userWon=" + userWon, UriKind.Relative));
            }
        }

        private void bListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            errorTextBlock.Text = "";
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            userWon = "no";
            aTextBlock = new TextBlock();
            aStackPanel.Children.Clear();
            aStackPanel.Children.Add(aTextBlock);
            errorTextBlock.Text = "";
            runningSum = 1;
            sumTextBlock.Text = "Sum: " + runningSum;
            bTextBlock.Text = "Choose a number between 1 and 10 both inclusive and press Go";
            aTextBlock.Text = "I choose 1.";
            bListBox.Items.Clear();
            errorTextBlock.Text = "";
            for (int i = 1; i < 11; i++)
                bListBox.Items.Add(i.ToString());
        }

    }
}