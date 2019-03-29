using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Principal;
using Xamarin.Forms;

namespace ComposTux.Views.Principal
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            this.BindingContext = new MenuPageViewModel();
        }
    }
}
