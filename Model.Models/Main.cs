using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Main
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
        public string NavigateUrl { get; set; }
        public string Icon { get; set; }
        public short? Order { get; set; }
    }
}
