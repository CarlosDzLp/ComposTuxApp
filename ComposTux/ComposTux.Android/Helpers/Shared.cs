using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.PM;
using ComposTux.Droid.Helpers;
using ComposTux.Helpers;
using Xamarin.Forms;
using static Android.Content.PM.PackageManager;

[assembly: Dependency(typeof(Shared))]
namespace ComposTux.Droid.Helpers
{
    public class Shared : IShared
    {
        public async Task<bool> SharedValidate(string packageName)
        {
            PackageManager pm = MainActivity.CurrentActivity.PackageManager;//context.getPackageManager();
            try
            {
                pm.GetPackageInfo(packageName, 0);
                return true;
            }
            catch (NameNotFoundException e)
            {
                return false;
            }
        }

        public async Task SharedSend(string packageName, string message)
        {
            try
            {
                Intent intent = new Intent(Intent.ActionSend);
                intent.SetType("text/plain");
                intent.PutExtra(Intent.ExtraText, message);
                intent.SetPackage(packageName);
                MainActivity.CurrentActivity.StartActivity(intent);//startActivity(intent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
