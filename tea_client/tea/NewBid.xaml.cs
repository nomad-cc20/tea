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

            try
            {
                availableToysList = new ObservableCollection<ToyDtoIn>(Query.GetMyToys(new UserNameDtoOut { username = this.username }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            toysList.ItemsSource = availableToysList;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (captionTb.Text.Length <= 0)
            {
                captionTb.PlaceholderForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                return;
            }

            if (descriptionTb.Text.Length <= 0)
            {
                descriptionTb.PlaceholderForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                return;
            }

            List<long> toys = new List<long>();
            List<ToyDtoIn> toyDtos = toysList.SelectedItems.OfType<ToyDtoIn>().ToList();
            toyDtos.ForEach((ToyDtoIn toy) => { toys.Add(toy.Id); });

            try
            {
                Query.NewBid(new NewBidDtoOut()
                {
                    caption = captionTb.Text,
                    description = descriptionTb.Text,
                    offerId = offer.OfferId,
                    toys = toys,
                    username = username
                });
                this.Frame.Navigate(typeof(Blank));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
