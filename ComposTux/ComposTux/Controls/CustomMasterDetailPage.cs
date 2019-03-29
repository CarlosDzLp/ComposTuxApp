using System;
using Xamarin.Forms;

namespace ComposTux.Controls
{
    public class CustomMasterDetailPage : MasterDetailPage
    {
        public static readonly BindableProperty DrawerWidthProperty = BindableProperty.Create<CustomMasterDetailPage, int>(p => p.DrawerWidth, default(int));

        public int DrawerWidth
        {
            get { return (int)GetValue(DrawerWidthProperty); }
            set { SetValue(DrawerWidthProperty, value); }
        }
    }
}
