using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Principal;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ComposTux.Views.Principal
{
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
            this.BindingContext = new PerfilPageViewModel();
        }
    }
}
