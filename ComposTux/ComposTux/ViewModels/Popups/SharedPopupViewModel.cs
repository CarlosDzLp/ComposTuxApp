using System;
using System.Windows.Input;
using ComposTux.Helpers;
using ComposTux.ViewModels.Base;
using Xamarin.Forms;

namespace ComposTux.ViewModels.Popups
{
    public class SharedPopupViewModel : BindableBase
    {
        #region Constructor

        public SharedPopupViewModel()
        {
            WhatsAppCommand = new Command(WhatsAppCommandExecuted);
            FaccebookCommand = new Command(FaccebookCommandExecuted);
            GmailCommand = new Command(GmailCommandExecuted);
            OutlookCommand = new Command(OutlookCommandExecuted);
            MessengerCommand = new Command(MessengerCommandExecuted);
        }

        #endregion


        #region Command

        public ICommand WhatsAppCommand { get; set; }
        public ICommand FaccebookCommand { get; set; }
        public ICommand GmailCommand { get; set; }
        public ICommand OutlookCommand { get; set; }
        public ICommand MessengerCommand { get; set; }

        #endregion


        #region Methods

        private async void SendPackage(string packageName)
        {
            try
            {
                var dependency = DependencyService.Get<IShared>();
                var validate = await dependency.SharedValidate(packageName);
                if (validate)
                {
                    await dependency.SharedSend(packageName, "https://play.google.com/store/apps/details?id=com.facebook.orca");
                }
                else
                {
                    ToastMessage("no tiene instalada la aplicacion");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region CommandExecuted

        public void WhatsAppCommandExecuted()
        {
            try
            {
                SendPackage("com.whatsapp");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void FaccebookCommandExecuted()
        {
            try
            {
                SendPackage("com.facebook.katana");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void GmailCommandExecuted()
        {
            try
            {
                SendPackage("com.google.android.gm");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void OutlookCommandExecuted()
        {
            try
            {
                SendPackage("com.microsoft.office.outlook");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void MessengerCommandExecuted()
        {
            try
            {
                SendPackage("com.facebook.orca");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
