using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Principal;
using Xamarin.Forms;

namespace ComposTux.Views.Principal
{
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
            this.BindingContext = new InicioPageViewModel();
        }
    }
}
