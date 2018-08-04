using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ProductLibraryHeader
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Value { get; set; }
        public int? ProductLibId { get; set; }

        public virtual ProductLibrary ProductLib { get; set; }
    }
}
