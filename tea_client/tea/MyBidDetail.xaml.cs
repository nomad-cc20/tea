using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tea.containers.dtos;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně Prázdná aplikace najdete na adrese https://go.microsoft.com/fwlink/?LinkId=234238

namespace tea
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo se na ni dá přejít v rámci
    /// </summary>
    public sealed partial class MyBidDetail : Page
    {
        private BidDtoIn bid = null;
        private OfferDtoIn offer = null;

        public MyBidDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            
            offer = (OfferDtoIn)(((object[])(e.Parameter))[0]);
            bid = (BidDtoIn)(((object[])(e.Parameter))[1]);

            ObservableCollection<Toy> dataListOffer = new ObservableCollection<Toy>();
            offer.Toys.ForEach((Toy toy) => dataListOffer.Add(toy));

            OfferCaptionTb.Text = offer.Caption;
            OfferDescriptionTb.Text = offer.Description;
            OfferUserTb.Text = offer.NameOfPerson;
            OfferToysList.ItemsSource = dataListOffer;

            ObservableCollection<Toy> dataListBid = new ObservableCollection<Toy>();
            bid.Toys.ForEach((Toy toy) => dataListBid.Add(toy));

            BidCaptionTb.Text = bid.Caption;
            BidDescriptionTb.Text = bid.Description;
            BidUserTb.Text = bid.NameOfPerson;
            BidToysList.ItemsSource = dataListBid;
        }

        private void OfferToysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy toy = ((Toy)OfferToysList.SelectedItem);
            this.Frame.Navigate(typeof(ToyDetail), toy);
        }

        private void BidToysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy toy = ((Toy)BidToysList.SelectedItem);
            this.Frame.Navigate(typeof(ToyDetail), toy);
        }
    }
}
