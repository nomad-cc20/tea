using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Offers : Page
    {
        private int userID = -1;

        public Offers()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // TODO new bid
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            userID = (int)e.Parameter;

            // TODO datalist of all active offers from API

            ObservableCollection<Offer> dataList = new ObservableCollection<Offer>();

            Offer anOffer = new Offer(0, new User(0, "aUsername", "aPassword"));
            Offer anotherOffer = new Offer(1, new User(1, "anotherUsername", "anotherPassword"));
            Offer oneMoreOffer = new Offer(2, new User(2, "oneMoreCaption", "oneMoreCaption"));

            dataList.Add(anOffer);
            dataList.Add(anotherOffer);
            dataList.Add(oneMoreOffer);

            offersList.ItemsSource = dataList;
        }

        private void offersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
