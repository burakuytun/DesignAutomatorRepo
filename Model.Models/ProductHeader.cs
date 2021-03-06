﻿using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ProductHeader
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Value { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
