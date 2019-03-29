using System;
using System.Windows.Input;
using ComposTux.DbLocal;
using ComposTux.Models.User;
using ComposTux.Service;
using ComposTux.ViewModels.Base;
using Xamarin.Forms;

namespace ComposTux.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {

        #region Properties
        private bool isPassword = true;
        public bool IsPassword
        {
            get { return isPassword; }
            set { SetProperty(ref isPassword, value); }
        }
        private string image="show";
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        #endregion

        #region Constructor

        public LoginPageViewModel()
        {
            LogInCommand = new Command(LogInCommandExecuted);
            RegisterCommand = new Command(RegisterCommandExecuted);
            TapImageCommand = new Command(TapImageCommandExecuted);
        }

        #endregion

        #region Command

        public ICommand RegisterCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand TapImageCommand { get; set; }

        #endregion

        #region CommandExecuted


        private async void LogInCommandExecuted()
        {
            try
            {
                Loading("Cargando...");
                if(!string.IsNullOrWhiteSpace(User))
                {
                    if(!string.IsNullOrWhiteSpace(Password))
                    {
                        ServiceClient client = new ServiceClient();
                        DbContext db = new DbContext();
                        var response = await client.Get<ListUserModel>(string.Format("user/selectuser?UserName={0}&Password={1}", User, Password));
                        if(response.Result != null)
                        {
                            db.InsertUser(response.Result);
                            NavigationMainPage(new Views.Principal.MasterPage());
                        }
                        else
                        {
                            SnackBarError(response.Message);
                        }
                    }
                    else
                    {
                        SnackBarError("Ingrese un password");
                    }
                }
                else
                {
                    SnackBarError("Ingrese un usuario");
                }
                CloseLoading();
            }
            catch (Exception ex)
            {
                throw;
                CloseLoading();
            }
        }
        private void RegisterCommandExecuted()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Session.RegisterPage());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        int bandera = 0;
        private void TapImageCommandExecuted()
        {
            try
            {
                if(bandera==0)
                {
                    IsPassword = false;
                    Image = "isshow";
                    bandera = 1;
                }
                else
                {
                    IsPassword = true;
                    Image = "show";
                    bandera = 0;
                }
            }
            catch(Exception ex)
            {

            }
        }

        #endregion
    }
}
