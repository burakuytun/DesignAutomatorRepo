using System;
using System.Collections.Generic;

namespace Model.ViewModels
{
    public partial class UserViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public bool IsAdmin { get; set; }
        public bool Dnamanager { get; set; }
        public bool IsSqlauthentication { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedDate { get; set; }
        public int Role { get; set; }
        public string ProfilePicture { get; set; }

        //public Client Client { get; set; }
        //public ICollection<UserDnaclient> UserDnaclients { get; set; }
    }
}
