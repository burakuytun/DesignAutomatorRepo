using System.Collections.Generic;

namespace Model.Models
{
    public partial class DnaClient
    {
        public DnaClient()
        {
            AssignedProduct = new HashSet<AssignedProduct>();
            Dna = new HashSet<Dna>();
            DoorComponentMap = new HashSet<DoorComponentMap>();
            ProductData = new HashSet<ProductData>();
            ProductLibDnaclient = new HashSet<ProductLibDnaclient>();
            UserDnaclient = new HashSet<UserDnaClient>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string Uname { get; set; }
        public string Dnalogo { get; set; }
        public string Colour1 { get; set; }
        public string Colour2 { get; set; }
        public string Naming { get; set; }
        public string Colour3 { get; set; }
        public string Colour4 { get; set; }
        public string Colour5 { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string ClientCountry { get; set; }
        public string ClientPostCode { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<AssignedProduct> AssignedProduct { get; set; }
        public virtual ICollection<Dna> Dna { get; set; }
        public virtual ICollection<DoorComponentMap> DoorComponentMap { get; set; }
        public virtual ICollection<ProductData> ProductData { get; set; }
        public virtual ICollection<ProductLibDnaclient> ProductLibDnaclient { get; set; }
        public virtual ICollection<UserDnaClient> UserDnaclient { get; set; }
    }
}
