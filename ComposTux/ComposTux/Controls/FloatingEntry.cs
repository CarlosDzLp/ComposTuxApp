using System;
using Xamarin.Forms;

namespace ComposTux.Controls
{
    public class FloatingEntry : Entry
    {
        public static readonly BindableProperty FloatingHintEnabledProperty = BindableProperty.Create(nameof(FloatingHintEnabled),
            typeof(bool),
            typeof(FloatingEntry),
            true);

        public static readonly BindableProperty ActivePlaceholderColorProperty = BindableProperty.Create(nameof(ActivePlaceholderColor),
            typeof(Color),
            typeof(FloatingEntry),
            Color.Accent);

        /// <summary>
        /// ActivePlaceholderColor summary. This is a bindable property.
        /// </summary>
        public Color ActivePlaceholderColor
        {
            get { return (Color)GetValue(ActivePlaceholderColorProperty); }
            set { SetValue(ActivePlaceholderColorProperty, value); }
        }

        /// <summary>
        /// <c>true</c> to float the hint into a label, otherwise <c>false</c>. This is a bindable property.
        /// </summary>
        public bool FloatingHintEnabled
        {
            get { return (bool)GetValue(FloatingHintEnabledProperty); }
            set { SetValue(FloatingHintEnabledProperty, value); }
        }
    }
}
