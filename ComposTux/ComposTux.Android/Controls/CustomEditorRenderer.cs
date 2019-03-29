using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using ComposTux.Controls;
using ComposTux.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEditorControl), typeof(CustomEditorRenderer))]
namespace ComposTux.Droid.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);
            var customControl = (ExtendedEditorControl)Element;
            if (Control != null)
            {
                Control.SetMaxLines(3);
                Control.Hint = customControl.Placeholder;
                Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());
                Control.SetPadding(5, 5, 5, 5);
                Control.Background = null;

            }
        }
    }
}
