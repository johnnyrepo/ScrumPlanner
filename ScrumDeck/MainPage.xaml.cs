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
using ScrumDeck.ViewModel;

namespace ScrumDeck
{
    public partial class MainPage : PhoneApplicationPage
    {

        private bool IsFibonacci = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new CardViewModel(new Card[] { card1, card2, card3, card4, card5, card6, card7});

            ((CardViewModel) DataContext).SetTShirtScale();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ChangeScaleBtn_Click(object sender, EventArgs e)
        {
            if (IsFibonacci)
            {
                ((CardViewModel) DataContext).SetTShirtScale();

                ((ApplicationBarIconButton) sender).Text = "Fibonacci";

                IsFibonacci = false;
            }
            else
            {
                ((CardViewModel) DataContext).SetFibonacciScale();

                ((ApplicationBarIconButton)sender).Text = "T-Shirt size";

                IsFibonacci = true;
            }
        }

        private void OnCardSelection_changed(object sender, SelectionChangedEventArgs e)
        {
            ((CardViewModel)DataContext).ResetCards();
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