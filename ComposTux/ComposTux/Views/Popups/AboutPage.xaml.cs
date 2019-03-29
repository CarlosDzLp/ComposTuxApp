using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ComposTux.Views.Popups
{
    public partial class AboutPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}
