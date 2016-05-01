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

        private bool _IsCardBackShown = false;

        private bool _IsEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public Card()
        {
            InitializeComponent();
        }
        
        private void RaisePropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.WriteLine(propertyName + " to be raised in Card");
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsCardBackShown
        {
            get
            {
                return this._IsCardBackShown;
            }
            set
            {
                if (this._IsCardBackShown != value)
                {
                    this._IsCardBackShown = value;
                    this.RaisePropertyChanged("IsCardBackShown");
                }
            }
        }

        public new bool IsEnabled
        {
            get
            {
                return this._IsEnabled;
            }

            set
            {
                if (this._IsEnabled != value)
                {
                    this._IsEnabled = value;
                    this.RaisePropertyChanged("IsEnabled");
                }
            }
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
