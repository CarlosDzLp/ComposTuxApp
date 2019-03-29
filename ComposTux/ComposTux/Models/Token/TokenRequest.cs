using System;
namespace ComposTux.Models.Token
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public string Expired { get; set; }
        public DateTime Date { get; set; }
    }
}
