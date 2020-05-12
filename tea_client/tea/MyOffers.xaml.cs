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
    public sealed partial class MyOffers : Page
    {
        private string username = "";

        public MyOffers()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)e.Parameter;

            ObservableCollection<OfferDtoIn> dataList = new ObservableCollection<OfferDtoIn>();

            try
            {
                Query.GetMyOffers(new UserNameDtoOut { username = this.username }).ForEach(async (OfferDtoIn o) => {
                    try
                    {
                        await o.BuildImage();
                        dataList.Add(o);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
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
            OfferDtoIn dto = ((OfferDtoIn)offersList.SelectedItem);
            this.Frame.Navigate(typeof(Bids), new object[] { username, dto });
        }

        private void offersList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (((OfferDtoIn)args.Item).Active == false)
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
        }
    }
}
