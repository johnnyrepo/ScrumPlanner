using ScrumDeck.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumDeck.ViewModel
{
    class CardViewModel : INotifyPropertyChanged
    {
        private Card[] cards;

        public CardViewModel(Card[] cards)
        {
            this.cards = cards;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ResetCards()
        {
            foreach (Card card in cards) {
                card.Reset();
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
        public void SetTShirtScale()
        {
            cards[0].text.Text = "XXS";
            cards[1].text.Text = "XS";
            cards[2].text.Text = "S";
            cards[3].text.Text = "M";
            cards[4].text.Text = "L";
            cards[5].text.Text = "XL";
            cards[6].text.Text = "XXL";

            cards[0].text.FontSize /= 2;
            cards[6].text.FontSize /= 2;
        }


        public void SetFibonacciScale()
        {
            cards[0].text.Text = "1";
            cards[1].text.Text = "2";
            cards[2].text.Text = "3";
            cards[3].text.Text = "5";
            cards[4].text.Text = "8";
            cards[5].text.Text = "13";
            cards[6].text.Text = "21";

            cards[0].text.FontSize = cards[1].text.FontSize;
            cards[6].text.FontSize = cards[1].text.FontSize;
        }
    }
}
