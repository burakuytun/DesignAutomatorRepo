using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class DoorComponentMap
    {
        public int Id { get; set; }
        public int DnaclientId { get; set; }
        public int DoorTypeId { get; set; }
        public int ComponentTypeId { get; set; }

        public virtual DnaClient Dnaclient { get; set; }
    }
}
