using System;
using System.Threading.Tasks;

namespace ComposTux.Helpers
{
    public interface IShared
    {
        Task<bool> SharedValidate(string packageName);
        Task SharedSend(string packageName, string message);
    }
}
