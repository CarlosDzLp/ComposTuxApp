using Android.Content;
using Android.Support.V4.Widget;
using Android.Views;
using ComposTux.Controls;
using ComposTux.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomMasterDetailPage), typeof(CustomMasterDetailPageRenderer))]
namespace ComposTux.Droid.Controls
{
    public class CustomMasterDetailPageRenderer : MasterDetailPageRenderer
    {
        public CustomMasterDetailPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            //var width = Resources.DisplayMetrics.WidthPixels;

            var fieldInfo = GetType().BaseType.GetField("_masterLayout", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var _masterLayout = (ViewGroup)fieldInfo.GetValue(this);
            var lp = new DrawerLayout.LayoutParams(_masterLayout.LayoutParameters);

            CustomMasterDetailPage page = (CustomMasterDetailPage)newElement;
            lp.Width = page.DrawerWidth;
            lp.Gravity = (int)GravityFlags.Left;
            _masterLayout.LayoutParameters = lp;
        }
    }
}