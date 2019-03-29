using System;
using System.Threading.Tasks;
using ComposTux.Models.Token;

namespace ComposTux.Service
{
    public interface IServiceClient
    {
        Task<T> Get<T>(string urlType);
        Task<TokenRequest> PostToken();
        Task<T> Post<T,K>(K deserialice, string urlType);
    }
}
