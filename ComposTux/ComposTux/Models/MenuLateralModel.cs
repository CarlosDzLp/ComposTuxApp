using System;
using ComposTux.ViewModels.Base;

namespace ComposTux.Models
{
    public class MenuLateralModel : BindableBase
    {
        private string _icon;

        public int IDMenu { get; set; }
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
    }
}
