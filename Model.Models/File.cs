using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class File
    {
        public File()
        {
            Objects = new HashSet<PhoenixObject>();
        }

        public decimal Id { get; set; }
        public string Url { get; set; }
        public DateTime? Calculated { get; set; }
        public DateTime? DataUpdated { get; set; }
        public DateTime? Modified { get; set; }
        public bool Corrupted { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<PhoenixObject> Objects { get; set; }
    }
}
