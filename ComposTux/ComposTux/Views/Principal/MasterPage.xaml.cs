using System;
using System.Collections.Generic;
using ComposTux.Controls;
using Xamarin.Forms;

namespace ComposTux.Views.Principal
{
    public partial class MasterPage : CustomMasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.masterDetailPage = this;
        }
    }
}
