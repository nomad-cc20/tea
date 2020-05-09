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
    public sealed partial class Offers : Page
    {
        private string username = "";

        public Offers()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OfferDtoIn dto = ((OfferDtoIn)offersList.SelectedItem);
            this.Frame.Navigate(typeof(OfferDetail), new object[] { username, dto });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)e.Parameter;

            ObservableCollection<OfferDtoIn> dataList = new ObservableCollection<OfferDtoIn>();

            try
            {
                Query.GetAllActiveOffers().ForEach((OfferDtoIn o) => {
                    if (!o.Username.Equals(username))
                        dataList.Add(o);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            offersList.ItemsSource = dataList;
        }

        private void offersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
