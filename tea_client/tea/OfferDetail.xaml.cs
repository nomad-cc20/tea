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
    public sealed partial class OfferDetail : Page
    {
        private string username = "";
        private OfferDtoIn offer = null;

        public OfferDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)(((object[])(e.Parameter))[0]);
            offer = (OfferDtoIn)(((object[])(e.Parameter))[1]);

            ObservableCollection<Toy> dataList = new ObservableCollection<Toy>(offer.Toys);

            toysList.ItemsSource = dataList;
        }

        private void toysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewBid), new object[] { username, offer });
        }
    }
}
