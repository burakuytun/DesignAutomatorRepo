using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Client
    {
        public Client()
        {
            DnaClient = new HashSet<DnaClient>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public decimal? StatusId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Prefix { get; set; }

        public virtual ICollection<DnaClient> DnaClient { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
