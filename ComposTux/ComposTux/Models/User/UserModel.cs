using System;
using Newtonsoft.Json;
using SQLite;

namespace ComposTux.Models.User
{
    public class UserModel
    {
        [PrimaryKey]
        [JsonProperty("IdUser")]
        public string IdUser { get; set; }

        [JsonProperty("NameUser")]
        public string NameUser { get; set; }

        [JsonProperty("LastNameUser")]
        public string LastNameUser { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("PasswordUser")]
        public string PasswordUser { get; set; }

        [JsonProperty("UserType")]
        public bool UserType { get; set; }

        [JsonProperty("UserActive")]
        public bool UserActive { get; set; }

        [JsonProperty("Privacity")]
        public bool Privacity { get; set; }

        [JsonProperty("Latitud")]
        public string Latitud { get; set; }

        [JsonProperty("Longitud")]
        public string Longitud { get; set; }

        [JsonIgnore,SQLite.Ignore]
        public string Location { get; set; }
    }
    public class ListUserModel
    {
        [JsonProperty("Result")]
        public UserModel Result { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
