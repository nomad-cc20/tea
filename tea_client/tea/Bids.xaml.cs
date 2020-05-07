using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tea.containers.dtos;
using tea.utils;
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
    public sealed partial class Bids : Page
    {
        private string username = "";
        private OfferDtoIn offer = null;

        public Bids()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)(((object[])(e.Parameter))[0]);
            offer = (OfferDtoIn)(((object[])(e.Parameter))[1]);

            ObservableCollection<BidDtoIn> dataList = new ObservableCollection<BidDtoIn>();

            try
            {
                Query.GetBids(offer.OfferId).ForEach((BidDtoIn o) => { dataList.Add(o); });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bidsList.ItemsSource = dataList;
        }

        private void bidsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO -> BidDetail -> ToyDetail?
        }
    }
}
