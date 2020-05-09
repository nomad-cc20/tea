using System;
using System.Collections.Generic;
using System.Drawing;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nameTb.Text.Length == 0 || pwdTb.Password.Length == 0)
                {
                    infoTb.Text = "The provided credentials are incomplete.";
                    pwdTb.Password = "";
                    return;
                }
                string username = Query.LogIn(new UserDtoOut(nameTb.Text, pwdTb.Password));
                if (username.Equals("-1"))
                {
                    infoTb.Text = "The provided credentials are wrong.";
                    pwdTb.Password = "";
                    return;
                }
                this.Frame.Navigate(typeof(Main), username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                infoTb.Text = "Could not connect to the server. Please try again later.";
                pwdTb.Password = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
        }
    }
}
