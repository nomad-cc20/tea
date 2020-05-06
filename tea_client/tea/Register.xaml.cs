using System;
using System.Collections.Generic;
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
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameTb.Text.Length == 0 || nameTb.Text.Length == 0
                    || pwdTb.Text.Length == 0 || phoneTb.Text.Length == 0)
                {
                    infoTb.Text = "The provided credentials are incomplete.";
                    pwdTb.Text = "";
                    return;
                }
                Query.register(new RegisterDtoOut(usernameTb.Text,
                    nameTb.Text, pwdTb.Text, phoneTb.Text));
                this.Frame.Navigate(typeof(Login));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                infoTb.Text = "Could not connect to the server. Please try again later.";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }
    }
}
