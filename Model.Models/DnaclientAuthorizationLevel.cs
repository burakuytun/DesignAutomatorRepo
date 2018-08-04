using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class DnaClientAuthorizationLevel
    {
        public DnaClientAuthorizationLevel()
        {
            UserDnaclients = new HashSet<UserDnaClient>();
        }

        public int Id { get; set; }
        public string AuthorizationLevel { get; set; }

        public virtual ICollection<UserDnaClient> UserDnaclients { get; set; }
    }
}
