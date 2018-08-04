using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("Phoenix.Objects")]
    public partial class PhoenixObject
    {
        public decimal Id { get; set; }
        public decimal BlckId { get; set; }
        public string BlckType { get; set; }
        public string Handle { get; set; }
        public string Name { get; set; }
        public string Layer { get; set; }
        public double? Xst { get; set; }
        public double? Yst { get; set; }
        public double? Zst { get; set; }
        public double? Xfn { get; set; }
        public double? Yfn { get; set; }
        public double? Zfn { get; set; }
        public double? XscaleFactor { get; set; }
        public string Spc { get; set; }
        public string Unit { get; set; }

        public virtual File IdNavigation { get; set; }
    }
}
