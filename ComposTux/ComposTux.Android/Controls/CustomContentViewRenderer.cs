using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using ComposTux.Controls;
using ComposTux.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomContentView), typeof(CustomContentViewRenderer))]
namespace ComposTux.Droid.Controls
{
    public class CustomContentViewRenderer : VisualElementRenderer<CustomContentView>
    {
        public CustomContentViewRenderer(Context context) : base(context)
        {
        }
        private GradientDrawable drawable;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<CustomContentView> e)
        {
            //taking the main custom frame (that exists in shared app)
            CustomContentView customFram = e.NewElement as CustomContentView;
            // Create a drawable for the button's normal state
            drawable = new Android.Graphics.Drawables.GradientDrawable();
            //taking the BackgroundColor property value that exists in ContentView and give it to the drawable object
            drawable.SetColor(customFram.BackgroundColor.ToAndroid());
            //taking the BorderWidth property value that we add it in  CustomFrame and give it to the drawable object
            drawable.SetStroke(customFram.BorderWidth, customFram.BorderColor.ToAndroid());
            //taking the BorderRadious properties values that we add it in  CustomFrame and send it to SetCornerRaii method
            drawable.SetCornerRadii(new float[] { (float)customFram.BorderRadiusTopLeft, (float)customFram.BorderRadiusTopLeft,
                (float)customFram.BorderRadiusTopRight, (float)customFram.BorderRadiusTopRight,
                (float)customFram.BorderRadiusBottomLeft, (float)customFram.BorderRadiusBottomLeft,
                (float)customFram.BorderRadiusBottomRight, (float)customFram.BorderRadiusBottomRight });
            //put the drawable object in the content view Background
            SetBackgroundDrawable(drawable);

            //call the base OnElementChanged method 
            base.OnElementChanged(e);
        }
    }
}
