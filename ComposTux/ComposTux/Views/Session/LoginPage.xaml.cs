using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Session;
using Xamarin.Forms;

namespace ComposTux.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoginPageViewModel();
        }
    }
}
