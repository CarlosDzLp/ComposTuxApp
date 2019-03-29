using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ComposTux.Helpers;
using Xamarin.Forms;

namespace ComposTux.ViewModels.Base
{
    public class BindableBase : INotifyPropertyChanged
    {
        IDialogs dialogs = DependencyService.Get<IDialogs>();
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public void NavigationMainPage(Page page)
        {
            try
            {
                App.Current.MainPage = page;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void NavigationPageAsync(Page page)
        {
            try
            {
                App.masterDetailPage.IsPresented = false;
                if (page != null)
                {
                    App.masterDetailPage.Detail.Navigation.PushAsync(page);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void LogOut()
        {
            try
            {
                DbLocal.DbContext db = new DbLocal.DbContext();
                db.DeleteUser();
                App.Current.MainPage = new Views.Session.LoginPage();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async void Loading(string message)
        {
            try
            {
                await dialogs.ShowDialog(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async void CloseLoading()
        {
            try
            {
                await dialogs.HideDialog();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async void SnackBarError(string message)
        {
            try
            {
                await dialogs.SnackBarError(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async void SnackBarSuccess(string message)
        {
            try
            {
                await dialogs.SnackBarSuccess(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async void ToastMessage(string message)
        {
            try
            {
                await dialogs.ToastMessage(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
