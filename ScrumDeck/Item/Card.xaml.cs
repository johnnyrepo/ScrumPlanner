using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ScrumDeck.Item
{
    public partial class Card : UserControl
    {

        private bool IsCardBackShown = false;

        public Card()
        {
            InitializeComponent();
        }

        private void StartFlipAnimation(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsCardBackShown)
            {
                IsEnabled = false;
                frontFlip1.Begin();
            }
            else
            {
                IsEnabled = false;
                backFlip1.Begin();
            }
        }

        private void On_backFlip1_Completed(object sender, EventArgs e)
        {
            text.Visibility = Visibility.Collapsed;
            backFlip2.Begin();
        }

        private void On_backFlip2_Completed(object sender, EventArgs e)
        {
            IsEnabled = true;
            IsCardBackShown = true;
        }

        private void On_frontFlip1_Completed(object sender, EventArgs e)
        {
            text.Visibility = Visibility.Visible;
            frontFlip2.Begin();
        }

        private void On_frontFlip2_Completed(object sender, EventArgs e)
        {
            IsEnabled = true;
            IsCardBackShown = false;
        }

        internal void Reset()
        {
            IsEnabled = true;
            IsCardBackShown = false;
            text.Visibility = Visibility.Visible;
            gridProjection.RotationY = 0;
        }
    }
}
