using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Session;
using Xamarin.Forms;

namespace ComposTux.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new RegisterPageViewModel();
        }
    }
}
