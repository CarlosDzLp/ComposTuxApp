using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ComposTux.Controls
{
    public class CustomListView : ListView
    {
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CustomListView), null);

        public ICommand ItemSelectedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemSelectedCommandProperty);
            }
            set
            {
                this.SetValue(ItemSelectedCommandProperty, value);
            }
        }

        public CustomListView()
        {
            this.ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ItemSelectedCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}
