using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ScrumDeck.Resources;
using ScrumDeck.Item;

namespace ScrumDeck
{
    public partial class MainPage : PhoneApplicationPage
    {

        private bool IsFibonacci = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            SetTShirtScale();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void changeScaleBtn_Click(object sender, EventArgs e)
        {
            if (IsFibonacci)
            {
                SetTShirtScale();

                ((ApplicationBarIconButton) sender).Text = "Fibonacci";

                IsFibonacci = false;
            }
            else
            {
                SetFibonacciScale();

                ((ApplicationBarIconButton)sender).Text = "T-Shirt size";

                IsFibonacci = true;
            }
        }

        /*
         * XXS = 1
         * XS = 2
         * S = 3
         * M = 5
         * L = 8
         * XL = 13
         * XXL = 21
         * */
        private void SetTShirtScale()
        {
            card1.text.Text = "XXS";
            card2.text.Text = "XS";
            card3.text.Text = "S";
            card4.text.Text = "M";
            card5.text.Text = "L";
            card6.text.Text = "XL";
            card7.text.Text = "XXL";

            card1.text.FontSize /= 2;
            card7.text.FontSize /= 2;
        }


        private void SetFibonacciScale()
        {
            card1.text.Text = "1";
            card2.text.Text = "2";
            card3.text.Text = "3";
            card4.text.Text = "5";
            card5.text.Text = "8";
            card6.text.Text = "13";
            card7.text.Text = "21";

            card1.text.FontSize = card2.text.FontSize;
            card7.text.FontSize = card2.text.FontSize;
        }

        private void ResetCards(object sender, SelectionChangedEventArgs e)
        {
            card1.Reset();
            card2.Reset();
            card3.Reset();
            card4.Reset();
            card5.Reset();
            card6.Reset();
            card7.Reset();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}