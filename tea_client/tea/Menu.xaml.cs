using System;
using System.Collections.Generic;
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
    public sealed partial class Menu : Page
    {
        private int userID = -1;

        public Menu()
        {
            this.InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Offers), userID);
        }

        private void btnOffers_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyOffers), userID);
        }

        private void btnBids_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            userID = (int)e.Parameter;
        }
    }
}
