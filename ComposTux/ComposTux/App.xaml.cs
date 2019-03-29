using System;
using Com.OneSignal;
using ComposTux.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ComposTux
{
    public partial class App : Application
    {
        public static string User = "Rendy";
        public static CustomMasterDetailPage masterDetailPage { get; set; }
        DbLocal.DbContext db = new DbLocal.DbContext();
        public App()
        {
            InitializeComponent();
            var use = db.GetUser();
            if(use != null)
            {
                MainPage = new Views.Principal.MasterPage();
            }
            else
            {
                MainPage = new NavigationPage(new Views.Session.LoginPage());
            }
            OneSignal.Current.IdsAvailable(IdsAvailable);
        }
        public async void IdsAvailable(string playerId, string pushToken)
        {

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
