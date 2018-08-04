using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ProductLibDnaclient
    {
        public int Id { get; set; }
        public int? DnaclientId { get; set; }
        public int? ProductLibId { get; set; }

        public virtual DnaClient Dnaclient { get; set; }
        public virtual ProductLibrary ProductLib { get; set; }
    }
}
