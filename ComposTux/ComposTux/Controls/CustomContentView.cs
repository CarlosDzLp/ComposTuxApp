using System;
using Xamarin.Forms;
namespace ComposTux.Controls
{
    public class CustomContentView : ContentView
    {
        #region RenderCornerRadius
        //Define the Border Radious bindable properties 
        public readonly static BindableProperty BorderRadiusTopLeftProperty = BindableProperty.Create("BorderRadiusTopLeft", typeof(double), typeof(CustomContentView), 0.0, BindingMode.OneWay, null, null, null, null, null);
        public readonly static BindableProperty BorderRadiusTopRightProperty = BindableProperty.Create("BorderRadiusTopRight", typeof(double), typeof(CustomContentView), 0.0, BindingMode.OneWay, null, null, null, null, null);
        public readonly static BindableProperty BorderRadiusBottomLeftProperty = BindableProperty.Create("BorderRadiusBottomLeft", typeof(double), typeof(CustomContentView), 0.0, BindingMode.OneWay, null, null, null, null, null);
        public readonly static BindableProperty BorderRadiusBottomRightProperty = BindableProperty.Create("BorderRadiusBottomRight", typeof(double), typeof(CustomContentView), 0.0, BindingMode.OneWay, null, null, null, null, null);

        //Define the Border Color bindable property
        public readonly static BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(CustomContentView), Color.Default, BindingMode.OneWay, null, null, null, null, null);

        //Define the Border Width bindable property
        public readonly static BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(int), typeof(CustomContentView), 2, BindingMode.OneWay, null, null, null, null, null);

        //Define the actual properties that are related to previous bindable
        public int BorderWidth
        {
            get { return (int)base.GetValue(CustomContentView.BorderWidthProperty); }
            set { base.SetValue(CustomContentView.BorderWidthProperty, value); }
        }

        public Color BorderColor
        {
            get
            {
                return (Color)base.GetValue(CustomContentView.BorderColorProperty);
            }
            set
            {
                base.SetValue(CustomContentView.BorderColorProperty, value);
            }
        }

        public double BorderRadiusTopLeft
        {
            get
            {
                return (double)base.GetValue(CustomContentView.BorderRadiusTopLeftProperty);
            }
            set
            {
                base.SetValue(CustomContentView.BorderRadiusTopLeftProperty, value);
            }
        }
        public double BorderRadiusTopRight
        {
            get
            {
                return (double)base.GetValue(CustomContentView.BorderRadiusTopRightProperty);
            }
            set
            {
                base.SetValue(CustomContentView.BorderRadiusTopRightProperty, value);
            }
        }
        public double BorderRadiusBottomLeft
        {
            get
            {
                return (double)base.GetValue(CustomContentView.BorderRadiusBottomLeftProperty);
            }
            set
            {
                base.SetValue(CustomContentView.BorderRadiusBottomLeftProperty, value);
            }
        }
        public double BorderRadiusBottomRight
        {
            get
            {
                return (double)base.GetValue(CustomContentView.BorderRadiusBottomRightProperty);
            }
            set
            {
                base.SetValue(CustomContentView.BorderRadiusBottomRightProperty, value);
            }
        }
        #endregion
    }
}
