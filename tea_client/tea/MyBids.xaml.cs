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
using Windows.UI;
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
    public sealed partial class MyBids : Page
    {
        private string username = "";

        public MyBids()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)e.Parameter;

            // TODO datalist of all user's offers from API

            ObservableCollection<BidDtoIn> dataList = new ObservableCollection<BidDtoIn>();

            try
            {
                Query.GetMyBids(new UserNameDtoOut { username = this.username }).ForEach((BidDtoIn o) => { dataList.Add(o); });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            offersList.ItemsSource = dataList;
        }

        private void offersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BidDtoIn bid = (BidDtoIn)offersList.SelectedItem;
            OfferDtoIn offer = Query.GetOffer(bid.OfferId);
            this.Frame.Navigate(typeof(MyBidDetail), new Object[] { offer, bid });
        }

        private void offersList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (((BidDtoIn)args.Item).Active == false)
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
        }
    }
}
