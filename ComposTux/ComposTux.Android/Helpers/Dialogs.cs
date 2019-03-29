using System;
using System.Threading.Tasks;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using ComposTux.Droid.Helpers;
using ComposTux.Helpers;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(Dialogs))]
namespace ComposTux.Droid.Helpers
{
    public class Dialogs : IDialogs
    {
        public async Task HideDialog()
        {
            AndHUD.Shared.Dismiss();
        }

        public async Task ShowDialog(string message)
        {
            AndHUD.Shared.Show(MainActivity.CurrentActivity, message, -1, MaskType.Black, null, null, true, null);
        }

        public async Task SnackBarError(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Android.Support.Design.Widget.Snackbar snackBar = Android.Support.Design.Widget.Snackbar.Make(activityRootView, message, Snackbar.LengthLong);
            snackBar.SetActionTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
            Android.Views.View snackbarview = snackBar.View;
            snackbarview.SetBackgroundResource(Resource.Drawable.snackBackground);
            ViewGroup.MarginLayoutParams paramss = (ViewGroup.MarginLayoutParams)snackbarview.LayoutParameters;
            paramss.SetMargins(30, 0, 30, 40);
            snackbarview.SetBackground(
                MainActivity.CurrentActivity.ApplicationContext.GetDrawable(Resource.Drawable.snackBarError));
            snackBar.Show();
        }

        public async Task SnackBarSuccess(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Android.Support.Design.Widget.Snackbar snackBar = Android.Support.Design.Widget.Snackbar.Make(activityRootView, message, Snackbar.LengthLong);
            snackBar.SetActionTextColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
            Android.Views.View snackbarview = snackBar.View;
            snackbarview.SetBackgroundResource(Resource.Drawable.snackBackground);
            ViewGroup.MarginLayoutParams paramss = (ViewGroup.MarginLayoutParams)snackbarview.LayoutParameters;
            paramss.SetMargins(30, 0, 30, 40);
            snackbarview.SetBackground(
                MainActivity.CurrentActivity.ApplicationContext.GetDrawable(Resource.Drawable.snackBackground));
            snackBar.Show();
        }
        public async Task ToastMessage(string message)
        {
            var toast = Toast.MakeText(MainActivity.CurrentActivity, message, ToastLength.Short);
            toast.Show();
        }
    }
}
