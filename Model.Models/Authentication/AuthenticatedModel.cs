using Newtonsoft.Json;

namespace Model.Models.Authentication
{
    public class AuthenticatedModel
    {
        private string _profilePicture;

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("roles")]
        public int[] Roles { get; set; }


        [JsonProperty("profilePicture")]
        public string ProfilePicture
        {
            get => $"assets/img/profilepictures/{_profilePicture}";
            set => _profilePicture = value;
        }
    }
}
