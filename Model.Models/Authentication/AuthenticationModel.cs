namespace Model.Models.Authentication
{
    public class AuthenticationModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public bool isActiveDomainAccount { get; set; }
    }
}
