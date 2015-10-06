using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;

namespace ScrumDeck.Item
{
    public partial class Card : UserControl, INotifyPropertyChanged
    {

        public bool IsCardBackShown = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public Card()
        {
            InitializeComponent();
        }
        
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void StartFlipAnimation(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsCardBackShown)
            {
                this.IsEnabled = false;
                frontFlip1.Begin();
            }
            else
            {
                this.IsEnabled = false;
                backFlip1.Begin();
            }
        }

        private void On_backFlip1_Completed(object sender, EventArgs e)
        {
            this.text.Visibility = Visibility.Collapsed;
            backFlip2.Begin();
        }

        private void On_backFlip2_Completed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
            this.IsCardBackShown = true;
        }

        private void On_frontFlip1_Completed(object sender, EventArgs e)
        {
            this.text.Visibility = Visibility.Visible;
            frontFlip2.Begin();
        }

        private void On_frontFlip2_Completed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
            this.IsCardBackShown = false;
        }

        internal void Reset()
        {
            this.IsEnabled = true;
            this.IsCardBackShown = false;
            this.text.Visibility = Visibility.Visible;
            this.gridProjection.RotationY = 0;
        }
    }
}
