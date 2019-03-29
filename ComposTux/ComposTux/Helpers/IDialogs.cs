using System;
using System.Threading.Tasks;

namespace ComposTux.Helpers
{
    public interface IDialogs
    {
        Task ShowDialog(string message);
        Task HideDialog();
        Task ToastMessage(string message);
        Task SnackBarSuccess(string message);
        Task SnackBarError(string message);
    }
}
