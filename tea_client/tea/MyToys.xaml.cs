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
    public sealed partial class MyToys : Page
    {
        private string username = "";

        public MyToys()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)e.Parameter;

            ObservableCollection<Toy> dataList = new ObservableCollection<Toy>();

            try
            {
                Query.GetMyToys(new UserNameDtoOut { username = this.username }).ForEach(async (ToyDtoIn o) => {
                    Toy toy = new Toy(o);
                    await toy.BuildImage();
                    dataList.Add(toy);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            toysList.ItemsSource = dataList;
        }

        private void toysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy toy = ((Toy)toysList.SelectedItem);
            this.Frame.Navigate(typeof(ToyDetail), toy);
        }
    }
}
