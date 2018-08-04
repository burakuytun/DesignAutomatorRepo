using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class User
    {
        public User()
        {
            UserDnaclients = new HashSet<UserDnaClient>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public bool IsAdmin { get; set; }
        public bool Dnamanager { get; set; }
        public bool IsSqlauthentication { get; set; }
        public bool? IsActive { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedDate { get; set; }
        public short Role { get; set; }
        public string ProfilePicture { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<UserDnaClient> UserDnaclients { get; set; }
    }
}
