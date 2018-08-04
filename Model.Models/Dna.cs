using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Dna
    {
        public int Id { get; set; }
        public int? TypeTagId { get; set; }
        public int? DnaclientId { get; set; }
        public string Value { get; set; }

        public virtual DnaClient Dnaclient { get; set; }
        public virtual TypeTagMap TypeTag { get; set; }
    }
}
