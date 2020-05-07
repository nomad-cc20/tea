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
    public sealed partial class NewBid : Page
    {
        private string username = "";
        private OfferDtoIn offer = null;

        public NewBid()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)(((object[])(e.Parameter))[0]);
            offer = (OfferDtoIn)(((object[])(e.Parameter))[1]);

            ObservableCollection<ToyDtoIn> availableToysList = new ObservableCollection<ToyDtoIn>();
            ObservableCollection<ToyDtoIn> offeredToysList = new ObservableCollection<ToyDtoIn>();

            try
            {
                availableToysList = new ObservableCollection<ToyDtoIn>(Query.GetMyToys(new UserNameDtoOut { username = this.username }));
                offeredToysList = new ObservableCollection<ToyDtoIn>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            storedList.ItemsSource = availableToysList;
            offeredList.ItemsSource = offeredToysList;
        }

        private void storedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToyDtoIn toy = (ToyDtoIn)storedList.SelectedItem;

            ((ObservableCollection<ToyDtoIn>)storedList.ItemsSource).Remove(toy);
            ((ObservableCollection<ToyDtoIn>)offeredList.ItemsSource).Add(toy);
        }

        private void offeredList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToyDtoIn toy = (ToyDtoIn)offeredList.SelectedItem;

            ((ObservableCollection<ToyDtoIn>)offeredList.ItemsSource).Remove(toy);
            ((ObservableCollection<ToyDtoIn>)storedList.ItemsSource).Add(toy);
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (captionTb.Text.Length <= 0)
            {
                captionTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                return;
            }

            if (DescriptionTb.Text.Length <= 0)
            {
                DescriptionTb.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                return;
            }

            try
            {
                Query.NewBid(new NewBidDtoOut()
                {
                    caption = captionTb.Text,
                    description = DescriptionTb.Text,
                    offerId = offer.OfferId,
                    toys = offer.Toys,
                    username = username
                });
                this.Frame.Navigate(typeof(MyBids), username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
