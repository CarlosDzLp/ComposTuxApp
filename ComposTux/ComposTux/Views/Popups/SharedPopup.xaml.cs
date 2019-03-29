using System;
using System.Collections.Generic;
using ComposTux.ViewModels.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ComposTux.Views.Popups
{
    public partial class SharedPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public SharedPopup()
        {
            InitializeComponent();
            this.BindingContext = new SharedPopupViewModel();
        }
        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}
