using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ComposTux.Models.Token;
using ComposTux.Settings;
using Newtonsoft.Json;
using RestSharp;

namespace ComposTux.Service
{
    public class ServiceClient : IServiceClient
    {
        public async Task<T> Get<T>(string urlType)
        {
            try
            {
                T deserializer = default(T);
                var token = await PostToken();
                HttpClient client = new HttpClient();
                var url = BaseSettings.UrlBase + urlType;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }

        public async Task<T> Post<T, K>(K deserialice, string urlType)
        {
            try
            {
                var token = await PostToken();
                T deserializer = default(T);
                var serializer = JsonConvert.SerializeObject(deserialice);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseSettings.UrlBase);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer " , token.Token);
                var response = await client.PostAsync(urlType, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }

        public async Task<TokenRequest> PostToken()
        {
            try
            {
                var deserializer = new TokenRequest();
                var token = new TokenModel { UserName = "carlos", Password = "carlos" };
                var serializer = JsonConvert.SerializeObject(token);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseSettings.UrlBase);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("authentication/authenticate", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = JsonConvert.DeserializeObject<TokenRequest>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
